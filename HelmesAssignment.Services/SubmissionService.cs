﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using HelmesAssignment.Entities.Requests;
using System.Threading.Tasks;
using HelmesAssignment.DataLayer;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Entities.Responses;
using HelmesAssignment.Interfaces;


namespace HelmesAssignment.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ISubmissionEditRepository _submissionEditRepository;
        private readonly ISubmissionSectorEditRepository _submissionSectorEditRepository;
        private readonly ISectorReadRepository _sectorReadRepository;

        public SubmissionService(
            ApplicationDbContext applicationDbContext,
            ISubmissionEditRepository submissionEditRepository,
            ISubmissionSectorEditRepository submissionSectorEditRepository,
            ISectorReadRepository sectorReadRepository
        )
        {
            _applicationDbContext = applicationDbContext;
            _submissionEditRepository = submissionEditRepository;
            _submissionSectorEditRepository = submissionSectorEditRepository;
            _sectorReadRepository = sectorReadRepository;
        }

        /// <summary>
        /// Returns the submission by the session id or null
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public async Task<Submission> GetSubmissionBySessionId(string sessionId)
        {
            return await _submissionEditRepository.GetSubmissionBySessionId(sessionId);
        }

        /// <summary>
        /// Creates or updates a submission
        /// </summary>
        /// <param name="request">SubmissionCreateOrUpdateRequest</param>
        /// <returns></returns>
        public async Task<SubmissionCreateOrUpdateResponse> CreateOrUpdateSubmission(SubmissionCreateOrUpdateRequest request)
        {
            using (DbContextTransaction dbTran = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    var currentSubmission = await GetSubmissionBySessionId(request.SessionId);

                    var updatedAt = DateTime.Now;

                    if (currentSubmission == null)
                    {
                        currentSubmission = new Submission
                        {
                            ID = Guid.NewGuid(),
                            AgreeToTerms = request.FormSubmissionViewModel.AgreeToTerms,
                            Name = request.FormSubmissionViewModel.Name,
                            SessionId = request.SessionId,
                            CreatedAt = updatedAt
                        };
                    }

                    currentSubmission.UpdatedAt = updatedAt;

                    // clear previous sectors
                    currentSubmission.SubmissionSectors = new List<SubmissionSector>();
                    await _submissionSectorEditRepository.ClearSectorsFromSubmission(currentSubmission);

                    var selectedSectors = await
                        _sectorReadRepository.GetSectorsByIds(request.FormSubmissionViewModel.SelectedSectors.ToList());

                    selectedSectors
                        .ForEach(sector =>
                        {
                            currentSubmission.SubmissionSectors.Add(new SubmissionSector
                            {
                                Id = Guid.NewGuid(),
                                Submission = currentSubmission,
                                Sector = sector
                            });
                        });

                    await _submissionEditRepository.InsertOrModifyAsync(currentSubmission, s => s.ID == currentSubmission.ID);

                    dbTran.Commit();

                    return new SubmissionCreateOrUpdateResponse
                    {
                        Error = null,
                        Success = true,
                        Response = currentSubmission
                    };
                }
                catch (DbEntityValidationException ex)
                {
                    dbTran.Rollback();
                    throw;
                }
            }

        }
    }
}

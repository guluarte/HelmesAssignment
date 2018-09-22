using HelmesAssignment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HelmesAssignment.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
    }

    public interface IEditableRepository<T> : IRepository<T>
    {
        Task InsertAsync(T entity);
        Task InsertOrModifyAsync(T entity, Expression<Func<T, bool>> predicate);
        Task DeleteASync(T entity);
    }

    public interface ISectorReadRepository : IRepository<Sector>
    {
        Task<IEnumerable<Sector>> GetSectors();
        Task<List<Sector>> GetSectorsByIds(IEnumerable<int> sectors);
    }

    public interface ISubmissionEditRepository : IEditableRepository<Submission>
    {
        Task<Submission> GetSubmissionBySessionId(string sessionId);
    }

    public interface ISubmissionSectorEditRepository : IEditableRepository<SubmissionSector>
    {
        Task ClearSectorsFromSubmission(Submission submission);
    }

}

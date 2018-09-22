using HelmesAssignment.Entities.Models;
using System;
using System.Collections.Generic;

namespace HelmesAssignment.Entities.Responses
{
    public class BaseResponse<T> where T: class
    {
        public Boolean Success { get; set; }
        public Exception Error { get; set; }
        public T Response { get; set; }
    }

    public class GetSectorsAsATreeResponse : BaseResponse<IEnumerable<SectorViewModel>>
    {
    }
}
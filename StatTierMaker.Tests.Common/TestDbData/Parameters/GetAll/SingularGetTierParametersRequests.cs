using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Parameters.GetAll
{
    public static class SingularGetTierParametersRequests
    {
        public static GetTierParametersRequest Normal()
        {
            return new()
            {
                PageNumber = 1,
                PageSize = 1,
            };
        }
        public static GetTierParametersRequest Invalid()
        {
            return new()
            {
                PageNumber = -1,
                PageSize = -1
            };
        }
        public static GetTierParametersRequest Default()
        {
            return new();
        }
        public static GetTierParametersRequest? Null()
        {
            return null;
        }
    }
}

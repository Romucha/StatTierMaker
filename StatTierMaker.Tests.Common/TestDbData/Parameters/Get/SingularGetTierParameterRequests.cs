using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Parameters.Get
{
    public static class SingularGetTierParameterRequests
    {
        public static GetTierParameterRequest Normal(int id = 1)
        {
            return new()
            {
                Id = id
            };
        }
        public static GetTierParameterRequest Invalid()
        {
            return new()
            {
                Id = -1
            };
        }
        public static GetTierParameterRequest Default()
        {
            return new();
        }
        public static GetTierParameterRequest? Null()
        {
            return null;
        }
    }
}

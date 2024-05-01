using StatTierMaker.Db.DTO.Requests.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Parameters.Delete
{
    public static class SingularDeleteTierParameterRequests
    {
        public static DeleteTierParameterRequest Normal(int id = 1)
        {
            return new()
            {
                Id = id
            };
        }
        public static DeleteTierParameterRequest Invalid()
        {
            return new()
            {
                Id = -1
            };
        }
        public static DeleteTierParameterRequest Default()
        {
            return new();
        }
        public static DeleteTierParameterRequest? Null()
        {
            return null;
        }
    }
}

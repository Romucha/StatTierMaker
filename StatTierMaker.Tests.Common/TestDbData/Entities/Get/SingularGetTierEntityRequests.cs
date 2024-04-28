using StatTierMaker.Db.DTO.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.Get
{
    public static class SingularGetTierEntityRequests
    {
        public static GetTierEntityRequest Normal(int id)
        {
            return new()
            {
                Id = id,
            };
        }

        public static GetTierEntityRequest Invalid()
        {
            return new()
            {
                Id = -1
            };
        }

        public static GetTierEntityRequest Default()
        {
            return new();
        }

        public static GetTierEntityRequest? Null()
        {
            return null;
        }
    }
}

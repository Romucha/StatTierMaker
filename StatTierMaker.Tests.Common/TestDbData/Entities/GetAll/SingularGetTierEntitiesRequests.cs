using StatTierMaker.Db.DTO.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.GetAll
{
    public static class SingularGetAllTierEntitiesRequests
    {
        public static GetTierEntitiesRequest Normal()
        {
            return new()
            {
                PageNumber = 1,
                PageSize = 1,
            };
        }

        public static GetTierEntitiesRequest Invalid()
        {
            return new()
            {
                PageNumber = -1,
                PageSize = -1,
            };
        }

        public static GetTierEntitiesRequest Default()
        {
            return new();
        }

        public static GetTierEntitiesRequest? Null()
        {
            return null;
        }
    }
}

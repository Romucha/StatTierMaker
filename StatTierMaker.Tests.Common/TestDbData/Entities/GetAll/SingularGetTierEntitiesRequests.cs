using StatTierMaker.Db.DTO.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.GetAll
{
    public static class SingularUpdateTierEntitiyRequests
    {
        public static GetTierEntitiesRequest Normal(int id)
        {
            return new()
            {
                
            };
        }

        public static GetTierEntitiesRequest Invalid()
        {
            return new()
            {
                
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

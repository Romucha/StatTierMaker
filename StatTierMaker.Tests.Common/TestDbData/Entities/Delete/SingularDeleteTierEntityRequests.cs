using StatTierMaker.Db.DTO.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Tests.Common.TestDbData.Entities.Delete
{
    public static class SingularDeleteTierEntityRequests
    {
        public static DeleteTierEntityRequest Normal(int id = 1)
        {
            return new DeleteTierEntityRequest()
            {
                Id = id,
            };
        }

        public static DeleteTierEntityRequest Invalid()
        {
            return new DeleteTierEntityRequest()
            {
                Id = -1,
            };
        }

        public static DeleteTierEntityRequest Default()
        {
            return new();
        }

        public static DeleteTierEntityRequest? Null()
        {
            return null;
        }
    }
}

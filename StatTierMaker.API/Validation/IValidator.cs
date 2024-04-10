using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Validation
{
    public interface IValidator
    {
        Task<T> ValidateAsync<T>(T value, CancellationToken cancellationToken = default);
    }
}

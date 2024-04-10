using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Attributes
{
    public class CollectionNotEmpty : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is IEnumerable result)
            {
                foreach (var item in result) 
                {
                    return true;
                }
            }
            ErrorMessage = "Collection is empty.";
            return false;
        }
    }
}

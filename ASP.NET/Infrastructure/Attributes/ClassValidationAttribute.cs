using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Infrastructure.Attributes
{
    public class ClassValidationAttribute : ValidationAttribute
    {
        public ClassValidationAttribute()
        {
            
        }

        public ClassValidationAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            var @class = (int?) value;
            return !@class.HasValue || @class <= 11 && @class >= 1;
        }
    }
}

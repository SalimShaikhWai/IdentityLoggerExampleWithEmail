using System.ComponentModel.DataAnnotations;

namespace Demo63Assignment.CustomValidation
{
    public class AgeValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime givenDate = Convert.ToDateTime(value);
            DateTime todayDate = DateTime.Now;
            if ((todayDate.Year - givenDate.Year) < 18)
                return false;
            return true;
        }


    }
}

using System.ComponentModel.DataAnnotations;

namespace Exterminator.Models.Attributes
{
    public class ExpertizeAttribute : ValidationAttribute
    {
        private string[] validInputs = new[] {"Ghost catcher", "Ghoul strangler", "Monster encager", "Zombie exploder"};
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            foreach(var input in validInputs) {
                if(input == value.ToString()) { return ValidationResult.Success; }
            }

            return new ValidationResult("Invalid input! Enter one of the following: \"Ghost catcher\", \"Ghoul stranger\", \"Monster encager\" or \"Zombie exploder\"");
            
        }
    }
}
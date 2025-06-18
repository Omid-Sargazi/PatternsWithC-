namespace AdvantureWorksDatabse02.CleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id {get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Domain Logic - Business Rules
        public bool IsValidEmail()
        {
            return Email.Contains("@") && Email.Contains(".");
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool CanBeActivated()
        {
            return IsValidEmail() && !string.IsNullOrEmpty(FirstName);
        }
    }
}
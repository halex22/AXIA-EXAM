using System.ComponentModel.DataAnnotations;

namespace ContactsAPI_V2.Model.DTO
{
    public class ContactCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "First name must be at least 5 chars long")]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

    }
}

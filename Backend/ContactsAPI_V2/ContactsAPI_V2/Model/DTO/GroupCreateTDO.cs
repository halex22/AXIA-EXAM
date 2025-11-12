using System.ComponentModel.DataAnnotations;

namespace ContactsAPI_V2.Model.DTO
{
    public class GroupCreateTDO
    {
        [Required(ErrorMessage = "This field is required")]
        public string? Name { get; set; }
    }
}

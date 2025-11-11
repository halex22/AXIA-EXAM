namespace ContactsAPI_V2.Model.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}

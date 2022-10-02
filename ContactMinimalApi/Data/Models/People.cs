namespace ContactMinimalApi.Models
{
    public class People
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}

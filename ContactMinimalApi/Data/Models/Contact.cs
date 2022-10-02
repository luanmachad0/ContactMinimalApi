namespace ContactMinimalApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string? Value { get; set; }

        public Contact(string name)
        {
            Name = name;
        }
    }
}

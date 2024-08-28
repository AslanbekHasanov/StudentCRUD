namespace StudentCRUD.Core.Api.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StudentType StudentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}



namespace StudList.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MidName { get; set; }
        public int Grade { get; set; }    

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}

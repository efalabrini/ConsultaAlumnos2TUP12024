namespace ConsultaAlumnos.Domain.Entities

{
    public class Student : User
    {
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    }
}

namespace ConsultaAlumnos.Domain.Entities
{
    public class Professor : User
    {
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    }
}

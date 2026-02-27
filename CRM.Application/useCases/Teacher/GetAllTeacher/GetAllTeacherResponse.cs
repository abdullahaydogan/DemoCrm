namespace DemoCRM.Application.useCases.Teacher.GetAllTeacher
{
    public class GetAllTeacherResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public string? ContactValue { get; set; }

    }
}

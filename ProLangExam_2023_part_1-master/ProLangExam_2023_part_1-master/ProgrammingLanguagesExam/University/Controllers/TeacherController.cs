using Microsoft.AspNetCore.Mvc;
using University.DataAccess;

namespace University.Controllers;

[Route("{controller}")]
public class TestController
{
    private readonly UniversityDbContext _universityDbContext;

    public TestController(UniversityDbContext universityDbContext) => _universityDbContext = universityDbContext;

    [HttpGet]
    public string Test(string message) => $"Test: database contains {_universityDbContext.Teachers.Count()} teachers with {_universityDbContext.Skills.Count()} skills in total";
    [HttpGet("All")]
    public IActionResult GetAllTeachers()
    {
        
        List<Teacher> teachers = GetTeachersFromDataSource();

       
        List<TeacherWithoutSkills> teachersWithoutSkills = new List<TeacherWithoutSkills>();

     
        foreach (Teacher teacher in teachers)
        {
            TeacherWithoutSkills teacherWithoutSkills = new TeacherWithoutSkills
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Age = teacher.Age,
              
            };

            teachersWithoutSkills.Add(teacherWithoutSkills);
        }

        return Ok(teachersWithoutSkills);
    }


    private List<Teacher> GetTeachersFromDataSource()
    {
       
        List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "John Doe", Age = 35, Skills = new List<string> { "Math", "Physics" } },
                new Teacher { Id = 2, Name = "Jane Smith", Age = 42, Skills = new List<string> { "English", "History" } },
                
            };

        return teachers;
    }
}


public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Skills { get; set; }
}


public class TeacherWithoutSkills
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
}


using System.ComponentModel.DataAnnotations;

namespace Lektion_2__API_Backend___Code_First_Database.Models
{
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }

       
        public virtual List<Student> Students { get; set; }
        public virtual List<ClassCourse> ClassCourses { get; set; }
    }
}

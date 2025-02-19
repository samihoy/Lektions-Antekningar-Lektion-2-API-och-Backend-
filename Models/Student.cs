using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion_2__API_Backend___Code_First_Database.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [ForeignKey("Class")]
        public int ClassID_FK { get; set; }
        public virtual Class Class { get; set; }
    }
}

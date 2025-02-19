using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion_2__API_Backend___Code_First_Database.Models
{
    public class ClassCourse
    {
        [Key]
        public int ID { get; set; }


        // Under vissas ett exempel på hur man skappar en Foreign Key (FK)
        // man skappar en int property och en constructor som länkar till den klassen som Foreign keyn pekar mot
        // I deta fall länkar ClassCourse till Class klassen/table Via ClassID_FK och Class Class construktorn (fårvirande namn men se exemplet under så förstår du)
        // 
        // när du senare skappar din databasen via Console window så Auto detectar Entity Framework (EF) oftast vad för typ av property och hur den ska skrivas om till databasen
        // tex vilken som är primary key, vilka som är foreign key eller att string blir till nvarchar() etc
        // men ibland kan det vara viktigt att förtydliga attributerna endå eftersom EF inte är perfekt och kan göra mistag
        // Deta görs via "attributes" som är inom brakets []. I exemplet under förtydligar vi att "CLassID_FK" är en foreign Key och Länkar till Constructorn via Constructorns namn
        // Men man kan också specifiera vilken som är primary key [Key] eller hur lång en sträng får vara [StringLength(50)]
        // några exempel på såna attributs är: [Key] = Primary Key
        //                                     [Range(min, max)] = interval för tal tex 10-25
        //                                     [Required] = får inte vara Null
        //                                     [StringLength(MAX - MIN)], [MaxLength], [MinLength] = Nvarchar och hur lång den får vara

        [ForeignKey("Class")]
        public int CLassID_FK { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}

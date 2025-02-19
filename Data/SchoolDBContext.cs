using Lektion_2__API_Backend___Code_First_Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lektion_2__API_Backend___Code_First_Database.Data
{
    public class SchoolDBContext : DbContext
    {
        // Såhär ser det utt i i Context Folder, Man skapar en CLass som i det här fallet hetter SchoolDBContext, den måste också "ärva" från DBcontext för att fungera

        // Man skapar sedan en construktor som den nedan, Constructorn tar den emot en parameter och ett value som ärvs från Dbcontext och hetter
        // "DbContextOptions<>" och ": Base options" (se Constructorn nedan så ser du hur det är upplagt)
        // "DbContextOptions" och ": base options" kommer från Dbcontext, Därav varför man behöver ärva från Dbcontext  

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {
            
        }
        // Under construktorn länkar man sina Tabels som kommer vara i databasen i form av klasser med DbSet<> som tar emot Table Classerna (se kåden under för exempel)
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassCourse> ClassCourses { get; set; }

    }
}

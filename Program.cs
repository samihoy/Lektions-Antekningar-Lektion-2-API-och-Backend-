
using Lektion_2__API_Backend___Code_First_Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Lektion_2__API_Backend___Code_First_Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Den h�r koden har jag sj�lv laggt till h�r och kom inte f�rskriven n�r jag startade programet, se lektions antekningar f�r deras syfte
            //-----------------------------------------------------------------------------------------------------------------------------------------
            builder.Services.AddDbContext<SchoolDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            //------------------------------------------------------------------------------------------------------------------------------------------
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            

            app.Run();
        }

        //------------------------------------------------------------Lektions Antekningar------------------------------------------------------------

        // Steg 1 man b�rjar med att skappa tv� folders kallade "Data" och "Models", i Models l�gger man in tabelerna man vill ha som klasser och deras atributer/values.

        // steg 2 (Models Folder)
        //        I Models foldret L�gger man till sina klasser som kommer bli Tabels i databasen, varje kolumn representerar av en property i klassen
        //        tex "public string Name { get; set; }" blir en column f�r namn i Students
        //
        //        Om man vill skapa en Foreign Key (FK) skapar man en int propery och en constructor i Klassen, constructorn tar emot en klass av den typen som fereign key ska l�nka
        //        till se klassen ClassCourse f�r exempel och mer antekningar 

        // Steg 3 (Data Folder)
        //        I datafolder l�gger man till en class som d�ps till DBContext och har en prefix som oftast �r namnet p� databasen (tex SchoolDBContext)
        //        I DBcontext classen l�gger man till sina Table klasser fr�n Models foldret. F�r uttf�rlga antekningar kring hur man g�r deta g� till SchoolDBContext.


        //-----------------------------------------------------Hur Man kopplar till sin databasen-----------------------------------------------------

        // Steg 1 hitta din conection string s� du kan koppla till databasen du g�r deta antingen via din "server Explorer" eller "SQL Server Object Explorer"
        //        du hittar dessa f�nster till v�nster om sk�rmen men om du inte ser dom kan du g� in p� Veiw och hitta dom d�r.
        //        klicka p� din databas (i deta fall "(localdb)\MSSQLLocalDB") och kopiera conection stringen

        //        *OBS* Beroende p� vad f�r databas server du anv�nder kan den h�r Processen se lite anorlunda utt, tex om du anv�nder Azure eller Amazon men principen �r samma *OBS*

        //        Ta bort dom delarna av conection stringen du inte beh�ver och l�gg till namnet p� databasen, ditt resultat b�r se utt s�h�r:
        //       
        //        Data Source=(localdb)\MSSQLLocalDB;                    Integrated Security=True;Encrypt=True;Trust Server Certificate=True;    <---efter bortagning
        //        Data Source=(localdb)\MSSQLLocalDB;Database = SchoolDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;    <---efter du laggt till namnet

        // Steg 2 hitta din appsettings.json fil, den b�r ligga i din solution Explorer
        //        I Json filen b�r det finas en atribut som hetter "AllowedHosts": "*"
        //        Du kommer nu l�gga till din conectionstring genom att l�gga till ett kolon =>(,) efter stj�rnan och skriva en conection k�d, ditt resultat b�r se utt s�h�r:
        //
        //          "AllowedHosts": "*",
        //          "ConnectionStrings": {
        //             "DefaultConnection" : "Data Source=(localdb)\\MSSQLLocalDB;Database = SchoolDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"
        //        

        // Steg 3 Ta bort allt mellan app.UseAuthorization();  och  app.Run();
        //        all koden som �r d�r n�r du startar �r bara exempel kod och beh�vs inte, du kommer skriva din egen senare.
        //
        //        vart som h�llst under "var builder = WebApplication.CreateBuilder(args);"  och  ovanf�r "var app = builder.Build();" ska du koppa din databas s� den k�rs i Mainen
        //        Under har du en f�rdig mall du kan kolla p� och kopiera
        //        som du kan se kopplar koden i slut�ndan till "DefaultConnection" vilket �r vad du la in i appsettings.json filen i steg 2

        //          builder.Services.AddDbContext<SchoolDBContext>(options =>
        //          {
        //              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        //
        //          });

        // Steg 4 Du har nu allt du beh�ver f�r att koppla din databas till servern, under ser du comandsen du kan anv�nda i package Maneger Console och en f�rklaring vad dom g�r 


        //---------------------------------comands----------------------------

        //add-migration init    --l�gger in all k�d som beh�vs f�r att skappa databasen, sparas som en klass i "Migrations" Folder som du kan kolla igenom ifall du vill f� en �verblik av strukturen  
        //update-database       --skappar/updaterar databasen

        //------om man skriver om n�t i database som tex att man l�gger till en ny rad eller "markerar" en foreign key s� k�r man comandsen under

        //add-migration ettnamndusj�lvv�ljer     --uppdaterar/skappar en ny Klass i Migrations Foldret som reflekterar  dom nya tabelerna/datan/�ndringarna du gjort, om du vill kan du inspektera och j�mf�ra klassen f�r att se vad som �ndrats
        //update-database                        --uppdaterar databasen
    }
}

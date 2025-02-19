
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

            // Den här koden har jag själv laggt till här och kom inte förskriven när jag startade programet, se lektions antekningar för deras syfte
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

        // Steg 1 man börjar med att skappa två folders kallade "Data" och "Models", i Models lägger man in tabelerna man vill ha som klasser och deras atributer/values.

        // steg 2 (Models Folder)
        //        I Models foldret Lägger man till sina klasser som kommer bli Tabels i databasen, varje kolumn representerar av en property i klassen
        //        tex "public string Name { get; set; }" blir en column för namn i Students
        //
        //        Om man vill skapa en Foreign Key (FK) skapar man en int propery och en constructor i Klassen, constructorn tar emot en klass av den typen som fereign key ska länka
        //        till se klassen ClassCourse för exempel och mer antekningar 

        // Steg 3 (Data Folder)
        //        I datafolder lägger man till en class som döps till DBContext och har en prefix som oftast är namnet på databasen (tex SchoolDBContext)
        //        I DBcontext classen lägger man till sina Table klasser från Models foldret. För uttförlga antekningar kring hur man gör deta gå till SchoolDBContext.


        //-----------------------------------------------------Hur Man kopplar till sin databasen-----------------------------------------------------

        // Steg 1 hitta din conection string så du kan koppla till databasen du gör deta antingen via din "server Explorer" eller "SQL Server Object Explorer"
        //        du hittar dessa fönster till vänster om skärmen men om du inte ser dom kan du gå in på Veiw och hitta dom där.
        //        klicka på din databas (i deta fall "(localdb)\MSSQLLocalDB") och kopiera conection stringen

        //        *OBS* Beroende på vad för databas server du använder kan den här Processen se lite anorlunda utt, tex om du använder Azure eller Amazon men principen är samma *OBS*

        //        Ta bort dom delarna av conection stringen du inte behöver och lägg till namnet på databasen, ditt resultat bör se utt såhär:
        //       
        //        Data Source=(localdb)\MSSQLLocalDB;                    Integrated Security=True;Encrypt=True;Trust Server Certificate=True;    <---efter bortagning
        //        Data Source=(localdb)\MSSQLLocalDB;Database = SchoolDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;    <---efter du laggt till namnet

        // Steg 2 hitta din appsettings.json fil, den bör ligga i din solution Explorer
        //        I Json filen bör det finas en atribut som hetter "AllowedHosts": "*"
        //        Du kommer nu lägga till din conectionstring genom att lägga till ett kolon =>(,) efter stjärnan och skriva en conection kåd, ditt resultat bör se utt såhär:
        //
        //          "AllowedHosts": "*",
        //          "ConnectionStrings": {
        //             "DefaultConnection" : "Data Source=(localdb)\\MSSQLLocalDB;Database = SchoolDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"
        //        

        // Steg 3 Ta bort allt mellan app.UseAuthorization();  och  app.Run();
        //        all koden som är där när du startar är bara exempel kod och behövs inte, du kommer skriva din egen senare.
        //
        //        vart som hällst under "var builder = WebApplication.CreateBuilder(args);"  och  ovanför "var app = builder.Build();" ska du koppa din databas så den körs i Mainen
        //        Under har du en färdig mall du kan kolla på och kopiera
        //        som du kan se kopplar koden i slutändan till "DefaultConnection" vilket är vad du la in i appsettings.json filen i steg 2

        //          builder.Services.AddDbContext<SchoolDBContext>(options =>
        //          {
        //              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        //
        //          });

        // Steg 4 Du har nu allt du behöver för att koppla din databas till servern, under ser du comandsen du kan använda i package Maneger Console och en förklaring vad dom gör 


        //---------------------------------comands----------------------------

        //add-migration init    --lägger in all kåd som behövs för att skappa databasen, sparas som en klass i "Migrations" Folder som du kan kolla igenom ifall du vill få en överblik av strukturen  
        //update-database       --skappar/updaterar databasen

        //------om man skriver om nåt i database som tex att man lägger till en ny rad eller "markerar" en foreign key så kör man comandsen under

        //add-migration ettnamndusjälvväljer     --uppdaterar/skappar en ny Klass i Migrations Foldret som reflekterar  dom nya tabelerna/datan/ändringarna du gjort, om du vill kan du inspektera och jämföra klassen för att se vad som ändrats
        //update-database                        --uppdaterar databasen
    }
}

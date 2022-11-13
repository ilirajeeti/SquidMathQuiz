using Microsoft.EntityFrameworkCore;
using SquidMathQuiz.Entities;


namespace SquidMathQuiz
{
    public class SquidMathQuizContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS; Database=SquidMathQuiz; Integrated Security=SSPI; TrustServerCertificate=True"
                );
        }

        public DbSet<Players> Players { get; set; }
        
        public DbSet<SquidMathQuiz.Entities.Results> Results { get; set; }



    }
}

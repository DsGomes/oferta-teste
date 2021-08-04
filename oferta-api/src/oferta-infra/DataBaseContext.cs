using Microsoft.EntityFrameworkCore;

namespace oferta_infra
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Filename=../../../../../data/oferta-database.db");
        }
    }
}
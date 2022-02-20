namespace SolidSavings.Web.DataAccess
{
    using Microsoft.EntityFrameworkCore;

    using SolidSavings.Web.Models;

    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Outcome> Outcomes { get; set; }

        public DbSet<SolidUser> Users { get; set; }
    }
}
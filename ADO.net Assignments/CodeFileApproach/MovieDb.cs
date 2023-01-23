namespace ADO_Week3.CodeFileApproach
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieDb : DbContext
    {
        public MovieDb()
            : base("name=MovieDb")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public DbSet<Movies> movies { get; set; }
        public DbSet<Directors> directors { get; set; }
    }
}

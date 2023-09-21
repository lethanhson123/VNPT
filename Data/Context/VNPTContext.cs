namespace Data.Context
{
    public partial class VNPTContext : DbContext
    {
        public VNPTContext()
        {
        }
        public VNPTContext(DbContextOptions<VNPTContext> options)
            : base(options)
        {
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalHelper.SQLServerConectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

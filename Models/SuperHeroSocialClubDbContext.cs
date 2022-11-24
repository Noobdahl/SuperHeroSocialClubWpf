using Microsoft.EntityFrameworkCore;

namespace SuperHeroSocialClubWpf.Models;

public partial class SuperHeroSocialClubDbContext : DbContext
{
    public SuperHeroSocialClubDbContext()
    {
    }

    public SuperHeroSocialClubDbContext(DbContextOptions<SuperHeroSocialClubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SuperHero> SuperHeroes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SuperHeroSocialClubDb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuperHero>(entity =>
        {
            entity.HasKey(e => e.SuperHeroId).HasName("PK__SuperHer__5D7B13424DEA95F3");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SecretIdentity).HasMaxLength(50);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

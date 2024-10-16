using HitBallWebServer.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Score> Scores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Score>()
            .HasKey(s => s.user_id); // user_id를 기본 키로 설정

        modelBuilder.Entity<Score>()
            .Property(s => s.user_id)
            .ValueGeneratedNever(); // user_id는 자동 생성되지 않음, 클라이언트가 제공해야 함

        modelBuilder.Entity<Score>()
            .Property(s => s.user_name)
            .IsRequired(); // user_name은 필수 필드

        modelBuilder.Entity<Score>()
            .Property(s => s.department)
            .IsRequired(); // department도 필수 필드

        modelBuilder.Entity<Score>()
            .Property(s => s.tryCount)
            .HasDefaultValue(0); // tryCount의 기본값은 0

        modelBuilder.Entity<Score>()
            .Property(s => s.user_score)
            .HasDefaultValue(0); // user_score의 기본값은 0
    }
}
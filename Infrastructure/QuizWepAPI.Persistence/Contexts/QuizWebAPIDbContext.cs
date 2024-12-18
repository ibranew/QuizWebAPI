using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizWepAPI.Domain.Entities;
using QuizWepAPI.Domain.Entities.Identity;

namespace QuizWepAPI.Persistence.Contexts
{
    public class QuizWebAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizWebAPIDbContext(DbContextOptions<QuizWebAPIDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz) // Her soru bir quiz'e ait
                .WithMany(q => q.Questions) // Her quiz birçok soruya sahip
                .HasForeignKey(q => q.QuizId) // Soru modelindeki QuizId, Quiz modelindeki Id'ye bağlanacak
                .OnDelete(DeleteBehavior.Cascade); // Quiz silindiğinde ilgili sorular da silinsin

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade); // Soru silindiğinde cevaplar da silinsin

            modelBuilder.Entity<Question>()
                .Property(q => q.IsDeleted)
                .HasDefaultValue(false);
        }

    }
}

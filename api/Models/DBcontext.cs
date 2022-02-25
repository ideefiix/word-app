using Microsoft.EntityFrameworkCore;
namespace api.Models
{
    public class DBcontext: DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
             : base(options)
        {
        }

        public DbSet<WordList> WordLists {get; set;} = null!;
        public DbSet<Word> words {get; set;} = null!;

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordList>().ToTable("WordList");
            modelBuilder.Entity<Word>().ToTable("Word");

            WordList firstWordList = new WordList{Id=-1, Name="first", CreatedAt=DateTime.UtcNow};

            modelBuilder.Entity<WordList>().HasData(
                firstWordList
            );

            modelBuilder.Entity<Word>().HasData(
                new Word{Id=-1, Sv="äpple",En="apple", InListId=-1},
                new Word{Id=-2,Sv="bajs",En="poop", InListId=-1},
                new Word{Id=-3,Sv="uppträdande",En="demeanour", InListId=-1}
            );

        } 
    }
}
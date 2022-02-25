namespace api.Models
{
    public class WordList
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime CreatedAt {get; set;}

        public ICollection<Word> Words {get; set;}
    }
}
namespace api.Models
{
    public class Word
    {
        public int Id {get; set;}
        public string Sv {get; set;}
        public string En {get; set;}

        public WordList InList {get; set;}
        public int InListId {get; set;}

        public DateTime AddedAt = DateTime.UtcNow;
    }
}
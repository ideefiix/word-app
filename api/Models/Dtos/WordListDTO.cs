namespace api.Models.Dtos
{
    public class WordListDTO : IComparable<WordListDTO>
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime CreatedAt {get; set;}

        public int CompareTo(WordListDTO? other)
        {
            if (other == null) return 1;
            return DateTime.Compare(other.CreatedAt, CreatedAt);
        }
    }
}
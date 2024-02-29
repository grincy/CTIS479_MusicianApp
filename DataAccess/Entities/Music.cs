#nullable disable // t�m entity ve modellerde yaz�lmal�

using DataAccess.Entities.Bases

namespace DataAccess.Entities
{
    public class Music : Record
    {
        public string Title { get; set; } = null!
        
        public DateTime? PublishedYear { get; set; }
        public decimal Price { get; set; }
        // one to many k�sm� buras� one k�sm�
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}
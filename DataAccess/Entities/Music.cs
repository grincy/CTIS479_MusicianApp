#nullable disable // tüm entity ve modellerde yazýlmalý

using DataAccess.Entities.Bases;

namespace DataAccess.Entities
{
    public class Music : Record
    {
        public string Title { get; set; } = null!;


        public DateTime? PublishedYear { get; set; }
  
        public decimal Price { get; set; }
        // one to many kýsmý burasý one kýsmý
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }

        public List<AlbumsMusic> AlbumsMusics { get; set; }
    }
}
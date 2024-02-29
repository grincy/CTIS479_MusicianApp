#nullable disable // t�m entity ve modellerde yaz�lmal�

using DataAccess.Entities.Bases

namespace DataAccess.Entities
{
    public class Musician : Record
    {
        public string Name { get; set; } = null!
        public string Surname { get; set; } = null!
        public bool IsRetired { get; set; }
        // one to many k�sm� many k�sm�
        public List<Music> Music { get; set; }
    }
}
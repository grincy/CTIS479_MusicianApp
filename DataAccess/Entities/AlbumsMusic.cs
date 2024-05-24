using DataAccess.Entities.Bases;


namespace DataAccess.Entities
{
    public class AlbumsMusic: Record
    {
        public int MusicId { get; set; }

        public Music Music { get; set; }    

        public int AlbumId { get; set; }

        public Album Album { get; set; }    
    }
}

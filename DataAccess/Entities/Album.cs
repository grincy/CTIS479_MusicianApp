
#nullable disable
using DataAccess.Entities.Bases;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.Entities
{
    public class Album : Record // açtığınız 3. entitiy için
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public DateTime? PublishedYear { get; set; }

        public bool IsAvailable {  get; set; }

        public decimal Price {  get; set; }

        public List<AlbumsMusic> AlbumsMusics { get; set; }
    }
}

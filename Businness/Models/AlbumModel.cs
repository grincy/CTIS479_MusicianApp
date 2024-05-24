#nullable disable

using DataAccess.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Models
{
    public class AlbumModel : Record
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} character")]
        [DisplayName("Musician Name")]
        public string Name { get; set; }


        [DisplayName("Published Year")]
        public DateTime? PublishedYear { get; set; }

        [DisplayName("Is Available")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }
        #endregion



        #region Extra Properties
        [DisplayName("Musics")]
        public List<int> MusicIdInput { get; set; }


        [DisplayName("Published Year")]
        public string PublishedYearOutput { get; set; }

        [DisplayName("Is Available")]
        public string IsAvailableOutput { get; set; }

        [DisplayName("Price")]
        public string PriceOutput { get; set; }

		[DisplayName("Music")]
		public string MusicNameOutput { get; set; }
        #endregion
    }
}

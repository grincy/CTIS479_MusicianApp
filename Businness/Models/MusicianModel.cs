#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.Bases;

namespace Businness.Models
{
    public class MusicianModel : Record
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength =2, ErrorMessage ="{0} must be minimum {2} and maximum {1} character")]
        [DisplayName("Musician Name")]
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public bool IsRetired { get; set; }


        

        #endregion


        #region Extra Properties
        [DisplayName("Musician Count")]
        public int MusicianCountOutput{ get; set; }

        [DisplayName("Music Count")]
        public int MusicCount { get; set; }

        [DisplayName("Music Name")]
        public string MusicNamesOutput { get; set; }
        #endregion
    }
}

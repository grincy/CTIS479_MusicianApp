#nullable disable

using DataAccess.Entities;
using DataAccess.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable
using System.Text;
using System.Threading.Tasks;

namespace Businness.Models
{
    public class MusicModel : Record
    {
        #region Entity Properties
        public string Title { get; set; }


        public DateTime PublishedYear { get; set; }

        public decimal Price { get; set; }
        // one to many kýsmý burasý one kýsmý
        public int MusicianId { get; set; }
        #endregion
    }
}

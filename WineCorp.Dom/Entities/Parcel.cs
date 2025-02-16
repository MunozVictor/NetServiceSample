using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCorp.Dom.Entities
{
    [Table("Parcels")]
    public class Parcel
    {
        public int Id { get; set; }

        public int ManagerId { get; set; }

        public int VineyardId { get; set; }

        public int GrapeId { get; set; }

        public int YearPlanted { get; set; }

        public int Area { get; set; }

        public Manager Manager { get; set; }
        public Vineyard Vineyard { get; set; }
        public Grape Grape { get; set; }
    }
}

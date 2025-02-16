using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCorp.Dom.Entities
{
    [Table("Managers")]
    public class Manager
    {
        
        public int Id { get; set; }
        public string TaxNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;


        public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>();
    }
}
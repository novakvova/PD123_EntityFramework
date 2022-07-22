using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_PD123.Data
{
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Model { get; set; }
        [Required, StringLength(100)]
        public string Mark { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace GearBox_Webshop_BackEnd.Model
{
    public class Termek
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Nev { get; set; }
        [Required]
        [Column(TypeName = "longtext")]
        public string Leiras { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Ar { get; set; }
        [Required]
        public bool VanERaktaron { get; set; }
        [Required]
        [Column(TypeName = "blob")]
        public byte[] Kep { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearBox_Webshop_BackEnd.Model
{
    public class Jogosultsagok
    {
        [Key]
        [Column(TypeName = "int(50)")]
        public int Id;
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Nev;

    }
}

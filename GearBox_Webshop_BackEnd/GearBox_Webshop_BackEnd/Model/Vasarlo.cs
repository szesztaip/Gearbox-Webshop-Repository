using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GearBox_Webshop_BackEnd.Model
{
    public class Vasarlo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(65)")]
        public string Keresztnev { get; set; }

        [Required]
        [Column(TypeName = "varchar(65)")]
        public string Vezeteknev { get; set; }

        [Required]
        [Column(TypeName = "int(11)")]
        public int Telefonszam { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Jelszo { get; set; }

        [Required]
        [Column(TypeName = "varchar(65)")]
        public string HASH { get; set; }

        [Required]
        [Column(TypeName = "varchar(65)")]
        public string SALT { get; set; }

        [Required]
        public int JogosultsagErtek { get; set; }
        public Jogosultsagok Jogosultsag { get; set; }
    }
}

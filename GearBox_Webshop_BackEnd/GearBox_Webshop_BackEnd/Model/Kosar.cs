using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearBox_Webshop_BackEnd.Model
{
    public class Kosar
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TermekId { get; set; }
        [Required]
        [Column(TypeName = "varchar(65)")]
        public string TermekNev { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int TermekAr { get; set; }
        [Required]
        public Guid VasarloId { get; set; }

        public Termek Termek { get; set; }
        public Vasarlo Vasarlo { get; set; }
    }
}

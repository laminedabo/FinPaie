using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinPaie.Models
{
    public class CategorieSalarie
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Libelle { get; set; }
        [Display(Name = "Salaire De Base")]

        public decimal SalaireDeBase { get; set; }
    }
}

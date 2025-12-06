using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Entities
{
  
    public class Borrowing
    {
        // ===== PRIMARY KEY =====
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ===== FOREIGN KEY =====
        [Required]
        public int BookId { get; set; }

        // ===== PROPERTIES =====
        [Required(ErrorMessage = "Le nom de l'emprunteur est requis")]
        [MaxLength(100)]
        public string NomEmprunteur { get; set; } = string.Empty;

        [Required]
        public DateTime DateEmprunt { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateRetourPrevue { get; set; }

        public DateTime? DateRetourReelle { get; set; } // Nullable - null means not returned yet

        [Column(TypeName = "decimal(6,2)")]
        public decimal Penalite { get; set; } = 0.00m;

        // ===== NAVIGATION PROPERTY =====
        // Many-to-one relationship with Book
        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Entities
{
    /// <summary>
    /// Represents a book in the library system
    /// </summary>
    public class Book
    {
        // ===== PRIMARY KEY =====
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ===== PROPERTIES =====
        [Required(ErrorMessage = "Le titre est requis")]
        [MaxLength(200)]
        public string Titre { get; set; } = string.Empty;

        [Range(1000, 9999, ErrorMessage = "L'année doit être entre 1000 et 9999")]
        public int? AnneePublication { get; set; }

        [MaxLength(20)]
        public string? ISBN { get; set; }

        [Required]
        public bool Disponible { get; set; } = true; // Default: available

        // ===== NAVIGATION PROPERTIES =====
        // Many-to-many relationship with Authors through AuthorBook
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

        // One-to-many relationship with Borrowings
        public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Entities
{
    
    public class Author
    {
        // ===== PRIMARY KEY =====
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ===== PROPERTIES =====
        [Required(ErrorMessage = "Le nom est requis")]
        [MaxLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est requis")]
        [MaxLength(100)]
        public string Prenom { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Nationalite { get; set; }

        // ===== NAVIGATION PROPERTIES =====
        // Many-to-many relationship with Books through AuthorBook
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}
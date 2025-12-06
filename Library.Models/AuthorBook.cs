using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Entities
{
    /// <summary>
    /// Junction table for Many-to-Many relationship between Authors and Books
    /// </summary>
    public class AuthorBook
    {
        // ===== COMPOSITE PRIMARY KEY (configured in DbContext) =====
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int BookId { get; set; }

        // ===== NAVIGATION PROPERTIES =====
        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }

        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }
    }
}
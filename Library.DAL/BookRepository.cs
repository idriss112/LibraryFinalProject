using Library.DAL.Data;
using Library.Models.Entities;

namespace Library.DAL.Repositories
{
    
    /// Repository simple pour gérer les livres
    /// Simple repository to manage books
    
    public class BookRepository
    {
        // ===== OBTENIR TOUS LES LIVRES =====
        public List<Book> GetAll()
        {
            using (var context = new LibraryContext())
            {
                return context.Books.ToList();
            }
        }

        // ===== OBTENIR UN LIVRE PAR ID =====
        public Book? GetById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Find(id);
            }
        }

        // ===== AJOUTER UN NOUVEAU LIVRE =====
        public void Add(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        // ===== MODIFIER UN LIVRE =====
        public void Update(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        // ===== SUPPRIMER UN LIVRE =====
        public void Delete(int id)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(id);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }

        // ===== OBTENIR LIVRES DISPONIBLES SEULEMENT =====
        
        /// Récupère uniquement les livres disponibles
        /// Gets only available books
        
        public List<Book> GetAvailableBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books
                    .Where(b => b.Disponible == true)
                    .ToList();
            }
        }
    }
}
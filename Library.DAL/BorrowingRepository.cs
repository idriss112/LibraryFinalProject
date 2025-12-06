using Library.DAL.Data;
using Library.Models.Entities;

namespace Library.DAL.Repositories
{
    
    /// Repository simple pour gérer les emprunts
    /// Simple repository to manage borrowings
    
    public class BorrowingRepository
    {
        // ===== OBTENIR TOUS LES EMPRUNTS =====
        public List<Borrowing> GetAll()
        {
            using (var context = new LibraryContext())
            {
                return context.Borrowings.ToList();
            }
        }

        // ===== OBTENIR UN EMPRUNT PAR ID =====
        public Borrowing? GetById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Borrowings.Find(id);
            }
        }

        // ===== AJOUTER UN NOUVEL EMPRUNT =====
        public void Add(Borrowing borrowing)
        {
            using (var context = new LibraryContext())
            {
                context.Borrowings.Add(borrowing);
                context.SaveChanges();
            }
        }

        // ===== MODIFIER UN EMPRUNT =====
        public void Update(Borrowing borrowing)
        {
            using (var context = new LibraryContext())
            {
                context.Borrowings.Update(borrowing);
                context.SaveChanges();
            }
        }

        // ===== SUPPRIMER UN EMPRUNT =====
        public void Delete(int id)
        {
            using (var context = new LibraryContext())
            {
                var borrowing = context.Borrowings.Find(id);
                if (borrowing != null)
                {
                    context.Borrowings.Remove(borrowing);
                    context.SaveChanges();
                }
            }
        }

        // ===== OBTENIR EMPRUNTS ACTIFS (NON RETOURNÉS) =====
        
        /// Récupère les emprunts qui ne sont pas encore retournés
        /// Gets borrowings that haven't been returned yet
        
        public List<Borrowing> GetActiveBorrowings()
        {
            using (var context = new LibraryContext())
            {
                return context.Borrowings
                    .Where(b => b.DateRetourReelle == null)
                    .ToList();
            }
        }
    }
}
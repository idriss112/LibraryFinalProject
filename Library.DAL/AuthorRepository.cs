using Library.DAL.Data;
using Library.Models.Entities;

namespace Library.DAL.Repositories
{
    
    /// Repository simple pour gérer les auteurs dans la base de données
    /// Simple repository to manage authors in the database
    
    public class AuthorRepository
    {
        // ===== MÉTHODE 1: OBTENIR TOUS LES AUTEURS =====
    
        /// Récupère tous les auteurs de la base de données
        /// Gets all authors from the database
      
        public List<Author> GetAll()
        {
            using (var context = new LibraryContext())
            {
                return context.Authors.ToList();
            }
        }

        // ===== MÉTHODE 2: OBTENIR UN AUTEUR PAR ID =====
        
        /// Récupère un auteur spécifique par son ID
        /// Gets a specific author by their ID
        
        public Author? GetById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Authors.Find(id);
            }
        }

        // ===== MÉTHODE 3: AJOUTER UN NOUVEL AUTEUR =====
        
        /// Ajoute un nouvel auteur à la base de données
        /// Adds a new author to the database
        
        public void Add(Author author)
        {
            using (var context = new LibraryContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        // ===== MÉTHODE 4: MODIFIER UN AUTEUR =====
        
        /// Modifie un auteur existant
        /// Updates an existing author
        
        public void Update(Author author)
        {
            using (var context = new LibraryContext())
            {
                context.Authors.Update(author);
                context.SaveChanges();
            }
        }

        // ===== MÉTHODE 5: SUPPRIMER UN AUTEUR =====
        
        /// Supprime un auteur de la base de données
        /// Deletes an author from the database
        
        public void Delete(int id)
        {
            using (var context = new LibraryContext())
            {
                var author = context.Authors.Find(id);
                if (author != null)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
            }
        }
    }
}
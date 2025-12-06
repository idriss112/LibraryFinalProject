using Library.DAL.Repositories;
using Library.Models.Entities;

namespace Library.BLL.Managers
{
    /// <summary>
    /// Manager pour la logique métier des livres avec validation
    /// Manager for book business logic with validation
    /// </summary>
    public class BookManager
    {
        private readonly BookRepository _repository;

        public BookManager()
        {
            _repository = new BookRepository();
        }

        // ===== OBTENIR TOUS LES LIVRES =====
        public List<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        // ===== OBTENIR LIVRES DISPONIBLES =====
        public List<Book> GetAvailableBooks()
        {
            return _repository.GetAvailableBooks();
        }

        // ===== OBTENIR UN LIVRE =====
        public Book? GetBookById(int id)
        {
            return _repository.GetById(id);
        }

        // ===== AJOUTER UN LIVRE (AVEC VALIDATION) =====
        public string AddBook(string titre, int? annee, string? isbn)
        {
            // VALIDATION 1: Titre requis
            if (string.IsNullOrWhiteSpace(titre))
            {
                return "❌ Le titre est requis.";
            }

            // VALIDATION 2: Titre minimum 2 caractères
            if (titre.Trim().Length < 2)
            {
                return "❌ Le titre doit contenir au moins 2 caractères.";
            }

            // VALIDATION 3: Année valide (si fournie)
            if (annee.HasValue && (annee.Value < 1000 || annee.Value > DateTime.Now.Year + 1))
            {
                return $"❌ L'année doit être entre 1000 et {DateTime.Now.Year + 1}.";
            }

            // VALIDATION 4: ISBN unique (si fourni)
            if (!string.IsNullOrWhiteSpace(isbn))
            {
                if (IsISBNExists(isbn))
                {
                    return "❌ Cet ISBN existe déjà dans la base de données.";
                }
            }

            // Créer le livre
            var book = new Book
            {
                Titre = titre.Trim(),
                AnneePublication = annee,
                ISBN = string.IsNullOrWhiteSpace(isbn) ? null : isbn.Trim(),
                Disponible = true
            };

            _repository.Add(book);
            return "✅ Livre ajouté avec succès!";
        }

        // ===== MODIFIER UN LIVRE (AVEC VALIDATION) =====
        public string UpdateBook(int id, string titre, int? annee, string? isbn, bool disponible)
        {
            // VALIDATION 1: Titre requis
            if (string.IsNullOrWhiteSpace(titre))
            {
                return "❌ Le titre est requis.";
            }

            // VALIDATION 2: Titre minimum 2 caractères
            if (titre.Trim().Length < 2)
            {
                return "❌ Le titre doit contenir au moins 2 caractères.";
            }

            // VALIDATION 3: Année valide (si fournie)
            if (annee.HasValue && (annee.Value < 1000 || annee.Value > DateTime.Now.Year + 1))
            {
                return $"❌ L'année doit être entre 1000 et {DateTime.Now.Year + 1}.";
            }

            // Trouver le livre
            var book = _repository.GetById(id);
            if (book == null)
            {
                return "❌ Livre non trouvé.";
            }

            // VALIDATION 4: ISBN unique (si changé)
            if (!string.IsNullOrWhiteSpace(isbn))
            {
                // Vérifier si ISBN existe pour un AUTRE livre
                if (IsISBNExistsForOtherBook(isbn, id))
                {
                    return "❌ Cet ISBN existe déjà pour un autre livre.";
                }
            }

            // Modifier
            book.Titre = titre.Trim();
            book.AnneePublication = annee;
            book.ISBN = string.IsNullOrWhiteSpace(isbn) ? null : isbn.Trim();
            book.Disponible = disponible;

            _repository.Update(book);
            return "✅ Livre modifié avec succès!";
        }

        // ===== SUPPRIMER UN LIVRE =====
        public string DeleteBook(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return "❌ Livre non trouvé.";
            }

            // Vérifier si le livre est emprunté
            if (!book.Disponible)
            {
                return "❌ Impossible de supprimer un livre emprunté.";
            }

            _repository.Delete(id);
            return "✅ Livre supprimé avec succès!";
        }

        // ===== MARQUER COMME DISPONIBLE/NON DISPONIBLE =====
        public void SetAvailability(int bookId, bool isAvailable)
        {
            var book = _repository.GetById(bookId);
            if (book != null)
            {
                book.Disponible = isAvailable;
                _repository.Update(book);
            }
        }

        // ===== VÉRIFIER SI ISBN EXISTE =====
        private bool IsISBNExists(string isbn)
        {
            var allBooks = _repository.GetAll();
            return allBooks.Any(b => b.ISBN != null &&
                                     b.ISBN.Equals(isbn.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // ===== VÉRIFIER SI ISBN EXISTE POUR UN AUTRE LIVRE =====
        private bool IsISBNExistsForOtherBook(string isbn, int currentBookId)
        {
            var allBooks = _repository.GetAll();
            return allBooks.Any(b => b.Id != currentBookId &&
                                     b.ISBN != null &&
                                     b.ISBN.Equals(isbn.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
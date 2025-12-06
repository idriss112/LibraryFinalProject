using Library.DAL.Repositories;
using Library.Models.Entities;

namespace Library.BLL.Managers
{
    /// <summary>
    /// Manager simple pour la logique métier des emprunts
    /// Simple manager for borrowing business logic
    /// </summary>
    public class BorrowingManager
    {
        private readonly BorrowingRepository _borrowingRepo;
        private readonly BookRepository _bookRepo;

        // Tarif de pénalité par jour de retard
        private const decimal PENALTY_PER_DAY = 1.00m;

        public BorrowingManager()
        {
            _borrowingRepo = new BorrowingRepository();
            _bookRepo = new BookRepository();
        }

        // ===== OBTENIR TOUS LES EMPRUNTS =====
        public List<Borrowing> GetAllBorrowings()
        {
            return _borrowingRepo.GetAll();
        }

        // ===== OBTENIR EMPRUNTS ACTIFS =====
        public List<Borrowing> GetActiveBorrowings()
        {
            return _borrowingRepo.GetActiveBorrowings();
        }

        // ===== EMPRUNTER UN LIVRE =====
        public string BorrowBook(int bookId, string nomEmprunteur, DateTime dateRetourPrevue)
        {
            // Vérifier que le nom n'est pas vide
            if (string.IsNullOrWhiteSpace(nomEmprunteur))
            {
                return "Le nom de l'emprunteur est requis.";
            }

            // Vérifier que le livre existe
            var book = _bookRepo.GetById(bookId);
            if (book == null)
            {
                return "Livre non trouvé.";
            }

            // RÈGLE MÉTIER: Vérifier que le livre est disponible
            if (!book.Disponible)
            {
                return "Ce livre n'est pas disponible.";
            }

            // Créer l'emprunt
            var borrowing = new Borrowing
            {
                BookId = bookId,
                NomEmprunteur = nomEmprunteur,
                DateEmprunt = DateTime.Now,
                DateRetourPrevue = dateRetourPrevue,
                DateRetourReelle = null,
                Penalite = 0
            };

            // Sauvegarder l'emprunt
            _borrowingRepo.Add(borrowing);

            // Marquer le livre comme non disponible
            book.Disponible = false;
            _bookRepo.Update(book);

            return "Livre emprunté avec succès!";
        }

        // ===== RETOURNER UN LIVRE =====
        public string ReturnBook(int borrowingId)
        {
            // Trouver l'emprunt
            var borrowing = _borrowingRepo.GetById(borrowingId);
            if (borrowing == null)
            {
                return "Emprunt non trouvé.";
            }

            // Vérifier que le livre n'est pas déjà retourné
            if (borrowing.DateRetourReelle != null)
            {
                return "Ce livre a déjà été retourné.";
            }

            // Enregistrer la date de retour
            borrowing.DateRetourReelle = DateTime.Now;

            // RÈGLE MÉTIER: Calculer la pénalité si retard
            borrowing.Penalite = CalculatePenalty(borrowing.DateRetourPrevue, borrowing.DateRetourReelle.Value);

            // Sauvegarder l'emprunt
            _borrowingRepo.Update(borrowing);

            // Marquer le livre comme disponible
            var book = _bookRepo.GetById(borrowing.BookId);
            if (book != null)
            {
                book.Disponible = true;
                _bookRepo.Update(book);
            }

            return $"Livre retourné! Pénalité: {borrowing.Penalite:C}";
        }

        // ===== CALCULER LA PÉNALITÉ =====
        private decimal CalculatePenalty(DateTime dateRetourPrevue, DateTime dateRetourReelle)
        {
            // Si retourné à temps ou en avance, pas de pénalité
            if (dateRetourReelle <= dateRetourPrevue)
            {
                return 0;
            }

            // Calculer les jours de retard
            TimeSpan retard = dateRetourReelle - dateRetourPrevue;
            int joursRetard = retard.Days;

            // Calculer la pénalité
            decimal penalite = joursRetard * PENALTY_PER_DAY;

            return penalite;
        }

        // ===== OBTENIR UN EMPRUNT PAR ID =====
        public Borrowing? GetBorrowingById(int id)
        {
            return _borrowingRepo.GetById(id);
        }
    }
}
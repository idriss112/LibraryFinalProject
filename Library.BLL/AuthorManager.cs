using Library.DAL.Repositories;
using Library.Models.Entities;

namespace Library.BLL.Managers
{
    /// <summary>
    /// Manager pour la logique métier des auteurs avec validation
    /// </summary>
    public class AuthorManager
    {
        private readonly AuthorRepository _repository;

        public AuthorManager()
        {
            _repository = new AuthorRepository();
        }

        // ===== OBTENIR TOUS LES AUTEURS =====
        public List<Author> GetAllAuthors()
        {
            return _repository.GetAll();
        }

        // ===== OBTENIR UN AUTEUR =====
        public Author? GetAuthorById(int id)
        {
            return _repository.GetById(id);
        }

        // ===== AJOUTER UN AUTEUR (AVEC VALIDATION) =====
        public string AddAuthor(string nom, string prenom, string? nationalite)
        {
            // VALIDATION 1: Nom requis
            if (string.IsNullOrWhiteSpace(nom))
            {
                return "❌ Le nom est requis.";
            }

            // VALIDATION 2: Prénom requis
            if (string.IsNullOrWhiteSpace(prenom))
            {
                return "❌ Le prénom est requis.";
            }

            // VALIDATION 3: Nom minimum 2 caractères
            if (nom.Trim().Length < 2)
            {
                return "❌ Le nom doit contenir au moins 2 caractères.";
            }

            // VALIDATION 4: Prénom minimum 2 caractères
            if (prenom.Trim().Length < 2)
            {
                return "❌ Le prénom doit contenir au moins 2 caractères.";
            }

            // VALIDATION 5: Vérifier si auteur existe déjà
            if (AuthorExists(nom, prenom))
            {
                return "❌ Cet auteur existe déjà dans la base de données.";
            }

            // Créer le nouvel auteur
            var author = new Author
            {
                Nom = nom.Trim(),
                Prenom = prenom.Trim(),
                Nationalite = string.IsNullOrWhiteSpace(nationalite) ? null : nationalite.Trim()
            };

            _repository.Add(author);
            return "✅ Auteur ajouté avec succès!";
        }

        // ===== MODIFIER UN AUTEUR =====
        public string UpdateAuthor(int id, string nom, string prenom, string? nationalite)
        {
            // Validations
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
            {
                return "❌ Le nom et le prénom sont requis.";
            }

            if (nom.Trim().Length < 2 || prenom.Trim().Length < 2)
            {
                return "❌ Le nom et le prénom doivent contenir au moins 2 caractères.";
            }

            // Chercher l'auteur
            var author = _repository.GetById(id);
            if (author == null)
            {
                return "❌ Auteur non trouvé.";
            }

            // Vérifier si le nouveau nom/prénom existe déjà pour un autre auteur
            if (AuthorExistsExcept(nom, prenom, id))
            {
                return "❌ Un autre auteur avec ce nom et prénom existe déjà.";
            }

            // Modifier les données
            author.Nom = nom.Trim();
            author.Prenom = prenom.Trim();
            author.Nationalite = string.IsNullOrWhiteSpace(nationalite) ? null : nationalite.Trim();

            _repository.Update(author);
            return "✅ Auteur modifié avec succès!";
        }

        // ===== SUPPRIMER UN AUTEUR =====
        public string DeleteAuthor(int id)
        {
            var author = _repository.GetById(id);
            if (author == null)
            {
                return "❌ Auteur non trouvé.";
            }

            _repository.Delete(id);
            return "✅ Auteur supprimé avec succès!";
        }

        // ===== VÉRIFIER SI AUTEUR EXISTE =====
        private bool AuthorExists(string nom, string prenom)
        {
            var allAuthors = _repository.GetAll();
            return allAuthors.Any(a =>
                a.Nom.Equals(nom.Trim(), StringComparison.OrdinalIgnoreCase) &&
                a.Prenom.Equals(prenom.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // ===== VÉRIFIER SI AUTEUR EXISTE (SAUF ID SPÉCIFIÉ) =====
        private bool AuthorExistsExcept(string nom, string prenom, int exceptId)
        {
            var allAuthors = _repository.GetAll();
            return allAuthors.Any(a =>
                a.Id != exceptId &&
                a.Nom.Equals(nom.Trim(), StringComparison.OrdinalIgnoreCase) &&
                a.Prenom.Equals(prenom.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
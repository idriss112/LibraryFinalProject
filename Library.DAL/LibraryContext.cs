using Microsoft.EntityFrameworkCore;
using Library.Models.Entities;

namespace Library.DAL.Data
{
    
    /// Contexte de base de données pour le système de gestion de bibliothèque
    /// Database context for the Library Management System
    
    public class LibraryContext : DbContext
    {
        // ===== DB SETS (TABLES) =====
        // Chaque DbSet représente une table dans la base de données
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        // ===== CONSTRUCTEURS / CONSTRUCTORS =====

        
        /// Constructeur par défaut requis pour les migrations EF Core.
        /// Default constructor required for EF Core migrations.
        
        public LibraryContext()
        {
        }

        
        /// Constructeur avec options (utilisé pour l'injection de dépendances si nécessaire).
        /// Constructor with options (used for dependency injection if needed).
        
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // ===== CONFIGURATION DE LA CONNEXION =====

       
        /// Configure la connexion à la base de données SQL Server LocalDB.
        /// Configures the connection to SQL Server LocalDB database.
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // On configure seulement si aucune configuration n'a été fournie
            // Only configure if no configuration has been provided
            if (!optionsBuilder.IsConfigured)
            {
                // Chaîne de connexion vers SQL Server LocalDB
                // Connection string to SQL Server LocalDB
                // La base s'appellera "GestionBibliotheque"
                // The database will be called "GestionBibliotheque"
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=GestionBibliotheque;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }

        // ===== CONFIGURATION DU MODÈLE =====

        
        /// Configure les relations, clés et contraintes du modèle.
        /// Configures model relationships, keys, and constraints.
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure les relations Many-to-Many (Author ↔ Book)
            ConfigureAuthorBookRelationship(modelBuilder);

            // Configure les relations One-to-Many (Book → Borrowing)
            ConfigureBookBorrowingRelationship(modelBuilder);

            // Configuration additionnelle des tables
            ConfigureTableNames(modelBuilder);

            // SEED DATA - Données initiales
            SeedData(modelBuilder);

        }

        // ===== CONFIGURE AUTHOR-BOOK MANY-TO-MANY =====

       
        /// Configure la relation plusieurs-à-plusieurs entre Author et Book.
        /// Configures the many-to-many relationship between Author and Book.
        
        private void ConfigureAuthorBookRelationship(ModelBuilder modelBuilder)
        {
            // Définir la clé composite pour AuthorBook
            // Define composite primary key for AuthorBook
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            // Configurer le côté Author de la relation
            // Configure Author side of the relationship
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Si auteur supprimé, supprimer ses liens de livres

            // Configurer le côté Book de la relation
            // Configure Book side of the relationship
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Cascade); // Si livre supprimé, supprimer ses liens d'auteurs
        }

        // ===== CONFIGURE BOOK-BORROWING ONE-TO-MANY =====

        
        /// Configure la relation un-à-plusieurs entre Book et Borrowing.
        /// Configures the one-to-many relationship between Book and Borrowing.
        
        private void ConfigureBookBorrowingRelationship(ModelBuilder modelBuilder)
        {
            // Un Book peut avoir plusieurs Borrowings
            // One Book can have many Borrowings
            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.Borrowings)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict); // Empêcher la suppression d'un livre s'il a un historique d'emprunt
        }

        // ===== CONFIGURE TABLE NAMES =====

        
        /// Configure explicitement les noms des tables.
        /// Explicitly configures table names.
        
        private void ConfigureTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Borrowing>().ToTable("Borrowings");
            modelBuilder.Entity<AuthorBook>().ToTable("AuthorBooks");
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // ===== SEED AUTHORS =====
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Nom = "Hugo", Prenom = "Victor", Nationalite = "Française" },
                new Author { Id = 2, Nom = "Tolkien", Prenom = "J.R.R.", Nationalite = "Britannique" },
                new Author { Id = 3, Nom = "Rowling", Prenom = "J.K.", Nationalite = "Britannique" },
                new Author { Id = 4, Nom = "Saint-Exupéry", Prenom = "Antoine de", Nationalite = "Française" },
                new Author { Id = 5, Nom = "Orwell", Prenom = "George", Nationalite = "Britannique" },
                new Author { Id = 6, Nom = "Camus", Prenom = "Albert", Nationalite = "Française" },
                new Author { Id = 7, Nom = "García Márquez", Prenom = "Gabriel", Nationalite = "Colombienne" },
                new Author { Id = 8, Nom = "Hemingway", Prenom = "Ernest", Nationalite = "Américaine" }
            );

            // ===== SEED BOOKS =====
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Titre = "Les Misérables", AnneePublication = 1862, ISBN = "978-2-253-09633-4", Disponible = true },
                new Book { Id = 2, Titre = "Le Seigneur des Anneaux", AnneePublication = 1954, ISBN = "978-2-266-15410-9", Disponible = true },
                new Book { Id = 3, Titre = "Harry Potter à l'école des sorciers", AnneePublication = 1997, ISBN = "978-2-07-054127-3", Disponible = true },
                new Book { Id = 4, Titre = "Le Petit Prince", AnneePublication = 1943, ISBN = "978-2-07-061275-8", Disponible = false },
                new Book { Id = 5, Titre = "1984", AnneePublication = 1949, ISBN = "978-0-452-28423-4", Disponible = true },
                new Book { Id = 6, Titre = "L'Étranger", AnneePublication = 1942, ISBN = "978-2-07-036002-4", Disponible = false },
                new Book { Id = 7, Titre = "Cent ans de solitude", AnneePublication = 1967, ISBN = "978-2-02-037644-2", Disponible = true },
                new Book { Id = 8, Titre = "Le Vieil Homme et la Mer", AnneePublication = 1952, ISBN = "978-0-684-80122-3", Disponible = true }
            );

            // ===== SEED AUTHOR-BOOK RELATIONSHIPS =====
            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook { AuthorId = 1, BookId = 1 }, // Hugo - Les Misérables
                new AuthorBook { AuthorId = 2, BookId = 2 }, // Tolkien - Le Seigneur des Anneaux
                new AuthorBook { AuthorId = 3, BookId = 3 }, // Rowling - Harry Potter
                new AuthorBook { AuthorId = 4, BookId = 4 }, // Saint-Exupéry - Le Petit Prince
                new AuthorBook { AuthorId = 5, BookId = 5 }, // Orwell - 1984
                new AuthorBook { AuthorId = 6, BookId = 6 }, // Camus - L'Étranger
                new AuthorBook { AuthorId = 7, BookId = 7 }, // García Márquez - Cent ans de solitude
                new AuthorBook { AuthorId = 8, BookId = 8 }  // Hemingway - Le Vieil Homme et la Mer
            );

            // ===== SEED BORROWINGS =====
            modelBuilder.Entity<Borrowing>().HasData(
                // Emprunt actif (à temps)
                new Borrowing
                {
                    Id = 1,
                    BookId = 4, // Le Petit Prince
                    NomEmprunteur = "Jean Dupont",
                    DateEmprunt = new DateTime(2024, 12, 1),
                    DateRetourPrevue = new DateTime(2024, 12, 15),
                    DateRetourReelle = null,
                    Penalite = 0
                },

                // Emprunt actif (EN RETARD)
                new Borrowing
                {
                    Id = 2,
                    BookId = 6, // L'Étranger
                    NomEmprunteur = "Marie Laurent",
                    DateEmprunt = new DateTime(2024, 11, 16),
                    DateRetourPrevue = new DateTime(2024, 11, 30),
                    DateRetourReelle = null,
                    Penalite = 6.00m
                },

                // Emprunt retourné à temps
                new Borrowing
                {
                    Id = 3,
                    BookId = 1, // Les Misérables
                    NomEmprunteur = "Pierre Martin",
                    DateEmprunt = new DateTime(2024, 11, 6),
                    DateRetourPrevue = new DateTime(2024, 11, 20),
                    DateRetourReelle = new DateTime(2024, 11, 18),
                    Penalite = 0
                },

                // Emprunt retourné EN RETARD
                new Borrowing
                {
                    Id = 4,
                    BookId = 2, // Le Seigneur des Anneaux
                    NomEmprunteur = "Sophie Bernard",
                    DateEmprunt = new DateTime(2024, 11, 1),
                    DateRetourPrevue = new DateTime(2024, 11, 15),
                    DateRetourReelle = new DateTime(2024, 11, 20),
                    Penalite = 5.00m
                }
            );
        }
    }
}
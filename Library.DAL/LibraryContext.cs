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
    }
}
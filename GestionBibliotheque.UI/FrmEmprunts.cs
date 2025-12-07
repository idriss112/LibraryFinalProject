using Library.BLL.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque.UI;

public partial class FrmEmprunts : Form

{
    private BorrowingManager _borrowingManager;
    private BookManager _bookManager;

    private int? _selectedBorrowingId = null;

    // Custom rounded buttons
    private CustomControls.RoundedButton btnEmprunter;
    private CustomControls.RoundedButton btnRetourner;
    private CustomControls.RoundedButton btnDelete;
    private CustomControls.RoundedButton btnClear;

    // Penalty rate per day
    private const decimal TARIF_JOURNALIER = 1.00m; // 1$ per day
    public FrmEmprunts()
    {
        _borrowingManager = new BorrowingManager();
        _bookManager = new BookManager();

        InitializeComponent();
        InitializeCustomButtons();
        InitializeDataGridView();
        PopulateBookComboBox();
        LoadBorrowingsFromDatabase();
        ConfigureDatePickers();
    }

    // ===== INITIALIZE CUSTOM BUTTONS =====
    private void InitializeCustomButtons()
    {
        // Borrow Button (Green)
        btnEmprunter = new CustomControls.RoundedButton
        {
            Name = "btnEmprunter",
            Text = "📚 Emprunter",
            Size = new System.Drawing.Size(160, 40),
            Location = new System.Drawing.Point(0, 5),
            BackColor = UIHelpers.UIColors.AccentGreen,
            HoverBackColor = System.Drawing.Color.FromArgb(20, 180, 140),
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnEmprunter.Click += BtnEmprunter_Click;

        // Return Button (Blue)
        btnRetourner = new CustomControls.RoundedButton
        {
            Name = "btnRetourner",
            Text = "✅ Retourner",
            Size = new System.Drawing.Size(160, 40),
            Location = new System.Drawing.Point(170, 5),
            BackColor = UIHelpers.UIColors.Primary,
            HoverBackColor = UIHelpers.UIColors.PrimaryDark,
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnRetourner.Click += BtnRetourner_Click;

        // Delete Button (Red)
        btnDelete = new CustomControls.RoundedButton
        {
            Name = "btnDelete",
            Text = "🗑️ Supprimer",
            Size = new System.Drawing.Size(160, 40),
            Location = new System.Drawing.Point(340, 5),
            BackColor = UIHelpers.UIColors.AccentRed,
            HoverBackColor = System.Drawing.Color.FromArgb(200, 40, 60),
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnDelete.Click += BtnDelete_Click;

        // Clear Button (Gray)
        btnClear = new CustomControls.RoundedButton
        {
            Name = "btnClear",
            Text = "🔄 Effacer",
            Size = new System.Drawing.Size(160, 40),
            Location = new System.Drawing.Point(510, 5),
            BackColor = UIHelpers.UIColors.TextSecondary,
            HoverBackColor = System.Drawing.Color.FromArgb(80, 90, 110),
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnClear.Click += BtnClear_Click;

        // Add buttons to the panel
        pnlButtons.Controls.Add(btnEmprunter);
        pnlButtons.Controls.Add(btnRetourner);
        pnlButtons.Controls.Add(btnDelete);
        pnlButtons.Controls.Add(btnClear);
    }

    // ===== INITIALIZE AND STYLE DATAGRIDVIEW =====
    private void InitializeDataGridView()
    {
        dgvEmprunts.SelectionChanged += dgvEmprunts_SelectionChanged;
        dgvEmprunts.DefaultCellStyle.SelectionBackColor = UIHelpers.UIColors.Primary;
        dgvEmprunts.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        

        // Column header style
        dgvEmprunts.EnableHeadersVisualStyles = false;
        dgvEmprunts.ColumnHeadersDefaultCellStyle.BackColor = UIHelpers.UIColors.Primary;
        dgvEmprunts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        dgvEmprunts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        dgvEmprunts.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvEmprunts.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

        // Row style
        dgvEmprunts.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        dgvEmprunts.DefaultCellStyle.ForeColor = UIHelpers.UIColors.TextPrimary;
        dgvEmprunts.DefaultCellStyle.Font = UIHelpers.UIFonts.BodyText;
        dgvEmprunts.DefaultCellStyle.SelectionBackColor = UIHelpers.UIColors.PrimaryLight;
        dgvEmprunts.DefaultCellStyle.SelectionForeColor = UIHelpers.UIColors.TextPrimary;
        dgvEmprunts.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);

        // Alternating row color
        dgvEmprunts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9FAFB");

        // Grid lines
        dgvEmprunts.GridColor = UIHelpers.UIColors.Border;
        dgvEmprunts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

        // Create columns
        dgvEmprunts.Columns.Clear();

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "IdEmprunt",
            HeaderText = "ID",
            Width = 60,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Livre",
            HeaderText = "Livre",
            Width = 200,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Emprunteur",
            HeaderText = "Emprunteur",
            AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "DateEmprunt",
            HeaderText = "Date Emprunt",
            Width = 120,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "DateRetourPrevue",
            HeaderText = "Retour Prévu",
            Width = 120,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "DateRetourReelle",
            HeaderText = "Retour Réel",
            Width = 120,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Penalite",
            HeaderText = "Pénalité",
            Width = 100,
            ReadOnly = true
        });

        dgvEmprunts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Statut",
            HeaderText = "Statut",
            Width = 120,
            ReadOnly = true
        });
    }

    // ===== POPULATE BOOK COMBOBOX =====
    private void PopulateBookComboBox()
    {
        cmbLivre.Items.Clear();

        // Get only available books from database
        var availableBooks = _bookManager.GetAvailableBooks();

        foreach (var book in availableBooks)
        {
            // Format: "ID - Title"
            cmbLivre.Items.Add($"{book.Id} - {book.Titre}");
        }

        // Select first item if available
        if (cmbLivre.Items.Count > 0)
        {
            cmbLivre.SelectedIndex = 0;
        }
    }

    // ===== CONFIGURE DATE PICKERS =====
    private void ConfigureDatePickers()
    {
        // Set default dates
        dtpDateEmprunt.Value = DateTime.Now;
        dtpDateRetourPrevue.Value = DateTime.Now.AddDays(14); // Default 14 days loan
        dtpDateRetourReelle.Value = DateTime.Now;

        // Disable return date initially (only enabled when returning)
        dtpDateRetourReelle.Enabled = false;

        // Add event handler for penalty calculation
        dtpDateRetourReelle.ValueChanged += DtpDateRetourReelle_ValueChanged;
    }

    // ===== LOAD SAMPLE DATA =====
    private void LoadBorrowingsFromDatabase()
    {

        dgvEmprunts.Rows.Clear();

        var borrowings = _borrowingManager.GetAllBorrowings();

        foreach (var borrowing in borrowings)
        {
            // Get book title
            var book = _bookManager.GetBookById(borrowing.BookId);
            string bookTitle = book?.Titre ?? "Inconnu";

            // Format dates
            string dateEmprunt = borrowing.DateEmprunt.ToString("dd/MM/yyyy");
            string dateRetourPrevue = borrowing.DateRetourPrevue.ToString("dd/MM/yyyy");
            string dateRetourReelle = borrowing.DateRetourReelle?.ToString("dd/MM/yyyy") ?? "-";

            // Format penalty
            string penalite = $"{borrowing.Penalite:F2} $";

            // Status
            string statut = borrowing.DateRetourReelle == null ? "En cours" : "Retourné";
            if (borrowing.DateRetourReelle == null && DateTime.Now > borrowing.DateRetourPrevue)
            {
                statut = "🔴 En retard";
            }

            dgvEmprunts.Rows.Add(
                borrowing.Id,
                bookTitle,
                borrowing.NomEmprunteur,
                dateEmprunt,
                dateRetourPrevue,
                dateRetourReelle,
                penalite,
                statut
            );
        }
    }

    // ===== CALCULATE PENALTY =====
    private decimal CalculerPenalite(DateTime dateRetourPrevue, DateTime dateRetourReelle)
    {
        // If returned on time or early, no penalty
        if (dateRetourReelle <= dateRetourPrevue)
        {
            return 0.00m;
        }

        // Calculate days late
        TimeSpan retard = dateRetourReelle - dateRetourPrevue;
        int joursRetard = retard.Days;

        // Calculate penalty
        decimal penalite = joursRetard * TARIF_JOURNALIER;

        return penalite;
    }

    // ===== UPDATE PENALTY WHEN RETURN DATE CHANGES =====
    private void DtpDateRetourReelle_ValueChanged(object sender, EventArgs e)
    {
        if (dtpDateRetourReelle.Enabled)
        {
            decimal penalite = CalculerPenalite(dtpDateRetourPrevue.Value, dtpDateRetourReelle.Value);
            lblPenalite.Text = $"Pénalité: {penalite:F2} $";

            // Change color based on penalty
            if (penalite > 0)
            {
                lblPenalite.ForeColor = UIHelpers.UIColors.AccentRed;
            }
            else
            {
                lblPenalite.ForeColor = UIHelpers.UIColors.AccentGreen;
            }
        }
    }

    // ===== BUTTON CLICK EVENTS =====

    private void BtnEmprunter_Click(object sender, EventArgs e)
    {
        // ===== NEW: CHECK IF EDITING AN EXISTING BORROWING =====
        if (_selectedBorrowingId.HasValue)
        {
            var dialogResult = MessageBox.Show(
                "⚠️ Vous avez sélectionné un emprunt existant!\n\n" +
                "Pour emprunter un nouveau livre, vous devez d'abord:\n" +
                "1. Cliquer sur le bouton 'Vider'\n" +
                "2. Ou retourner le livre sélectionné\n\n" +
                "Voulez-vous vider le formulaire maintenant?",
                "Attention",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult == DialogResult.Yes)
            {
                ClearForm();
                return; // Stop here, user can now fill form again
            }
            else
            {
                return; // Stop here, don't create borrowing
            }
        }

        // Validate book selection
        if (cmbLivre.SelectedIndex == -1)
        {
            MessageBox.Show("❌ Veuillez sélectionner un livre.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validate borrower name
        if (string.IsNullOrWhiteSpace(txtEmprunteur.Text))
        {
            MessageBox.Show("❌ Veuillez entrer le nom de l'emprunteur.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validate return date
        if (dtpDateRetourPrevue.Value <= dtpDateEmprunt.Value)
        {
            MessageBox.Show("❌ La date de retour prévue doit être après la date d'emprunt.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Extract book ID from selection (format: "ID - Title")
        string selected = cmbLivre.SelectedItem.ToString();
        int bookId = int.Parse(selected.Split('-')[0].Trim());

        // Call manager to borrow
        string result = _borrowingManager.BorrowBook(
            bookId,
            txtEmprunteur.Text,
            dtpDateRetourPrevue.Value
        );

        MessageBox.Show(result, "Information",
            MessageBoxButtons.OK,
            result.Contains("✅") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        if (result.Contains("✅"))
        {
            // Refresh everything
            LoadBorrowingsFromDatabase();
            PopulateBookComboBox(); // Book is no longer available
            ClearForm();
        }
    }

    private void BtnRetourner_Click(object sender, EventArgs e)
    {
        // Check if a borrowing is selected
        if (!_selectedBorrowingId.HasValue)
        {
            MessageBox.Show("Veuillez sélectionner un emprunt à retourner dans la liste.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Get borrowing details
        int borrowingId = _selectedBorrowingId.Value;
        var borrowing = _borrowingManager.GetBorrowingById(borrowingId);
        var book = _bookManager.GetBookById(borrowing.BookId);

        // Calculate penalty
        decimal penalty = CalculatePotentialPenalty(borrowing.DateRetourPrevue, DateTime.Now);

        // Confirmation message
        string confirmMessage = $"Retourner ce livre?\n\n" +
                               $"📚 Livre: {book.Titre}\n" +
                               $"👤 Emprunteur: {borrowing.NomEmprunteur}\n" +
                               $"📅 Emprunté le: {borrowing.DateEmprunt:dd/MM/yyyy}\n" +
                               $"📅 Retour prévu: {borrowing.DateRetourPrevue:dd/MM/yyyy}\n" +
                               $"💰 Pénalité: {penalty:F2} $";

        var confirmResult = MessageBox.Show(confirmMessage,
            "Confirmation de retour",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmResult == DialogResult.Yes)
        {
            // Return the book
            string result = _borrowingManager.ReturnBook(borrowingId);

            MessageBox.Show(result, "Information",
                MessageBoxButtons.OK,
                result.Contains("✅") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (result.Contains("✅"))
            {
                LoadBorrowingsFromDatabase();
                PopulateBookComboBox();
                ClearForm();
            }
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (dgvEmprunts.SelectedRows.Count == 0)
        {
            MessageBox.Show("Veuillez sélectionner un emprunt à supprimer.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet emprunt?",
            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            MessageBox.Show("Emprunt supprimé!\n(Fonctionnalité complète sera implémentée avec la base de données)",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    // ===== HELPER METHOD =====
    private void ClearForm()
    {
        _selectedBorrowingId = null;

        cmbLivre.SelectedIndex = -1;
        txtEmprunteur.Clear();
        dtpDateEmprunt.Value = DateTime.Now;
        dtpDateRetourPrevue.Value = DateTime.Now.AddDays(14);
        dtpDateRetourReelle.Value = DateTime.Now;
        dtpDateRetourReelle.Enabled = false;
        lblPenalite.Text = "Pénalité: 0.00 $";
        lblPenalite.ForeColor = UIHelpers.UIColors.TextSecondary;
    }

    private void dgvEmprunts_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvEmprunts.SelectedRows.Count > 0)
        {
            var row = dgvEmprunts.SelectedRows[0];

            // Get borrowing ID
            int borrowingId = (int)row.Cells["IdEmprunt"].Value;

            _selectedBorrowingId = borrowingId;

            // Load borrowing from database
            var borrowing = _borrowingManager.GetBorrowingById(borrowingId);

            if (borrowing != null)
            {
                // Get the book details
                var book = _bookManager.GetBookById(borrowing.BookId);

                // Load data into form fields

                // Find the book in the dropdown (format: "ID - Title")
                string bookItem = $"{book.Id} - {book.Titre}";
                int index = cmbLivre.FindStringExact(bookItem);
                if (index != -1)
                {
                    cmbLivre.SelectedIndex = index;
                }
                else
                {
                    // Book not in list (because it's borrowed), add it temporarily
                    cmbLivre.Items.Add(bookItem);
                    cmbLivre.SelectedIndex = cmbLivre.Items.Count - 1;
                }

                // Load borrower name
                txtEmprunteur.Text = borrowing.NomEmprunteur;

                // Load dates
                dtpDateEmprunt.Value = borrowing.DateEmprunt;
                dtpDateRetourPrevue.Value = borrowing.DateRetourPrevue;

                // If already returned, show return date
                if (borrowing.DateRetourReelle.HasValue)
                {
                    dtpDateRetourReelle.Enabled = true;
                    dtpDateRetourReelle.Value = borrowing.DateRetourReelle.Value;
                    lblPenalite.Text = $"Pénalité: {borrowing.Penalite:F2} $";
                }
                else
                {
                    // Not returned yet
                    dtpDateRetourReelle.Enabled = true;
                    dtpDateRetourReelle.Value = DateTime.Now;

                    // Calculate LIVE penalty if returned today
                    decimal potentialPenalty = CalculatePotentialPenalty(
                        borrowing.DateRetourPrevue,
                        DateTime.Now
                    );

                    if (potentialPenalty > 0)
                    {
                        lblPenalite.Text = $"Pénalité si retourné maintenant: {potentialPenalty:F2} $";
                        lblPenalite.ForeColor = UIHelpers.UIColors.AccentRed;
                    }
                    else
                    {
                        lblPenalite.Text = $"Pénalité: 0.00 $ (À temps)";
                        lblPenalite.ForeColor = UIHelpers.UIColors.AccentGreen;
                    }
                }
            }
        }
    }

    private decimal CalculatePotentialPenalty(DateTime dateRetourPrevue, DateTime dateRetourReelle)
    {
        if (dateRetourReelle <= dateRetourPrevue)
        {
            return 0;
        }

        TimeSpan retard = dateRetourReelle - dateRetourPrevue;
        int joursRetard = retard.Days;
        decimal penalite = joursRetard * 1.00m; // 1$ per day

        return penalite;
    }
}

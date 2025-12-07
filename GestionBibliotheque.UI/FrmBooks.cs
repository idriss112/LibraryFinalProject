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

public partial class FrmBooks : Form
{

    private BookManager _bookManager;


    // Custom rounded buttons
    private CustomControls.RoundedButton btnAdd;
    private CustomControls.RoundedButton btnEdit;
    private CustomControls.RoundedButton btnDelete;
    private CustomControls.RoundedButton btnClear;


    public FrmBooks()
    {

        _bookManager = new BookManager();

        InitializeComponent();
        InitializeCustomButtons();
        InitializeDataGridView();
        LoadBooksFromDatabase();
    }

    // ===== INITIALIZE CUSTOM BUTTONS =====
    private void InitializeCustomButtons()
    {
        // Add Button (Green)
        btnAdd = new CustomControls.RoundedButton
        {
            Name = "btnAdd",
            Text = "➕ Ajouter",
            Size = new System.Drawing.Size(150, 40),
            Location = new System.Drawing.Point(0, 5),
            BackColor = UIHelpers.UIColors.AccentGreen,
            HoverBackColor = System.Drawing.Color.FromArgb(20, 180, 140),
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnAdd.Click += BtnAdd_Click;

        // Edit Button (Blue)
        btnEdit = new CustomControls.RoundedButton
        {
            Name = "btnEdit",
            Text = "✏️ Modifier",
            Size = new System.Drawing.Size(150, 40),
            Location = new System.Drawing.Point(160, 5),
            BackColor = UIHelpers.UIColors.Primary,
            HoverBackColor = UIHelpers.UIColors.PrimaryDark,
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnEdit.Click += BtnEdit_Click;

        // Delete Button (Red)
        btnDelete = new CustomControls.RoundedButton
        {
            Name = "btnDelete",
            Text = "🗑️ Supprimer",
            Size = new System.Drawing.Size(150, 40),
            Location = new System.Drawing.Point(320, 5),
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
            Size = new System.Drawing.Size(150, 40),
            Location = new System.Drawing.Point(480, 5),
            BackColor = UIHelpers.UIColors.TextSecondary,
            HoverBackColor = System.Drawing.Color.FromArgb(80, 90, 110),
            ForeColor = System.Drawing.Color.White,
            Font = UIHelpers.UIFonts.ButtonText
        };
        btnClear.Click += BtnClear_Click;

        // Add buttons to the panel
        pnlButtons.Controls.Add(btnAdd);
        pnlButtons.Controls.Add(btnEdit);
        pnlButtons.Controls.Add(btnDelete);
        pnlButtons.Controls.Add(btnClear);
    }

    // ===== BUTTON CLICK EVENTS =====

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(txtTitre.Text))
        {
            MessageBox.Show("❌ Veuillez entrer un titre.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Parse year (if entered)
        int? annee = null;
        if (!string.IsNullOrWhiteSpace(txtAnnee.Text))
        {
            if (int.TryParse(txtAnnee.Text, out int parsedYear))
            {
                annee = parsedYear;
            }
            else
            {
                MessageBox.Show("❌ L'année doit être un nombre valide.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Call the manager to add the book
        string result = _bookManager.AddBook(
            txtTitre.Text,
            annee,
            txtISBN.Text
        );

        // Show result message
        MessageBox.Show(result, "Information",
            MessageBoxButtons.OK,
            result.Contains("✅") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        // If success, reload and clear
        if (result.Contains("✅"))
        {
            LoadBooksFromDatabase();
            ClearForm();
        }
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        // Vérifier qu'un livre est sélectionné
        if (dgvBooks.SelectedRows.Count == 0)
        {
            MessageBox.Show("Veuillez sélectionner un livre à modifier.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Récupérer les données de la ligne sélectionnée
        var selectedRow = dgvBooks.SelectedRows[0];
        int bookId = (int)selectedRow.Cells["IdLivre"].Value;

        // Valider les champs
        if (string.IsNullOrWhiteSpace(txtTitre.Text))
        {
            MessageBox.Show("Veuillez entrer un titre.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Parser l'année
        int? annee = null;
        if (!string.IsNullOrWhiteSpace(txtAnnee.Text))
        {
            if (int.TryParse(txtAnnee.Text, out int parsedYear))
            {
                annee = parsedYear;
            }
        }

        // Appeler le manager pour modifier
        string result = _bookManager.UpdateBook(
            bookId,
            txtTitre.Text,
            annee,
            txtISBN.Text,
            chkDisponible.Checked
        );

        // Afficher le résultat
        MessageBox.Show(result, "Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Si succès, recharger et vider
        if (result.Contains("✅"))
        {
            LoadBooksFromDatabase();
            ClearForm();
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (dgvBooks.SelectedRows.Count == 0)
        {
            MessageBox.Show("Veuillez sélectionner un livre à supprimer.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce livre?",
            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Get the book ID from the selected row
            int bookId = (int)dgvBooks.SelectedRows[0].Cells[0].Value;

            // Call manager to delete
            string message = _bookManager.DeleteBook(bookId);

            MessageBox.Show(message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reload the grid
            LoadBooksFromDatabase();
        }
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    // ===== HELPER METHOD =====
    private void ClearForm()
    {
        txtTitre.Clear();
        txtAnnee.Clear();
        txtISBN.Clear();
        chkDisponible.Checked = true;
        txtTitre.Focus();
    }

    // ===== INITIALIZE AND STYLE DATAGRIDVIEW =====
    private void InitializeDataGridView()
    {
        // Column header style
        dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
        dgvBooks.EnableHeadersVisualStyles = false;
        dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = UIHelpers.UIColors.Primary;
        dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        dgvBooks.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        dgvBooks.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvBooks.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

        // Row style
        dgvBooks.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        dgvBooks.DefaultCellStyle.ForeColor = UIHelpers.UIColors.TextPrimary;
        dgvBooks.DefaultCellStyle.Font = UIHelpers.UIFonts.BodyText;
        dgvBooks.DefaultCellStyle.SelectionBackColor = UIHelpers.UIColors.PrimaryLight;
        dgvBooks.DefaultCellStyle.SelectionForeColor = UIHelpers.UIColors.TextPrimary;
        dgvBooks.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);

        // Alternating row color
        dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9FAFB");

        // Grid lines
        dgvBooks.GridColor = UIHelpers.UIColors.Border;
        dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

        // Create columns
        dgvBooks.Columns.Clear();

        dgvBooks.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "IdLivre",
            HeaderText = "ID",
            Width = 60,
            ReadOnly = true
        });

        dgvBooks.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Titre",
            HeaderText = "Titre",
            AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dgvBooks.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Annee",
            HeaderText = "Année",
            Width = 100,
            ReadOnly = true
        });

        dgvBooks.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "ISBN",
            HeaderText = "ISBN",
            Width = 150,
            ReadOnly = true
        });

        dgvBooks.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Disponible",
            HeaderText = "Disponible",
            Width = 100,
            ReadOnly = true
        });
    }

    // ===== LOAD SAMPLE DATA =====
    private void LoadBooksFromDatabase()
    {
        dgvBooks.Rows.Clear();

        // Get all books from database
        var books = _bookManager.GetAllBooks();

        // Add each book to the grid
        foreach (var book in books)
        {
            string disponible = book.Disponible ? "✓ Oui" : "✗ Non";

            dgvBooks.Rows.Add(
                book.Id,
                book.Titre,
                book.AnneePublication ?? 0,
                book.ISBN ?? "",
                disponible
            );
        }
    }

    private void dgvBooks_SelectionChanged(object sender, EventArgs e)
    {

        if (dgvBooks.SelectedRows.Count > 0)
        {
            var row = dgvBooks.SelectedRows[0];

            // Charger les données dans les champs
            txtTitre.Text = row.Cells["Titre"].Value?.ToString() ?? "";
            txtAnnee.Text = row.Cells["Annee"].Value?.ToString() ?? "";
            txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";

            // Checkbox disponible
            string dispo = row.Cells["Disponible"].Value?.ToString() ?? "";
            chkDisponible.Checked = dispo.Contains("✓");
        }
    }
}

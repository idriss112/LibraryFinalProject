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

public partial class FrmAuteurs : Form
{
    private AuthorManager _authorManager;

    // Custom rounded buttons
    private CustomControls.RoundedButton btnAdd;
    private CustomControls.RoundedButton btnEdit;
    private CustomControls.RoundedButton btnDelete;
    private CustomControls.RoundedButton btnClear;
    public FrmAuteurs()
    {
        _authorManager = new AuthorManager();

        InitializeComponent();
        InitializeCustomButtons();
        InitializeDataGridView();
        LoadAuthorsFromDatabase();
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

    // ===== INITIALIZE AND STYLE DATAGRIDVIEW =====
    private void InitializeDataGridView()
    {
        // Column header style
        dgvAuteurs.EnableHeadersVisualStyles = false;
        dgvAuteurs.ColumnHeadersDefaultCellStyle.BackColor = UIHelpers.UIColors.Primary;
        dgvAuteurs.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        dgvAuteurs.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        dgvAuteurs.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvAuteurs.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

        // Row style
        dgvAuteurs.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        dgvAuteurs.DefaultCellStyle.ForeColor = UIHelpers.UIColors.TextPrimary;
        dgvAuteurs.DefaultCellStyle.Font = UIHelpers.UIFonts.BodyText;
        dgvAuteurs.DefaultCellStyle.SelectionBackColor = UIHelpers.UIColors.PrimaryLight;
        dgvAuteurs.DefaultCellStyle.SelectionForeColor = UIHelpers.UIColors.TextPrimary;
        dgvAuteurs.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);

        // Alternating row color
        dgvAuteurs.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9FAFB");

        // Grid lines
        dgvAuteurs.GridColor = UIHelpers.UIColors.Border;
        dgvAuteurs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

        // Create columns
        dgvAuteurs.Columns.Clear();

        dgvAuteurs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "IdAuteur",
            HeaderText = "ID",
            Width = 80,
            ReadOnly = true
        });

        dgvAuteurs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Nom",
            HeaderText = "Nom",
            AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dgvAuteurs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Prenom",
            HeaderText = "Prénom",
            AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dgvAuteurs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
        {
            Name = "Nationalite",
            HeaderText = "Nationalité",
            AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dgvAuteurs.SelectionChanged += dgvAuteurs_SelectionChanged;
    }

    // ===== LOAD REAL DATA FROM DATABASE =====
    private void LoadAuthorsFromDatabase()
    {
        dgvAuteurs.Rows.Clear();

        // Get all authors from database
        var authors = _authorManager.GetAllAuthors();

        // Add each author to the grid
        foreach (var author in authors)
        {
            dgvAuteurs.Rows.Add(
                author.Id,
                author.Nom,
                author.Prenom,
                author.Nationalite ?? ""
            );
        }
    }

    // ===== BUTTON CLICK EVENTS =====

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(txtNom.Text))
        {
            MessageBox.Show("❌ Veuillez entrer le nom.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPrenom.Text))
        {
            MessageBox.Show("❌ Veuillez entrer le prénom.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Call the manager to add the author
        string result = _authorManager.AddAuthor(
            txtNom.Text,
            txtPrenom.Text,
            txtNationalite.Text
        );

        // Show result
        MessageBox.Show(result, "Information",
            MessageBoxButtons.OK,
            result.Contains("✅") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        // If success, reload and clear
        if (result.Contains("✅"))
        {
            LoadAuthorsFromDatabase();
            ClearForm();
        }
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        if (dgvAuteurs.SelectedRows.Count == 0)
        {
            MessageBox.Show("Veuillez sélectionner un auteur à modifier.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Get selected author ID
        var selectedRow = dgvAuteurs.SelectedRows[0];
        int authorId = (int)selectedRow.Cells["IdAuteur"].Value;

        // Validate
        if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
        {
            MessageBox.Show("❌ Le nom et le prénom sont requis.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Call manager to update
        string result = _authorManager.UpdateAuthor(
            authorId,
            txtNom.Text,
            txtPrenom.Text,
            txtNationalite.Text
        );

        MessageBox.Show(result, "Information",
            MessageBoxButtons.OK,
            result.Contains("✅") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        if (result.Contains("✅"))
        {
            LoadAuthorsFromDatabase();
            ClearForm();
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (dgvAuteurs.SelectedRows.Count == 0)
        {
            MessageBox.Show("Veuillez sélectionner un auteur à supprimer.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet auteur?",
            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            int authorId = (int)dgvAuteurs.SelectedRows[0].Cells["IdAuteur"].Value;

            string message = _authorManager.DeleteAuthor(authorId);

            MessageBox.Show(message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (message.Contains("✅"))
            {
                LoadAuthorsFromDatabase();
                ClearForm();
            }
        }
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    // ===== HELPER METHOD =====
    private void ClearForm()
    {
        txtNom.Clear();
        txtPrenom.Clear();
        txtNationalite.Clear();
        txtNom.Focus();
    }

    private void dgvAuteurs_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvAuteurs.SelectedRows.Count > 0)
        {
            var row = dgvAuteurs.SelectedRows[0];

            txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            txtPrenom.Text = row.Cells["Prenom"].Value?.ToString() ?? "";
            txtNationalite.Text = row.Cells["Nationalite"].Value?.ToString() ?? "";
        }
    }
}

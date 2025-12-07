namespace GestionBibliotheque.UI;

partial class FrmBooks
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlTop = new Panel();
        txtSearch = new TextBox();
        lblSearch = new Label();
        pnlBookForm = new Panel();
        pnlButtons = new Panel();
        chkDisponible = new CheckBox();
        txtISBN = new TextBox();
        lblISBN = new Label();
        txtAnnee = new TextBox();
        lblAnnee = new Label();
        txtTitre = new TextBox();
        lblTitre = new Label();
        lblFormTitle = new Label();
        dgvBooks = new DataGridView();
        pnlTop.SuspendLayout();
        pnlBookForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.Transparent;
        pnlTop.Controls.Add(txtSearch);
        pnlTop.Controls.Add(lblSearch);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1100, 80);
        pnlTop.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtSearch.Location = new Point(788, 25);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Rechercher par titre ou ISBN...\n";
        txtSearch.Size = new Size(300, 29);
        txtSearch.TabIndex = 1;
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSearch.ForeColor = Color.FromArgb(107, 114, 128);
        lblSearch.Location = new Point(20, 25);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(117, 21);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "🔍 Rechercher:";
        // 
        // pnlBookForm
        // 
        pnlBookForm.BackColor = Color.White;
        pnlBookForm.Controls.Add(pnlButtons);
        pnlBookForm.Controls.Add(chkDisponible);
        pnlBookForm.Controls.Add(txtISBN);
        pnlBookForm.Controls.Add(lblISBN);
        pnlBookForm.Controls.Add(txtAnnee);
        pnlBookForm.Controls.Add(lblAnnee);
        pnlBookForm.Controls.Add(txtTitre);
        pnlBookForm.Controls.Add(lblTitre);
        pnlBookForm.Controls.Add(lblFormTitle);
        pnlBookForm.Location = new Point(20, 100);
        pnlBookForm.Name = "pnlBookForm";
        pnlBookForm.Size = new Size(1060, 220);
        pnlBookForm.TabIndex = 1;
        // 
        // pnlButtons
        // 
        pnlButtons.BackColor = Color.Transparent;
        pnlButtons.Location = new Point(20, 165);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(1020, 50);
        pnlButtons.TabIndex = 8;
        // 
        // chkDisponible
        // 
        chkDisponible.AutoSize = true;
        chkDisponible.Checked = true;
        chkDisponible.CheckState = CheckState.Checked;
        chkDisponible.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        chkDisponible.ForeColor = Color.FromArgb(22, 199, 154);
        chkDisponible.Location = new Point(20, 135);
        chkDisponible.Name = "chkDisponible";
        chkDisponible.Size = new Size(103, 25);
        chkDisponible.TabIndex = 7;
        chkDisponible.Text = "Disponible";
        chkDisponible.UseVisualStyleBackColor = true;
        // 
        // txtISBN
        // 
        txtISBN.Location = new Point(710, 85);
        txtISBN.Name = "txtISBN";
        txtISBN.Size = new Size(300, 26);
        txtISBN.TabIndex = 6;
        // 
        // lblISBN
        // 
        lblISBN.AutoSize = true;
        lblISBN.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblISBN.Location = new Point(710, 60);
        lblISBN.Name = "lblISBN";
        lblISBN.Size = new Size(41, 20);
        lblISBN.TabIndex = 5;
        lblISBN.Text = "ISBN";
        // 
        // txtAnnee
        // 
        txtAnnee.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtAnnee.Location = new Point(540, 85);
        txtAnnee.Name = "txtAnnee";
        txtAnnee.Size = new Size(150, 29);
        txtAnnee.TabIndex = 4;
        // 
        // lblAnnee
        // 
        lblAnnee.AutoSize = true;
        lblAnnee.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAnnee.ForeColor = Color.FromArgb(26, 26, 26);
        lblAnnee.Location = new Point(540, 60);
        lblAnnee.Name = "lblAnnee";
        lblAnnee.Size = new Size(151, 20);
        lblAnnee.TabIndex = 3;
        lblAnnee.Text = "Année de publication";
        // 
        // txtTitre
        // 
        txtTitre.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtTitre.Location = new Point(20, 85);
        txtTitre.Name = "txtTitre";
        txtTitre.Size = new Size(500, 29);
        txtTitre.TabIndex = 2;
        // 
        // lblTitre
        // 
        lblTitre.AutoSize = true;
        lblTitre.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitre.ForeColor = Color.FromArgb(26, 26, 26);
        lblTitre.Location = new Point(20, 60);
        lblTitre.Name = "lblTitre";
        lblTitre.Size = new Size(92, 20);
        lblTitre.TabIndex = 1;
        lblTitre.Text = "Titre du livre";
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblFormTitle.ForeColor = Color.FromArgb(0, 120, 212);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(245, 25);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "INFORMATIONS DU LIVRE";
        // 
        // dgvBooks
        // 
        dgvBooks.AllowUserToAddRows = false;
        dgvBooks.AllowUserToDeleteRows = false;
        dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        dgvBooks.BackgroundColor = Color.White;
        dgvBooks.BorderStyle = BorderStyle.None;
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBooks.Location = new Point(20, 340);
        dgvBooks.MultiSelect = false;
        dgvBooks.Name = "dgvBooks";
        dgvBooks.ReadOnly = true;
        dgvBooks.RowHeadersVisible = false;
        dgvBooks.RowHeadersWidth = 49;
        dgvBooks.RowTemplate.Height = 35;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size = new Size(1060, 340);
        dgvBooks.TabIndex = 2;
        dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
        // 
        // FrmBooks
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1100, 700);
        Controls.Add(dgvBooks);
        Controls.Add(pnlBookForm);
        Controls.Add(pnlTop);
        FormBorderStyle = FormBorderStyle.None;
        Location = new Point(20, 340);
        Name = "FrmBooks";
        StartPosition = FormStartPosition.Manual;
        Text = "Gestion des Livres";
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlBookForm.ResumeLayout(false);
        pnlBookForm.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private TextBox txtSearch;
    private Label lblSearch;
    private Panel pnlBookForm;
    private Label lblFormTitle;
    private TextBox txtTitre;
    private Label lblTitre;
    private CheckBox chkDisponible;
    private TextBox txtISBN;
    private Label lblISBN;
    private TextBox txtAnnee;
    private Label lblAnnee;
    private Panel pnlButtons;
    private DataGridView dgvBooks;
}
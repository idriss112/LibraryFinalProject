namespace GestionBibliotheque.UI;

partial class FrmAuteurs
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
        lblTitle = new Label();
        pnlAuthorForm = new Panel();
        pnlButtons = new Panel();
        txtNationalite = new TextBox();
        lblNationalite = new Label();
        txtPrenom = new TextBox();
        lblPrenom = new Label();
        txtNom = new TextBox();
        lblNom = new Label();
        lblFormTitle = new Label();
        dgvAuteurs = new DataGridView();
        pnlTop.SuspendLayout();
        pnlAuthorForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAuteurs).BeginInit();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.Transparent;
        pnlTop.Controls.Add(txtSearch);
        pnlTop.Controls.Add(lblSearch);
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1082, 80);
        pnlTop.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtSearch.Location = new Point(800, 25);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Rechercher par nom ou prénom...\n";
        txtSearch.Size = new Size(300, 29);
        txtSearch.TabIndex = 2;
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.ForeColor = Color.FromArgb(107, 114, 128);
        lblSearch.Location = new Point(680, 30);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(110, 20);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "🔍 Rechercher:";
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20.0347824F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.FromArgb(26, 26, 26);
        lblTitle.Location = new Point(20, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(408, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "✍️ GESTION DES AUTEURS";
        // 
        // pnlAuthorForm
        // 
        pnlAuthorForm.BackColor = Color.White;
        pnlAuthorForm.Controls.Add(pnlButtons);
        pnlAuthorForm.Controls.Add(txtNationalite);
        pnlAuthorForm.Controls.Add(lblNationalite);
        pnlAuthorForm.Controls.Add(txtPrenom);
        pnlAuthorForm.Controls.Add(lblPrenom);
        pnlAuthorForm.Controls.Add(txtNom);
        pnlAuthorForm.Controls.Add(lblNom);
        pnlAuthorForm.Controls.Add(lblFormTitle);
        pnlAuthorForm.Location = new Point(20, 100);
        pnlAuthorForm.Name = "pnlAuthorForm";
        pnlAuthorForm.Size = new Size(1060, 200);
        pnlAuthorForm.TabIndex = 1;
        // 
        // pnlButtons
        // 
        pnlButtons.BackColor = Color.Transparent;
        pnlButtons.Location = new Point(20, 140);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(1020, 50);
        pnlButtons.TabIndex = 7;
        // 
        // txtNationalite
        // 
        txtNationalite.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtNationalite.Location = new Point(660, 85);
        txtNationalite.Name = "txtNationalite";
        txtNationalite.Size = new Size(300, 29);
        txtNationalite.TabIndex = 6;
        // 
        // lblNationalite
        // 
        lblNationalite.AutoSize = true;
        lblNationalite.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNationalite.ForeColor = Color.FromArgb(26, 26, 26);
        lblNationalite.Location = new Point(660, 60);
        lblNationalite.Name = "lblNationalite";
        lblNationalite.Size = new Size(83, 20);
        lblNationalite.TabIndex = 5;
        lblNationalite.Text = "Nationalité";
        // 
        // txtPrenom
        // 
        txtPrenom.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPrenom.Location = new Point(340, 85);
        txtPrenom.Name = "txtPrenom";
        txtPrenom.Size = new Size(300, 29);
        txtPrenom.TabIndex = 4;
        // 
        // lblPrenom
        // 
        lblPrenom.AutoSize = true;
        lblPrenom.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPrenom.ForeColor = Color.FromArgb(26, 26, 26);
        lblPrenom.Location = new Point(340, 60);
        lblPrenom.Name = "lblPrenom";
        lblPrenom.Size = new Size(60, 20);
        lblPrenom.TabIndex = 3;
        lblPrenom.Text = "Prénom";
        // 
        // txtNom
        // 
        txtNom.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtNom.Location = new Point(20, 85);
        txtNom.Name = "txtNom";
        txtNom.Size = new Size(300, 29);
        txtNom.TabIndex = 2;
        // 
        // lblNom
        // 
        lblNom.AutoSize = true;
        lblNom.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNom.ForeColor = Color.FromArgb(26, 26, 26);
        lblNom.Location = new Point(20, 60);
        lblNom.Name = "lblNom";
        lblNom.Size = new Size(42, 20);
        lblNom.TabIndex = 1;
        lblNom.Text = "Nom";
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.ForeColor = Color.FromArgb(0, 120, 212);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(261, 25);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "INFORMATIONS DE L'AUTEUR";
        // 
        // dgvAuteurs
        // 
        dgvAuteurs.AllowUserToAddRows = false;
        dgvAuteurs.AllowUserToDeleteRows = false;
        dgvAuteurs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvAuteurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAuteurs.BackgroundColor = Color.White;
        dgvAuteurs.BorderStyle = BorderStyle.None;
        dgvAuteurs.ColumnHeadersHeight = 40;
        dgvAuteurs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvAuteurs.Location = new Point(20, 320);
        dgvAuteurs.MultiSelect = false;
        dgvAuteurs.Name = "dgvAuteurs";
        dgvAuteurs.ReadOnly = true;
        dgvAuteurs.RowHeadersVisible = false;
        dgvAuteurs.RowHeadersWidth = 49;
        dgvAuteurs.RowTemplate.Height = 35;
        dgvAuteurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAuteurs.Size = new Size(1060, 360);
        dgvAuteurs.TabIndex = 2;
        dgvAuteurs.SelectionChanged += dgvAuteurs_SelectionChanged;
        // 
        // FrmAuteurs
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1082, 655);
        Controls.Add(dgvAuteurs);
        Controls.Add(pnlAuthorForm);
        Controls.Add(pnlTop);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmAuteurs";
        StartPosition = FormStartPosition.Manual;
        Text = "Gestion des Auteurs";
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlAuthorForm.ResumeLayout(false);
        pnlAuthorForm.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAuteurs).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblTitle;
    private TextBox txtSearch;
    private Label lblSearch;
    private Panel pnlAuthorForm;
    private TextBox txtPrenom;
    private Label lblPrenom;
    private TextBox txtNom;
    private Label lblNom;
    private Label lblFormTitle;
    private Panel pnlButtons;
    private TextBox txtNationalite;
    private Label lblNationalite;
    private DataGridView dgvAuteurs;
}
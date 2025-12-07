namespace GestionBibliotheque.UI;

partial class FrmEmprunts
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
        lblTitle = new Label();
        pnlBorrowingForm = new Panel();
        pnlButtons = new Panel();
        lblPenalite = new Label();
        dtpDateRetourReelle = new DateTimePicker();
        lblDateRetourReelle = new Label();
        dtpDateRetourPrevue = new DateTimePicker();
        lblDateRetourPrevue = new Label();
        dtpDateEmprunt = new DateTimePicker();
        lblDateEmprunt = new Label();
        txtEmprunteur = new TextBox();
        lblEmprunteur = new Label();
        cmbLivre = new ComboBox();
        lblLivre = new Label();
        lblFormTitle = new Label();
        dgvEmprunts = new DataGridView();
        pnlTop.SuspendLayout();
        pnlBorrowingForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEmprunts).BeginInit();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.Transparent;
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1082, 80);
        pnlTop.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20.0347824F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.FromArgb(26, 26, 26);
        lblTitle.Location = new Point(20, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(436, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "📖 GESTION DES EMPRUNTS";
        // 
        // pnlBorrowingForm
        // 
        pnlBorrowingForm.BackColor = Color.White;
        pnlBorrowingForm.Controls.Add(pnlButtons);
        pnlBorrowingForm.Controls.Add(lblPenalite);
        pnlBorrowingForm.Controls.Add(dtpDateRetourReelle);
        pnlBorrowingForm.Controls.Add(lblDateRetourReelle);
        pnlBorrowingForm.Controls.Add(dtpDateRetourPrevue);
        pnlBorrowingForm.Controls.Add(lblDateRetourPrevue);
        pnlBorrowingForm.Controls.Add(dtpDateEmprunt);
        pnlBorrowingForm.Controls.Add(lblDateEmprunt);
        pnlBorrowingForm.Controls.Add(txtEmprunteur);
        pnlBorrowingForm.Controls.Add(lblEmprunteur);
        pnlBorrowingForm.Controls.Add(cmbLivre);
        pnlBorrowingForm.Controls.Add(lblLivre);
        pnlBorrowingForm.Controls.Add(lblFormTitle);
        pnlBorrowingForm.Location = new Point(20, 100);
        pnlBorrowingForm.Name = "pnlBorrowingForm";
        pnlBorrowingForm.Size = new Size(1060, 280);
        pnlBorrowingForm.TabIndex = 1;
        // 
        // pnlButtons
        // 
        pnlButtons.BackColor = Color.Transparent;
        pnlButtons.Location = new Point(20, 215);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(1020, 50);
        pnlButtons.TabIndex = 12;
        // 
        // lblPenalite
        // 
        lblPenalite.AutoSize = true;
        lblPenalite.Font = new Font("Segoe UI", 11.2695656F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblPenalite.ForeColor = Color.FromArgb(230, 57, 70);
        lblPenalite.Location = new Point(800, 163);
        lblPenalite.Name = "lblPenalite";
        lblPenalite.Size = new Size(140, 25);
        lblPenalite.TabIndex = 11;
        lblPenalite.Text = "Pénalité: 0.00 $";
        // 
        // dtpDateRetourReelle
        // 
        dtpDateRetourReelle.Enabled = false;
        dtpDateRetourReelle.Format = DateTimePickerFormat.Short;
        dtpDateRetourReelle.Location = new Point(540, 160);
        dtpDateRetourReelle.Name = "dtpDateRetourReelle";
        dtpDateRetourReelle.Size = new Size(240, 26);
        dtpDateRetourReelle.TabIndex = 10;
        // 
        // lblDateRetourReelle
        // 
        lblDateRetourReelle.AutoSize = true;
        lblDateRetourReelle.ForeColor = Color.FromArgb(26, 26, 26);
        lblDateRetourReelle.Location = new Point(540, 135);
        lblDateRetourReelle.Name = "lblDateRetourReelle";
        lblDateRetourReelle.Size = new Size(147, 20);
        lblDateRetourReelle.TabIndex = 9;
        lblDateRetourReelle.Text = "Date de retour réelle";
        // 
        // dtpDateRetourPrevue
        // 
        dtpDateRetourPrevue.Format = DateTimePickerFormat.Short;
        dtpDateRetourPrevue.Location = new Point(280, 160);
        dtpDateRetourPrevue.Name = "dtpDateRetourPrevue";
        dtpDateRetourPrevue.Size = new Size(240, 26);
        dtpDateRetourPrevue.TabIndex = 8;
        // 
        // lblDateRetourPrevue
        // 
        lblDateRetourPrevue.AutoSize = true;
        lblDateRetourPrevue.ForeColor = Color.FromArgb(26, 26, 26);
        lblDateRetourPrevue.Location = new Point(280, 135);
        lblDateRetourPrevue.Name = "lblDateRetourPrevue";
        lblDateRetourPrevue.Size = new Size(155, 20);
        lblDateRetourPrevue.TabIndex = 7;
        lblDateRetourPrevue.Text = "Date de retour prévue";
        // 
        // dtpDateEmprunt
        // 
        dtpDateEmprunt.Format = DateTimePickerFormat.Short;
        dtpDateEmprunt.Location = new Point(20, 160);
        dtpDateEmprunt.Name = "dtpDateEmprunt";
        dtpDateEmprunt.Size = new Size(240, 26);
        dtpDateEmprunt.TabIndex = 6;
        // 
        // lblDateEmprunt
        // 
        lblDateEmprunt.AutoSize = true;
        lblDateEmprunt.ForeColor = Color.FromArgb(26, 26, 26);
        lblDateEmprunt.Location = new Point(20, 135);
        lblDateEmprunt.Name = "lblDateEmprunt";
        lblDateEmprunt.Size = new Size(113, 20);
        lblDateEmprunt.TabIndex = 5;
        lblDateEmprunt.Text = "Date d'emprunt";
        // 
        // txtEmprunteur
        // 
        txtEmprunteur.Location = new Point(540, 85);
        txtEmprunteur.Name = "txtEmprunteur";
        txtEmprunteur.Size = new Size(470, 26);
        txtEmprunteur.TabIndex = 4;
        // 
        // lblEmprunteur
        // 
        lblEmprunteur.AutoSize = true;
        lblEmprunteur.ForeColor = Color.FromArgb(26, 26, 26);
        lblEmprunteur.Location = new Point(540, 60);
        lblEmprunteur.Name = "lblEmprunteur";
        lblEmprunteur.Size = new Size(151, 20);
        lblEmprunteur.TabIndex = 3;
        lblEmprunteur.Text = "Nom de l'emprunteur";
        // 
        // cmbLivre
        // 
        cmbLivre.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLivre.FormattingEnabled = true;
        cmbLivre.Location = new Point(20, 85);
        cmbLivre.Name = "cmbLivre";
        cmbLivre.Size = new Size(500, 27);
        cmbLivre.TabIndex = 2;
        // 
        // lblLivre
        // 
        lblLivre.AutoSize = true;
        lblLivre.ForeColor = Color.FromArgb(26, 26, 26);
        lblLivre.Location = new Point(20, 60);
        lblLivre.Name = "lblLivre";
        lblLivre.Size = new Size(125, 20);
        lblLivre.TabIndex = 1;
        lblLivre.Text = "Livre à emprunter";
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.ForeColor = Color.FromArgb(0, 120, 212);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(175, 25);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "NOUVEL EMPRUNT";
        // 
        // dgvEmprunts
        // 
        dgvEmprunts.AllowUserToAddRows = false;
        dgvEmprunts.AllowUserToDeleteRows = false;
        dgvEmprunts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvEmprunts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEmprunts.BackgroundColor = Color.White;
        dgvEmprunts.BorderStyle = BorderStyle.None;
        dgvEmprunts.ColumnHeadersHeight = 40;
        dgvEmprunts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvEmprunts.Location = new Point(22, 401);
        dgvEmprunts.MultiSelect = false;
        dgvEmprunts.Name = "dgvEmprunts";
        dgvEmprunts.ReadOnly = true;
        dgvEmprunts.RowHeadersVisible = false;
        dgvEmprunts.RowHeadersWidth = 49;
        dgvEmprunts.RowTemplate.Height = 35;
        dgvEmprunts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEmprunts.Size = new Size(1060, 242);
        dgvEmprunts.TabIndex = 2;
        dgvEmprunts.SelectionChanged += dgvEmprunts_SelectionChanged;
        // 
        // FrmEmprunts
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1082, 655);
        Controls.Add(dgvEmprunts);
        Controls.Add(pnlBorrowingForm);
        Controls.Add(pnlTop);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmEmprunts";
        StartPosition = FormStartPosition.Manual;
        Text = "Gestion des Emprunts";
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlBorrowingForm.ResumeLayout(false);
        pnlBorrowingForm.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEmprunts).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblTitle;
    private Panel pnlBorrowingForm;
    private Label lblFormTitle;
    private Label lblDateRetourPrevue;
    private DateTimePicker dtpDateEmprunt;
    private Label lblDateEmprunt;
    private TextBox txtEmprunteur;
    private Label lblEmprunteur;
    private ComboBox cmbLivre;
    private Label lblLivre;
    private Label lblPenalite;
    private DateTimePicker dtpDateRetourReelle;
    private Label lblDateRetourReelle;
    private DateTimePicker dtpDateRetourPrevue;
    private Panel pnlButtons;
    private DataGridView dgvEmprunts;
}
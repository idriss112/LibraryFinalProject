namespace GestionBibliotheque.UI;

partial class FrmMain
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
        pnlSidebar = new Panel();
        pnlMenuLogout = new Panel();
        lblMenuLogout = new Label();
        pnlMenuEmprunts = new Panel();
        lblMenuEmprunts = new Label();
        pnlMenuAuteurs = new Panel();
        lblMenuAuteurs = new Label();
        pnlMenuLivres = new Panel();
        lblMenuLivres = new Label();
        pnlMenuDashboard = new Panel();
        lblMenuDashboard = new Label();
        lblSidebarLogo = new Label();
        pnlHeader = new Panel();
        lblHeaderTitle = new Label();
        pnlContent = new Panel();
        pnlSidebar.SuspendLayout();
        pnlMenuLogout.SuspendLayout();
        pnlMenuEmprunts.SuspendLayout();
        pnlMenuAuteurs.SuspendLayout();
        pnlMenuLivres.SuspendLayout();
        pnlMenuDashboard.SuspendLayout();
        pnlHeader.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(30, 41, 59);
        pnlSidebar.Controls.Add(pnlMenuLogout);
        pnlSidebar.Controls.Add(pnlMenuEmprunts);
        pnlSidebar.Controls.Add(pnlMenuAuteurs);
        pnlSidebar.Controls.Add(pnlMenuLivres);
        pnlSidebar.Controls.Add(pnlMenuDashboard);
        pnlSidebar.Controls.Add(lblSidebarLogo);
        pnlSidebar.Cursor = Cursors.Hand;
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Font = new Font("Segoe UI", 11.2695656F, FontStyle.Regular, GraphicsUnit.Point, 0);
        pnlSidebar.ForeColor = SystemColors.Window;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(250, 755);
        pnlSidebar.TabIndex = 0;
        // 
        // pnlMenuLogout
        // 
        pnlMenuLogout.BackColor = Color.FromArgb(15, 23, 42);
        pnlMenuLogout.Controls.Add(lblMenuLogout);
        pnlMenuLogout.Dock = DockStyle.Bottom;
        pnlMenuLogout.Location = new Point(0, 705);
        pnlMenuLogout.Name = "pnlMenuLogout";
        pnlMenuLogout.Size = new Size(250, 50);
        pnlMenuLogout.TabIndex = 5;
        // 
        // lblMenuLogout
        // 
        lblMenuLogout.BackColor = Color.Transparent;
        lblMenuLogout.ForeColor = Color.FromArgb(230, 57, 70);
        lblMenuLogout.Location = new Point(0, 0);
        lblMenuLogout.Name = "lblMenuLogout";
        lblMenuLogout.Padding = new Padding(30, 0, 0, 0);
        lblMenuLogout.Size = new Size(250, 50);
        lblMenuLogout.TabIndex = 0;
        lblMenuLogout.Text = "🚪  Déconnexion";
        lblMenuLogout.TextAlign = ContentAlignment.MiddleLeft;
        lblMenuLogout.Click += lblMenuLogout_Click;
        // 
        // pnlMenuEmprunts
        // 
        pnlMenuEmprunts.Controls.Add(lblMenuEmprunts);
        pnlMenuEmprunts.Location = new Point(0, 230);
        pnlMenuEmprunts.Name = "pnlMenuEmprunts";
        pnlMenuEmprunts.Size = new Size(250, 50);
        pnlMenuEmprunts.TabIndex = 4;
        // 
        // lblMenuEmprunts
        // 
        lblMenuEmprunts.BackColor = Color.Transparent;
        lblMenuEmprunts.ForeColor = Color.White;
        lblMenuEmprunts.Location = new Point(0, 0);
        lblMenuEmprunts.Name = "lblMenuEmprunts";
        lblMenuEmprunts.Padding = new Padding(30, 0, 0, 0);
        lblMenuEmprunts.Size = new Size(250, 50);
        lblMenuEmprunts.TabIndex = 0;
        lblMenuEmprunts.Text = "📖  Gérer les Emprunts";
        lblMenuEmprunts.TextAlign = ContentAlignment.MiddleLeft;
        lblMenuEmprunts.Click += lblMenuEmprunts_Click;
        // 
        // pnlMenuAuteurs
        // 
        pnlMenuAuteurs.Controls.Add(lblMenuAuteurs);
        pnlMenuAuteurs.Cursor = Cursors.Hand;
        pnlMenuAuteurs.Location = new Point(0, 180);
        pnlMenuAuteurs.Name = "pnlMenuAuteurs";
        pnlMenuAuteurs.Size = new Size(250, 50);
        pnlMenuAuteurs.TabIndex = 3;
        // 
        // lblMenuAuteurs
        // 
        lblMenuAuteurs.BackColor = Color.Transparent;
        lblMenuAuteurs.Location = new Point(0, 0);
        lblMenuAuteurs.Name = "lblMenuAuteurs";
        lblMenuAuteurs.Padding = new Padding(30, 0, 0, 0);
        lblMenuAuteurs.Size = new Size(250, 50);
        lblMenuAuteurs.TabIndex = 0;
        lblMenuAuteurs.Text = "✍️  Gérer les Auteurs";
        lblMenuAuteurs.TextAlign = ContentAlignment.MiddleLeft;
        lblMenuAuteurs.Click += lblMenuAuteurs_Click;
        // 
        // pnlMenuLivres
        // 
        pnlMenuLivres.Controls.Add(lblMenuLivres);
        pnlMenuLivres.Cursor = Cursors.Hand;
        pnlMenuLivres.Location = new Point(0, 130);
        pnlMenuLivres.Name = "pnlMenuLivres";
        pnlMenuLivres.Size = new Size(250, 50);
        pnlMenuLivres.TabIndex = 2;
        // 
        // lblMenuLivres
        // 
        lblMenuLivres.BackColor = Color.Transparent;
        lblMenuLivres.Location = new Point(0, 0);
        lblMenuLivres.Name = "lblMenuLivres";
        lblMenuLivres.Padding = new Padding(30, 0, 0, 0);
        lblMenuLivres.Size = new Size(250, 50);
        lblMenuLivres.TabIndex = 0;
        lblMenuLivres.Text = "📚  Gérer les Livres";
        lblMenuLivres.TextAlign = ContentAlignment.MiddleLeft;
        lblMenuLivres.Click += lblMenuLivres_Click;
        // 
        // pnlMenuDashboard
        // 
        pnlMenuDashboard.Controls.Add(lblMenuDashboard);
        pnlMenuDashboard.Cursor = Cursors.Hand;
        pnlMenuDashboard.Location = new Point(0, 80);
        pnlMenuDashboard.Name = "pnlMenuDashboard";
        pnlMenuDashboard.Size = new Size(250, 50);
        pnlMenuDashboard.TabIndex = 1;
        // 
        // lblMenuDashboard
        // 
        lblMenuDashboard.BackColor = Color.Transparent;
        lblMenuDashboard.Font = new Font("Segoe UI", 11.2695656F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblMenuDashboard.ForeColor = Color.White;
        lblMenuDashboard.Location = new Point(0, 0);
        lblMenuDashboard.Name = "lblMenuDashboard";
        lblMenuDashboard.Padding = new Padding(30, 0, 0, 0);
        lblMenuDashboard.Size = new Size(250, 50);
        lblMenuDashboard.TabIndex = 0;
        lblMenuDashboard.Text = "📊  Dashboard";
        lblMenuDashboard.TextAlign = ContentAlignment.MiddleLeft;
        lblMenuDashboard.Click += lblMenuDashboard_Click;
        // 
        // lblSidebarLogo
        // 
        lblSidebarLogo.BackColor = Color.FromArgb(15, 23, 42);
        lblSidebarLogo.Font = new Font("Segoe UI", 13.7739134F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSidebarLogo.ForeColor = Color.White;
        lblSidebarLogo.Location = new Point(0, 0);
        lblSidebarLogo.Name = "lblSidebarLogo";
        lblSidebarLogo.Size = new Size(250, 60);
        lblSidebarLogo.TabIndex = 0;
        lblSidebarLogo.Text = "📚 BIBLIOTHÈQUE";
        lblSidebarLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblHeaderTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(250, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1132, 60);
        pnlHeader.TabIndex = 1;
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.Font = new Font("Segoe UI", 13.7739134F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblHeaderTitle.ForeColor = Color.FromArgb(26, 26, 26);
        lblHeaderTitle.Location = new Point(20, 0);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(400, 60);
        lblHeaderTitle.TabIndex = 1;
        lblHeaderTitle.Text = "Bienvenue, Administrateur";
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContent
        // 
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(250, 60);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(20);
        pnlContent.Size = new Size(1132, 695);
        pnlContent.TabIndex = 2;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1382, 755);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        MinimumSize = new Size(1200, 700);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bibliothèque - Système de Gestion";
        WindowState = FormWindowState.Maximized;
        pnlSidebar.ResumeLayout(false);
        pnlMenuLogout.ResumeLayout(false);
        pnlMenuEmprunts.ResumeLayout(false);
        pnlMenuAuteurs.ResumeLayout(false);
        pnlMenuLivres.ResumeLayout(false);
        pnlMenuDashboard.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlSidebar;
    private Panel pnlHeader;
    private Panel pnlContent;
    private Label lblSidebarLogo;
    private Label lblHeaderTitle;
    private Panel pnlMenuDashboard;
    private Label lblMenuDashboard;
    private Panel pnlMenuLivres;
    private Label lblMenuLivres;
    private Panel pnlMenuAuteurs;
    private Label lblMenuAuteurs;
    private Panel pnlMenuEmprunts;
    private Label lblMenuEmprunts;
    private Panel pnlMenuLogout;
    private Label lblMenuLogout;
}
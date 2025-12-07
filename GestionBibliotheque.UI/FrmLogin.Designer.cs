namespace GestionBibliotheque.UI;

partial class FrmLogin
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
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblError = new Label();
        btnLogin = new GestionBibliotheque.UI.CustomControls.RoundedButton();
        btnTogglePassword = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 23.7913036F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.FromArgb(0, 120, 212);
        lblTitle.Location = new Point(50, 80);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(287, 51);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "BIBLIOTHÈQUE";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
        lblSubtitle.Location = new Point(50, 130);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(185, 25);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Système de Gestion";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblUsername.ForeColor = Color.FromArgb(26, 26, 26);
        lblUsername.Location = new Point(75, 200);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(123, 20);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Nom d'utilisateur";
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtUsername.Location = new Point(75, 225);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(350, 29);
        txtUsername.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI", 8.765218F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPassword.ForeColor = Color.FromArgb(26, 26, 26);
        lblPassword.Location = new Point(75, 285);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(98, 20);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "Mot de passe";
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Segoe UI", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPassword.Location = new Point(75, 310);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(300, 29);
        txtPassword.TabIndex = 5;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 13.7739134F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblError.ForeColor = Color.FromArgb(230, 57, 70);
        lblError.Location = new Point(75, 365);
        lblError.Name = "lblError";
        lblError.Size = new Size(350, 30);
        lblError.TabIndex = 6;
        lblError.TextAlign = ContentAlignment.MiddleCenter;
        lblError.Visible = false;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(0, 120, 212);
        btnLogin.BorderColor = Color.FromArgb(0, 120, 212);
        btnLogin.BorderRadius = 8;
        btnLogin.BorderThickness = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.HoverBackColor = Color.FromArgb(0, 90, 158);
        btnLogin.Location = new Point(75, 410);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(350, 45);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "SE CONNECTER";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += BtnLogin_Click;
        // 
        // btnTogglePassword
        // 
        btnTogglePassword.BackColor = SystemColors.Window;
        btnTogglePassword.Cursor = Cursors.Hand;
        btnTogglePassword.FlatAppearance.BorderSize = 0;
        btnTogglePassword.FlatStyle = FlatStyle.Flat;
        btnTogglePassword.Location = new Point(390, 310);
        btnTogglePassword.Name = "btnTogglePassword";
        btnTogglePassword.Size = new Size(35, 29);
        btnTogglePassword.TabIndex = 7;
        btnTogglePassword.TabStop = false;
        btnTogglePassword.Text = "👁";
        btnTogglePassword.UseVisualStyleBackColor = false;
        btnTogglePassword.Click += btnTogglePassword_Click;
        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(482, 555);
        Controls.Add(btnTogglePassword);
        Controls.Add(lblError);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblUsername);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        Controls.Add(btnLogin);
        ForeColor = Color.FromArgb(26, 26, 26);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Location = new Point(75, 310);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Connexion - Bibliothèque";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblError;
    private Button btnTogglePassword;
}
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

public partial class FrmLogin : Form
{
    // Custom rounded button for login
    private CustomControls.RoundedButton btnLogin;
    public FrmLogin()
    {
        InitializeComponent();
        ConfigurePasswordToggle();

        this.AcceptButton = btnLogin;
    }

    // ===== LOGIN BUTTON CLICK EVENT =====
    private void BtnLogin_Click(object sender, EventArgs e)
    {
        // Hide any previous error
        lblError.Visible = false;

        // Get username and password
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Validate inputs
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("Veuillez remplir tous les champs.");
            return;
        }

        // Check credentials (simple hardcoded authentication)
        if (username == "admin" && password == "admin")
        {
            // Login successful - open main dashboard
            this.Hide();  // Hide login form
            FrmMain mainForm = new FrmMain();
            mainForm.ShowDialog();  // Show main form
            this.Close();  // Close login when main form closes
        }
        else
        {
            ShowError("Nom d'utilisateur ou mot de passe incorrect.");
        }
    }

    // ===== HELPER METHOD TO SHOW ERRORS =====
    private void ShowError(string message)
    {
        lblError.Text = message;
        lblError.Visible = true;
    }

    private void btnTogglePassword_Click(object sender, EventArgs e)
    {
        // Toggle password visibility
        if (txtPassword.PasswordChar == '●')
        {
            // Show password
            txtPassword.PasswordChar = '\0';  // \0 means no masking character
            btnTogglePassword.Text = "👁‍🗨";  // Eye with slash (showing)
        }
        else
        {
            // Hide password
            txtPassword.PasswordChar = '●';
            btnTogglePassword.Text = "👁";  // Regular eye (hidden)
        }
    }

    // ===== CONFIGURE PASSWORD TOGGLE BUTTON =====
    private void ConfigurePasswordToggle()
    {
        // Set initial state
        txtPassword.PasswordChar = '●';
        btnTogglePassword.Text = "👁";

        // Add hover effects
        btnTogglePassword.MouseEnter += (s, e) =>
        {
            btnTogglePassword.BackColor = UIHelpers.UIColors.PrimaryLight;
        };

        btnTogglePassword.MouseLeave += (s, e) =>
        {
            btnTogglePassword.BackColor = System.Drawing.Color.White;
        };
    }
}

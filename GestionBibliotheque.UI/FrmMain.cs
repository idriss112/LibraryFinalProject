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

public partial class FrmMain : Form
{
     // Track the currently selected menu panel
        private Panel currentSelectedMenu;

    private BookManager _bookManager;
    private AuthorManager _authorManager;
    private BorrowingManager _borrowingManager;
    public FrmMain()
    {
        _bookManager = new BookManager();
        _authorManager = new AuthorManager();
        _borrowingManager = new BorrowingManager();


        InitializeComponent();

        // Initialize menu system
        SetupMenuSystem();

        // Select Dashboard by default
        SelectMenu(pnlMenuDashboard);

        LoadDashboard();
    }

    // ===== SETUP MENU SYSTEM =====
    private void SetupMenuSystem()
    {
        // Dashboard Menu
        SetupMenuItem(pnlMenuDashboard, lblMenuDashboard, OnDashboardClick);

        // Livres Menu
        SetupMenuItem(pnlMenuLivres, lblMenuLivres, OnLivresClick);

        // Auteurs Menu
        SetupMenuItem(pnlMenuAuteurs, lblMenuAuteurs, OnAuteursClick);

        // Emprunts Menu
        SetupMenuItem(pnlMenuEmprunts, lblMenuEmprunts, OnEmpruntsClick);

        // Logout Menu
        SetupMenuItem(pnlMenuLogout, lblMenuLogout, OnLogoutClick);
    }

    // ===== SETUP INDIVIDUAL MENU ITEM =====
    private void SetupMenuItem(Panel panel, Label label, EventHandler clickHandler)
    {
        // Add click event to both panel and label
        panel.Click += clickHandler;
        label.Click += clickHandler;

        // Hover effect - Panel
        panel.MouseEnter += (s, e) =>
        {
            if (currentSelectedMenu != panel)
            {
                panel.BackColor = UIHelpers.UIColors.SidebarHover;
            }
        };

        panel.MouseLeave += (s, e) =>
        {
            if (currentSelectedMenu != panel)
            {
                // Special color for logout
                if (panel == pnlMenuLogout)
                    panel.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F172A");
                else
                    panel.BackColor = UIHelpers.UIColors.SidebarDark;
            }
        };

        // Hover effect - Label (must also change parent panel)
        label.MouseEnter += (s, e) =>
        {
            if (currentSelectedMenu != panel)
            {
                panel.BackColor = UIHelpers.UIColors.SidebarHover;
            }
        };

        label.MouseLeave += (s, e) =>
        {
            if (currentSelectedMenu != panel)
            {
                // Special color for logout
                if (panel == pnlMenuLogout)
                    panel.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F172A");
                else
                    panel.BackColor = UIHelpers.UIColors.SidebarDark;
            }
        };
    }

    // ===== SELECT MENU (HIGHLIGHT CURRENT SELECTION) =====
    private void SelectMenu(Panel selectedPanel)
    {
        // Reset previous selection
        if (currentSelectedMenu != null)
        {
            if (currentSelectedMenu == pnlMenuLogout)
                currentSelectedMenu.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F172A");
            else
                currentSelectedMenu.BackColor = UIHelpers.UIColors.SidebarDark;
        }

        // Highlight new selection (except logout)
        if (selectedPanel != pnlMenuLogout)
        {
            selectedPanel.BackColor = UIHelpers.UIColors.Primary;
            currentSelectedMenu = selectedPanel;
        }
    }

    // ===== MENU CLICK HANDLERS =====

    private void OnDashboardClick(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuDashboard);
        LoadDashboard();
    }

    private void OnLivresClick(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuLivres);
        LoadLivresForm();
    }

    private void OnAuteursClick(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuAuteurs);
        LoadAuteursForm();
    }

    private void OnEmpruntsClick(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuEmprunts);
        LoadEmpruntsForm();
    }

    private void OnLogoutClick(object sender, EventArgs e)
    {
        // Confirm logout
        var result = MessageBox.Show(
            "Êtes-vous sûr de vouloir vous déconnecter?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Close this form and show login
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.ShowDialog();
            this.Close();
        }
    }

    // ===== MENU CLICK HANDLERS =====

    private void lblMenuDashboard_Click(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuDashboard);
        LoadDashboard();
    }

    private void lblMenuLivres_Click(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuLivres);
        LoadLivresForm();
    }

    private void lblMenuAuteurs_Click(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuAuteurs);
        LoadAuteursForm();
    }

    private void lblMenuEmprunts_Click(object sender, EventArgs e)
    {
        SelectMenu(pnlMenuEmprunts);
        LoadEmpruntsForm();
    }

    private void lblMenuLogout_Click(object sender, EventArgs e)
    {
        // Confirm logout
        var result = MessageBox.Show(
            "Êtes-vous sûr de vouloir vous déconnecter?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Close this form and show login
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.ShowDialog();
            this.Close();
        }
    }

    // ===== LOAD CONTENT METHODS =====

    private void LoadDashboard()
    {
        // Clear content area
        pnlContent.Controls.Clear();

        // Get statistics
        int totalBooks = _bookManager.GetAllBooks().Count;
        int availableBooks = _bookManager.GetAvailableBooks().Count;
        int totalAuthors = _authorManager.GetAllAuthors().Count;
        int activeBorrowings = _borrowingManager.GetActiveBorrowings().Count;

        // Create welcome panel
        var pnlWelcome = new CustomControls.RoundedPanel
        {
            Size = new Size(600, 400),
            Location = new Point(50, 50),
            BackColor = UIHelpers.UIColors.Surface,
            BorderRadius = UIHelpers.UIMetrics.PanelRadius
        };

        // Title
        var lblTitle = new Label
        {
            Text = "📊 TABLEAU DE BORD",
            Font = UIHelpers.UIFonts.FormTitle,
            ForeColor = UIHelpers.UIColors.Primary,
            AutoSize = false,
            Size = new Size(550, 50),
            Location = new Point(25, 25),
            TextAlign = ContentAlignment.MiddleCenter
        };

        // Statistics
        var lblStats = new Label
        {
            Text = $"📚 Total de livres: {totalBooks}\n\n" +
                   $"✅ Livres disponibles: {availableBooks}\n\n" +
                   $"✍️ Total d'auteurs: {totalAuthors}\n\n" +
                   $"📖 Emprunts actifs: {activeBorrowings}\n\n" +
                   $"━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                   $"Bienvenue dans le système de\n" +
                   $"gestion de bibliothèque!",
            Font = UIHelpers.UIFonts.SectionHeader,
            ForeColor = UIHelpers.UIColors.TextPrimary,
            AutoSize = false,
            Size = new Size(550, 300),
            Location = new Point(25, 100),
            TextAlign = ContentAlignment.TopLeft
        };

        pnlWelcome.Controls.Add(lblTitle);
        pnlWelcome.Controls.Add(lblStats);
        pnlContent.Controls.Add(pnlWelcome);
    }

    private void LoadLivresForm()
    {
        // Clear content area
        pnlContent.Controls.Clear();

        // Create and display the Books form
        FrmBooks frmBooks = new FrmBooks
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        pnlContent.Controls.Add(frmBooks);
        frmBooks.Show();
    }

    private void LoadAuteursForm()
    {
        // Clear content area
        pnlContent.Controls.Clear();

        // Create and display the Authors form
        FrmAuteurs frmAuteurs = new FrmAuteurs
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        pnlContent.Controls.Add(frmAuteurs);
        frmAuteurs.Show();
    }

    private void LoadEmpruntsForm()
    {
        // Clear content area
        pnlContent.Controls.Clear();

        // Create and display the Borrowings form
        FrmEmprunts frmEmprunts = new FrmEmprunts
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        pnlContent.Controls.Add(frmEmprunts);
        frmEmprunts.Show();
    }


}

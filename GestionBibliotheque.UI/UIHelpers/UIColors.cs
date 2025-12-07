using System.Drawing;

namespace GestionBibliotheque.UI.UIHelpers
{
    /// <summary>
    /// Centralized color palette for the entire application
    /// Modern Windows 2026 Design System
    /// </summary>
    public static class UIColors
    {
        // ===== PRIMARY COLORS =====
        public static readonly Color Primary = ColorTranslator.FromHtml("#0078D4");
        public static readonly Color PrimaryDark = ColorTranslator.FromHtml("#005A9E");
        public static readonly Color PrimaryLight = ColorTranslator.FromHtml("#E3F2FD");

        // ===== ACCENT COLORS =====
        public static readonly Color AccentGreen = ColorTranslator.FromHtml("#16C79A");
        public static readonly Color AccentOrange = ColorTranslator.FromHtml("#FF9800");
        public static readonly Color AccentRed = ColorTranslator.FromHtml("#E63946");

        // ===== NEUTRAL COLORS =====
        public static readonly Color Background = ColorTranslator.FromHtml("#F5F7FA");
        public static readonly Color Surface = ColorTranslator.FromHtml("#FFFFFF");
        public static readonly Color Border = ColorTranslator.FromHtml("#E0E0E0");
        public static readonly Color TextPrimary = ColorTranslator.FromHtml("#1A1A1A");
        public static readonly Color TextSecondary = ColorTranslator.FromHtml("#6B7280");

        // ===== SIDEBAR COLORS =====
        public static readonly Color SidebarDark = ColorTranslator.FromHtml("#1E293B");
        public static readonly Color SidebarHover = ColorTranslator.FromHtml("#334155");

        // ===== SEMANTIC COLORS =====
        public static readonly Color Success = AccentGreen;
        public static readonly Color Warning = AccentOrange;
        public static readonly Color Error = AccentRed;
    }
}
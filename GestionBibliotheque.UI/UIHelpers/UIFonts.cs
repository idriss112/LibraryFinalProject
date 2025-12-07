using System.Drawing;

namespace GestionBibliotheque.UI.UIHelpers
{
    /// <summary>
    /// Centralized font system for the entire application
    /// Modern Windows 2026 Typography
    /// </summary>
    public static class UIFonts
    {
        // Base font family
        private const string FontFamily = "Segoe UI";

        // ===== FONT DEFINITIONS =====
        public static readonly Font FormTitle = new Font(FontFamily, 24F, FontStyle.Bold);
        public static readonly Font SectionHeader = new Font(FontFamily, 16F, FontStyle.Bold);
        public static readonly Font ButtonText = new Font(FontFamily, 10F, FontStyle.Bold);
        public static readonly Font BodyText = new Font(FontFamily, 9F, FontStyle.Regular);
        public static readonly Font Label = new Font(FontFamily, 9F, FontStyle.Regular);
        public static readonly Font InputText = new Font(FontFamily, 9F, FontStyle.Regular);
        public static readonly Font SmallText = new Font(FontFamily, 8F, FontStyle.Regular);
    }
}
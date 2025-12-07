using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GestionBibliotheque.UI.UIHelpers;

namespace GestionBibliotheque.UI.CustomControls
{
    /// <summary>
    /// Modern rounded panel with shadow support
    /// </summary>
    public class RoundedPanel : Panel
    {
        // Properties for customization
        private int borderRadius = UIMetrics.PanelRadius;
        private Color borderColor = UIColors.Border;
        private int borderThickness = 1;
        private bool hasShadow = false;

        // ===== PUBLIC PROPERTIES =====
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public int BorderThickness
        {
            get => borderThickness;
            set { borderThickness = value; Invalidate(); }
        }

        public bool HasShadow
        {
            get => hasShadow;
            set { hasShadow = value; Invalidate(); }
        }

        // ===== CONSTRUCTOR =====
        public RoundedPanel()
        {
            // Set default modern styling
            this.BackColor = UIColors.Surface;
            this.Padding = new Padding(UIMetrics.CardPadding);

            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        // ===== CUSTOM PAINTING =====
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the rounded rectangle path
            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetRoundedRectangle(bounds, borderRadius);

            // Fill the panel background
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                graphics.FillPath(brush, path);
            }

            // Draw shadow if enabled
            if (hasShadow)
            {
                DrawShadow(graphics, bounds);
            }

            // Draw border if thickness > 0
            if (borderThickness > 0)
            {
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    graphics.DrawPath(pen, path);
                }
            }
        }

        // ===== HELPER METHOD: CREATE ROUNDED RECTANGLE =====
        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // Top-left corner
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            // Bottom-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            // Bottom-left corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }

        // ===== HELPER METHOD: DRAW SHADOW =====
        private void DrawShadow(Graphics graphics, Rectangle bounds)
        {
            // Simple shadow effect (you can enhance this)
            using (GraphicsPath shadowPath = GetRoundedRectangle(
                new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height),
                borderRadius))
            {
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(50, 0, 0, 0);
                    shadowBrush.SurroundColors = new[] { Color.FromArgb(0, 0, 0, 0) };
                    graphics.FillPath(shadowBrush, shadowPath);
                }
            }
        }

        // Override region to match rounded shape
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, Width - 1, Height - 1), borderRadius))
            {
                this.Region = new Region(path);
            }
        }
    }
}

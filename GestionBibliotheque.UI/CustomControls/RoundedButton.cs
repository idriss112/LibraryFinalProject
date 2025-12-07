using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GestionBibliotheque.UI.UIHelpers;

namespace GestionBibliotheque.UI.CustomControls
{
    /// <summary>
    /// Modern rounded button with hover effects
    /// </summary>
    public class RoundedButton : Button
    {
        // Properties for customization
        private int borderRadius = UIMetrics.ButtonRadius;
        private Color borderColor = UIColors.Primary;
        private int borderThickness = 0;
        private Color hoverBackColor = UIColors.PrimaryDark;
        private bool isHovering = false;

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

        public Color HoverBackColor
        {
            get => hoverBackColor;
            set => hoverBackColor = value;
        }

        // ===== CONSTRUCTOR =====
        public RoundedButton()
        {
            // Set default modern styling
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = UIColors.Primary;
            this.ForeColor = Color.White;
            this.Font = UIFonts.ButtonText;
            this.Cursor = Cursors.Hand;
            this.Size = new Size(120, UIMetrics.ButtonHeight);

            // Remove default focus rectangle
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        // ===== CUSTOM PAINTING =====
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the rounded rectangle path
            GraphicsPath path = GetRoundedRectangle(ClientRectangle, borderRadius);

            // Determine background color (hover or normal)
            Color currentBackColor = isHovering ? hoverBackColor : BackColor;

            // Fill the button background
            using (SolidBrush brush = new SolidBrush(currentBackColor))
            {
                graphics.FillPath(brush, path);
            }

            // Draw border if needed
            if (borderThickness > 0)
            {
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    graphics.DrawPath(pen, path);
                }
            }

            // Draw the text
            TextRenderer.DrawText(
                graphics,
                Text,
                Font,
                ClientRectangle,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        // ===== HOVER EFFECTS =====
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovering = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovering = false;
            Invalidate();
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

        // Override region to match rounded shape
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (GraphicsPath path = GetRoundedRectangle(ClientRectangle, borderRadius))
            {
                this.Region = new Region(path);
            }
        }
    }
}
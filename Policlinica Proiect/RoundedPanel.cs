namespace Policlinica_Proiect
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public int BorderSize { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Black;
        public Color ShadowColor { get; set; } = Color.Black;
        public int ShadowOffset { get; set; } = 5;  // Distanța umbrei

        public RoundedPanel()
        {
            this.BackColor = Color.FromArgb(30, Color.White); // Transparentă pentru panel
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Desenăm umbra
            Rectangle shadowRect = new Rectangle(
                ShadowOffset,
                ShadowOffset,
                this.Width - 1 - ShadowOffset,
                this.Height - 1 - ShadowOffset
            );
            using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, BorderRadius))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, ShadowColor)))  // Umbra semi-transparentă
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Desenăm panelul propriu-zis (mai mic pentru a lăsa umbra vizibilă)
            Rectangle panelRect = new Rectangle(
                0,
                0,
                this.Width - ShadowOffset,
                this.Height - ShadowOffset
            );
            using (GraphicsPath panelPath = GetRoundedRectanglePath(panelRect, BorderRadius))
            using (SolidBrush panelBrush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(panelBrush, panelPath);
            }

            // Desenăm bordura
            using (GraphicsPath panelPath = GetRoundedRectanglePath(panelRect, BorderRadius))
            using (Pen borderPen = new Pen(BorderColor, BorderSize))
            {
                e.Graphics.DrawPath(borderPen, panelPath);
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 20;
    public int BorderSize { get; set; } = 2;
    public Color BorderColor { get; set; } = Color.Black;
    public Color ShadowColor { get; set; } = Color.Gray;
    public int ShadowSize { get; set; } = 5;

    public RoundedPanel()
    {
        this.BackColor = Color.FromArgb(180, Color.White); // Semi-transparent alb
        this.SetStyle(ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Desenăm umbra
        Rectangle shadowRect = new Rectangle(ShadowSize, ShadowSize, this.Width - ShadowSize, this.Height - ShadowSize);
        using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, BorderRadius))
        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, ShadowColor)))
        {
            e.Graphics.FillPath(shadowBrush, shadowPath);
        }

        // Desenăm panelul propriu-zis
        Rectangle rect = new Rectangle(0, 0, this.Width - ShadowSize, this.Height - ShadowSize);
        using (GraphicsPath path = GetRoundedRectanglePath(rect, BorderRadius))
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillPath(brush, path);
        }

        // Desenăm bordura
        using (GraphicsPath path = GetRoundedRectanglePath(rect, BorderRadius))
        using (Pen pen = new Pen(BorderColor, BorderSize))
        {
            e.Graphics.DrawPath(pen, path);
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

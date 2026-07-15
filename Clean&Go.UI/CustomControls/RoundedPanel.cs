using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.CustomControls
{
    public class RoundedPanel : Panel
    {
        private int _borderRadius = 20;
        private Color _gradientStart = Color.FromArgb(8, 145, 178);
        private Color _gradientEnd = Color.FromArgb(20, 184, 166);
        private float _gradientAngle = 135f;
        private bool _useGradient = false;
        private Color _borderColor = Color.Transparent;
        private int _borderWidth = 0;

        [Category("Apariencia Custom")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color GradientColorStart
        {
            get => _gradientStart;
            set { _gradientStart = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color GradientColorEnd
        {
            get => _gradientEnd;
            set { _gradientEnd = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public bool UseGradient
        {
            get => _useGradient;
            set { _useGradient = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color CustomBorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public int CustomBorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = GetRoundedPath(rect, _borderRadius))
            {
                Region = new Region(path);

                if (_useGradient)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect, _gradientStart, _gradientEnd, _gradientAngle))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                if (_borderWidth > 0 && _borderColor != Color.Transparent)
                {
                    using (Pen pen = new Pen(_borderColor, _borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}

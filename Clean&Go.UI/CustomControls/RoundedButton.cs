using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.CustomControls
{
    public class RoundedButton : Control
    {
        private int _borderRadius = 12;
        private Color _gradientStart = Color.FromArgb(8, 145, 178);
        private Color _gradientEnd = Color.FromArgb(14, 116, 144);
        private Color _hoverGradientStart = Color.FromArgb(14, 116, 144);
        private Color _hoverGradientEnd = Color.FromArgb(8, 95, 120);
        private Color _pressedColor = Color.FromArgb(6, 82, 105);
        private float _gradientAngle = 90f;
        private bool _isHovering = false;
        private bool _isPressed = false;

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
        public Color HoverGradientStart
        {
            get => _hoverGradientStart;
            set { _hoverGradientStart = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color HoverGradientEnd
        {
            get => _hoverGradientEnd;
            set { _hoverGradientEnd = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color PressedColor
        {
            get => _pressedColor;
            set { _pressedColor = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; Invalidate(); }
        }

        public RoundedButton()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            Size = new Size(300, 48);
            Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(d, d));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundedPath(rect, _borderRadius))
            {
                Region = new Region(path);

                if (_isPressed)
                {
                    using (SolidBrush brush = new SolidBrush(_pressedColor))
                        e.Graphics.FillPath(brush, path);
                }
                else
                {
                    Color start = _isHovering ? _hoverGradientStart : _gradientStart;
                    Color end = _isHovering ? _hoverGradientEnd : _gradientEnd;

                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect, start, end, _gradientAngle))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                using (SolidBrush textBrush = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Text, Font, textBrush, rect, sf);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovering = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovering = false;
            _isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }
    }
}

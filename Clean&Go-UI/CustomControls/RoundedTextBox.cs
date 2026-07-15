using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.CustomControls
{
    public class RoundedTextBox : UserControl
    {
        private TextBox _textBox;
        private int _borderRadius = 12;
        private Color _borderColor = Color.FromArgb(226, 232, 240);
        private Color _borderColorFocus = Color.FromArgb(8, 145, 178);
        private Color _borderColorError = Color.FromArgb(239, 68, 68);
        private string _placeholderText = "";
        private Color _placeholderColor = Color.FromArgb(148, 163, 184);
        private string _iconText = "";
        private bool _isPassword = false;
        private bool _isFocused = false;
        private bool _hasError = false;
        private Font _iconFont;

        [Category("Apariencia Custom")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color BorderColorNormal
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color BorderColorFocus
        {
            get => _borderColorFocus;
            set { _borderColorFocus = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color BorderColorError
        {
            get => _borderColorError;
            set { _borderColorError = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set { _placeholderText = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public Color PlaceholderColor
        {
            get => _placeholderColor;
            set { _placeholderColor = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public string IconText
        {
            get => _iconText;
            set { _iconText = value; Invalidate(); }
        }

        [Category("Apariencia Custom")]
        public bool IsPassword
        {
            get => _isPassword;
            set
            {
                _isPassword = value;
                _textBox.UseSystemPasswordChar = value;
            }
        }

        [Category("Apariencia Custom")]
        public bool HasError
        {
            get => _hasError;
            set { _hasError = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Apariencia Custom")]
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public TextBox InnerTextBox => _textBox;

        public RoundedTextBox()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Size = new Size(300, 48);
            BackColor = Color.FromArgb(241, 245, 249);
            Padding = new Padding(40, 0, 15, 0);

            _iconFont = new Font("Segoe UI", 14f, FontStyle.Regular);

            _textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(30, 41, 59),
                Font = new Font("Segoe UI", 11f),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };

            _textBox.GotFocus += (s, e) => { _isFocused = true; Invalidate(); };
            _textBox.LostFocus += (s, e) => { _isFocused = false; Invalidate(); };
            _textBox.TextChanged += (s, e) => { Invalidate(); OnTextChanged(e); };

            Controls.Add(_textBox);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_textBox != null)
            {
                int iconSpace = string.IsNullOrEmpty(_iconText) ? 15 : 42;
                _textBox.Location = new Point(iconSpace, (Height - _textBox.Height) / 2);
                _textBox.Width = Width - iconSpace - 15;
            }
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

                using (SolidBrush bg = new SolidBrush(BackColor))
                    e.Graphics.FillPath(bg, path);

                Color borderC = _hasError ? _borderColorError :
                                _isFocused ? _borderColorFocus : _borderColor;
                float borderW = _isFocused || _hasError ? 2f : 1f;

                using (Pen pen = new Pen(borderC, borderW))
                    e.Graphics.DrawPath(pen, path);
            }

            // Dibujar ícono
            if (!string.IsNullOrEmpty(_iconText))
            {
                Color iconColor = _isFocused ? _borderColorFocus : _placeholderColor;
                using (SolidBrush brush = new SolidBrush(iconColor))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    Rectangle iconRect = new Rectangle(8, 0, 30, Height);
                    e.Graphics.DrawString(_iconText, _iconFont, brush, iconRect, sf);
                }
            }

            // Dibujar placeholder
            if (string.IsNullOrEmpty(_textBox.Text) && !_isFocused && !string.IsNullOrEmpty(_placeholderText))
            {
                int iconSpace = string.IsNullOrEmpty(_iconText) ? 15 : 42;
                using (SolidBrush brush = new SolidBrush(_placeholderColor))
                {
                    StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                    Rectangle phRect = new Rectangle(iconSpace, 0, Width - iconSpace - 15, Height);
                    e.Graphics.DrawString(_placeholderText, _textBox.Font, brush, phRect, sf);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _iconFont?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

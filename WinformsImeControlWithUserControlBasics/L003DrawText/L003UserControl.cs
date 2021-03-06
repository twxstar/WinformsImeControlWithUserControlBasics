﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformsImeControlWithUserControlBasics.L003DrawText {
    public partial class L003UserControl : UserControl {
        public L003UserControl() {
            InitializeComponent();
            InitControl();
        }

        protected override bool CanEnableIme {
            #region L001
            get {
                return true;
            }
            #endregion
        }

        public event EventHandler OnTextChange;  // L002

        protected virtual void InitControl() {
            #region L001
            this.Height = 40;
            this.Width = 450;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            #endregion
        }

        protected override Size DefaultSize {
            #region L001
            get {
                return new Size(450, 40);
            }
            #endregion
        }

        public override string Text {
            #region L002
            get {
                return base.Text;
            }
            set {
                base.Text = value;
                if (OnTextChange != null) {
                    OnTextChange(this, new EventArgs());
                }
            }
            #endregion
        }

        protected override void WndProc(ref Message m) {
            IntPtr hIMC = IntPtr.Zero;
            switch (m.Msg) {
                case Native.WM_CHAR:
                    hIMC = Native.ImmGetContext(this.Handle);
                    if (Native.ImmGetOpenStatus(hIMC)) {
                        char chr = Convert.ToChar(m.WParam.ToInt64() & 0xffff);

                        if (m.WParam.ToInt64() >= 32) {
                            string str = chr.ToString();
                            this.Text += str;
                        }
                    }
                    Native.ImmReleaseContext(this.Handle, hIMC);
                    Invalidate();  // L003 Add this Line.
                    break;
            }
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.DrawString(Text, this.Font, new Pen(ForeColor).Brush, new PointF(2, 2));

        }
    }
}

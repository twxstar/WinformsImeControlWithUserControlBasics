﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformsImeControlWithUserControlBasics.L001OverrideCanEnableIme {
    public partial class L001UserControl : UserControl {
        public L001UserControl() {
            InitializeComponent();
            InitControl();
        }

        protected override bool CanEnableIme {
            get {
                return true;
            }
        }

        protected virtual void InitControl() {
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        }
        
        protected override Size DefaultSize {
            get {
                return new Size(450, 40);
            }
        }
        
    }
}

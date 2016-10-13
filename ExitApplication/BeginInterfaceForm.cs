using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExitApplication
{
    public partial class BeginInterfaceForm : Form
    {
        public BeginInterfaceForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void BeginInterface_Load(object sender, EventArgs e)
        {

        }
    }
}

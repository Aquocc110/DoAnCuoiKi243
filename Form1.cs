using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnCuoiKi242
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDNGV open = new frmDNGV();
            this.Hide();
            open.Show();
            

        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            frmDNSV open = new frmDNSV();
            this.Hide();
            open.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tắtỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}

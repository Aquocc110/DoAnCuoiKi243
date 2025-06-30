using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class xemTTGV : Form
    {
        private GiangVien giangVien;
        public xemTTGV(GiangVien gv)
        {
            InitializeComponent();
            this.giangVien= gv;
        }

        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void xemTTGV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiSinhVien1_DoAnCuoiKi242DataSet.GiangVien' table. You can move, or remove it, as needed.
            this.giangVienTableAdapter.Fill(this.quanLiSinhVien1_DoAnCuoiKi242DataSet.GiangVien);
            
        }

        private void ngaySinhDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
                    }

        private void maMHTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

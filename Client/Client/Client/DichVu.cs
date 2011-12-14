using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class DichVu : Form
    {
        public DichVu()
        {
            InitializeComponent();
        }
        private void tìmĐịaĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimDiaDiem tdd = new TimDiaDiem();
            tdd.MdiParent = this;
            tdd.Show();
        }
        private void DichVu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void đăngBàiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThongTinNHCF db = new ThongTinNHCF();
            db.MdiParent = this;
            db.Show();
        }

        private void cậpNhậtBàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangThucDon dtd = new DangThucDon();
            dtd.MdiParent = this;
            dtd.Show();
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKhuyenMai dkm = new DangKhuyenMai();
            dkm.MdiParent = this;
            dkm.Show();
        }

        private void tìmKhôngGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKhongGian tkg = new TimKhongGian();
            tkg.MdiParent = this;
            tkg.Show();
        }

        private void tìmMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimMonAn tma = new TimMonAn();
            tma.MdiParent = this;
            tma.Show();
        }

        private void tìmNhuCầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimNhuCau tnc = new TimNhuCau();
            tnc.MdiParent = this;
            tnc.Show();
        }

        private void tìmGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimGia tg = new TimGia();
            tg.MdiParent = this;
            tg.Show();
        }

        private void tìmKhuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKhuyenMai tkm = new TimKhuyenMai();
            tkm.MdiParent = this;
            tkm.Show();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia tgia = new TacGia();
            tgia.MdiParent = this;
            tgia.Show();
        }
    }
}

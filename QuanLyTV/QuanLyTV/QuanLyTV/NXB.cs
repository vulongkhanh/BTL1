using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTV
{
    public partial class NXB : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public NXB()
        {
            InitializeComponent();
            dtNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            sql = "SELECT idNXB, TenNXB,NgayNhap,SoBan,GiaSach,SoÐT,ÐiaChi  FROM NXB  WHERE idNXB = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtNXB.DataSource = dt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dtNXB.Enabled = true;
            txtTim.Text = "";
            dtNXB.CurrentCell = dtNXB[0, 0];
            dtNXB_SelectionChanged(sender, e);
            sql = "SELECT * FROM NXB";
            HienThi(sql);
        }

        private void NXB_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idNXB AS 'idNXB', TenNXB AS 'TenN',NgayNhap AS 'NgayNhap',SoBan AS 'SoBan',GiaSach AS 'GiaSach',SoDT AS 'SoDT',DiaChi AS 'DiaChi' FROM NXB";
                HienThi(sql);





            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void NXB_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        #region [ các hàm dùng chung cho tất cả các FORM]
        private void TrangThaiButton(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnReset.Enabled = !b;
        }
        private void ClearTXT()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtsoban.Text = "";
            txtgia.Text = "";
            txtdt.Text = "";
            txtdiachi.Text = "";
            dtpnhap.Text = "";

        }
        private void TrangThaiTXT(bool b)
        {
            txtMa.Enabled = b;
            txtTen.Enabled = b;
            txtsoban.Enabled = b;
            txtgia.Enabled = b;
            txtdt.Enabled = b;
            txtdiachi.Enabled = b;
            dtpnhap.Enabled = b;
            txtTim.Enabled = b;


        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtNXB.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraTrungDL(string sql)
        {
            bool bKiemtra = false;
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bKiemtra = true;
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return bKiemtra;
        }
        private string SinhMaTuDong(string ma)
        {
            string Matusinh = "";
            int count = 0;
            count = dtNXB.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtNXB.Rows[count - 2].Cells[0].Value);
            chuoiSo = Convert.ToInt32(ChuoiMa.Replace(ma, ""));
            if (chuoiSo + 1 < 10)
            {
                Matusinh = ma + "00" + (chuoiSo + 1).ToString();
            }
            else if (chuoiSo + 1 < 100)
            {
                Matusinh = ma + "0" + (chuoiSo + 1).ToString();
            }

            return Matusinh;
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);

            TrangThaiButton(false);
            dtNXB.Enabled = false;
            txtMa.Text = SinhMaTuDong("nxb");
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dtNXB.Enabled = false;
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETENXB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNXB", txtMa.Text);
               
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                // load lại dữ liệu trong datagridview.
                sql = "SELECT * FROM NXB";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            TrangThaiButton(true);
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtMa.Text;
                cmd = new SqlCommand("ThemNXB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNXB", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNXB", txtTen.Text);
                cmd.Parameters.AddWithValue("@NgayNhap", dtpnhap.Value);
                cmd.Parameters.AddWithValue("@SoBan", txtsoban.Text);
                cmd.Parameters.AddWithValue("@GiaSach", txtgia.Text);
                cmd.Parameters.AddWithValue("@SoDT", txtdt.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else if (Trangthai == "EDIT")
            {
                cmd = new SqlCommand("EDITNXB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNXB", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNXB", txtTen.Text);
                cmd.Parameters.AddWithValue("@NgayNhap", dtpnhap.Value);
                cmd.Parameters.AddWithValue("@SoBan", txtsoban.Text);
                cmd.Parameters.AddWithValue("@GiaSach", txtgia.Text);
                cmd.Parameters.AddWithValue("@SoDT", txtdt.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dtNXB.Enabled = true;
            txtTim.Text = "";
            dtNXB.CurrentCell = dtNXB[0, 0];
            dtNXB_SelectionChanged(sender, e);
            sql = "SELECT * FROM NXB";
            HienThi(sql);
        }

        private void dtNXB_SelectionChanged(object sender, EventArgs e)
        {
            if (dtNXB.SelectedCells.Count > 0 && dtNXB.SelectedRows.Count > 0)
            {
                int Index = dtNXB.CurrentCell.RowIndex;
                txtMa.Text = dtNXB.Rows[Index].Cells[0].Value.ToString();
                txtTen.Text = dtNXB.Rows[Index].Cells[1].Value.ToString();
                dtpnhap.Text = dtNXB.Rows[Index].Cells[2].Value.ToString();
                txtsoban.Text = dtNXB.Rows[Index].Cells[3].Value.ToString();
                txtgia.Text = dtNXB.Rows[Index].Cells[4].Value.ToString();
                txtdt.Text = dtNXB.Rows[Index].Cells[5].Value.ToString();
                txtdiachi.Text = dtNXB.Rows[Index].Cells[6].Value.ToString();


            }
            else
            {
                ClearTXT();
            }
        }

        private void ckLuaChon_CheckedChanged(object sender, EventArgs e)
        {
           
        }

 

        private void btnTTV_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheThuVien ttv = new TheThuVien();
            ttv.Show();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void btnMTS_Click(object sender, EventArgs e)
        {
            this.Hide();
            MuonTraSach mts = new MuonTraSach();
            mts.Show();
        }

        private void btnTG_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia();
            tg.Show();
            this.Hide();
        }

        private void btnNN_Click(object sender, EventArgs e)
        {
            NgonNgu nn = new NgonNgu();
            nn.Show();
            this.Hide();
        }

        private void btnVT_Click(object sender, EventArgs e)
        {
            ViTri vt = new ViTri();
            vt.Show();
            this.Hide();
        }

        private void btnTL_Click(object sender, EventArgs e)
        {
            TheLoai tl = new TheLoai();
            tl.Show();
            this.Hide();
        }

        private void btnTS_Click(object sender, EventArgs e)
        {
            TuaSach ts = new TuaSach();
            ts.Show();
            this.Hide();
        }

        private void btnTGTS_Click(object sender, EventArgs e)
        {
            TG_TS tgts = new TG_TS();
            tgts.Show();
            this.Hide();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            Sach s = new Sach();
            s.Show();
            this.Hide();
        }

        private void btnCTPM_Click(object sender, EventArgs e)
        {
            CTPM ctpm = new CTPM();
            ctpm.Show();
            this.Hide();
        }
    }
}

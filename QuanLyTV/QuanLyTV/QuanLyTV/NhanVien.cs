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
    public partial class NhanVien : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public NhanVien()
        {
            InitializeComponent();
            dtNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //Bảng nhân viên
        private void NhanVien_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idNV AS 'idNV',TenNV AS 'TenNV',NgaySinh AS 'NgaySinh',GioiTinh AS 'GioiTinh',SoDT AS 'SoDT',DiaChi AS 'DiaChi' FROM NhanVien";
                HienThi(sql);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        private void TrangThaiButton(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
        }
        private void TrangThaiTXT(bool b)
        {

            txtHoTen.Enabled = b;
            txtGioiTinh.Enabled = b;
            dtpNgaySinh.Enabled = b;
            txtSDT.Enabled = b;
            txtDiaChi.Enabled = b;



        }
        private void ClearTXT()
        {
            txtMa.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtNhanVien.DataSource = dt;
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
            count = dtNhanVien.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtNhanVien.Rows[count - 2].Cells[0].Value);
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
        private DataTable LoadComBoBox(string sqlCBB)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(sqlCBB, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);

            TrangThaiButton(false);
            dtNhanVien.Enabled = false;
            txtMa.Text = SinhMaTuDong("nv");
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dtNhanVien.Enabled = false;
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DeleteNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txtMa.Text);
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
                sql = "SELECT * FROM NhanVien";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtMa.Text;
                cmd = new SqlCommand("ThemNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SoDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
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
                cmd = new SqlCommand("EDITTheThuVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SoDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

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
            btnHuy_Click(sender, e);
            txtTimKiem.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dtNhanVien.Enabled = true;
            dtNhanVien.CurrentCell = dtNhanVien[0, 0];
            dtNhanVien_SelectionChanged(sender, e);
            sql = "SELECT * FROM NhanVien";
            HienThi(sql);
            txtTimKiem.Clear();
        }

        private void dtNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtNhanVien.SelectedCells.Count > 0 && dtNhanVien.SelectedRows.Count > 0)
            {
                int Index = dtNhanVien.CurrentCell.RowIndex;
                txtMa.Text = dtNhanVien.Rows[Index].Cells[0].Value.ToString();
                txtHoTen.Text = dtNhanVien.Rows[Index].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dtNhanVien.Rows[Index].Cells[2].Value.ToString();
                txtGioiTinh.Text = dtNhanVien.Rows[Index].Cells[3].Value.ToString();
                txtSDT.Text = dtNhanVien.Rows[Index].Cells[4].Value.ToString();
                txtDiaChi.Text = dtNhanVien.Rows[Index].Cells[5].Value.ToString();
            }
            else
            {
                ClearTXT();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sql = "SELECT idNV, TenNV, NgaySinh ,GioiTinh ,SoDT ,DiaChi FROM NhanVien  WHERE idNV = '" + txtTimKiem.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtNhanVien.DataSource = dt;
            TrangThaiButton(false);
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void btnMuonTraSach_Click(object sender, EventArgs e)
        {
            this.Hide();
            MuonTraSach mts = new MuonTraSach();
            mts.Show();
        }

        private void btnTTV_Click(object sender, EventArgs e)
        {
            TheThuVien ttv = new TheThuVien();
            ttv.Show();
            this.Hide();
        }



        private void btnMTS_Click(object sender, EventArgs e)
        {
            MuonTraSach mts = new MuonTraSach();
            mts.Show();
            this.Hide();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            NXB nxb = new NXB();
            nxb.Show();
            this.Hide();
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

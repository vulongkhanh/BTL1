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
    public partial class TheThuVien : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public TheThuVien()
        {
            InitializeComponent();
            dtTheThuVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtTheThuVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TheThuVien_Load(object sender, EventArgs e)
        {
            TTNut(true);
            TTText(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idThe AS 'idThe', HoTen AS 'HoTen', NgaySinh AS 'NgaySinh',GioiTinh AS 'GioiTinh',NgayLap AS 'NgayLap',HanDung AS 'HanDung' FROM TheThuVien";
                HienThi(sql);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void TheThuVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        
        private void TTNut(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
        }
        private void TTText(bool b)
        {

            txtHoTen.Enabled = b;
            txtGioiTinh.Enabled = b;
            dtpNgaySinh.Enabled = b;
            dtpNgayLap.Enabled = b;
            dtpHSD.Enabled = b;



        }
        private void ClearTXT()
        {
            txtMa.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            dtpNgayLap.Text = "";
            dtpHSD.Text = "";

        }

        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtTheThuVien.DataSource = dt;
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
            count = dtTheThuVien.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtTheThuVien.Rows[count - 2].Cells[0].Value);
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
            TTText(true);

            TTNut(false);
            dtTheThuVien.Enabled = false;
            txtMa.Text = SinhMaTuDong("t");
            txtMa.Focus();
        }
        //adsahdjshad
        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TTText(true);
            TTNut(false);
            dtTheThuVien.Enabled = false;
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DeleteTheThuVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idThe", txtMa.Text);
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
                sql = "SELECT * FROM TheThuVien";
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
                cmd = new SqlCommand("ThemTheThuVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idThe", txtMa.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@HanDung", dtpHSD.Value);
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
                cmd.Parameters.AddWithValue("@idThe", txtMa.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@HanDung", dtpHSD.Value);

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
            TTText(false);
            TTNut(true);
            dtTheThuVien.Enabled = true;
            dtTheThuVien.CurrentCell = dtTheThuVien[0, 0];
            dtTheThuVien_SelectionChanged(sender, e);
            sql = "SELECT * FROM TheThuVien";
            HienThi(sql);
            txtTimKiem.Clear();
        }

        private void dtTheThuVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtTheThuVien.SelectedCells.Count > 0 && dtTheThuVien.SelectedRows.Count > 0)
            {
                int Index = dtTheThuVien.CurrentCell.RowIndex;
                txtMa.Text = dtTheThuVien.Rows[Index].Cells[0].Value.ToString();
                txtHoTen.Text = dtTheThuVien.Rows[Index].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dtTheThuVien.Rows[Index].Cells[2].Value.ToString();
                txtGioiTinh.Text = dtTheThuVien.Rows[Index].Cells[3].Value.ToString();
                dtpNgayLap.Text = dtTheThuVien.Rows[Index].Cells[4].Value.ToString();
                dtpHSD.Text = dtTheThuVien.Rows[Index].Cells[5].Value.ToString();
            }
            else
            {
                ClearTXT();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sql = "SELECT idThe, HoTen, NgaySinh, GioiTinh, NgayLap, HanDung  FROM TheThuVien  WHERE idThe = '" + txtTimKiem.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtTheThuVien.DataSource = dt;
            TTNut(false);
        }


        private void btnNV_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Show();
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
            Sach s = new Sach();
            s.Show();
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

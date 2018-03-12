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
    public partial class TacGia : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public TacGia()
        {
            InitializeComponent();
            dgvTacGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idTG AS 'idTG', TenTG AS 'TenTG',NgayKiHopDong AS 'NgayKiHopDong',NgayHetHopDong AS 'NgayHetHopDong',SoDT AS 'SoDT',DiaChi AS 'DiaChi' FROM TacGia";
                HienThi(sql);





            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void TacGia_FormClosing(object sender, FormClosingEventArgs e)
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
            txtTG.Text = "";
            txtTen.Text = "";
            datNgayKy.Text = "";
            datNgayHet.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

        }
        private void TrangThaiTXT(bool b)
        {

            //txtTG.Enabled = b;
            txtTen.Enabled = b;
            datNgayKy.Enabled = b;
            datNgayHet.Enabled = b;
            txtSDT.Enabled = b;
            txtDiaChi.Enabled = b;



        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTacGia.DataSource = dt;
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
            count = dgvTacGia.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvTacGia.Rows[count - 2].Cells[0].Value);
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
            Trangthai = "Them";
            ClearTXT();
            TrangThaiTXT(true);

            TrangThaiButton(false);
            dgvTacGia.Enabled = false;
            txtTG.Text = SinhMaTuDong("tg");
            //txtTG.Focus();
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "Sua";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvTacGia.Enabled = false;
            txtTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETETacGia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTG", txtTG.Text);
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
                sql = "SELECT * FROM TacGia";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "Them")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtTG.Text;
                cmd = new SqlCommand("ThemTacGia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTG", txtTG.Text);
                cmd.Parameters.AddWithValue("@TenTG", txtTen.Text);
                cmd.Parameters.AddWithValue("@NgayKiHopÐong", datNgayKy.Value);
                cmd.Parameters.AddWithValue("@NgayHetHopÐong", datNgayHet.Value);
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
            else if (Trangthai == "Sua")
            {
                cmd = new SqlCommand("EDITTacGia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTG", txtTG.Text);
                cmd.Parameters.AddWithValue("@TenTG", txtTen.Text);
                cmd.Parameters.AddWithValue("@NgayKiHopDong", datNgayKy.Value);
                cmd.Parameters.AddWithValue("@NgayHetHopDong", datNgayHet.Value);
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
            btnReset_Click(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvTacGia.Enabled = true;
            dgvTacGia.CurrentCell = dgvTacGia[0, 0];
            dgvTacGia_SelectionChanged(sender, e);
            sql = "SELECT * FROM TacGia";
            txtTim.Clear();
            HienThi(sql);
        }

        private void dgvTacGia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTacGia.SelectedCells.Count > 0 && dgvTacGia.SelectedRows.Count > 0)
            {
                int Index = dgvTacGia.CurrentCell.RowIndex;
                txtTG.Text = dgvTacGia.Rows[Index].Cells[0].Value.ToString();
                txtTen.Text = dgvTacGia.Rows[Index].Cells[1].Value.ToString();
                datNgayKy.Text = dgvTacGia.Rows[Index].Cells[2].Value.ToString();
                datNgayHet.Text = dgvTacGia.Rows[Index].Cells[3].Value.ToString();
                txtSDT.Text = dgvTacGia.Rows[Index].Cells[4].Value.ToString();
                txtDiaChi.Text = dgvTacGia.Rows[Index].Cells[5].Value.ToString();


            }
            else
            {
                ClearTXT();
            }
         }

        private void btnTim_Click(object sender, EventArgs e)
        {
            sql = "SELECT idTG, TenTG , NgayKiHopDong, NgayHetHopDong, SoDT, DiaChi FROM TacGia  WHERE idTG = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvTacGia.DataSource = dt;
        }

        private void ckLuaChon_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLuaChon.Checked == true)
            {
                btnTim.Enabled = true;
                txtTim.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                btnTim.Enabled = false;
                txtTim.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        private void btnTTV_Click(object sender, EventArgs e)
        {
            TheThuVien ttv = new TheThuVien();
            ttv.Show();
            this.Hide();
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

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
    
    public partial class NgonNgu : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public NgonNgu()
        {
            InitializeComponent();
            dgvViTri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViTri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void NgonNgu_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idNN AS 'idNN', TenNN AS 'TenNN'FROM NgonNgu";
                HienThi(sql);
                




            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void NgonNgu_FormClosing(object sender, FormClosingEventArgs e)
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
            txtVT.Text = "";
            txtTen.Text = "";

        }
        private void TrangThaiTXT(bool b)
        {
            txtTen.Enabled = b;


        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvViTri.DataSource = dt;
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
            count = dgvViTri.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvViTri.Rows[count - 2].Cells[0].Value);
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
            dgvViTri.Enabled = false;
            txtVT.Text = SinhMaTuDong("nn");
            txtVT.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvViTri.Enabled = false;
            txtVT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DeleteNgonNgu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNN", txtVT.Text);
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
                sql = "SELECT * FROM NgonNgu";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtVT.Text;
                cmd = new SqlCommand("ThemNgonNgu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNN", txtVT.Text);
                cmd.Parameters.AddWithValue("@TenNN", txtTen.Text);
                

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
                cmd = new SqlCommand("EDITNgonNgu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNN", txtVT.Text);
                cmd.Parameters.AddWithValue("@TenNN", txtTen.Text);
                

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
            dgvViTri.Enabled = true;
            txtTim.Text = "";
            dgvViTri.CurrentCell = dgvViTri[0, 0];
            dgvViTri_SelectionChanged(sender, e);
            sql = "SELECT * FROM NgonNgu";
            HienThi(sql);
        }

        private void dgvViTri_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvViTri.SelectedCells.Count > 0 && dgvViTri.SelectedRows.Count > 0)
            {
                int Index = dgvViTri.CurrentCell.RowIndex;
                txtVT.Text = dgvViTri.Rows[Index].Cells[0].Value.ToString();
                txtTen.Text = dgvViTri.Rows[Index].Cells[1].Value.ToString();
                

            }
            else
            {
                ClearTXT();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            sql = "SELECT idNN, TenNN  FROM NgonNgu  WHERE idNN = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvViTri.DataSource = dt;
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
                btnReset.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TuaSach ts = new TuaSach();
            ts.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViTri vt = new ViTri();
            vt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TheThuVien ttv = new TheThuVien();
            ttv.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NgonNgu nn = new NgonNgu();
            nn.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CTPM ctpm = new CTPM();
            ctpm.Show();
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

        private void btnTL_Click(object sender, EventArgs e)
        {
            TheLoai tl = new TheLoai();
            tl.Show();
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
    }
}

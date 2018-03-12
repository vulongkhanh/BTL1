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
    public partial class TG_TS : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public TG_TS()
        {
            InitializeComponent();
            dtTGTS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtTGTS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TG_TS_Load(object sender, EventArgs e)
        {
            TTNut(true);
            TTText(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idTGTS AS 'idTGTS', idTG AS 'idTG', idTS AS 'idTS' FROM TG_TS";
                HienThi(sql);
                cmbMaTG.DataSource = LoadComBoBox("SELECT * FROM TacGia");
                cmbMaTG.DisplayMember = "TenTG";
                cmbMaTG.ValueMember = "idTG";

                cmbMaTS.DataSource = LoadComBoBox("SELECT * FROM TuaSach");
                cmbMaTS.DisplayMember = "TenTS";
                cmbMaTS.ValueMember = "idTS";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void TG_TS_FormClosing(object sender, FormClosingEventArgs e)
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

            txtMa.Enabled = b;
            cmbMaTG.Enabled = b;
            cmbMaTS.Enabled = b;



        }
        private void ClearTXT()
        {
            txtMa.Text = "";
            cmbMaTG.SelectedIndex = -1;
            cmbMaTS.SelectedIndex = -1;

        }

        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtTGTS.DataSource = dt;
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
            count = dtTGTS.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtTGTS.Rows[count - 2].Cells[0].Value);
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
            dtTGTS.Enabled = false;
            txtMa.Text = SinhMaTuDong("tgts");
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TTText(true);
            TTNut(false);
            dtTGTS.Enabled = false;
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DeleteTGTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTGTS", txtMa.Text);
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
                sql = "SELECT * FROM TG_TS";
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
                cmd = new SqlCommand("ThemTG_TS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTGTS", txtMa.Text);
                cmd.Parameters.AddWithValue("@idTG", cmbMaTG.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idTS", cmbMaTS.SelectedValue.ToString());

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
                cmd = new SqlCommand("EDITTGTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTGTS", txtMa.Text);
                cmd.Parameters.AddWithValue("@idTG", cmbMaTG.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idTS", cmbMaTS.SelectedValue.ToString());

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
            dtTGTS.Enabled = true;
            dtTGTS.CurrentCell = dtTGTS[0, 0];
            dtTGTS_SelectionChanged(sender, e);
            sql = "SELECT * FROM TG_TS";
            HienThi(sql);
            txtTimKiem.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sql = "SELECT idTGTS, idTG, idTS  FROM TG_TS  WHERE idTGTS = '" + txtTimKiem.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtTGTS.DataSource = dt;
            TTNut(false);
        }

        private void dtTGTS_SelectionChanged(object sender, EventArgs e)
        {
            if (dtTGTS.SelectedCells.Count > 0 && dtTGTS.SelectedRows.Count > 0)
            {
                int Index = dtTGTS.CurrentCell.RowIndex;
                txtMa.Text = dtTGTS.Rows[Index].Cells[0].Value.ToString();
                cmbMaTG.Text = dtTGTS.Rows[Index].Cells[1].Value.ToString();
                cmbMaTS.Text = dtTGTS.Rows[Index].Cells[2].Value.ToString();


                string IDcmbMaTG = dtTGTS.Rows[Index].Cells[1].Value.ToString();
                string sqlCBB = "SELECT * FROM TacGia where idTG = '" + IDcmbMaTG + "' ";

                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cmbMaTG.Text = dr["TenTG"].ToString();
                }


                string IDcmbMaTS = dtTGTS.Rows[Index].Cells[2].Value.ToString();
                string sqlCBB1 = "SELECT * FROM TuaSach where idTS= '" + IDcmbMaTS + "' ";

                cmd = new SqlCommand(sqlCBB1, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dtCBB1 = new DataTable();
                da2.Fill(dtCBB1);
                foreach (DataRow dr in dtCBB1.Rows)
                {
                    cmbMaTS.Text = dr["TenTS"].ToString();
                }
            }
            else
            {
                ClearTXT();
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

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
    //muon tra sach
    public partial class MuonTraSach : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";

        public MuonTraSach()
        {
            InitializeComponent();
            dtMuonTraSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtMuonTraSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MuonTraSach_Load(object sender, EventArgs e)
        {
            TTNut(true);
            TTText(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idPMT AS 'idPMT', NgayMuon AS 'NgayMuon', NgayTra AS 'NgayTra',idThe AS 'idThe',idNV AS 'idNV' FROM MuonTraSach";
                HienThi(sql);
                cmbMaThe.DataSource = LoadComBoBox("SELECT * FROM TheThuVien");
                cmbMaThe.DisplayMember = "HoTen";
                cmbMaThe.ValueMember = "idThe";

                cmbMaNV.DataSource = LoadComBoBox("SELECT * FROM NhanVien");
                cmbMaNV.DisplayMember = "TenNV";
                cmbMaNV.ValueMember = "idNV";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void MuonTraSach_FormClosing(object sender, FormClosingEventArgs e)
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
            dtpNgayMuon.Enabled = b;
            dtpNgayTra.Enabled = b;
            cmbMaThe.Enabled = b;
            cmbMaNV.Enabled = b;



        }
        private void ClearTXT()
        {
            txtMa.Text = "";
            dtpNgayMuon.Text = "";
            dtpNgayTra.Text = "";
            cmbMaThe.SelectedIndex = -1;
            cmbMaNV.SelectedIndex = -1;

        }

        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtMuonTraSach.DataSource = dt;
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
            count = dtMuonTraSach.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtMuonTraSach.Rows[count - 2].Cells[0].Value);
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
            dtMuonTraSach.Enabled = false;
            txtMa.Text = SinhMaTuDong("pmt");
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TTText(true);
            TTNut(false);
            dtMuonTraSach.Enabled = false;
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DeleteMuonTraSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPMT", txtMa.Text);
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
                sql = "SELECT * FROM MuonTraSach";
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
                cmd = new SqlCommand("ThemMuonTraSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPMT", txtMa.Text);
                cmd.Parameters.AddWithValue("@NgayMuon", dtpNgayMuon.Value);
                cmd.Parameters.AddWithValue("@NgayTra", dtpNgayTra.Value);
                cmd.Parameters.AddWithValue("@idThe", cmbMaThe.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idNV", cmbMaNV.SelectedValue.ToString());

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
                cmd = new SqlCommand("EDITMuonTraSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPMT", txtMa.Text);
                cmd.Parameters.AddWithValue("@NgayMuon", dtpNgayMuon.Value);
                cmd.Parameters.AddWithValue("@NgayTra", dtpNgayTra.Value);
                cmd.Parameters.AddWithValue("@idThe", cmbMaThe.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idNV", cmbMaNV.SelectedValue.ToString());

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
            dtMuonTraSach.Enabled = true;
            dtMuonTraSach.CurrentCell = dtMuonTraSach[0, 0];
            dtMuonTraSach_SelectionChanged(sender, e);
            sql = "SELECT * FROM MuonTraSach";
            HienThi(sql);
            txtTimKiem.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sql = "SELECT idPMT, NgayMuon, NgayTra, idThe, idNV  FROM MuonTraSach  WHERE idPMT = '" + txtTimKiem.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtMuonTraSach.DataSource = dt;
            TTNut(false);
        }

        private void dtMuonTraSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dtMuonTraSach.SelectedCells.Count > 0 && dtMuonTraSach.SelectedRows.Count > 0)
            {
                int Index = dtMuonTraSach.CurrentCell.RowIndex;
                txtMa.Text = dtMuonTraSach.Rows[Index].Cells[0].Value.ToString();
                dtpNgayMuon.Text = dtMuonTraSach.Rows[Index].Cells[1].Value.ToString();
                dtpNgayTra.Text = dtMuonTraSach.Rows[Index].Cells[2].Value.ToString();
                cmbMaThe.Text = dtMuonTraSach.Rows[Index].Cells[3].Value.ToString();
                cmbMaNV.Text = dtMuonTraSach.Rows[Index].Cells[4].Value.ToString();


                string IDcmbMaThe = dtMuonTraSach.Rows[Index].Cells[3].Value.ToString();
                string sqlCBB = "SELECT * FROM TheThuVien where idThe= '" + IDcmbMaThe + "' ";

                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cmbMaThe.Text = dr["HoTen"].ToString();
                }


                string IDcmbMaNV = dtMuonTraSach.Rows[Index].Cells[4].Value.ToString();
                string sqlCBB1 = "SELECT * FROM NhanVien where idNV= '" + IDcmbMaNV + "' ";

                cmd = new SqlCommand(sqlCBB1, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dtCBB1 = new DataTable();
                da2.Fill(dtCBB1);
                foreach (DataRow dr in dtCBB1.Rows)
                {
                    cmbMaNV.Text = dr["TenNV"].ToString();
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
            TuaSach ts = new TuaSach();
            ts.Show();
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

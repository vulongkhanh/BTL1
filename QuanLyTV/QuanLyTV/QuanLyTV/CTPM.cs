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
    public partial class CTPM : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public CTPM()
        {
            InitializeComponent();
            dtgCTPM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCTPM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            sql = "SELECT idCTPM, idPMT , SoCaBiet  FROM CTPMSach  WHERE idCTPM = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtgCTPM.DataSource = dt;
        }

        private void CTPM_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idCTPM AS 'idCTPM', idPMT AS 'idPMT', SoCaBiet AS 'SoCaBiet'  FROM CTPMSach ";
                HienThi(sql);

                //Lấy ra 1 DataTable hiển thị ra Bảng NXB trong SQL
                cmbcb.DataSource = LoadComBoBox("SELECT * FROM Sach");
                //cmbNXB.DisplayMember = "TenNXB";//Hiển thị lên TenNXB trong CBB
                cmbcb.DisplayMember = "SoCaBiet";
                cmbcb.ValueMember = "SoCaBiet";//Lấy theo idNXB trong Bảng TacGia 

                //Lấy ra 1 DataTable hiển thị ra Bảng NgonNgu trong SQL
                cmbma.DataSource = LoadComBoBox("SELECT * FROM MuonTraSach");
                //cmbNN.DisplayMember = "TenNN";//Hiển thị lên TenNN trong CBB
                cmbma.DisplayMember = "idPMT";
                cmbma.ValueMember = "idPMT";//Lấy theo idNN trong Bảng TacGia









            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void CTPM_FormClosing(object sender, FormClosingEventArgs e)
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
            btnReset.Enabled = b;
            btnTim.Enabled = b;
            txtTim.Enabled = b;
        }
        private void ClearTXT()
        {
            txtma.Text = "";



            cmbma.SelectedIndex = -1;
            cmbcb.SelectedIndex = -1;

        }
        private void TrangThaiTXT(bool b)
        {

            txtma.Enabled = b;




            cmbma.Enabled = b;
            cmbcb.Enabled = b;



        }

        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgCTPM.DataSource = dt;
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
            count = dtgCTPM.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dtgCTPM.Rows[count - 2].Cells[0].Value);
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
        #region[xử lý các COMBOBOX...]
        private DataTable LoadComBoBox(string sqlCBB)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(sqlCBB, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        #endregion


        #region[Các Button]
        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);


            TrangThaiButton(false);
            dtgCTPM.Enabled = false;
            btnReset.Enabled = true;
            txtma.Text = SinhMaTuDong("ts");
            txtma.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            btnReset.Enabled = true;
            dtgCTPM.Enabled = false;
            txtma.Focus();


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETECTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);
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
                sql = "SELECT * FROM CTPMSach";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtma.Text;
                cmd = new SqlCommand("ThemCTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);


                cmd.Parameters.AddWithValue("@idPMT", cmbma.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoCaBiet", cmbcb.SelectedValue.ToString());


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
                cmd = new SqlCommand("EDITCTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);


                cmd.Parameters.AddWithValue("@idPMT", cmbma.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoCaBiet", cmbcb.SelectedValue.ToString());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sql = "SELECT * FROM CTPMSach";
                HienThi(sql);
            }
            btnReset_Click(sender, e);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dtgCTPM.Enabled = true;
            txtTim.Text = "";
            dtgCTPM.CurrentCell = dtgCTPM[0, 0];
            dtgCTPM_SelectionChanged(sender, e);
            sql = "SELECT * FROM CTPMSach";
            HienThi(sql);
        }


        #endregion

        private void dtgCTPM_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgCTPM.SelectedCells.Count > 0 && dtgCTPM.SelectedRows.Count > 0)
            {
                int Index = dtgCTPM.CurrentCell.RowIndex;
                txtma.Text = dtgCTPM.Rows[Index].Cells[0].Value.ToString();


                cmbma.Text = dtgCTPM.Rows[Index].Cells[1].Value.ToString();
                cmbcb.Text = dtgCTPM.Rows[Index].Cells[2].Value.ToString();



            }
            else
            {
                ClearTXT();
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dtgCTPM.Enabled = true;
            txtTim.Text = "";
            dtgCTPM.CurrentCell = dtgCTPM[0, 0];
            dtgCTPM_SelectionChanged(sender, e);
            sql = "SELECT * FROM CTPMSach";
            HienThi(sql);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);


            TrangThaiButton(false);
            dtgCTPM.Enabled = false;
            btnReset.Enabled = true;
            txtma.Text = SinhMaTuDong("ctpm");
            txtma.Focus();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            btnReset.Enabled = true;
            dtgCTPM.Enabled = false;
            txtma.Focus();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETECTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);
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
                sql = "SELECT * FROM CTPMSach";
                HienThi(sql);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtma.Text;
                cmd = new SqlCommand("ThemCTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);
                cmd.Parameters.AddWithValue("@idPMT", cmbma.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoCaBiet", cmbcb.SelectedValue.ToString());

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
                cmd = new SqlCommand("EDITCTPMSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCTPM", txtma.Text);
                cmd.Parameters.AddWithValue("@idPMT", cmbma.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoCaBiet", cmbcb.SelectedValue.ToString());

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
            btnReset_Click_1(sender, e);
            txtTim.Clear();
            sql = "SELECT * FROM CTPMSach";
            HienThi(sql);
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

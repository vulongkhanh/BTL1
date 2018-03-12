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
    public partial class Sach : Form
    {

        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public Sach()
        {
            InitializeComponent();
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Công đẹp trai làm phần này
        private void Sach_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT SoCaBiet AS 'SoCaBiet', TinhTrangSach AS 'TinhTrangSach', TinhTrangMuon AS 'TinhTrangMuon', SoLuong AS 'SoLuong', idTS AS 'idTS' FROM Sach";
                HienThi(sql);
                //Lấy ra 1 DataTable hiển thị ra Bảng TacGia trong SQL
                //cmbTG.DataSource = LoadComBoBox("SELECT * FROM TacGia");

                //cmbTG.DisplayMember = "TenTG";
                //cmbTG.ValueMember = "idTG";
                //
                cmbTS.DataSource = LoadComBoBox("SELECT * FROM TuaSach");
                cmbTS.DisplayMember = "TenTS";
                cmbTS.ValueMember = "idTS";
                //
                cmbTTS.DataSource = LoadComBoBox("SELECT * FROM Sach");

                cmbTTS.DisplayMember = "TinhTrangSach";
                cmbTTS.ValueMember = "TinhTrangSach";
                //
                cmbTT.DataSource = LoadComBoBox("SELECT * FROM Sach");

                cmbTT.DisplayMember = "TinhTrangMuon";
                cmbTT.ValueMember = "TinhTrangMuon";




                //cmbTG.DisplayMember = "TenTG";
                //cmbTG.ValueMember = "TenTG";
                //Lấy theo idTG trong Bảng TacGia 

                //Lấy ra 1 DataTable hiển thị ra Bảng ThanhLI trong SQL
                //cmbTL.DataSource = LoadComBoBox("SELECT * FROM ThanhLi");

                //cmbTL.DisplayMember = "idTL";
                //cmbTL.ValueMember = "idTL";//Lấy theo idTL trong Bảng ThanhLi 

                //Lấy ra 1 DataTable hiển thị ra Bảng NXB trong SQL
                //cmbNXB.DataSource = LoadComBoBox("SELECT * FROM NXB");

                //cmbNXB.DisplayMember = "idNXB";
                //cmbNXB.ValueMember = "idNXB";//Lấy theo idNXB trong Bảng TacGia 

                ////Lấy ra 1 DataTable hiển thị ra Bảng NgonNgu trong SQL
                //cmbNN.DataSource = LoadComBoBox("SELECT * FROM NgonNgu");

                //cmbNN.DisplayMember = "idNN";
                //cmbNN.ValueMember = "idNN";//Lấy theo idNN trong Bảng TacGia

                ////Lấy ra 1 DataTable hiển thị ra Bảng ViTri trong SQL
                //cmbVT.DataSource = LoadComBoBox("SELECT * FROM ViTriSach");

                //cmbVT.DisplayMember = "idVT";
                //cmbVT.ValueMember = "idVT";//Lấy theo idVT trong Bảng TacGia 


                ////Lấy ra 1 DataTable hiển thị ra Bảng TheLoai trong SQL
                //cmbLS.DataSource = LoadComBoBox("SELECT * FROM TheLoai");

                //cmbLS.DisplayMember = "idLS";
                //cmbLS.ValueMember = "idLS";//Lấy theo idLS trong Bảng TacGia 




            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void Sach_FormClosing(object sender, FormClosingEventArgs e)
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
            txtS.Text = "";
            cmbTTS.SelectedIndex = -1;
            cmbTT.SelectedIndex = -1;
            //cmbTG.SelectedIndex = -1;
            //cmbTL.SelectedIndex = -1;
            txtSoLuong.Text = "";
            cmbTS.SelectedIndex = -1;
            

        }
        private void TrangThaiTXT(bool b)
        {

            cmbTTS.Enabled = b;
            //txtSoTrang.Enabled = b;
            //cmbTG.Enabled = b;
            //cmbTL.Enabled = b;
            txtSoLuong.Enabled = b;
            cmbTT.Enabled = b;
            cmbTS.Enabled = b;
            
            //cmbLS.Enabled = b;


        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSach.DataSource = dt;
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
            count = dgvSach.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvSach.Rows[count - 2].Cells[0].Value);
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvSach.Enabled = false;
            txtS.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETESach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SoCaBiet", txtS.Text);
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
                sql = "SELECT * FROM Sach";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtS.Text;
                cmd = new SqlCommand("ThemSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SoCaBiet", txtS.Text);
                //cmd.Parameters.AddWithValue("@TenTS", txtTen.Text);
                //cmd.Parameters.AddWithValue("@SoTrang", txtSoTrang.Text);
                //cmd.Parameters.AddWithValue("@idTG", cmbTG.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@idTL", cmbTL.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idTinhtrangSach", cmbTTS.Text);
                cmd.Parameters.AddWithValue("@idTinhTrangMuon", cmbTT.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idTS", cmbTS.SelectedValue.ToString());

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
                cmd = new SqlCommand("EDITNhonSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SoCaBiet", txtS.Text);
                cmd.Parameters.AddWithValue("@TinhTrangSach", cmbTTS.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@TinhTrangMuon", cmbTT.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                //cmd.Parameters.AddWithValue("@TenTG", cmbTG.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@idTL", cmbTL.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idTS", cmbTS.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@idTG", cmbTG.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@idVT", cmbVT.SelectedValue.ToString());
                //cmd.Parameters.AddWithValue("@idLS", cmbLS.SelectedValue.ToString());

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
            dgvSach.Enabled = true;
            dgvSach.CurrentCell = dgvSach[0, 0];
            dgvSach_SelectionChanged(sender, e);
            sql = "SELECT * FROM Sach";
            HienThi(sql);
        }
        #endregion

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.SelectedCells.Count > 0 && dgvSach.SelectedRows.Count > 0)
            {
                int Index = dgvSach.CurrentCell.RowIndex;
                txtS.Text = dgvSach.Rows[Index].Cells[0].Value.ToString();
                cmbTTS.Text = dgvSach.Rows[Index].Cells[1].Value.ToString();
                cmbTT.Text = dgvSach.Rows[Index].Cells[2].Value.ToString();
                //cmbTG.Text = dgvTuaSach.Rows[Index].Cells[3].Value.ToString();
                //cmbTL.Text = dgvTuaSach.Rows[Index].Cells[4].Value.ToString();
                txtSoLuong.Text = dgvSach.Rows[Index].Cells[3].Value.ToString();
                cmbTS.Text = dgvSach.Rows[Index].Cells[4].Value.ToString();
                
                //cmbLS.Text = dgvTuaSach.Rows[Index].Cells[6].Value.ToString();


            }
            else
            {
                ClearTXT();
            }

        }



        private void btnThem_Click_1(object sender, EventArgs e)
        {

            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);
            //txtTim.Text="";

            TrangThaiButton(false);
            dgvSach.Enabled = false;
            txtS.Text = SinhMaTuDong("scb");
            txtS.Focus();

        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            sql = "SELECT SoCaBiet, TinhTrangSach , TinhTrangMuon ,SoLuong, idTS FROM Sach  WHERE SoCaBiet = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvSach.DataSource = dt;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void btnCTPM_Click(object sender, EventArgs e)
        {
            CTPM ctpm = new CTPM();
            ctpm.Show();
            this.Hide();
        }
    }
}

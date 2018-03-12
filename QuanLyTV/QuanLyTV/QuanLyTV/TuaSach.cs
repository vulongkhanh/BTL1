using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Data.SqlClient;
namespace QuanLyTV
{
    public partial class TuaSach : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-9N4C0JP\SQLEXPRESS;Initial Catalog=ThuViendemo2;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public TuaSach()
        {
            InitializeComponent();
            dgvTuaSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTuaSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TuaSach_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT idTS AS 'idTS', TenTS AS 'TenTS', SoTrang AS 'SoTrang', idNXB AS 'idNXB',idNN AS 'id NN',idVT AS 'idVT',idLS AS 'idLS' FROM TuaSach";
                HienThi(sql);





                //Lấy ra 1 DataTable hiển thị ra Bảng NXB trong SQL
                cmbNXB.DataSource = LoadComBoBox("SELECT * FROM NXB");
                //cmbNXB.DisplayMember = "TenNXB";//Hiển thị lên TenNXB trong CBB
                cmbNXB.DisplayMember = "TenNXB";
                cmbNXB.ValueMember = "idNXB";//Lấy theo idNXB trong Bảng TacGia 

                //Lấy ra 1 DataTable hiển thị ra Bảng NgonNgu trong SQL
                cmbNN.DataSource = LoadComBoBox("SELECT * FROM NgonNgu");
                //cmbNN.DisplayMember = "TenNN";//Hiển thị lên TenNN trong CBB
                cmbNN.DisplayMember = "TenNN";
                cmbNN.ValueMember = "idNN";//Lấy theo idNN trong Bảng TacGia

                //Lấy ra 1 DataTable hiển thị ra Bảng ViTri trong SQL
                cmbVT.DataSource = LoadComBoBox("SELECT * FROM ViTriSach");
                //cmbVT.DisplayMember = "TenVT";//Hiển thị lên TenVT trong CBB
                cmbVT.DisplayMember = "TenVT";
                cmbVT.ValueMember = "idVT";//Lấy theo idVT trong Bảng TacGia 


                //Lấy ra 1 DataTable hiển thị ra Bảng TheLoai trong SQL
                cmbLS.DataSource = LoadComBoBox("SELECT * FROM TheLoai");
                //cmbLS.DisplayMember = "TenTL";//Hiển thị lên TenTG trong CBB
                cmbLS.DisplayMember = "TenTL";
                cmbLS.ValueMember = "idLS";//Lấy theo idLS trong Bảng TacGia 




            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void TuaSach_FormClosing(object sender, FormClosingEventArgs e)
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
            txtTS.Text = "";
            txtTen.Text = "";
            txtSoTrang.Text = "";


            cmbNXB.SelectedIndex = -1;
            cmbNN.SelectedIndex = -1;
            cmbVT.SelectedIndex = -1;
            cmbLS.SelectedIndex = -1;
        }
        private void TrangThaiTXT(bool b)
        {

            txtTen.Enabled = b;
            txtSoTrang.Enabled = b;



            cmbNXB.Enabled = b;
            cmbNN.Enabled = b;
            cmbVT.Enabled = b;
            cmbLS.Enabled = b;


        }

        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTuaSach.DataSource = dt;
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
            count = dgvTuaSach.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvTuaSach.Rows[count - 2].Cells[0].Value);
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
            dgvTuaSach.Enabled = false;
            btnReset.Enabled = true;
            txtTS.Text = SinhMaTuDong("ts");
            txtTS.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            btnReset.Enabled = true;
            dgvTuaSach.Enabled = false;
            txtTS.Focus();


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETETuaSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTS", txtTS.Text);
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
                sql = "SELECT * FROM TuaSach";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtTS.Text;
                cmd = new SqlCommand("ThemTuaSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTS", txtTS.Text);
                cmd.Parameters.AddWithValue("@TenTS", txtTen.Text);
                cmd.Parameters.AddWithValue("@SoTrang", txtSoTrang.Text);

                cmd.Parameters.AddWithValue("@idNXB", cmbNXB.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idNN", cmbNN.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idVT", cmbVT.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idLS", cmbLS.SelectedValue.ToString());

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
                cmd = new SqlCommand("EDITTuaSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTS", txtTS.Text);
                cmd.Parameters.AddWithValue("@TenTS", txtTen.Text);
                cmd.Parameters.AddWithValue("@SoTrang", txtSoTrang.Text);
                cmd.Parameters.AddWithValue("@idNXB", cmbNXB.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idNN", cmbNN.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idVT", cmbVT.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@idLS", cmbLS.SelectedValue.ToString());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sql = "SELECT * FROM TuaSach";
                HienThi(sql);
            }
            btnReset_Click(sender, e);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvTuaSach.Enabled = true;
            txtTim.Text = "";
            dgvTuaSach.CurrentCell = dgvTuaSach[0, 0];
            dgvTuaSach_SelectionChanged_1(sender, e);
            sql = "SELECT * FROM TuaSach";
            HienThi(sql);
        }


        #endregion

        private void dgvTuaSach_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvTuaSach.SelectedCells.Count > 0 && dgvTuaSach.SelectedRows.Count > 0)
            {
                int Index = dgvTuaSach.CurrentCell.RowIndex;
                txtTS.Text = dgvTuaSach.Rows[Index].Cells[0].Value.ToString();
                txtTen.Text = dgvTuaSach.Rows[Index].Cells[1].Value.ToString();
                txtSoTrang.Text = dgvTuaSach.Rows[Index].Cells[2].Value.ToString();


                cmbNXB.Text = dgvTuaSach.Rows[Index].Cells[3].Value.ToString();
                cmbNN.Text = dgvTuaSach.Rows[Index].Cells[4].Value.ToString();
                cmbVT.Text = dgvTuaSach.Rows[Index].Cells[5].Value.ToString();
                cmbLS.Text = dgvTuaSach.Rows[Index].Cells[6].Value.ToString();
                //
                string IDcmmNXB = dgvTuaSach.Rows[Index].Cells[3].Value.ToString();
                string sqlCBB = "SELECT * FROM NXB where idNXB = '" + IDcmmNXB + "' ";

                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cmbNXB.Text = dr["TenNXB"].ToString();
                }
                //
                string IDcmbNN = dgvTuaSach.Rows[Index].Cells[4].Value.ToString();
                string sqlCBB1 = "SELECT * FROM NgonNgu where idNN= '" + IDcmbNN + "' ";

                cmd = new SqlCommand(sqlCBB1, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                DataTable dtCBB1 = new DataTable();
                da2.Fill(dtCBB1);
                foreach (DataRow dr in dtCBB1.Rows)
                {
                    cmbNN.Text = dr["TenNN"].ToString();
                }
                //
                string IDcmbVT = dgvTuaSach.Rows[Index].Cells[5].Value.ToString();
                string sqlCBB2 = "SELECT * FROM ViTriSach where idVT= '" + IDcmbVT + "' ";

                cmd = new SqlCommand(sqlCBB2, conn);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                DataTable dtCBB2 = new DataTable();
                da3.Fill(dtCBB2);
                foreach (DataRow dr in dtCBB2.Rows)
                {
                    cmbNN.Text = dr["TenVT"].ToString();
                }
                //
                string IDcmbLS = dgvTuaSach.Rows[Index].Cells[6].Value.ToString();
                string sqlCBB3 = "SELECT * FROM TheLoai where idLS= '" + IDcmbLS + "' ";

                cmd = new SqlCommand(sqlCBB3, conn);
                SqlDataAdapter da4 = new SqlDataAdapter(cmd);
                DataTable dtCBB3 = new DataTable();
                da4.Fill(dtCBB3);
                foreach (DataRow dr in dtCBB3.Rows)
                {
                    cmbNN.Text = dr["TenTL"].ToString();
                }


            }
            else
            {
                ClearTXT();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            sql = "SELECT idTS, TenTS , SoTrang , idNXB ,idNN ,idVT ,idLS  FROM TuaSach  WHERE idTS = '" + txtTim.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvTuaSach.DataSource = dt;
        }

        private void ckLuaChon_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void btnTroLaiTK_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cmbLS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            NXB nxb = new NXB();
            nxb.Show();
            this.Hide();
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

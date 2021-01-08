using HouseManagement.DAO;
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

namespace HouseManagement
{
    public partial class fNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string sqlString = @"";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public fNhanVien()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            LoadHouseList();
            LoadNhaThue();
            LoadNhaBan();
            LoadKhachHang();
        }
        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void dtgvNha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvNha.CurrentRow.Index;
            cb_ThanhPho_Nha.Text = dtgvNha.Rows[i].Cells[7].Value.ToString();
            cb_KhuVuc_Nha.Text = dtgvNha.Rows[i].Cells[5].Value.ToString();
            cb_Quan_Nha.Text = dtgvNha.Rows[i].Cells[6].Value.ToString();
            cb_Duong_Nha.Text = dtgvNha.Rows[i].Cells[4].Value.ToString();
            tb_ID_Nha.Text = dtgvNha.Rows[i].Cells[0].Value.ToString();
            cb_LoaiNha_Nha.Text = dtgvNha.Rows[i].Cells[8].Value.ToString();
            tb_SoLuongPhong_Nha.Text = dtgvNha.Rows[i].Cells[1].Value.ToString();
            tb_SoLuotXem_Nha.Text = dtgvNha.Rows[i].Cells[2].Value.ToString();
            cb_TinhTrang_Nha.Text = dtgvNha.Rows[i].Cells[3].Value.ToString();
            cb_ChiNhanh_Nha.Text = dtgvNha.Rows[i].Cells[9].Value.ToString();
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            string str = "exec sp_addApartment @ID , @soLuongPhong , @soLuotXem , @tinhTrang , @duong , @khuVuc , @quan , @thanhPho , @loaiNhaID , @chiNhanhID"; // nho 2 dau cach bao quanh dau phay
            DataProvider.Instance.ExecuteNonQuery(str, new object[] {tb_ID_Nha.Text, tb_SoLuongPhong_Nha.Text, tb_SoLuotXem_Nha.Text, cb_TinhTrang_Nha.SelectedValue, cb_Duong_Nha.SelectedValue.ToString(), cb_KhuVuc_Nha.SelectedValue.ToString(), cb_Quan_Nha.SelectedValue.ToString(), cb_ThanhPho_Nha.SelectedValue.ToString(), cb_LoaiNha_Nha.SelectedValue, cb_ChiNhanh_Nha.SelectedValue });
            LoadHouseList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhaDataSet.NHA' table. You can move, or remove it, as needed.
            //this.nHATableAdapter.Fill(this.quanLyNhaDataSet.NHA);

        }

        private void bt_TImKiem_NhaThue_Click(object sender, EventArgs e)
        {

        }

        #region Method
        void LoadHouseList()
        {
            string query = "select * from NHA";
            //DataProvider provider = new DataProvider();
            dtgvNha.DataSource = DataProvider.Instance.ExecuxeQuery(query, new object[] { });
        }
        void LoadNhaThue()
        {
            string query = "select * from THONGTINCHOTHUE";
            //DataProvider provider = new DataProvider();
            dtgvNhaThue.DataSource = DataProvider.Instance.ExecuxeQuery(query, new object[] { });
        }
        void LoadNhaBan()
        {
            string query = "select * from THONGTINBAN";
            //DataProvider provider = new DataProvider();
            dtgvNhaBan.DataSource = DataProvider.Instance.ExecuxeQuery(query, new object[] { });
        }
        void LoadKhachHang()
        {
            string query = "select * from KHACHHANG";
            //DataProvider provider = new DataProvider();
            dtgvKhachHang.DataSource = DataProvider.Instance.ExecuxeQuery(query, new object[] { });
        }
        #endregion

        void LoadDataTTNha()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_Nha_ThongTinNha";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvttnha.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu" + ex.Message);
            }
        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void btnThaydoittnha_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Nha_CapNhatTrangThai";
            command.Parameters.Add("@ID", SqlDbType.Int).Value = tbManha.Text.Trim();
            command.Parameters.Add("@status", SqlDbType.Bit).Value = cbTinhtrangnha.Text.Trim();
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Thay đổi thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadDataTTNha();
            connection.Close();
        }

        void LoadDataLoaiNha()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_Nha_ThongTinNha";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvloainha.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu" + ex.Message);
            }
        }
        private void btnThaydoiloainha_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Nha_CapNhatLoaiNha";
            command.Parameters.Add("IDNha", SqlDbType.Int).Value = tbManha2.Text.Trim();
            command.Parameters.Add("IDLoaiNha", SqlDbType.Int).Value = cbLoainha.Text.Trim();
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Thay đổi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDataLoaiNha();
            connection.Close();
        }

        void LoadHopDongThue()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ThongTinHopDongThue";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvHopdongthue.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_ThemHopDongThue";
            command.Parameters.Add("IDHopDong", SqlDbType.Int).Value = tbIDHopDong.Text.Trim();
            command.Parameters.Add("IDKhach", SqlDbType.Int).Value = tbIDKhach.Text.Trim();
            command.Parameters.Add("IDNha", SqlDbType.Int).Value = tbIDNha.Text.Trim();
            command.Parameters.Add("startDate", SqlDbType.Date).Value = dtpNgaythue.Text;
            command.Parameters.Add("endDate", SqlDbType.Date).Value = dtpNgaykt.Text;
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadHopDongThue();
            connection.Close();
        }
        //kg vào được connection (báo lỗi chưa gán giá trị nên tạo riêng)
        SqlConnection connectionOfC = new SqlConnection(@"Data Source=OLD-GOLD-3RD-DE\MSSQLSERVER1;Initial Catalog=QuanLyNha;Integrated Security=True");
        //Tìm hợp đồng thuê
        private void button1_Click(object sender, EventArgs e)
        {
            int houseID = 0;
            try
            {
                houseID = Int32.Parse(textBox1.Text);
                if (houseID < 0)
                    MessageBox.Show("ID khong duoc la be hon 1.", "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    connectionOfC.Open();
                    try
                    {                      
                        SqlCommand findRentContract = new SqlCommand("Find_RentContract", connectionOfC);
                        findRentContract.CommandType = CommandType.StoredProcedure;
                        findRentContract.Parameters.AddWithValue("@p_HouseID", SqlDbType.Int).Value = houseID;
                        findRentContract.Parameters.AddWithValue("@p_StartDate", SqlDbType.Date).Value = dateTimePicker1.Value;
                        SqlDataReader reader = findRentContract.ExecuteReader();
                        table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                        
                    }
                    catch (SqlException sqlExcept)
                    {
                        MessageBox.Show(sqlExcept.Message, "SQL Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connectionOfC.Close();
                }
            }
            catch (FormatException except)
            {
                MessageBox.Show("Phai nhap ID hop le.\n" + except.Message, "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tìm hợp đông bán
        private void button2_Click(object sender, EventArgs e)
        {
            int houseID = 0;
            try
            {
                houseID = Int32.Parse(textBox2.Text);
                if (houseID < 0)
                    MessageBox.Show("ID khong duoc la be hon 1.", "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    connectionOfC.Open();
                    try
                    {
                        SqlCommand findSellContract = new SqlCommand("Find_SellContract", connectionOfC);
                        findSellContract.CommandType = CommandType.StoredProcedure;
                        findSellContract.Parameters.AddWithValue("@p_HouseID", SqlDbType.Int).Value = houseID;
                        findSellContract.Parameters.AddWithValue("@p_SellDate", SqlDbType.Date).Value = dateTimePicker2.Value;
                        SqlDataReader reader = findSellContract.ExecuteReader();
                        table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                    }
                    catch (SqlException sqlExcept)
                    {
                        MessageBox.Show(sqlExcept.Message, "SQL Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connectionOfC.Close();
                }
            }
            catch (FormatException except)
            {
                MessageBox.Show("Phai nhap ID hop le.\n" + except.Message, "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int houseID = 0;
            try
            {
                houseID = Int32.Parse(textBox3.Text);
                if (houseID < 0)
                    MessageBox.Show("ID khong duoc la be hon 1.", "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    connectionOfC.Open();
                    try
                    {                   
                        SqlCommand updateSellContract = new SqlCommand("Update_SellContract", connectionOfC);
                        updateSellContract.CommandType = CommandType.StoredProcedure;
                        updateSellContract.Parameters.AddWithValue("@p_HouseID", SqlDbType.Int).Value = houseID;
                        updateSellContract.Parameters.AddWithValue("@p_SellDate", SqlDbType.Date).Value = dateTimePicker3.Value;
                        updateSellContract.Parameters.AddWithValue("@p_NewSellDate", SqlDbType.Date).Value = dateTimePicker4.Value;
                        SqlDataReader reader = updateSellContract.ExecuteReader();
                        table = new DataTable();
                        table.Load(reader);
                        dataGridView2.DataSource = table;
                        
                    }
                    catch (SqlException sqlExcept)
                    {
                        MessageBox.Show(sqlExcept.Message, "SQL Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connectionOfC.Close();
                }
            }
            catch (FormatException except)
            {
                MessageBox.Show("Phai nhap ID hop le.\n" + except.Message, "Input Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


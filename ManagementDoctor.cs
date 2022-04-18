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

namespace CuoiKiCDCNPM
{
    public partial class ManagementDoctor : Form
    {



        SqlConnection connect;
        SqlCommand command;
        string str = CuoiKiCDCNPM.Properties.Resources.connectString;
        //string str = "Data Source=MSI\SQLEXPRESS;Initial Catalog=cuoikicd;Persist Security Info=True;User ID=sa;Password=123456";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ManagementDoctor()
        {
            InitializeComponent();
        }

        void Loaddata_nhanvien()
        {
            command = connect.CreateCommand();
            command.CommandText = "select * from hosonhanvien ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvNhanVien.DataSource = table;

        }

        private void ManagementDoctor_Load(object sender, EventArgs e)
        {
            this.hosonhanvienTableAdapter1.Fill(this.cuoikicdDataSet1.hosonhanvien);
            connect = new SqlConnection(str);
            connect.Open();

            Loaddata_nhanvien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn Lưu những thông tin vừa sửa đổi không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Nhập thiếu tên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                else if (txtGioiTinh.Text == "")
                {
                    MessageBox.Show("Nhập thiếu giới tính nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGioiTinh.Focus();
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập thiếu CMND nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND.Focus();
                }
                else if (txtQuocTich.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Quốc tịch nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuocTich.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Nhập thiếu SĐT nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Địa Chỉ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Email nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else if (txtChuyenMon.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chuyên môn nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChuyenMon.Focus();
                }
                else if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Khoa nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();
                }
                else if (txtTrinhDoNgoaiNgu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ Ngoại Ngữ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrinhDoNgoaiNgu.Focus();
                }
                else if (txtHeSoLuong.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Hệ số lương nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHeSoLuong.Focus();
                }
                else if (txtTenTrinhDo.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTrinhDo.Focus();
                }
                else if (txtDang.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin Đảng viên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDang.Focus();
                }
                else if (txtChucVu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chức vụ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChucVu.Focus();
                }
                else
                {
                    command = connect.CreateCommand();
                    command.CommandText = "update hosonhanvien set chuyenmon = '" + txtChuyenMon.Text + "', " +
                                                    "khoa =  '" + txtKhoa.Text + "', " +
                                                    "ngaysinh = '" + dtpNgaySinh.Text + "'," +
                                                    "diachi ='" + txtDiaChi.Text + "'," +
                                                    "socmnd ='" + txtCMND.Text + "'," +
                                                    "hesoluong ='" + txtHeSoLuong.Text + "'," +
                                                    "tentrinhdo ='" + txtTenTrinhDo.Text + "'," +
                                                    "dang ='" + txtDang.Text + "'," +
                                                    "chucvu ='" + txtChucVu.Text + "'," +
                                                    "hoten ='" + txtHoTen.Text + "'," +
                                                    "gioitinh ='" + txtGioiTinh.Text + "'," +
                                                    "sdt ='" + txtSDT.Text + "'," +
                                                    "trinhdonn ='" + txtTrinhDoNgoaiNgu.Text + "'," +
                                                    "quoctich ='" + txtQuocTich.Text + "'," +
                                                    "email ='" + txtEmail.Text + "'" +
                                                    "where idnhanvien = '" + txtIDNhanVien.Text + "'";
                    command.ExecuteNonQuery();
                    Loaddata_nhanvien();

                }
            }
            else
            {
                MessageBox.Show("Đã hủy tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Loaddata_nhanvien();
        }

        /*private void btnThem_Click(object sender, EventArgs e)
        {
            *//*SqlDataAdapter dacheck = new SqlDataAdapter("select idnhanvien from hosonhanvien where idnhanvien = '" + txtIDNhanVien.Text + "' and idnhanvien_user= '" + txtIdUser", connect);
            DataTable dtcheck = new DataTable();
            dacheck.Fill(dtcheck);*//*
            DialogResult result = MessageBox.Show("Bạn có muốn THÊM không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Nhập thiếu tên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                else if (txtGioiTinh.Text == "")
                {
                    MessageBox.Show("Nhập thiếu giới tính nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGioiTinh.Focus();
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập thiếu CMND nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND.Focus();
                }
                else if (txtQuocTich.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Quốc tịch nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuocTich.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Nhập thiếu SĐT nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Địa Chỉ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Email nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else if (txtChuyenMon.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chuyên môn nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChuyenMon.Focus();
                }
                else if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Khoa nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();
                }
                else if (txtTrinhDoNgoaiNgu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ Ngoại Ngữ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrinhDoNgoaiNgu.Focus();
                }
                else if (txtHeSoLuong.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Hệ số lương nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHeSoLuong.Focus();
                }
                else if (txtTenTrinhDo.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTrinhDo.Focus();
                }
                else if (txtDang.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin Đảng viên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDang.Focus();
                }
                else if (txtChucVu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chức vụ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChucVu.Focus();
                }
                else
                {
                    command = connect.CreateCommand();
                    command.CommandText = "insert into hosonhanvien values ( '" + txtChuyenMon.Text + "'," + "'" + txtKhoa.Text + "'," + "'" + dtpNgaySinh.Text + "'," + "'" + txtDiaChi.Text + "'," + "'" + txtCMND.Text + "'," + "'" + txtHeSoLuong.Text + "'," + "'" + txtTenTrinhDo.Text + "'," + "'" + txtDang.Text + "','" + txtChucVu.Text + "','" + txtHoTen.Text + "','" + txtGioiTinh.Text + "','" + txtSDT.Text + "' ,'" + txtTrinhDoNgoaiNgu.Text + "' ,'" + txtQuocTich.Text + "' ,'" + txtEmail.Text + "')";
                    command.ExecuteNonQuery();
                    Loaddata_nhanvien();

                }
            }
            else
            {
                MessageBox.Show("Đã hủy tác vụ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        private void btnSua_1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn SỬA không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Nhập thiếu tên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                else if (txtGioiTinh.Text == "")
                {
                    MessageBox.Show("Nhập thiếu giới tính nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGioiTinh.Focus();
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập thiếu CMND nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND.Focus();
                }
                else if (txtQuocTich.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Quốc tịch nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuocTich.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Nhập thiếu SĐT nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Địa Chỉ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Email nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else if (txtChuyenMon.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chuyên môn nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChuyenMon.Focus();
                }
                else if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Khoa nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();
                }
                else if (txtTrinhDoNgoaiNgu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ Ngoại Ngữ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrinhDoNgoaiNgu.Focus();
                }
                else if (txtHeSoLuong.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Hệ số lương nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHeSoLuong.Focus();
                }
                else if (txtTenTrinhDo.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTrinhDo.Focus();
                }
                else if (txtDang.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin Đảng viên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDang.Focus();
                }
                else if (txtChucVu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chức vụ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChucVu.Focus();
                }
                else
                {
                    command = connect.CreateCommand();
                    command.CommandText = "update hosonhanvien set chuyenmon = '" + txtChuyenMon.Text + "', " +
                                                    "khoa =  '" + txtKhoa.Text + "', " +
                                                    "ngaysinh = '" + dtpNgaySinh.Text + "'," +
                                                    "diachi ='" + txtDiaChi.Text + "'," +
                                                    "socmnd ='" + txtCMND.Text + "'," +
                                                    "hesoluong ='" + txtHeSoLuong.Text + "'," +
                                                    "tentrinhdo ='" + txtTenTrinhDo.Text + "'," +
                                                    "dang ='" + txtDang.Text + "'," +
                                                    "chucvu ='" + txtChucVu.Text + "'," +
                                                    "hoten ='" + txtHoTen.Text + "'," +
                                                    "gioitinh ='" + txtGioiTinh.Text + "'," +
                                                    "sdt ='" + txtSDT.Text + "'," +
                                                    "trinhdonn ='" + txtTrinhDoNgoaiNgu.Text + "'," +
                                                    "quoctich ='" + txtQuocTich.Text + "'," +
                                                    "email ='" + txtEmail.Text + "'" +
                                                    "where idnhanvien = '" + txtIDNhanVien.Text + "'";
                    command.ExecuteNonQuery();
                    Loaddata_nhanvien();

                }
            }
            else
            {
                MessageBox.Show("Đã HỦY tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn XÓA không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                command = connect.CreateCommand();
                command.CommandText = "delete from hosonhanvien where idnhanvien = '" + txtIDNhanVien.Text + "'";
                command.ExecuteNonQuery();
                Loaddata_nhanvien();
                //countcanho();
            }
            else
            {
                MessageBox.Show("Đã HỦY tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminInterface back = new AdminInterface();
            //back.ShowDialog();
            back.Show();
        }

        private void btnLamSach_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtCMND.Text = "";
            txtQuocTich.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtChuyenMon.Text = "";
            txtTrinhDoNgoaiNgu.Text = "";
            txtDang.Text = "";
            txtChucVu.Text = "";
            txtHeSoLuong.Text = "";
            txtTenTrinhDo.Text = "";
            txtKhoa.Text = "";
            txtTimKiem.Text = "";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvNhanVien.CurrentRow.Index;
            txtIDNhanVien.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[i].Cells[10].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtGioiTinh.Text = dgvNhanVien.Rows[i].Cells[11].Value.ToString();
            txtCMND.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtQuocTich.Text = dgvNhanVien.Rows[i].Cells[14].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[i].Cells[12].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[i].Cells[15].Value.ToString();
            txtChuyenMon.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtKhoa.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            txtTrinhDoNgoaiNgu.Text = dgvNhanVien.Rows[i].Cells[13].Value.ToString();
            txtHeSoLuong.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            txtTenTrinhDo.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
            txtDang.Text = dgvNhanVien.Rows[i].Cells[8].Value.ToString();
            txtChucVu.Text = dgvNhanVien.Rows[i].Cells[9].Value.ToString();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtHeSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn SỬA không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Nhập thiếu tên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                else if (txtGioiTinh.Text == "")
                {
                    MessageBox.Show("Nhập thiếu giới tính nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGioiTinh.Focus();
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập thiếu CMND nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND.Focus();
                }
                else if (txtQuocTich.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Quốc tịch nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuocTich.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Nhập thiếu SĐT nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Địa Chỉ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Email nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else if (txtChuyenMon.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chuyên môn nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChuyenMon.Focus();
                }
                else if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Khoa nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();
                }
                else if (txtTrinhDoNgoaiNgu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ Ngoại Ngữ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrinhDoNgoaiNgu.Focus();
                }
                else if (txtHeSoLuong.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Hệ số lương nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHeSoLuong.Focus();
                }
                else if (txtTenTrinhDo.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTrinhDo.Focus();
                }
                else if (txtDang.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin Đảng viên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDang.Focus();
                }
                else if (txtChucVu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chức vụ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChucVu.Focus();
                }
                else
                {
                    command = connect.CreateCommand();
                    command.CommandText = "update hosonhanvien set chuyenmon = '" + txtChuyenMon.Text + "', " +
                                                    "khoa =  '" + txtKhoa.Text + "', " +
                                                    "ngaysinh = '" + dtpNgaySinh.Text + "'," +
                                                    "diachi ='" + txtDiaChi.Text + "'," +
                                                    "socmnd ='" + txtCMND.Text + "'," +
                                                    "hesoluong ='" + txtHeSoLuong.Text + "'," +
                                                    "tentrinhdo ='" + txtTenTrinhDo.Text + "'," +
                                                    "dang ='" + txtDang.Text + "'," +
                                                    "chucvu ='" + txtChucVu.Text + "'," +
                                                    "hoten ='" + txtHoTen.Text + "'," +
                                                    "gioitinh ='" + txtGioiTinh.Text + "'," +
                                                    "sdt ='" + txtSDT.Text + "'," +
                                                    "trinhdonn ='" + txtTrinhDoNgoaiNgu.Text + "'," +
                                                    "quoctich ='" + txtQuocTich.Text + "'," +
                                                    "email ='" + txtEmail.Text + "'" +
                                                    "where idnhanvien = '" + txtIDNhanVien.Text + "'";
                    command.ExecuteNonQuery();
                    Loaddata_nhanvien();

                }
            }
            else
            {
                MessageBox.Show("Đã HỦY tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtCMND.Text = "";
            txtQuocTich.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtChuyenMon.Text = "";
            txtTrinhDoNgoaiNgu.Text = "";
            txtDang.Text = "";
            txtChucVu.Text = "";
            txtHeSoLuong.Text = "";
            txtTenTrinhDo.Text = "";
            txtKhoa.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn XÓA không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                command = connect.CreateCommand();
                command.CommandText = "delete from hosonhanvien where idnhanvien = '" + txtIDNhanVien.Text + "'";
                command.ExecuteNonQuery();
                Loaddata_nhanvien();
                //countcanho();
            }
            else
            {
                MessageBox.Show("Đã HỦY tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminInterface back = new AdminInterface();
            //back.ShowDialog();
            back.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn SỬA không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Nhập thiếu tên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                else if (txtGioiTinh.Text == "")
                {
                    MessageBox.Show("Nhập thiếu giới tính nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGioiTinh.Focus();
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập thiếu CMND nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND.Focus();
                }
                else if (txtQuocTich.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Quốc tịch nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuocTich.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Nhập thiếu SĐT nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Địa Chỉ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Email nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else if (txtChuyenMon.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chuyên môn nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChuyenMon.Focus();
                }
                else if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Khoa nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();
                }
                else if (txtTrinhDoNgoaiNgu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ Ngoại Ngữ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrinhDoNgoaiNgu.Focus();
                }
                else if (txtHeSoLuong.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Hệ số lương nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHeSoLuong.Focus();
                }
                else if (txtTenTrinhDo.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Trình độ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTrinhDo.Focus();
                }
                else if (txtDang.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin Đảng viên nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDang.Focus();
                }
                else if (txtChucVu.Text == "")
                {
                    MessageBox.Show("Nhập thiếu Chức vụ nhân viên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChucVu.Focus();
                }
                else
                {
                    command = connect.CreateCommand();
                    command.CommandText = "update hosonhanvien set chuyenmon = '" + txtChuyenMon.Text + "', " +
                                                    "khoa =  '" + txtKhoa.Text + "', " +
                                                    "ngaysinh = '" + dtpNgaySinh.Text + "'," +
                                                    "diachi ='" + txtDiaChi.Text + "'," +
                                                    "socmnd ='" + txtCMND.Text + "'," +
                                                    "hesoluong ='" + txtHeSoLuong.Text + "'," +
                                                    "tentrinhdo ='" + txtTenTrinhDo.Text + "'," +
                                                    "dang ='" + txtDang.Text + "'," +
                                                    "chucvu ='" + txtChucVu.Text + "'," +
                                                    "hoten ='" + txtHoTen.Text + "'," +
                                                    "gioitinh ='" + txtGioiTinh.Text + "'," +
                                                    "sdt ='" + txtSDT.Text + "'," +
                                                    "trinhdonn ='" + txtTrinhDoNgoaiNgu.Text + "'," +
                                                    "quoctich ='" + txtQuocTich.Text + "'," +
                                                    "email ='" + txtEmail.Text + "'" +
                                                    "where idnhanvien = '" + txtIDNhanVien.Text + "'";
                    command.ExecuteNonQuery();
                    Loaddata_nhanvien();

                }
            }
            else
            {
                MessageBox.Show("Đã HỦY tác vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

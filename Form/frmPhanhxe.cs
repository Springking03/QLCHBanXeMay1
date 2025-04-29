using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBanXeMay.form
{
    public partial class frmPhanhxe : Form
    {
        public frmPhanhxe()
        {
            InitializeComponent();
        }

        private void frmPhanhxe_Load(object sender, EventArgs e)
        {
            txtMaphanh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblNSX;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaChatlieu, TenChatlieu FROM tblChatlieu";
            tblNSX = Class.Functions.getdatatotable(sql);
            dgvPhanhxe.DataSource = tblNSX;

            //do dl tu bang vao datagridview

            dgvPhanhxe.Columns[0].HeaderText = "Mã chất liệu";
            dgvPhanhxe.Columns[1].HeaderText = "Tên chất liệu";
            dgvPhanhxe.Columns[0].Width = 100;
            dgvPhanhxe.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvPhanhxe.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvPhanhxe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvPhanhxe_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaphanh.Focus();
                return;
            }
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMaphanh.Text = dgvPhanhxe.CurrentRow.Cells["MaChatlieu"].Value.ToString();
            txtTenphanh.Text = dgvPhanhxe.CurrentRow.Cells["TenChatlieu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaphanh.Enabled = true;
            txtMaphanh.Focus();
        }
        private void ResetValues()
        {
            txtMaphanh.Text = "";
            txtTenphanh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaphanh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaphanh.Focus();
                return;
            }
            if (txtTenphanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenphanh.Focus();
                return;
            }
            sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu=N'" +
            txtMaphanh.Text.Trim() + "'";
            if (Class.Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaphanh.Focus();
                txtMaphanh.Text = "";
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu,Tenchatlieu) VALUES(N'" +
            txtMaphanh.Text + "',N'" + txtTenphanh.Text + "')";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaphanh.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMaphanh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenphanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenphanh.Focus();
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" + txtTenphanh.Text.ToString() +
            "' WHERE Machatlieu=N'" + txtMaphanh.Text + "'";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                return;
            }
            if (txtMaphanh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtMaphanh.Text + "'";
                Class.Functions.Runsqldel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaphanh.Enabled = false;

        }

        private void txtMaphanh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTenphanh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



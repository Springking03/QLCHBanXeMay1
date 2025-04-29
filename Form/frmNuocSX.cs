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
    public partial class frmNuocSX : Form
    {
        public frmNuocSX()
        {
            InitializeComponent();
        }

        private void frmNuocSX_Load(object sender, EventArgs e)
        {
            txtManuocsanxuat.Enabled = false;
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
            dgvNuocsanxuat.DataSource = tblNSX;

            //do dl tu bang vao datagridview

            dgvNuocsanxuat.Columns[0].HeaderText = "Mã chất liệu";
            dgvNuocsanxuat.Columns[1].HeaderText = "Tên chất liệu";
            dgvNuocsanxuat.Columns[0].Width = 100;
            dgvNuocsanxuat.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvNuocsanxuat.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvNuocsanxuat.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNuocsanxuat_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManuocsanxuat.Focus();
                return;
            }
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtManuocsanxuat.Text = dgvNuocsanxuat.CurrentRow.Cells["MaChatlieu"].Value.ToString();
            txtTennuocsanxuat.Text = dgvNuocsanxuat.CurrentRow.Cells["TenChatlieu"].Value.ToString();
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
            txtManuocsanxuat.Enabled = true;
            txtManuocsanxuat.Focus();
        }
        private void ResetValues()
        {
            txtManuocsanxuat.Text = "";
            txtTennuocsanxuat.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManuocsanxuat.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManuocsanxuat.Focus();
                return;
            }
            if (txtTennuocsanxuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennuocsanxuat.Focus();
                return;
            }
            sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu=N'" +
            txtManuocsanxuat.Text.Trim() + "'";
            if (Class.Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManuocsanxuat.Focus();
                txtManuocsanxuat.Text = "";
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu,Tenchatlieu) VALUES(N'" +
            txtManuocsanxuat.Text + "',N'" + txtTennuocsanxuat.Text + "')";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManuocsanxuat.Enabled = false;

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
            if (txtManuocsanxuat.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennuocsanxuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennuocsanxuat.Focus();
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" + txtTennuocsanxuat.Text.ToString() +
            "' WHERE Machatlieu=N'" + txtManuocsanxuat.Text + "'";
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
            if (txtManuocsanxuat.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtManuocsanxuat.Text + "'";
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
            txtManuocsanxuat.Enabled = false;

        }

        private void txtManuocsanxuat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTennuocsanxuat_KeyUp(object sender, KeyEventArgs e)
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



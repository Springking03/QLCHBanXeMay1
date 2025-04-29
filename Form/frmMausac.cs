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
    public partial class frmMausac : Form
    {
        public frmMausac()
        {
            InitializeComponent();
        }

        private void frmMausac_Load(object sender, EventArgs e)
        {
            txtMamau.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblMausac;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaChatlieu, TenChatlieu FROM tblChatlieu";
            tblMausac = Class.Functions.getdatatotable(sql);
            dgvMausac.DataSource = tblMausac;

            //do dl tu bang vao datagridview

            dgvMausac.Columns[0].HeaderText = "Mã chất liệu";
            dgvMausac.Columns[1].HeaderText = "Tên chất liệu";
            dgvMausac.Columns[0].Width = 100;
            dgvMausac.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvMausac.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvMausac.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvMausac_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMamau.Focus();
                return;
            }
            if (tblMausac.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMamau.Text = dgvMausac.CurrentRow.Cells["MaChatlieu"].Value.ToString();
            txtTenmau.Text = dgvMausac.CurrentRow.Cells["TenChatlieu"].Value.ToString();
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
            txtMamau.Enabled = true;
            txtMamau.Focus();
        }
        private void ResetValues()
        {
            txtMamau.Text = "";
            txtTenmau.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamau.Focus();
                return;
            }
            if (txtTenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmau.Focus();
                return;
            }
            sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu=N'" +
            txtMamau.Text.Trim() + "'";
            if (Class.Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamau.Focus();
                txtMamau.Text = "";
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu,Tenchatlieu) VALUES(N'" +
            txtMamau.Text + "',N'" + txtTenmau.Text + "')";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMamau.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMausac.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmau.Focus();
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" + txtTenmau.Text.ToString() +
            "' WHERE Machatlieu=N'" + txtMamau.Text + "'";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMausac.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtMamau.Text + "'";
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
            txtMamau.Enabled = false;

        }

        private void txtMamau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTenmau_KeyUp(object sender, KeyEventArgs e)
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



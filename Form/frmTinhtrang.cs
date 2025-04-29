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
    public partial class frmTinhtrang : Form
    {
        public frmTinhtrang()
        {
            InitializeComponent();
        }

        private void frmTinhtrang_Load(object sender, EventArgs e)
        {
            txtMatinhtrang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblTinhtrang;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaChatlieu, TenChatlieu FROM tblChatlieu";
            tblTinhtrang = Class.Functions.getdatatotable(sql);
            dgvTinhtrang.DataSource = tblTinhtrang;

            //do dl tu bang vao datagridview

            dgvTinhtrang.Columns[0].HeaderText = "Mã chất liệu";
            dgvTinhtrang.Columns[1].HeaderText = "Tên chất liệu";
            dgvTinhtrang.Columns[0].Width = 100;
            dgvTinhtrang.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvTinhtrang.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvTinhtrang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvTinhtrang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatinhtrang.Focus();
                return;
            }
            if (tblTinhtrang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMatinhtrang.Text = dgvTinhtrang.CurrentRow.Cells["MaChatlieu"].Value.ToString();
            txtTentinhtrang.Text = dgvTinhtrang.CurrentRow.Cells["TenChatlieu"].Value.ToString();
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
            txtMatinhtrang.Enabled = true;
            txtMatinhtrang.Focus();
        }
        private void ResetValues()
        {
            txtMatinhtrang.Text = "";
            txtTentinhtrang.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatinhtrang.Focus();
                return;
            }
            if (txtTentinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentinhtrang.Focus();
                return;
            }
            sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu=N'" +
            txtMatinhtrang.Text.Trim() + "'";
            if (Class.Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatinhtrang.Focus();
                txtMatinhtrang.Text = "";
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu,Tenchatlieu) VALUES(N'" +
            txtMatinhtrang.Text + "',N'" + txtTentinhtrang.Text + "')";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMatinhtrang.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTinhtrang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTentinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentinhtrang.Focus();
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" + txtTentinhtrang.Text.ToString() +
            "' WHERE Machatlieu=N'" + txtMatinhtrang.Text + "'";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTinhtrang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                return;
            }
            if (txtMatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtMatinhtrang.Text + "'";
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
            txtMatinhtrang.Enabled = false;

        }

        private void txtMatinhtrang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTentinhtrang_KeyUp(object sender, KeyEventArgs e)
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



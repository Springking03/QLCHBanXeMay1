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
    public partial class frmDongco : Form
    {
        public frmDongco()
        {
            InitializeComponent();
        }

        private void frmDongco_Load(object sender, EventArgs e)
        {
            txtMadongco.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblDongco;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaChatlieu, TenChatlieu FROM tblChatlieu";
            tblDongco = Class.Functions.getdatatotable(sql);
            dgvDongco.DataSource = tblDongco;

            //do dl tu bang vao datagridview

            dgvDongco.Columns[0].HeaderText = "Mã chất liệu";
            dgvDongco.Columns[1].HeaderText = "Tên chất liệu";
            dgvDongco.Columns[0].Width = 100;
            dgvDongco.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvDongco.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvDongco.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvDongco_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMadongco.Focus();
                return;
            }
            if (tblDongco.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMadongco.Text = dgvDongco.CurrentRow.Cells["MaChatlieu"].Value.ToString();
            txtTendongco.Text = dgvDongco.CurrentRow.Cells["TenChatlieu"].Value.ToString();
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
            txtMadongco.Enabled = true;
            txtMadongco.Focus();
        }
        private void ResetValues()
        {
            txtMadongco.Text = "";
            txtTendongco.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMadongco.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMadongco.Focus();
                return;
            }
            if (txtTendongco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendongco.Focus();
                return;
            }
            sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu=N'" +
            txtMadongco.Text.Trim() + "'";
            if (Class.Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMadongco.Focus();
                txtMadongco.Text = "";
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu,Tenchatlieu) VALUES(N'" +
            txtMadongco.Text + "',N'" + txtTendongco.Text + "')";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMadongco.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDongco.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMadongco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTendongco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendongco.Focus();
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" + txtTendongco.Text.ToString() +
            "' WHERE Machatlieu=N'" + txtMadongco.Text + "'";
            Class.Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDongco.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                return;
            }
            if (txtMadongco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtMadongco.Text + "'";
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
            txtMadongco.Enabled = false;

        }

        private void txtMadongco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTendongco_KeyUp(object sender, KeyEventArgs e)
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



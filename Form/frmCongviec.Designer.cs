namespace QLCHBanXeMay.form
{
    partial class frmCongviec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTenCongViec = new System.Windows.Forms.TextBox();
            this.txtMacongviec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.qlcH_BanXeDataSet1 = new QLCHBanXeMay.QLCH_BanXeDataSet();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grvCongviec = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLuongthang = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.qlcH_BanXeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongviec)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenCongViec
            // 
            this.txtTenCongViec.Location = new System.Drawing.Point(184, 125);
            this.txtTenCongViec.Name = "txtTenCongViec";
            this.txtTenCongViec.Size = new System.Drawing.Size(100, 22);
            this.txtTenCongViec.TabIndex = 7;
            this.txtTenCongViec.TextChanged += new System.EventHandler(this.txtTenCongViec_TextChanged);
            // 
            // txtMacongviec
            // 
            this.txtMacongviec.Location = new System.Drawing.Point(184, 89);
            this.txtMacongviec.Name = "txtMacongviec";
            this.txtMacongviec.Size = new System.Drawing.Size(100, 22);
            this.txtMacongviec.TabIndex = 8;
            this.txtMacongviec.TextChanged += new System.EventHandler(this.txtMacongviec_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên công việc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã công việc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(204, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "DANH MỤC CÔNG VIỆC";
            // 
            // qlcH_BanXeDataSet1
            // 
            this.qlcH_BanXeDataSet1.DataSetName = "QLCH_BanXeDataSet";
            this.qlcH_BanXeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDong.Location = new System.Drawing.Point(681, 402);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(64, 33);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBoqua.Location = new System.Drawing.Point(566, 402);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(64, 33);
            this.btnBoqua.TabIndex = 11;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = false;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLuu.Location = new System.Drawing.Point(440, 402);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(64, 33);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSua.Location = new System.Drawing.Point(307, 402);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(64, 33);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnXoa.Location = new System.Drawing.Point(188, 402);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(64, 33);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnThem.Location = new System.Drawing.Point(60, 402);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(64, 33);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // grvCongviec
            // 
            this.grvCongviec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvCongviec.Location = new System.Drawing.Point(34, 229);
            this.grvCongviec.Name = "grvCongviec";
            this.grvCongviec.RowHeadersWidth = 51;
            this.grvCongviec.RowTemplate.Height = 24;
            this.grvCongviec.Size = new System.Drawing.Size(711, 150);
            this.grvCongviec.TabIndex = 9;
            this.grvCongviec.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvCongviec_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Lương tháng";
            // 
            // txtLuongthang
            // 
            this.txtLuongthang.Location = new System.Drawing.Point(184, 165);
            this.txtLuongthang.Name = "txtLuongthang";
            this.txtLuongthang.Size = new System.Drawing.Size(100, 22);
            this.txtLuongthang.TabIndex = 17;
            this.txtLuongthang.TextChanged += new System.EventHandler(this.txtLuongthang_TextChanged);
            // 
            // frmCongviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.txtLuongthang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenCongViec);
            this.Controls.Add(this.txtMacongviec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grvCongviec);
            this.Name = "frmCongviec";
            this.Text = "frmCongviec";
            this.Load += new System.EventHandler(this.frmCongviec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlcH_BanXeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongviec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenCongViec;
        private System.Windows.Forms.TextBox txtMacongviec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QLCH_BanXeDataSet qlcH_BanXeDataSet1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView grvCongviec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLuongthang;
    }
}
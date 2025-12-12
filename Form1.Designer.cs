namespace responsi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNama = new TextBox();
            cbProyek = new ComboBox();
            cbStatus = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            txtFitur = new TextBox();
            txtBug = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvData = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(253, 101);
            label1.Name = "label1";
            label1.Size = new Size(206, 45);
            label1.TabIndex = 0;
            label1.Text = "Meong App";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(161, 146);
            label2.Name = "label2";
            label2.Size = new Size(376, 30);
            label2.TabIndex = 1;
            label2.Text = "Developer Team Performance Tracker";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 25);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 3;
            label4.Text = "Nama Developer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 51);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 4;
            label5.Text = "Pilih Proyek";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(8, 76);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 5;
            label6.Text = "Status Kontrak";
            // 
            // txtNama
            // 
            txtNama.BackColor = SystemColors.InactiveCaption;
            txtNama.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNama.Location = new Point(145, 22);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(489, 23);
            txtNama.TabIndex = 6;
            // 
            // cbProyek
            // 
            cbProyek.BackColor = SystemColors.InactiveCaption;
            cbProyek.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProyek.FormattingEnabled = true;
            cbProyek.Location = new Point(145, 51);
            cbProyek.Name = "cbProyek";
            cbProyek.Size = new Size(489, 23);
            cbProyek.TabIndex = 7;
            // 
            // cbStatus
            // 
            cbStatus.BackColor = SystemColors.InactiveCaption;
            cbStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(145, 80);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(489, 23);
            cbStatus.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(8, 29);
            label8.Name = "label8";
            label8.Size = new Size(110, 15);
            label8.TabIndex = 10;
            label8.Text = "Jumlah Fitur Selesai";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(8, 58);
            label9.Name = "label9";
            label9.Size = new Size(69, 15);
            label9.TabIndex = 11;
            label9.Text = "Jumlah Bug";
            // 
            // txtFitur
            // 
            txtFitur.BackColor = SystemColors.InactiveCaption;
            txtFitur.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFitur.Location = new Point(145, 26);
            txtFitur.Name = "txtFitur";
            txtFitur.Size = new Size(93, 23);
            txtFitur.TabIndex = 12;
            // 
            // txtBug
            // 
            txtBug.BackColor = SystemColors.InactiveCaption;
            txtBug.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBug.Location = new Point(145, 55);
            txtBug.Name = "txtBug";
            txtBug.Size = new Size(93, 23);
            txtBug.TabIndex = 13;
            // 
            // btnInsert
            // 
            btnInsert.ForeColor = SystemColors.ControlText;
            btnInsert.Location = new Point(33, 453);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(191, 34);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(253, 453);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(203, 34);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(483, 453);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(187, 34);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvData
            // 
            dgvData.BackgroundColor = SystemColors.ActiveCaption;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(0, 31);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(640, 195);
            dgvData.TabIndex = 17;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(cbProyek);
            groupBox1.Controls.Add(txtNama);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(30, 204);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(640, 120);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data Developer";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFitur);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtBug);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(30, 340);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(640, 97);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data Kinerja";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvData);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(30, 499);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(640, 226);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Daftar Performa Tim";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(320, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(697, 753);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNama;
        private ComboBox cbProyek;
        private ComboBox cbStatus;
        private Label label8;
        private Label label9;
        private TextBox txtFitur;
        private TextBox txtBug;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvData;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private PictureBox pictureBox1;
    }
}

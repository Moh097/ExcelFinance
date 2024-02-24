namespace AppForm
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            textBox1 = new TextBox();
            txtID = new TextBox();
            label1 = new Label();
            btnPrint = new Button();
            openFileDialog1 = new OpenFileDialog();
            lblUpload = new Label();
            brnBrowse = new Button();
            txtUpload = new TextBox();
            cmbServices = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.HotTrack;
            textBox1.Location = new Point(444, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(458, 26);
            textBox1.TabIndex = 0;
            textBox1.Text = "Takween Community";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // txtID
            // 
            txtID.Location = new Point(40, 263);
            txtID.Name = "txtID";
            txtID.Size = new Size(243, 27);
            txtID.TabIndex = 3;
            txtID.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 240);
            label1.Name = "label1";
            label1.Size = new Size(229, 20);
            label1.TabIndex = 4;
            label1.Text = "Please enter the Member ID here:";
            label1.Visible = false;
            label1.Click += label1_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(184, 299);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 33);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Visible = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblUpload
            // 
            lblUpload.AutoSize = true;
            lblUpload.Location = new Point(45, 67);
            lblUpload.Name = "lblUpload";
            lblUpload.Size = new Size(193, 20);
            lblUpload.TabIndex = 6;
            lblUpload.Text = "Please upload the excel file:";
            // 
            // brnBrowse
            // 
            brnBrowse.Location = new Point(290, 91);
            brnBrowse.Name = "brnBrowse";
            brnBrowse.Size = new Size(94, 31);
            brnBrowse.TabIndex = 7;
            brnBrowse.Text = "Browse";
            brnBrowse.UseVisualStyleBackColor = true;
            brnBrowse.Click += btnBrowse_Click;
            // 
            // txtUpload
            // 
            txtUpload.Location = new Point(40, 91);
            txtUpload.Name = "txtUpload";
            txtUpload.Size = new Size(243, 27);
            txtUpload.TabIndex = 8;
            txtUpload.TextChanged += txtUpload_TextChanged;
            // 
            // cmbServices
            // 
            cmbServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServices.FormattingEnabled = true;
            cmbServices.Items.AddRange(new object[] { "الاردن", "تكوينية فلسطين", "المغرب العربي", "تكوينية سيدرا", "التكوينية المختلطة ( تقوى)", "تكوينية تركيا (اسيل)" });
            cmbServices.Location = new Point(40, 185);
            cmbServices.Name = "cmbServices";
            cmbServices.Size = new Size(238, 28);
            cmbServices.TabIndex = 10;
            cmbServices.Visible = false;
            cmbServices.SelectedIndexChanged += cmbServices_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 163);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 11;
            label3.Text = "Please choose the city:";
            label3.Visible = false;
            label3.Click += label3_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1258, 921);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cmbServices);
            Controls.Add(txtUpload);
            Controls.Add(brnBrowse);
            Controls.Add(lblUpload);
            Controls.Add(btnPrint);
            Controls.Add(txtID);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox txtID;
        private Label label1;
        private Button btnPrint;
        private OpenFileDialog openFileDialog1;
        private Label lblUpload;
        private Button brnBrowse;
        private TextBox txtUpload;
        private ComboBox cmbServices;
        private Label label3;
    }
}
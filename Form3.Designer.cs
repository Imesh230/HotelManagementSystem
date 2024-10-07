
namespace HotelManagementSystem
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_managestaff = new System.Windows.Forms.Button();
            this.btn_managepackage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // btn_managestaff
            // 
            this.btn_managestaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_managestaff.Location = new System.Drawing.Point(93, 250);
            this.btn_managestaff.Margin = new System.Windows.Forms.Padding(4);
            this.btn_managestaff.Name = "btn_managestaff";
            this.btn_managestaff.Size = new System.Drawing.Size(263, 54);
            this.btn_managestaff.TabIndex = 1;
            this.btn_managestaff.Text = "Manage Staff";
            this.btn_managestaff.UseVisualStyleBackColor = true;
            this.btn_managestaff.Click += new System.EventHandler(this.btn_managestaff_Click);
            // 
            // btn_managepackage
            // 
            this.btn_managepackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_managepackage.Location = new System.Drawing.Point(91, 365);
            this.btn_managepackage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_managepackage.Name = "btn_managepackage";
            this.btn_managepackage.Size = new System.Drawing.Size(265, 54);
            this.btn_managepackage.TabIndex = 2;
            this.btn_managepackage.Text = "Manage Package";
            this.btn_managepackage.UseVisualStyleBackColor = true;
            this.btn_managepackage.Click += new System.EventHandler(this.btn_managepackage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(135, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(431, 501);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_managepackage);
            this.Controls.Add(this.btn_managestaff);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Main Menu  as Admin";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_managestaff;
        private System.Windows.Forms.Button btn_managepackage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
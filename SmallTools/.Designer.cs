namespace SmallTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ExProduct = new System.Windows.Forms.Button();
            this.btn_ShiftStudentContract = new System.Windows.Forms.Button();
            this.txt_temp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ExProduct
            // 
            this.btn_ExProduct.Location = new System.Drawing.Point(24, 36);
            this.btn_ExProduct.Name = "btn_ExProduct";
            this.btn_ExProduct.Size = new System.Drawing.Size(157, 56);
            this.btn_ExProduct.TabIndex = 1;
            this.btn_ExProduct.Text = "创建第三方产品Sql";
            this.btn_ExProduct.UseVisualStyleBackColor = true;
            this.btn_ExProduct.Click += new System.EventHandler(this.btn_ExProduct_Click);
            // 
            // btn_ShiftStudentContract
            // 
            this.btn_ShiftStudentContract.Location = new System.Drawing.Point(365, 36);
            this.btn_ShiftStudentContract.Name = "btn_ShiftStudentContract";
            this.btn_ShiftStudentContract.Size = new System.Drawing.Size(116, 56);
            this.btn_ShiftStudentContract.TabIndex = 2;
            this.btn_ShiftStudentContract.Text = "转移学员合同 ";
            this.btn_ShiftStudentContract.UseVisualStyleBackColor = true;
            this.btn_ShiftStudentContract.Click += new System.EventHandler(this.btn_ShiftStudentContract_Click);
            // 
            // txt_temp
            // 
            this.txt_temp.AllowDrop = true;
            this.txt_temp.BackColor = System.Drawing.SystemColors.Control;
            this.txt_temp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_temp.Location = new System.Drawing.Point(24, 120);
            this.txt_temp.Multiline = true;
            this.txt_temp.Name = "txt_temp";
            this.txt_temp.ReadOnly = true;
            this.txt_temp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_temp.Size = new System.Drawing.Size(735, 298);
            this.txt_temp.TabIndex = 4;
            this.txt_temp.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_temp);
            this.Controls.Add(this.btn_ShiftStudentContract);
            this.Controls.Add(this.btn_ExProduct);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ExProduct;
        private System.Windows.Forms.Button btn_ShiftStudentContract;
        private System.Windows.Forms.TextBox txt_temp;
    }
}


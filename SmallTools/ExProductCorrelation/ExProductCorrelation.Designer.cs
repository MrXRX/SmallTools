namespace SmallTools.ExProductCorrelation
{
    partial class ExProductForm
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
            this.txt_sql = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_sql
            // 
            this.txt_sql.AllowDrop = true;
            this.txt_sql.BackColor = System.Drawing.SystemColors.Control;
            this.txt_sql.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sql.Location = new System.Drawing.Point(12, 108);
            this.txt_sql.Multiline = true;
            this.txt_sql.Name = "txt_sql";
            this.txt_sql.ReadOnly = true;
            this.txt_sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_sql.Size = new System.Drawing.Size(776, 326);
            this.txt_sql.TabIndex = 3;
            this.txt_sql.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_sql_DragDrop);
            this.txt_sql.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_sql_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(302, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "请将文件拖到窗体内";
            // 
            // ExProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_sql);
            this.Controls.Add(this.label1);
            this.Name = "ExProductForm";
            this.Text = "ExProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_sql;
        private System.Windows.Forms.Label label1;
    }
}
using SmallTools.ExProductCorrelation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmallTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 打开添加产品窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExProduct_Click(object sender, EventArgs e)
        {
            ExProductForm ExProduct = new ExProductForm();
            ExProduct.Show();
        }

        /// <summary>
        /// 转移学员合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ShiftStudentContract_Click(object sender, EventArgs e)
        {
            txt_temp.Visible = true;

            StringBuilder sb = new StringBuilder();
            sb.Append("DECLARE @newStudentId int,@oldStudentId INT,@orderId INT,@desc VARCHAR(1000) \n");
            sb.Append("SELECT @newStudentId=556134,@oldStudentId=759230,@orderId=617585,@desc='学员修改了手机号，759230转移合同556134，时间：'+CONVERT(VARCHAR,GETDATE(),21)");
        }
    }
}

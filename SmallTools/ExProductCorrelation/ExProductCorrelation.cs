using Helper;
using Model.Common;
using Model.ExProductCorrelation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmallTools.ExProductCorrelation
{
    public partial class ExProductForm : Form
    {
        public ExProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取拖拽的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_sql_DragDrop(object sender, DragEventArgs e)
        {
            //获取文件地址
            string[] fileArr = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (fileArr == null || fileArr.Length <= 0)
            {
                MessageBox.Show("请拖放文件");
                return;
            }

            //读取文件数据
            var data = ExcelHelper.GetExcelData(fileArr[0]);

            //转化产品数据
            List<ExProductModel> exList = ConvertToHelper.ConvertTo<ExProductModel>(data);

            //读取官网产品
            data = ExcelHelper.GetExcelData(SiteSetting.MatchProductPath);
            var list = ConvertToHelper.ConvertTo<KeyValueModel<string, string>>(data);

            StringBuilder sbExtend = new StringBuilder("INSERT INTO dbo.ExProduct (OutsiderType ,ExProductId , Extend1 ,Extend2 , Status ,UpdateBy ,UpdateTime , CreateBy , CreateTime ,Remark) Values \n");
            StringBuilder sbDetail = new StringBuilder("INSERT INTO dbo.ExProductDetail( ExProductId , ProductId ,Quantity , Status ,UpdateBy ,UpdateTime , CreateBy ,CreateTime,Remark ) Values \n");
            foreach (var item in exList)
            {
                var temp = list.Find(a => a.Value == item.Name);
                if (temp != null)
                {
                    sbExtend.Append($"(104,'{item.Sku}',NULL,NULL,101,NULL, NULL, NULL, GETDATE(), NULL),\n");
                    sbDetail.Append($"(1,{temp.Key},{item.Count},101,NULL,NULL,NULL,GETDATE(),NULL), \n");
                }
            }
            txt_sql.Text = sbExtend.ToString() + "\n" + sbDetail.ToString();
        }

        /// <summary>
        /// 拖拽文件到工作区时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_sql_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}

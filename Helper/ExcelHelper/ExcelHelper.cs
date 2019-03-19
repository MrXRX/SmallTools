using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    /// <summary>
    /// Excel帮助类
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// OLEDB方式读取Excel
        /// </summary>
        /// <param name="pathName">Excel路径</param>
        /// <param name="sheetName">工作表名，默认读取第一个有数据的工作表（至少有2列数据）</param>
        /// <returns></returns>
        public static DataTable GetExcelData(string pathName, string sheetName = "")
        {
            DataTable dt = new DataTable();
            string ConnectionString = string.Empty;
            FileInfo file = new FileInfo(pathName);
            if (!file.Exists) { throw new Exception("文件不存在"); }
            string extension = file.Extension;
            switch (extension)                          // 连接字符串
            {
                case ".xls":
                default:
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=no;IMEX=1;'";
                    break;
                case ".xlsx":
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=no;IMEX=1;'";
                    break;
            }
            OleDbConnection con = new OleDbConnection(ConnectionString);
            try
            {
                con.Open();
                if (sheetName != "")                      //若指定了工作表名
                {      //读Excel的过程中，发现dt末尾有些行是空的，所以在sql语句中加了Where 条件筛选符合要求的数据。OLEDB会自动生成列名F1,F2……Fn  
                    OleDbCommand cmd = new OleDbCommand("select * from [" + sheetName + "$] where F1 is not null ", con);
                    OleDbDataAdapter apt = new OleDbDataAdapter(cmd);
                    try
                    {
                        apt.Fill(dt);
                    }
                    catch (Exception ex) { throw new Exception("该Excel文件中未找到指定工作表名," + ex.Message); }
                    dt.TableName = sheetName;
                }
                else
                {
                    //默认读取第一个有数据的工作表
                    var tables = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { });
                    if (tables.Rows.Count == 0)
                    {
                        throw new Exception("Excel必须包含一个表");
                    }
                    foreach (DataRow row in tables.Rows)
                    {
                        string strSheetTableName = row["TABLE_NAME"].ToString();
                        //过滤无效SheetName   
                        if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                        {
                            DataTable tableColumns = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, strSheetTableName, null });
                            if (tableColumns.Rows.Count < 0)                     //工作表列数
                                continue;
                            OleDbCommand cmd = new OleDbCommand("select * from [" + strSheetTableName + "] where F1 is not null", con);
                            OleDbDataAdapter apt = new OleDbDataAdapter(cmd);
                            apt.Fill(dt);
                            dt.TableName = strSheetTableName.Replace("$", "").Replace("'", "");
                            break;
                        }
                    }
                }
                if (dt.Rows.Count < 0)
                    throw new Exception("表必须包含数据");
                //重构字段名
                DataRow headRow = dt.Rows[0];
                foreach (DataColumn c in dt.Columns)
                {
                    string headValue = (headRow[c.ColumnName] == DBNull.Value || headRow[c.ColumnName] == null) ? "" : headRow[c.ColumnName].ToString().Trim();
                    if (headValue.Length == 0)
                    {
                        throw new Exception("必须输入列标题");
                    }
                    if (dt.Columns.Contains(headValue))
                    {
                        throw new Exception("不能用重复的列标题：" + headValue);
                    }
                    c.ColumnName = headValue;
                }
                dt.Rows.RemoveAt(0);
                return dt;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="table">表数据</param>
        /// <param name="file">文件路径</param>
        public static void ExcelExport(DataTable table, string file)
        {

            string title = "";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), Encoding.Default);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
            }
            title = title.Substring(0, title.Length - 1) + "\n";
            sw.Write(title);
            foreach (DataRow row in table.Rows)
            {
                string line = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                }
                line = line.Substring(0, line.Length - 1) + "\n";
                sw.Write(line);
            }
            sw.Close();
            fs.Close();
        }
    }
}

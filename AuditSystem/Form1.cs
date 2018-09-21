using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AuditSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            #region DataGridVeiw Style
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.RowTemplate.ReadOnly = true;
            #endregion

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void importdata_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

        }

        private void cleardata_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接 
                string strcmd = "SELECT DATE(strBeginDate), DAYNAME(strBeginDate) FROM alarmeventlog GROUP BY DATE(strBeginDate),DAYNAME(strBeginDate);";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                con.Close();//关闭连接
                DisplayDataSet(listView1, ds, true);
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
                MessageBox.Show("工作表读取失败");
            }


            //this.listView1.BeginUpdate();
            //for (int i = 0; i < 1; i++)
            //{
            //    ListViewItem lvi = new ListViewItem();
               
            //    System.DateTime currentTime = System.DateTime.Now;
            //    string time = currentTime.ToString("yyyy-MM-dd hh:mm:ss:ff");
            //    lvi.SubItems.Add(time);
            //    string week = currentTime.ToString("dddd");
            //    lvi.SubItems.Add(week);
            //    this.listView1.Items.Add(lvi);
            //}
            //this.listView1.EndUpdate();

        }
        /// <summary>
        /// 显示数据集
        /// </summary>
        /// <param name="listView">要显示的ListView</param>
        /// <param name="dataSet">数据集</param>
        /// <param name="includeNo">是否包含序号</param>
        public static void DisplayDataSet(ListView listView, DataSet dataSet, bool includeNo)
        {
            if (dataSet == null)
            {
                return;
            }
            listView.Items.Clear();
            DataTable dataTable = dataSet.Tables[0];
            int rowno = 0;
            ListViewItem item;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                item = new ListViewItem();
                rowno++;
                if (includeNo)
                {
                    item.Text = rowno.ToString();
                }
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    string str = dataRow[i].ToString();
                    item.SubItems.Add(dataRow[i].ToString());
                }
                listView.Items.Add(item);
            }
        }

        string mwt;
        string mawt;
        string awt;
        string aawt;
        int mwthour;
        int mwtmin;
        int mawthour;
        int mawtmin;
        int awthour;
        int awtmin;
        int aawthour;
        int aawtmin;
        private void audittraic_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接 
                string strcmd = "SELECT * FROM `dataprocessing` ORDER BY id DESC LIMIT 1 ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                mwt = ds.Tables[0].Rows[0]["mwt"].ToString();
                mawt = ds.Tables[0].Rows[0]["mawt"].ToString();
                awt = ds.Tables[0].Rows[0]["awt"].ToString();
                aawt = ds.Tables[0].Rows[0]["aawt"].ToString();
                //string s = ds.Tables[0].Rows[0]["mwt"].ToString();
                //DateTime mwt = DateTime.ParseExact(ds.Tables[0].Rows[0]["mwt"].ToString(), "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
                MessageBox.Show("请先设置上下班时间");
            }

        }

        private void dataprocess_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接 
                string strcmd = "SELECT * FROM `dataprocessing` ORDER BY id DESC LIMIT 1 ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                mwt = ds.Tables[0].Rows[0]["mwt"].ToString();
                mawt = ds.Tables[0].Rows[0]["mawt"].ToString();
                awt = ds.Tables[0].Rows[0]["awt"].ToString();
                aawt = ds.Tables[0].Rows[0]["aawt"].ToString();
                mwthour = int.Parse(mwt.Substring(0, 2));
                mwtmin = int.Parse(mwt.Substring(3, 2));
                mawthour = int.Parse(mawt.Substring(0, 2));
                mawtmin = int.Parse(mawt.Substring(3, 2));
                awthour = int.Parse(awt.Substring(0, 2));
                awtmin = int.Parse(awt.Substring(3, 2));
                aawthour = int.Parse(aawt.Substring(0, 2));
                aawtmin = int.Parse(aawt.Substring(3, 2));
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
                MessageBox.Show("未能查到上下班时间");
            }
            comboBox1.SelectedIndex = mwthour;
            comboBox2.SelectedIndex = mwtmin;
            comboBox4.SelectedIndex = mawthour;
            comboBox3.SelectedIndex = mawtmin; 
            comboBox6.SelectedIndex = awthour;
            comboBox5.SelectedIndex = awtmin; 
            comboBox8.SelectedIndex = aawthour;
            comboBox7.SelectedIndex = aawtmin;


            
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "SELECT *,time(duration) FROM alarmeventlog_jkm_all_result_2 where time(astrBeginDate) > '"+aawt+"'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns.Remove("duration");
                dt.Columns.Remove("aresult_ID");
                dt.Columns.Remove("ajkm_ID");
                dt.Columns.Remove("bresult_ID");
                dt.Columns.Remove("bjkm_ID");
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["astrBeginDate"].ColumnName = "开始时间";
                dt.Columns["bstrEndDate"].ColumnName = "结束时间";
                dt.Columns["time(duration)"].ColumnName = "持续时间";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Filter = "文本文件|*.xml";//设置文件后缀的过滤
            if (file1.ShowDialog() == DialogResult.OK)   //如果有选择打开文件
            {
                this.Cursor = Cursors.WaitCursor;//等待
                //xml文档转csv
                int i = 0;
                StringBuilder sb = new StringBuilder();
                string strXmlPath = file1.FileName;
                XmlReader xml_reader = XmlReader.Create(strXmlPath);
                string filename = System.IO.Path.GetFileName(strXmlPath);
                StreamWriter sw = new StreamWriter("./" + filename, true);
                DateTime start = DateTime.Now;
                while (xml_reader.Read())
                {
                    if (xml_reader.NodeType == XmlNodeType.Element)
                    {
                        if (i < 1500000)
                        {
                            switch (xml_reader.Name)
                            {
                                case "ID": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strIndex": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strBeginDate": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strEndDate": xml_reader.Read();
                                    if (xml_reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        sb.Append(" ,"); i++; break;
                                    }
                                    sb.Append(xml_reader.Value + ","); i++; break;
                                case "strText": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strUniqueTime": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "AppendInfo": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "nLevel": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strSrcID": xml_reader.Read(); sb.Append(xml_reader.Value + ">>"); i++; break;
                                default: break;
                            }
                        }
                        else
                        {
                            sw.WriteLine(sb);
                            sb.Remove(0, sb.Length);
                            i = 0;
                            switch (xml_reader.Name)
                            {
                                case "ID": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strIndex": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strBeginDate": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strEndDate": xml_reader.Read();
                                    if (xml_reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        sb.Append(" ,"); i++; break;
                                    }
                                    sb.Append(xml_reader.Value + ","); i++; break;
                                case "strText": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strUniqueTime": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "AppendInfo": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "nLevel": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strSrcID": xml_reader.Read(); sb.Append(xml_reader.Value + ">>"); i++; break;
                                default: break;
                            }

                        }

                    }
                }
                sw.WriteLine(sb);
                sw.Close();

                //链接MySQL
                string connStr = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection conn = new MySqlConnection(connStr);

                //CSV上传MySQL
                MySqlBulkLoader bl = new MySqlBulkLoader(conn);
                bl.TableName = "alarmeventlog0";//alarmeventlog
                bl.FieldTerminator = ",";//区分列
                bl.LineTerminator = ">>";//区分行
                bl.FileName = "./" + filename;
                bl.NumberOfLinesToSkip = 0; //跳过的行数，一般把第一行表头去掉
                try
                {
                    conn.Open();
                    // 开始上传数据
                    int count = bl.Load();
                    Console.WriteLine(count + " lines uploaded.");
                    TimeSpan ts = DateTime.Now - start;
                    conn.Close();
                    this.Cursor = Cursors.Default;//正常状态
                    File.Delete("./" + filename);
                    MessageBox.Show("上传数据" + count + "条\r\n" + "花费时间" + ts);
                }
                catch (Exception )
                {
                    this.Cursor = Cursors.Default;//正常状态
                    MessageBox.Show("导入失败，请检查原因！");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select *, time(thisduration)from alarmeventlog_jkm_all_falsealarm";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns.Remove("jkm_all_ID");
                dt.Columns.Remove("jkm_ID");
                dt.Columns.Remove("intervaltime");
                dt.Columns.Remove("thisduration");
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["remark"].ColumnName = "标示";
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dt.Columns["time(thisduration)"].ColumnName = "持续时间";
                dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Filter = "文本文件|*.xml";//设置文件后缀的过滤
            if (file1.ShowDialog() == DialogResult.OK)   //如果有选择打开文件
            {
                this.Cursor = Cursors.WaitCursor;//等待
                //xml文档转csv
                int i = 0;
                StringBuilder sb = new StringBuilder();
                string strXmlPath = file1.FileName;
                XmlReader xml_reader = XmlReader.Create(strXmlPath);
                string filename = System.IO.Path.GetFileName(strXmlPath);
                StreamWriter sw = new StreamWriter("./" + filename, true);
                DateTime start = DateTime.Now;
                while (xml_reader.Read())
                {
                    if (xml_reader.NodeType == XmlNodeType.Element)
                    {
                        if (i < 1500000)
                        {
                            switch (xml_reader.Name)
                            {
                                case "ID": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strIndex": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strBeginDate": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strEndDate": xml_reader.Read();
                                    if (xml_reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        sb.Append(" ,"); i++; break;
                                    }
                                    sb.Append(xml_reader.Value + ","); i++; break;
                                case "strText": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strUniqueTime": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "AppendInfo": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "nLevel": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strSrcID": xml_reader.Read(); sb.Append(xml_reader.Value + ">>"); i++; break;
                                default: break;
                            }
                        }
                        else
                        {
                            sw.WriteLine(sb);
                            sb.Remove(0, sb.Length);
                            i = 0;
                            switch (xml_reader.Name)
                            {
                                case "ID": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strIndex": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strBeginDate": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strEndDate": xml_reader.Read();
                                    if (xml_reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        sb.Append(" ,"); i++; break;
                                    }
                                    sb.Append(xml_reader.Value + ","); i++; break;
                                case "strText": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strUniqueTime": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "AppendInfo": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "nLevel": xml_reader.Read(); sb.Append(xml_reader.Value + ","); i++; break;
                                case "strSrcID": xml_reader.Read(); sb.Append(xml_reader.Value + ">>"); i++; break;
                                default: break;
                            }

                        }

                    }
                }
                sw.WriteLine(sb);
                sw.Close();

                //链接MySQL
                string connStr = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection conn = new MySqlConnection(connStr);

                //CSV上传MySQL
                MySqlBulkLoader bl = new MySqlBulkLoader(conn);
                bl.TableName = "alarmeventlog0";//alarmeventlog
                bl.FieldTerminator = ",";//区分列
                bl.LineTerminator = ">>";//区分行
                bl.FileName = "./" + filename;
                bl.NumberOfLinesToSkip = 0; //跳过的行数，一般把第一行表头去掉
                try
                {
                    conn.Open();
                    // 开始上传数据
                    int count = bl.Load();
                    Console.WriteLine(count + " lines uploaded.");
                    TimeSpan ts = DateTime.Now - start;
                    conn.Close();
                    this.Cursor = Cursors.Default;//正常状态
                    File.Delete("./" + filename);
                    MessageBox.Show("上传数据" + count + "条\r\n" + "花费时间" + ts);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;//正常状态
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string ss = comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString() + ":00";
                string sx = comboBox4.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString() + ":00";
                string xs = comboBox6.SelectedItem.ToString() + ":" + comboBox5.SelectedItem.ToString() + ":00";
                string xx = comboBox8.SelectedItem.ToString() + ":" + comboBox7.SelectedItem.ToString() + ":00";

                //DateTime ssdt = DateTime.ParseExact(comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString(), "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime sxdt = DateTime.ParseExact(comboBox4.SelectedItem.ToString() + comboBox3.SelectedItem.ToString(), "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime xsdt = DateTime.ParseExact(comboBox6.SelectedItem.ToString() + comboBox5.SelectedItem.ToString(), "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime xxdt = DateTime.ParseExact(comboBox8.SelectedItem.ToString() + comboBox7.SelectedItem.ToString(), "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                //string ss = Convert.ToDateTime(ssdt).ToString("yyyy-MM-dd HH:mm:ss");
                //string sx = Convert.ToDateTime(sxdt).ToString("yyyy-MM-dd HH:mm:ss");
                //string xs = Convert.ToDateTime(xsdt).ToString("yyyy-MM-dd HH:mm:ss");
                //string xx = Convert.ToDateTime(xxdt).ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    string strcmd = "INSERT INTO dataprocessing (mwt,mawt,awt,aawt) VALUES(" + "'" + ss + "'" + "," + "'" + sx + "'" + "," + "'" + xs + "'" + "," + "'" + xx + "'" + "); ";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);//创建一个命令，但是并没有执行！使用他的方法或者调用它，那么数据库就执行了这个命令
                    int count = cmd.ExecuteNonQuery();
                    con.Close();
                    if (count != 0)
                    {
                        MessageBox.Show("数据处理完毕");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("请重试");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请填写完整");
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "SELECT *,time(duration) FROM alarmeventlog_jkm_all_result_2 where time(astrBeginDate) < '" + mwt + "'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns.Remove("duration");
                dt.Columns.Remove("aresult_ID");
                dt.Columns.Remove("ajkm_ID");
                dt.Columns.Remove("bresult_ID");
                dt.Columns.Remove("bjkm_ID");
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["astrBeginDate"].ColumnName = "开始时间";
                dt.Columns["bstrEndDate"].ColumnName = "结束时间";
                dt.Columns["time(duration)"].ColumnName = "持续时间";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;//正常状态
            panel5.Visible = false;
        }
        DataTable dt = new DataTable();
        private void button22_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "excel文件|*.xls|所有文件|*.*";//设置文件类型
            saveFile.Title = "导出数据";//设置标题
            string FileName = "";
            saveFile.AddExtension = true;//是否自动增加所辍名
            if (saveFile.ShowDialog() == DialogResult.OK)//如果点的是确定就得到文件路径
            {
                this.Cursor = Cursors.WaitCursor;//等待
                FileName = saveFile.FileName;//得到文件路径
                dataTableToCsv(dt, FileName);
                this.Cursor = Cursors.Default;//正常状态
                MessageBox.Show("导出成功");
            }
        }
        private void dataTableToCsv(DataTable table, string file)
        {
            string title = "";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            //FileStream fs1 = File.Open(file, FileMode.Open, FileAccess.Read);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
            }
            title = title.Substring(0, title.Length - 1) + "\r\n";
            sw.Write(title);
            foreach (DataRow row in table.Rows)
            {
                string line = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                }
                line = line.Substring(0, line.Length - 1) + "\r\n";
                sw.Write(line);
            }
            sw.Close();
            fs.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "SELECT *,time(duration) FROM alarmeventlog_jkm_all_result_2 where time(astrBeginDate) BETWEEN   '" + mawt + " 'and '" + awt + "'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns.Remove("duration");
                dt.Columns.Remove("aresult_ID");
                dt.Columns.Remove("ajkm_ID");
                dt.Columns.Remove("bresult_ID");
                dt.Columns.Remove("bjkm_ID");
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["astrBeginDate"].ColumnName = "开始时间";
                dt.Columns["bstrEndDate"].ColumnName = "结束时间";
                dt.Columns["time(duration)"].ColumnName = "持续时间";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "SELECT *,time(duration) FROM alarmeventlog_jkm_all_result_2 where time(astrBeginDate) BETWEEN   '" + awt + " 'and '" + aawt + "'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns.Remove("duration");
                dt.Columns.Remove("aresult_ID");
                dt.Columns.Remove("ajkm_ID");
                dt.Columns.Remove("bresult_ID");
                dt.Columns.Remove("bjkm_ID");
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["astrBeginDate"].ColumnName = "开始时间";
                dt.Columns["bstrEndDate"].ColumnName = "结束时间";
                dt.Columns["time(duration)"].ColumnName = "持续时间";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select distinct date(astrBeginDate) from alarmeventlog_jkm_all_result_2 ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["date(astrBeginDate)"].ColumnName = "无视频录像日期";
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select distinct date(astrBeginDate) from alarmeventlog_jkm_all_result_2";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                //dataGridView1.Columns["duration"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
                dt = ds.Tables[0];
                dt.Columns["date(astrBeginDate)"].ColumnName = "无视频录像日期";
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select strBeginDate,strEndDate,strText from  alarmeventlog WHERE strText like '%遮盖报警%' ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                //dataGridView1.Columns["duration"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
                dt = ds.Tables[0];
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select  strBeginDate,strEndDate,strText from  alarmeventlog WHERE strText like '%设备不在线%'  ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                //dataGridView1.Columns["duration"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
                dt = ds.Tables[0];
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select  strBeginDate,strEndDate,strText from  alarmeventlog WHERE strText like '%枪库_移动侦测%'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;
                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select distinct date(strBeginDate) ,strText FROM alarmeventlog WHERE strText like '%金库大门内%'OR'%内交接间1%' ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["date(strBeginDate)"].ColumnName = "开始日期";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select * FROM alarmeventlog WHERE strText like '%安全防护门%'  ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select * FROM alarmeventlog WHERE strText like '%安全防护门% ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集                
                dt = ds.Tables[0];
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select  strBeginDate,strEndDate,strText from  alarmeventlog WHERE strText like '%枪库_移动侦测%'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集               
                dt = ds.Tables[0];
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "select * FROM alarmeventlog WHERE strText like '%守卫值班室门内%' ";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }
            catch (Exception)
            {
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
            this.Cursor = Cursors.WaitCursor;//等待
            DateTime start = DateTime.Now;
            string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
            MySqlConnection con = new MySqlConnection(str);//实例化链接
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand("procedure1", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            con.Close();
            TimeSpan ts = DateTime.Now - start;
            this.Cursor = Cursors.Default;//正常状态
            MessageBox.Show("数据刷新成功！\r\n" + "花费时间" + ts);
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;//正常状态
                MessageBox.Show("数据刷新失败，请重试！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {


        }

        private void comboBox15_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            if(comboBox15.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox14_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            if (comboBox14.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox19_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            if (comboBox19.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox18_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            if (comboBox18.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox21_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox21.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox20_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox20.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox10_TextChanged_1(object sender, EventArgs e)
        {
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox10.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox17_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox17.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox16_TextChanged_1(object sender, EventArgs e)
        {
            comboBox9.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox12.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox16.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox9_TextChanged_1(object sender, EventArgs e)
        {
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox9.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox12_TextChanged_1(object sender, EventArgs e)
        {
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox12.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void comboBox11_TextChanged_1(object sender, EventArgs e)
        {
            comboBox14.Enabled = false;
            comboBox15.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox20.Enabled = false;
            comboBox21.Enabled = false;
            comboBox18.Enabled = false;
            comboBox19.Enabled = false;
            if (comboBox11.SelectedIndex == 0)
            {
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex = 0;
                comboBox11.SelectedIndex = 0;
                comboBox12.SelectedIndex = 0;

                comboBox13.SelectedIndex = 0;

                comboBox14.SelectedIndex = 0;
                comboBox15.SelectedIndex = 0;
                comboBox16.SelectedIndex = 0;
                comboBox17.SelectedIndex = 0;
                comboBox18.SelectedIndex = 0;
                comboBox19.SelectedIndex = 0;
                comboBox20.SelectedIndex = 0;
                comboBox21.SelectedIndex = 0;

                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox12.Enabled = true;

                comboBox13.Enabled = true;

                comboBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox21.Enabled = true;
            }
        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;

            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;

            comboBox13.SelectedIndex = 0;

            comboBox14.SelectedIndex = 0;
            comboBox15.SelectedIndex = 0;
            comboBox16.SelectedIndex = 0;
            comboBox17.SelectedIndex = 0;
            comboBox18.SelectedIndex = 0;
            comboBox19.SelectedIndex = 0;
            comboBox20.SelectedIndex = 0;
            comboBox21.SelectedIndex = 0;

            comboBox9.Enabled = true;
            comboBox10.Enabled = true;
            comboBox11.Enabled = true;
            comboBox12.Enabled = true;

            comboBox13.Enabled = true;

            comboBox14.Enabled = true;
            comboBox15.Enabled = true;
            comboBox16.Enabled = true;
            comboBox17.Enabled = true;
            comboBox18.Enabled = true;
            comboBox19.Enabled = true;
            comboBox20.Enabled = true;
            comboBox21.Enabled = true;
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listView1.CheckedItems)
                {
                    string s = item.SubItems[1].Text;
                    string time = Convert.ToDateTime(s).ToString("yyyyMMdd");
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;//等待
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        string strcmd = "DELETE FROM alarmeventlog where DATE(strBeginDate)=" + time + ";DELETE FROM alarmeventlog_jkm_all_falsealarm where DATE(strBeginDate)=" + time + ";DELETE FROM alarmeventlog_jkm_all_result_2 where DATE(astrBeginDate)=" + time;
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);//创建一个命令，但是并没有执行！使用他的方法或者调用它，那么数据库就执行了这个命令
                        cmd.ExecuteNonQuery();
                        con.Close();
                        this.listView1.Items.Remove(item);
                        this.Cursor = Cursors.Default;//正常状态
                    }
                    catch (Exception)
                    {
                        this.Cursor = Cursors.Default;//正常状态
                        MessageBox.Show("删除失败，请重试！");
                    }


                }
                MessageBox.Show("删除成功！");

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("★是否要删除所有工作表？", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;//等待
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    FileInfo file = new FileInfo("./clear.sql");
                    string sql = file.OpenText().ReadToEnd();
                    MySqlScript script = new MySqlScript(con);
                    script.Query = sql;
                    script.Execute();
                    con.Close();
                    MessageBox.Show("已经删除所有工作表！");
                    this.Cursor = Cursors.Default;//正常状态
                    listView1.Items.Clear();
                }
                catch (Exception)
                {
                    this.Cursor = Cursors.Default;//正常状态
                    MessageBox.Show("删除失败，请检查数据库与脚本");
                }
            }
            else if (dr == DialogResult.No)
            {
            } 
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = true;
            dataGridView1.DataSource = null;
            #region 开始之前时间查询+地点
            if (comboBox15.SelectedItem.ToString() != "" && comboBox14.SelectedItem.ToString() != "")
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string time = comboBox15.SelectedItem.ToString() + ":" + comboBox14.SelectedItem.ToString() + ":00";
                if (comboBox13.SelectedItem.ToString() != "")
                {
                    try
                    {
                        string strText = comboBox13.SelectedItem.ToString();
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接

                        string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) <'" + time + "' and  strText like '%" + strText + "%'";
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);//查询结果填充数据集
                        dt = ds.Tables[0];
                        dt.Columns["ID"].ColumnName = "序号";
                        dt.Columns["strBeginDate"].ColumnName = "开始时间";
                        dt.Columns["strEndDate"].ColumnName = "结束时间";
                        dt.Columns["strText"].ColumnName = "摄像头";
                        dataGridView1.DataSource = dt;
                        con.Close();//关闭连接
                        this.Cursor = Cursors.Default;//正常状态
                        return;
                    }
                    catch (Exception)
                    {
                    }
                }

                try
                {
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) < '" + time + "'";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);//查询结果填充数据集
                    dt = ds.Tables[0];
                    dt.Columns["ID"].ColumnName = "序号";
                    dt.Columns["strBeginDate"].ColumnName = "开始时间";
                    dt.Columns["strEndDate"].ColumnName = "结束时间";
                    dt.Columns["strText"].ColumnName = "摄像头";
                    dataGridView1.DataSource = dt;

                    con.Close();//关闭连接
                    this.Cursor = Cursors.Default;//正常状态
                }
                catch (Exception)
                {
                }
            }
            #endregion

            #region 开始之后时间查询+地点
            else if (comboBox19.SelectedItem.ToString() != "" && comboBox18.SelectedItem.ToString() != "")
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string time = comboBox19.SelectedItem.ToString() + ":" + comboBox18.SelectedItem.ToString() + ":00";
                if (comboBox13.SelectedItem.ToString() != "")
                {
                    try
                    {
                        string strText = comboBox13.SelectedItem.ToString();
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) >'" + time + " 'and  strText like '%" + strText + "%'";
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);//查询结果填充数据集
                        dt = ds.Tables[0];
                        dt.Columns["ID"].ColumnName = "序号";
                        dt.Columns["strBeginDate"].ColumnName = "开始时间";
                        dt.Columns["strEndDate"].ColumnName = "结束时间";
                        dt.Columns["strText"].ColumnName = "摄像头";
                        dataGridView1.DataSource = dt;

                        con.Close();//关闭连接
                        this.Cursor = Cursors.Default;//正常状态
                        return;
                    }
                    catch (Exception)
                    {

                    }

                }

                try
                {
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) > '" + time + "'";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);//查询结果填充数据集
                    dt = ds.Tables[0];
                    dt.Columns["ID"].ColumnName = "序号";
                    dt.Columns["strBeginDate"].ColumnName = "开始时间";
                    dt.Columns["strEndDate"].ColumnName = "结束时间";
                    dt.Columns["strText"].ColumnName = "摄像头";
                    dataGridView1.DataSource = dt;

                    con.Close();//关闭连接
                    this.Cursor = Cursors.Default;//正常状态
                }
                catch (Exception)
                {
                }
            }
            #endregion

            #region 结束之前时间查询+地点
            else if (comboBox21.SelectedItem.ToString() != "" && comboBox20.SelectedItem.ToString() != "")
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string time = comboBox21.SelectedItem.ToString() + ":" + comboBox20.SelectedItem.ToString() + ":00";
                if (comboBox13.SelectedItem.ToString() != "")
                {
                    try
                    {
                        string strText = comboBox13.SelectedItem.ToString();
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        string strcmd = "SELECT * FROM alarmeventlog where time(strEndDate) <'" + time + " 'and  strText like '%" + strText + "%'";
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);//查询结果填充数据集
                        dt = ds.Tables[0];
                        dt.Columns["ID"].ColumnName = "序号";
                        dt.Columns["strBeginDate"].ColumnName = "开始时间";
                        dt.Columns["strEndDate"].ColumnName = "结束时间";
                        dt.Columns["strText"].ColumnName = "摄像头";
                        dataGridView1.DataSource = dt;

                        con.Close();//关闭连接
                        this.Cursor = Cursors.Default;//正常状态
                        return;
                    }
                    catch (Exception)
                    {
                    }

                }

                try
                {
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    string strcmd = "SELECT * FROM alarmeventlog where time(strEndDate) < '" + time + "'";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);//查询结果填充数据集
                    dt = ds.Tables[0];
                    dt.Columns["ID"].ColumnName = "序号";
                    dt.Columns["strBeginDate"].ColumnName = "开始时间";
                    dt.Columns["strEndDate"].ColumnName = "结束时间";
                    dt.Columns["strText"].ColumnName = "摄像头";
                    dataGridView1.DataSource = dt;

                    con.Close();//关闭连接
                    this.Cursor = Cursors.Default;//正常状态
                }
                catch (Exception)
                {
                }
            }
            #endregion

            #region 结束之后时间查询+地点
            else if (comboBox17.SelectedItem.ToString() != "" && comboBox16.SelectedItem.ToString() != "")
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string time = comboBox17.SelectedItem.ToString() + ":" + comboBox16.SelectedItem.ToString() + ":00";
                if (comboBox13.SelectedItem.ToString() != "")
                {
                    try
                    {
                        string strText = comboBox13.SelectedItem.ToString();
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        string strcmd = "SELECT * FROM alarmeventlog where time(strEndDate) >'" + time + " 'and  strText like '%" + strText + "%'";
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);//查询结果填充数据集
                        dt = ds.Tables[0];
                        dt.Columns["ID"].ColumnName = "序号";
                        dt.Columns["strBeginDate"].ColumnName = "开始时间";
                        dt.Columns["strEndDate"].ColumnName = "结束时间";
                        dt.Columns["strText"].ColumnName = "摄像头";
                        dataGridView1.DataSource = dt;

                        con.Close();//关闭连接
                        this.Cursor = Cursors.Default;//正常状态
                        return;
                    }
                    catch (Exception)
                    {
                    }

                }

                try
                {
                    string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                    MySqlConnection con = new MySqlConnection(str);//实例化链接
                    con.Open();//开启连接
                    string strcmd = "SELECT * FROM alarmeventlog where time(strEndDate) > '" + time + "'";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);//查询结果填充数据集
                    dt = ds.Tables[0];
                    dt.Columns["ID"].ColumnName = "序号";
                    dt.Columns["strBeginDate"].ColumnName = "开始时间";
                    dt.Columns["strEndDate"].ColumnName = "结束时间";
                    dt.Columns["strText"].ColumnName = "摄像头";
                    dataGridView1.DataSource = dt;

                    con.Close();//关闭连接
                    this.Cursor = Cursors.Default;//正常状态
                }
                catch (Exception)
                {
                }
            }
            #endregion

            #region 时间段查询+地点
            else if (comboBox10.SelectedItem.ToString() != "" && comboBox9.SelectedItem.ToString() != "" && comboBox12.SelectedItem.ToString() != "" && comboBox11.SelectedItem.ToString() != "")
            {      
                string time1 = comboBox10.SelectedItem.ToString() + ":" + comboBox9.SelectedItem.ToString() + ":00";
                string time2 = comboBox12.SelectedItem.ToString() + ":" + comboBox11.SelectedItem.ToString() + ":00";
                if (int.Parse(comboBox10.SelectedItem.ToString()) < int.Parse(comboBox12.SelectedItem.ToString()))
                {
                    #region
                    if (comboBox13.SelectedItem.ToString() != "")
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;//等待
                            string strText = comboBox13.SelectedItem.ToString();
                            string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                            MySqlConnection con = new MySqlConnection(str);//实例化链接
                            con.Open();//开启连接
                            string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) >'" + time1 + " 'and time(strEndDate) <'" + time2 + " ' and  strText like '%" + strText + "%'";
                            MySqlCommand cmd = new MySqlCommand(strcmd, con);
                            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            ada.Fill(ds);//查询结果填充数据集
                            dt = ds.Tables[0];
                            dt.Columns["ID"].ColumnName = "序号";
                            dt.Columns["strBeginDate"].ColumnName = "开始时间";
                            dt.Columns["strEndDate"].ColumnName = "结束时间";
                            dt.Columns["strText"].ColumnName = "摄像头";
                            dataGridView1.DataSource = dt;
                            con.Close();//关闭连接
                            this.Cursor = Cursors.Default;//正常状态
                            return;
                        }
                        catch (Exception)
                        {
                            this.Cursor = Cursors.Default;//正常状态
                        }
                    }
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;//等待
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) >'" + time1 + " 'and time(strEndDate) <'" + time2 + " '";
                        MySqlCommand cmd = new MySqlCommand(strcmd, con);
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);//查询结果填充数据集
                        dt = ds.Tables[0];
                        dt.Columns["ID"].ColumnName = "序号";
                        dt.Columns["strBeginDate"].ColumnName = "开始时间";
                        dt.Columns["strEndDate"].ColumnName = "结束时间";
                        dt.Columns["strText"].ColumnName = "摄像头";
                        dataGridView1.DataSource = dt;
                        this.Cursor = Cursors.Default;//正常状态
                        con.Close();//关闭连接

                    }
                    catch (Exception)
                    {
                        this.Cursor = Cursors.Default;//正常状态
                    }
                    #endregion
                }
                else if (int.Parse(comboBox10.SelectedItem.ToString()) == int.Parse(comboBox12.SelectedItem.ToString()))
                {
                    if (int.Parse(comboBox9.SelectedItem.ToString()) < int.Parse(comboBox11.SelectedItem.ToString()))
                    {
                        #region
                        if (comboBox13.SelectedItem.ToString() != "")
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;//等待
                                string strText = comboBox13.SelectedItem.ToString();
                                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                                MySqlConnection con = new MySqlConnection(str);//实例化链接
                                con.Open();//开启连接
                                string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) >'" + time1 + " 'and time(strEndDate) <'" + time2 + " ' and  strText like '%" + strText + "%'";
                                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                ada.Fill(ds);//查询结果填充数据集
                                dt = ds.Tables[0];
                                dt.Columns["ID"].ColumnName = "序号";
                                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                                dt.Columns["strEndDate"].ColumnName = "结束时间";
                                dt.Columns["strText"].ColumnName = "摄像头";
                                dataGridView1.DataSource = dt;
                                con.Close();//关闭连接
                                this.Cursor = Cursors.Default;//正常状态
                                return;
                            }
                            catch (Exception)
                            {
                                this.Cursor = Cursors.Default;//正常状态
                            }
                        }
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;//等待
                            string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                            MySqlConnection con = new MySqlConnection(str);//实例化链接
                            con.Open();//开启连接
                            string strcmd = "SELECT * FROM alarmeventlog where time(strBeginDate) >'" + time1 + " 'and time(strEndDate) <'" + time2 + " '";
                            MySqlCommand cmd = new MySqlCommand(strcmd, con);
                            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            ada.Fill(ds);//查询结果填充数据集
                            dt = ds.Tables[0];
                            dt.Columns["ID"].ColumnName = "序号";
                            dt.Columns["strBeginDate"].ColumnName = "开始时间";
                            dt.Columns["strEndDate"].ColumnName = "结束时间";
                            dt.Columns["strText"].ColumnName = "摄像头";
                            dataGridView1.DataSource = dt;
                            this.Cursor = Cursors.Default;//正常状态
                            con.Close();//关闭连接

                        }
                        catch (Exception)
                        {
                            this.Cursor = Cursors.Default;//正常状态
                        }
                        #endregion
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;//正常状态
                        MessageBox.Show("填写有误,请检查！");
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;//正常状态
                    MessageBox.Show("填写有误,请检查！");
                }

            }
            #endregion

            #region 地点单独查询
            else if (comboBox13.SelectedItem.ToString() != "")
            {
                this.Cursor = Cursors.WaitCursor;//等待
                string strText = comboBox13.SelectedItem.ToString();
                string str = "Server=127.0.0.1;User ID=root;Password=123456;Database=rmyh;CharSet=gbk;";
                MySqlConnection con = new MySqlConnection(str);//实例化链接
                con.Open();//开启连接
                string strcmd = "SELECT * FROM alarmeventlog where strText like '%" + strText + "%'";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dt = ds.Tables[0];
                dt.Columns["ID"].ColumnName = "序号";
                dt.Columns["strBeginDate"].ColumnName = "开始时间";
                dt.Columns["strEndDate"].ColumnName = "结束时间";
                dt.Columns["strText"].ColumnName = "摄像头";
                dataGridView1.DataSource = dt;

                con.Close();//关闭连接
                this.Cursor = Cursors.Default;//正常状态
            }

            #endregion
            else
            {
                MessageBox.Show("请填写完整！");
            }
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;

            comboBox13.SelectedIndex = 0;

            comboBox14.SelectedIndex = 0;
            comboBox15.SelectedIndex = 0;
            comboBox16.SelectedIndex = 0;
            comboBox17.SelectedIndex = 0;
            comboBox18.SelectedIndex = 0;
            comboBox19.SelectedIndex = 0;
            comboBox20.SelectedIndex = 0;
            comboBox21.SelectedIndex = 0;

            comboBox9.Enabled = true;
            comboBox10.Enabled = true;
            comboBox11.Enabled = true;
            comboBox12.Enabled = true;

            comboBox13.Enabled = true;

            comboBox14.Enabled = true;
            comboBox15.Enabled = true;
            comboBox16.Enabled = true;
            comboBox17.Enabled = true;
            comboBox18.Enabled = true;
            comboBox19.Enabled = true;
            comboBox20.Enabled = true;
            comboBox21.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否初始化数据库？", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DialogResult dd = MessageBox.Show("初始化数据库会清空所有数据，确定这么做", "提醒", MessageBoxButtons.YesNo);
                if (dd == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;//等待
                        string str = "Server=127.0.0.1;User ID=root;Password=123456;CharSet=gbk;";
                        MySqlConnection con = new MySqlConnection(str);//实例化链接
                        con.Open();//开启连接
                        FileInfo file = new FileInfo("./test.sql");
                        string sql = file.OpenText().ReadToEnd();
                        MySqlScript script = new MySqlScript(con);
                        script.Query = sql;
                        script.Execute();
                        con.Close();
                        MessageBox.Show("初始化成功！");
                        this.Cursor = Cursors.Default;//正常状态
                    }
                    catch (Exception)
                    {
                        this.Cursor = Cursors.Default;//正常状态
                        MessageBox.Show("初始化失败，请检查数据库与脚本");
                    }

                }
                else if (dd == DialogResult.No)
                {
                } 
            }
            else if (dr == DialogResult.No)
            {
            } 
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }


    }
}

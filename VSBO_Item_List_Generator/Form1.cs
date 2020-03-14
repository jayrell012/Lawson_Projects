using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBO_Item_List_Generator.SQL;
using VSBO_Item_List_Generator.Model;
using System.IO;

namespace VSBO_Item_List_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Stores> listStores = new List<Stores>();
        List<Items> listItems = new List<Items>();
        List<DataGridView> dataGridViews = new List<DataGridView>();
        List<string> selectedStores = new List<string>();
        DB2Executer dB2Executer = new DB2Executer();
        query query = new query();

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Parent = this;
            panel3.BringToFront();
            panel3.Location = new Point(
                (this.Width - panel3.Width)/2
                ,(this.Height - panel3.Height)/2
                );

            this.WindowState = FormWindowState.Maximized;
            this.panel1.Visible = false;
            this.panel2.Visible = false;

            fillChecklistStores();

            btnRun_.Show();
            btnStop_.Hide();
            btnReset_.Hide();
            btnSaveExcel_.Hide();
            btnStopSaveExcel_.Hide();
        }

        private void fillChecklistStores()
        {
            listStores = new List<Stores>();

            dB2Executer = new DB2Executer();
            dB2Executer.connect();
            var data = dB2Executer.showDGV(query.listOfStrores());

            ((ListBox)checkedListBox1).DataSource = data;
            ((ListBox)checkedListBox1).DisplayMember = "STORE_NAME";
            ((ListBox)checkedListBox1).ValueMember = "STORE_ID";

            var reader = dB2Executer.Reader(query.listOfStrores());
            while(reader.Read())
            {
                Stores stores = new Stores();
                stores.storeID = reader.GetInt32(0);
                stores.storeName = reader.GetString(1);
                listStores.Add(stores);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonVisible(string activity)
        {
            switch(activity)
            {
                case "Run":
                    btnRun_.Hide();
                    btnStop_.Show();
                    btnReset_.Hide();
                    btnSaveExcel_.Hide();
                    btnStopSaveExcel_.Hide();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "Stop":
                    btnRun_.Show();
                    btnStop_.Hide();
                    btnReset_.Show();
                    btnSaveExcel_.Show();
                    btnStopSaveExcel_.Hide();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "Reset":
                    btnRun_.Show();
                    btnStop_.Hide();
                    btnReset_.Hide();
                    btnSaveExcel_.Hide();
                    btnStopSaveExcel_.Hide();
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                case "Done":
                    btnRun_.Hide();
                    btnStop_.Hide();
                    btnReset_.Show();
                    btnSaveExcel_.Show();
                    btnStopSaveExcel_.Hide();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "Excel":
                    btnRun_.Hide();
                    btnStop_.Hide();
                    btnReset_.Hide();
                    btnSaveExcel_.Hide();
                    btnStopSaveExcel_.Show();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
            }
        }

        private void addControlTab(string selectedStoreName, int count, string strSelectedStore)
        {
            try
            {
                tabControl1.TabPages.Add(selectedStoreName);
                DataGridView grid = new DataGridView() { Dock = DockStyle.Fill };
                tabControl1.TabPages[count].Controls.Add(grid);

                var filtered = listItems.Where(x => x.storeID.Equals(strSelectedStore))
                                              .Select(x =>
                                                        new
                                                        {
                                                            x.storeID,
                                                            x.storeName,
                                                            x.itemCode,
                                                            x.itemDescription,
                                                            x.barcode,
                                                            x.sellingPrice,
                                                            x.baseCost,
                                                            x.netCost,
                                                            x.averageCost,
                                                            x.department,
                                                            x.category,
                                                            x.vatType,
                                                            x.assortmentType
                                                        }
                                                      ).ToList();

                grid.DataSource = filtered;

                dataGridViews.Add(grid);

                grid.Columns[0].Visible = true;
                grid.Columns[1].Visible = true;
                grid.Columns[2].Visible = true;
                grid.Columns[3].Visible = true;
                grid.Columns[4].Visible = false;
                grid.Columns[5].Visible = false;
                grid.Columns[6].Visible = false;
                grid.Columns[7].Visible = false;
                grid.Columns[8].Visible = false;
                grid.Columns[9].Visible = false;
                grid.Columns[10].Visible = false;
                grid.Columns[11].Visible = false;
                grid.Columns[12].Visible = false;

                foreach (int checkd in checkedListBox2.CheckedIndices)
                {
                    grid.Columns[checkd + 4].Visible = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeControlTabPage()
        {
            if (tabControl1.TabCount > 1)
            {
                do
                {
                    tabControl1.TabPages.RemoveAt(1);
                } while (tabControl1.TabCount > 1); 
            }
        }

        private List<string> selectedStoresFunction()
        {
            selectedStores = new List<string>();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedStores.Add(((DataRowView)item)["STORE_ID"].ToString());
            }

            return selectedStores;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            if(panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }


        int count01 = 0;
        private void label2_Click(object sender, EventArgs e)
        {
            count01++;
            if(count01 % 2 == 0)
            {
                label2.Text = "Select All";
                for(int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            else
            {
                label2.Text = "Unselect All";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        int count02 = 0;
        private void label3_Click(object sender, EventArgs e)
        {
            count02++;
            if (count02 % 2 == 0)
            {
                label3.Text = "Select All";
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
            else
            {
                label3.Text = "Unselect All";
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dgvListCount = tabControl1.SelectedIndex - 1;

            if (tabControl1.SelectedIndex != 0)
            {
                string numRecords = dataGridViews[dgvListCount].RowCount.ToString();

                label4.Text = $"Records: {numRecords}";
            }
            else
            {
                label4.Text = $"Records: {listItems.Count}";
            }

            label1.Text = String.Format("{0}/{1} tab(s)", tabControl1.SelectedIndex + 1, tabControl1.TabCount);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            listItems = new List<Items>();

            IBM.Data.DB2.DB2DataAdapter dataAdapter = new IBM.Data.DB2.DB2DataAdapter();
            
            removeControlTabPage();

            int count = 0;
            int maxCount = selectedStoresFunction().Count;
            int percentage = 0;
            foreach (string strSelectedStore in selectedStoresFunction())
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                count++;
                DataTable dataTable = new DataTable();
                var reader = dB2Executer.Reader(String.Format(query.listOfItems(), strSelectedStore));

                while (reader.Read())
                {
                    Items items = new Items();
                    items.storeID = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    items.storeName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    items.itemCode = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    items.itemDescription = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    items.barcode = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    items.sellingPrice = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                    items.baseCost = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
                    items.netCost = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                    items.averageCost = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                    items.department = reader.IsDBNull(9) ? "" : reader.GetString(9);
                    items.category = reader.IsDBNull(10) ? "" : reader.GetString(10);
                    items.vatType = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    items.assortmentType = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    listItems.Add(items);

                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                var storeName = listStores.Where(x => x.storeID.Equals(Convert.ToInt32(strSelectedStore)))
                                          .Select(x => x.storeName).ToList();

                percentage = Convert.ToInt32( (((double)count / (double)maxCount)) * 100);

                List<object> obj = new List<object>();
                obj.Add(storeName[0]);
                obj.Add(count);
                obj.Add(strSelectedStore);

                backgroundWorker1.ReportProgress(percentage, obj);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            panel3.Visible = true;

            List<object> obj = e.UserState as List<object>;


            progressBar1.Value = e.ProgressPercentage;
            label5.Text = String.Format("{0}%\ngetting data from {1}", progressBar1.Value.ToString(), obj[0]);
            label5.Location = new Point(
                    (panel3.Width - label5.Width) / 2
                    , (panel3.Height - label5.Height) / 2
                );

            label1.Text = String.Format("{0}/{1} tab(s)",tabControl1.SelectedIndex + 1,tabControl1.TabCount);

            addControlTab(obj[0].ToString(), Convert.ToInt32(obj[1]), obj[2].ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            panel3.Visible = false;

            buttonVisible("Done");
            MessageBox.Show("Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.DataSource = listItems;
            label4.Text = $"Records: {listItems.Count}";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void reset()
        {
            buttonVisible("Reset");

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
            checkedListBox1.ClearSelected();
            checkedListBox2.ClearSelected();
            dataGridViews.Clear();
            dataGridView1.DataSource = null;
            selectedStores.Clear();
            listItems.Clear();
            while (tabControl1.TabPages.Count != 1)
            {
                tabControl1.TabPages.RemoveAt(1);
            }
            label4.Text = $"Records: 0";
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            buttonVisible("Excel");
        }

        private void btnStopSaveExcel_Click(object sender, EventArgs e)
        {
            buttonVisible("Done");
        }

        private void btnRun__Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                buttonVisible("Run");
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                button2.BackColor = Color.Crimson;
                button2.ForeColor = Color.White;
                MessageBox.Show("Select at lease one (1) store", "Incomplete Parameter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStop__Click(object sender, EventArgs e)
        {
            buttonVisible("Stop");
            backgroundWorker1.CancelAsync();
        }

        private void btnReset__Click(object sender, EventArgs e)
        {
            reset();

            label1.Text = "1/1 tab(s)";
        }

        private void btnStopSaveExcel__Click(object sender, EventArgs e)
        {
            buttonVisible("Done");
            backgroundWorker2.CancelAsync();
        }

        private void btnSaveExcel__Click(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
            {
                buttonVisible("Excel");
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }
        StringBuilder strBuild = new StringBuilder();
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int percentage = 0;
            for (int i = 0; i < dataGridViews.Count; i++)
            {
                if (backgroundWorker2.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                List<object> obj = new List<object>();
                obj.Add(i);
                obj.Add(dataGridViews[i].Rows[0].Cells[1].Value.ToString());

                percentage = Convert.ToInt32((((double)i / (double)dataGridViews.Count)) * 100);
                backgroundWorker2.ReportProgress(percentage, obj);

                strBuild = new StringBuilder();
                
            }
        }
        
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<object> list = e.UserState as List<object>;

            storeProgressBar.Visible = true;
            storeProgressBar.Value = e.ProgressPercentage;
            saveCSV(Convert.ToInt32(list[0]), list[1].ToString());
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonVisible("Done");
            storeProgressBar.Visible = false;
            MessageBox.Show("Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveCSV(int count, string storeName)
        {
            try
            {
                string cols = "";
                for (int i = 0; i < dataGridViews[count].ColumnCount; i++)
                {
                    cols += dataGridViews[count].Columns[i].HeaderText + ",";
                }
                strBuild.AppendLine(cols.TrimEnd(','));

                for (int row = 0; row < dataGridViews[count].RowCount; row++)
                {
                    string rows = "";
                    for (int col = 0; col < dataGridViews[count].ColumnCount; col++)
                    {
                        rows += dataGridView1.Rows[row].Cells[col].Value.ToString().TrimEnd() + ",";
                    }
                    strBuild.AppendLine(rows.TrimEnd(','));
                }

                File.AppendAllText(Environment.CurrentDirectory + $@"\Result\{storeName}.csv", strBuild.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private int exportingPercentage(int min, int max)
        //{
        //    int percentage = Convert.ToInt32((((double)min / (double)max)) * 100);
        //    return percentage;
        //}
    }
}

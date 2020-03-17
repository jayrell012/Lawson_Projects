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
        StringBuilder strBuild = new StringBuilder();
        FTPCon fTP = new FTPCon();
        query query = new query();
        bool boolAutomated;
        List<string> strsStoreSet = new List<string>();
        List<bool> boolFieldSet = new List<bool>();
        bool boolSaveExcel;
        string strSavePath = "";
        bool boolExitAfterRunning;

        string[] ftpCon = File.ReadAllLines(Environment.CurrentDirectory + @"\Configuration\FTPCONFIG.cfg");

        private void Form1_Load(object sender, EventArgs e)
        {
            initComp();
            fillChecklistStores();
            initializedTextConfig();

            if (boolAutomated == true)
            {
                autoSetUpDetailsBeforeRun();
                buttonVisible("Run");
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void autoSetUpDetailsBeforeRun()
        {

            //Auto Select Stores
            foreach (string str in strsStoreSet)
            {
                try
                {
                    var storeName = listStores.Where(x => x.storeID.Equals(Convert.ToInt32(str)))
                                                      .Select(x => x.storeName).ToList();

                    int index = checkedListBox1.Items.IndexOf(storeName[0]);

                    checkedListBox1.SetItemChecked(index, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + $"\n\nPossible Solution: Check if the store id:{str} is in the list of operating stores at {Environment.CurrentDirectory + @"\STORELIST.csv"} \n\nIf you click OK, this store will be disregarded", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }

            //Auto Select Details
            int count = -1;
            foreach(bool boolean in boolFieldSet)
            {
                count++;
                checkedListBox2.SetItemChecked(count, boolean);
            }


        }

        private void initComp()
        {
            panel3.Parent = this;
            panel3.BringToFront();
            panel3.Location = new Point(
                (this.Width - panel3.Width) / 2
                , (this.Height - panel3.Height) / 2
                );

            this.WindowState = FormWindowState.Maximized;
            this.panel1.Visible = false;
            this.panel2.Visible = false;

            btnRun_.Show();
            btnStop_.Hide();
            btnReset_.Hide();
            btnSaveExcel_.Hide();
            btnStopSaveExcel_.Hide();
        }

        private void fillChecklistStores()
        {
            listStores = new List<Stores>();
            string[] stores = File.ReadAllLines(Environment.CurrentDirectory + @"\STORELIST.csv");

            for (int i = 1; i < stores.Count(); i++)
            {
                Stores stor = new Stores();
                stor.storeID = Convert.ToInt32(stores[i].Split(',')[0].TrimStart().TrimEnd());
                stor.storeName = stores[i].Split(',')[1].TrimStart().TrimEnd();
                
                if (Convert.ToChar(stores[i].Split(',')[2].TrimStart().TrimEnd()) == 'A')
                {
                    listStores.Add(stor);
                }
            }

            //dB2Executer = new DB2Executer();
            //dB2Executer.connect();
            //var reader = dB2Executer.Reader(query.listOfStrores());
            //while (reader.Read())
            //{
            //    Stores stores = new Stores();
            //    stores.storeID = reader.GetInt32(0);
            //    stores.storeName = reader.GetString(1).TrimEnd();
            //    listStores.Add(stores);
            //}

            for (int i = 0; i < listStores.Count; i++)
            {
                checkedListBox1.Items.Add(listStores[i].storeName);
            }


            

            //var data = dB2Executer.showDGV(query.listOfStrores());

            //((ListBox)checkedListBox1).DataSource = listStores;
            //((ListBox)checkedListBox1).DisplayMember = "storeName";
            //((ListBox)checkedListBox1).ValueMember = "storeID";
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
                                                            x.supplier,
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
                grid.Columns[13].Visible = false;

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
            try
            {

                foreach (string str in checkedListBox1.CheckedItems)
                {
                    selectedStores.Add(listStores.Where(x => x.storeName.Equals(str)).Select(x => x.storeID).ToList()[0].ToString());
                }

                return selectedStores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @"\nin selectedStoreFunction()");

                return selectedStores;
            }
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
                dB2Executer.connect();
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
                    items.supplier = reader.IsDBNull(9) ? "NO SUPPLIER" : reader.GetString(9);
                    items.department = reader.IsDBNull(10) ? "" : reader.GetString(10);
                    items.category = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    items.vatType = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    items.assortmentType = reader.IsDBNull(13) ? "" : reader.GetString(13);
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
            panel3.Visible = false;
            this.Cursor = Cursors.Default;
            dataGridView1.DataSource = listItems;
            label4.Text = $"Records: {listItems.Count}";
            buttonVisible("Done");

            if (FTPConnection() == true)
            {
                if (boolSaveExcel == true)
                {
                    if (!backgroundWorker2.IsBusy)
                    {
                        backgroundWorker2.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Execution Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Cannot connect to FTP Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Execution Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            label2.Text = "Select All";

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }

            label3.Text = "Select All";

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
        
        private bool FTPConnection()
        {
            bool conCheck = fTP.FTPConnectionCheck(ftpCon[0], ftpCon[1], ftpCon[2]);
            return conCheck;
        }

        private void initializedTextConfig()
        {
            string alltext = File.ReadAllText(Environment.CurrentDirectory + @"\Configuration\APPCONFIG.cfg");
            string[] criteria = alltext.Split('-');
            string automated = criteria[0].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd();
            string[] storeSet = criteria[1].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd().Split('\n');
            string[] fieldSet = criteria[2].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd().Split('\n');
            string saveExcel = criteria[3].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd();
            string savePath = criteria[4].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd();
            string exitAfterRunning = criteria[5].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd();

            if (automated.TrimEnd() == "true")
            {
                boolAutomated = true;
            }
            else
            {
                boolAutomated = false;
            }

            for (int i = 0; i < fieldSet.Count(); i++)
            {
                boolFieldSet.Add(Convert.ToBoolean(fieldSet[i].TrimStart().TrimEnd().Split(':')[1].TrimStart().TrimEnd()));
            }


            if(criteria[1].TrimStart().TrimEnd().Split('=')[1].TrimStart().TrimEnd() == "*")
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                label2.Text = "Unselect All";
                count01 = 1;
            }
            else
            {
                for (int i = 0; i < storeSet.Count(); i++)
                {
                    strsStoreSet.Add(Convert.ToString(storeSet[i]));
                }
            }


            if (saveExcel.TrimEnd() == "true")
            {
                boolSaveExcel = true;
            }
            else
            {
                boolSaveExcel = false;
            }

            strSavePath = savePath.TrimStart().TrimEnd();

            if (exitAfterRunning.TrimEnd() == "true")
            {
                boolExitAfterRunning = true;
            }
            else
            {
                boolExitAfterRunning = false;
            }

            //MessageBox.Show("Automated: " + boolAutomated);
            //for (int i = 0; i < strsStoreSet.Count(); i++)
            //{
            //    MessageBox.Show("stores: " + strsStoreSet[i]);
            //}
            //for (int i = 0; i < boolFieldSet.Count(); i++)
            //{
            //    MessageBox.Show("fields: " + boolFieldSet[i]);
            //}
            //MessageBox.Show("save Excel: " + boolSaveExcel.ToString());
            //MessageBox.Show("save Path: " + strSavePath.ToString());
            //MessageBox.Show("Exit after running: " + boolExitAfterRunning.ToString());
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
            }
        }
        
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = String.Format("{0}/{1} tab(s)", tabControl1.SelectedIndex + 1, tabControl1.TabCount);
            buttonVisible("Excel");
            List<object> list = e.UserState as List<object>;

            
            //MessageBox.Show(e.ProgressPercentage.ToString());
            storeProgressBar.Visible = true;
            storeProgressBar.Value = e.ProgressPercentage;
            
            label6.Text = String.Format("Saving File {0}%", e.ProgressPercentage);
            saveCSV(Convert.ToInt32(list[0]), list[1].ToString());
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonVisible("Done");
            storeProgressBar.Visible = false;
            label6.Hide();
            TransferFileToFTPServer();

            if (boolExitAfterRunning == true)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("CSV File Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveCSV(int count, string storeName)
        {
            try
            {
                strBuild = new StringBuilder();

                DataGridView grid = new DataGridView();
                grid = dataGridViews[count];

                grid.Columns[0].Visible = false;
                grid.Columns[1].Visible = false;
                grid.Columns[2].Visible = false;
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
                grid.Columns[13].Visible = false;

                foreach (int checkd in checkedListBox2.CheckedIndices)
                {
                    grid.Columns[checkd + 4].Visible = true;
                }
                

                string cols = "";
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    if(grid.Columns[i].Visible == true)
                    {
                        cols += grid.Columns[i].HeaderText + ",";
                    }
                }
                strBuild.AppendLine(cols.TrimEnd(','));

                for (int row = 0; row < grid.RowCount; row++)
                {
                    string rows = "";
                    for (int col = 0; col < grid.ColumnCount; col++)
                    {
                        if(grid.Columns[col].Visible == true)
                        {
                            rows += grid.Rows[row].Cells[col].Value.ToString().TrimEnd() + ",";
                        }
                    }
                    strBuild.AppendLine(rows.TrimEnd(','));
                }

                try
                {
                    if(File.Exists(strSavePath + @"\" + $"{storeName}.csv"))
                    {
                        File.Delete(strSavePath + @"\" + $"{storeName}.csv");
                    }
                    File.AppendAllText(strSavePath + @"\" + $"{storeName}.csv", strBuild.ToString());

                    outputDirectory = strSavePath;
                }
                catch
                {
                    if (File.Exists(Environment.CurrentDirectory + $@"\Result\{storeName}.csv"))
                    {
                        File.Delete(Environment.CurrentDirectory + $@"\Result\{storeName}.csv");
                    }
                    File.AppendAllText(Environment.CurrentDirectory + $@"\Result\{storeName}.csv", strBuild.ToString());

                    outputDirectory = Environment.CurrentDirectory + $@"\Result";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string outputDirectory = "";

        private void TransferFileToFTPServer()
        {

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(outputDirectory);

                if (outputDirectory != "")
                {
                    foreach (FileInfo fileInfo in dirInfo.GetFiles())
                    {
                        fTP.FTP(ftpCon[0], fileInfo.Name, ftpCon[1], ftpCon[2], fileInfo.FullName);
                    }
                }
                else
                {
                    MessageBox.Show("No file has been transferred to FTP Server because the Output Directory is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel3.Parent = this;
            panel3.BringToFront();
            panel3.Location = new Point(
                (this.Width - panel3.Width) / 2
                , (this.Height - panel3.Height) / 2
                );
        }

        //private int exportingPercentage(int min, int max)
        //{
        //    int percentage = Convert.ToInt32((((double)min / (double)max)) * 100);
        //    return percentage;
        //}
    }
}

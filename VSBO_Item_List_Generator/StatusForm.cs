using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSBO_Item_List_Generator
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
        }

        public int percentage { get; set; }
        public string storeName { get; set; }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = percentage;
            label5.Text = String.Format("{0}%\ngtting data from {1}", progressBar1.Value.ToString(), storeName);
            label5.Location = new Point(
                    (panel3.Width - label5.Width) / 2
                    , (panel3.Height - label5.Height) / 2
                );
        }
    }
}

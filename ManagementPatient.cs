using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKiCDCNPM
{
    public partial class ManagementPatient : Form
    {
        int account_id;
        public ManagementPatient(int id)
        {
            InitializeComponent();
            account_id = id;
        }

        private void ManagementPatient_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            EditProfile editProfile = new EditProfile(account_id);
            editProfile.ShowDialog();
            Show();
        }

        private void ManagementPatient_Load_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Hide();
            AdminInterface adminInterface = new AdminInterface();
            adminInterface.Show();
        }
    }
}

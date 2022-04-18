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
    public partial class AdminInterface : Form
    {
        int account_id;
        public AdminInterface()
        {
            InitializeComponent();
            
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagementDoctor managementDoctor = new ManagementDoctor();
            managementDoctor.Show();
           // Show();
        }

        private void AdminInterface_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
               pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagementDoctor managementDoctor = new ManagementDoctor();
            managementDoctor.Show();
            // Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagementPatient managementPatient = new ManagementPatient(account_id);
            managementPatient.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            welcome.Show();
           
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CuoiKiCDCNPM
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string connectionString = CuoiKiCDCNPM.Properties.Resources.connectString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = " SELECT user_id FROM [user] WHERE user_username=@username AND user_password=@password";
            command.Parameters.AddWithValue("@username", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);
            con.Open();
            var result = command.ExecuteScalar();
            con.Close();
            if (result != null)
            {
                //Authenticated
                if (textBox1.Text == "admin")
                {
                    //Hide();
                    //AdminPanel adminPanel = new AdminPanel();
                    //adminPanel.ShowDialog();
                    //Show();
                    //admin Panel

                    this.Hide();
                    AdminInterface adminInterface = new AdminInterface();
                    adminInterface.Show();
                  //  Show();
                }
                else
                {
                    con.Open();
                    command.CommandText = "Select account_id, account_type FROM account WHERE account_user_id=@user_id";
                    command.Parameters.AddWithValue("@user_id", result.ToString());
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int account_id = reader.GetInt32(0);
                        int account_type = reader.GetInt32(1);
                        con.Close();
                        if (account_type == 0)
                        {
                            // Secretary Panel
                            this.Hide();
                            ManagementPatient managementPatient = new ManagementPatient(account_id);
                            managementPatient.Show();
                            //Show();
                        }
                        else if (account_type == 1)
                        {
                            //Doctor Panel
                            this.Hide();
                            DoctorPanel doctorPanel = new DoctorPanel(account_id);
                            doctorPanel.Show();
                            //Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Authentication Failed");
            }
        }




        //Keo di chuyen

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }
    }
}

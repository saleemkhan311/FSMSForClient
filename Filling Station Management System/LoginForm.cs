using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filling_Station_Management_System
{
    public partial class LoginForm : KryptonForm
    {
        public LoginForm()
        {
            InitializeComponent();
            username = UserTextBox.Text;
            this.KeyPreview = true;
        }

        public static string username { get; set; }

        private void Login()
        {

            if (UserTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty)
            {
                MessageBox.Show("All Fields Are Required", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(AppSettings.UserConString());

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE Username=@Username", con);
                    cmd.Parameters.AddWithValue("@Username", UserTextBox.Text);


                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Invalid Username", "Caution!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        reader.Read();
                        string passFromDatabase = reader.GetString("Password");

                        if (PasswordTextBox.Text == passFromDatabase)
                        {
                            MainForm main = new MainForm();
                            username = UserTextBox.Text;
                            main.username = username;


                            this.Hide();
                            main.Show();

                        }
                        else
                        {
                            MessageBox.Show("Invalid Password", "Caution!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Run Xampp Services or " + ex.Message);
                }


            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void PasswordTextBox_OnIconRightClick(object sender, EventArgs e)
        {
            if (PasswordTextBox.UseSystemPasswordChar == false)
            {
                PasswordTextBox.UseSystemPasswordChar = true;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = false;
            }
        }

        private void QuitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            PumpSelectBox.SelectedIndex = 0;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void PumpSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSettings.PumpSelect = PumpSelectBox.SelectedIndex;
        }
    }
}

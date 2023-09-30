using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Filling_Station_Management_System
{
    public partial class PasswordCheckPanel : KryptonForm
    {
        public PasswordCheckPanel()
        {
            InitializeComponent();
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection con = new MySqlConnection(AppSettings.UserConString());

                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", LoginForm.username);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string passFromDatabase = reader.GetString("Confirmation_Password");

                    if (PasswordTextBox.Text == passFromDatabase)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Password", "Caution!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("System Error", "Caution!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Caution!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PasswordCheckPanel_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
        }

        private void PasswordCheckPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
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
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

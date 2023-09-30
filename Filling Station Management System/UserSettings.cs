using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Filling_Station_Management_System
{
    public partial class UserSettings : KryptonForm
    {
        int Id;
        public UserSettings()
        {
            InitializeComponent();
            //ConfirmCheck.Hide();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowPassFalse();
            PasswordCheckBox.Checked = false;

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {


        }

        private void ConfirmPassTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == ConfirmationPassTextBox.Text)
            {
                //ConfirmCheck.Hide();
            }
            else
            {
                //ConfirmCheck.Show();
            }

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Query();
            LoadData();

        }

        void LoadData()
        {
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.UserConString());
                connection.Open();

                string sql = $"SELECT * FROM users"; // Add your WHERE clause

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                UsersDataGrid.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Data User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetLastId()
        {

            int lastId = 0;

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.UserConString());
                connection.Open();

                string Idsql = $"SELECT ID FROM users ORDER BY ID DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Idsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastId = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Get Last ID User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastId;
        }

        void Query()
        {
            Id = GetLastId() + 1;

            try
            {
                if (isFilled())
                {

                    MySqlConnection connection = new MySqlConnection(AppSettings.UserConString());
                    connection.Open();
                    string sql = $"INSERT INTO users (ID,Username,User_Type,Password,Confirmation_Password) VALUES " + "(@ID,@Username,@User_Type,@Password,@Confirmation_Password)";


                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.Parameters.AddWithValue("@Username", UserTextBox.Text);
                    cmd.Parameters.AddWithValue("@User_Type", UserTypeBox.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text);
                    cmd.Parameters.AddWithValue("@Confirmation_Password", ConfirmationPassTextBox.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Records Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Please Run Xampp Serivces /" + ex.Message, "Query User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        void ClearBox()
        {
            UserTextBox.Clear();
            PasswordTextBox.Clear();
            ConfirmationPassTextBox.Clear();
        }
        void RemoveUser()
        {
            try
            {
                if (UsersDataGrid.SelectedRows.Count > 0)
                {
                    Id = Convert.ToInt32(UsersDataGrid.SelectedRows[0].Cells[0].Value);

                    MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                    con.Open();
                    MySqlCommand cmd;

                    cmd = con.CreateCommand();

                    cmd.CommandText = $"DELETE FROM users WHERE ID=@ID;";
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error: Please Select a User to Remove ", "Remove User Users Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove User Users Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        bool isFilled()
        {
            return UserTextBox.Text != string.Empty && PasswordTextBox.Text != string.Empty;
        }

        private void ShowPassButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.UseSystemPasswordChar == false)
            {
                PasswordTextBox.UseSystemPasswordChar = true;
                //PasswordTextBox.PasswordChar=char.e;
                ConfirmationPassTextBox.UseSystemPasswordChar = true;

                UsersDataGrid.Columns["Password"].Visible = true;
            }
            else if (PasswordTextBox.UseSystemPasswordChar == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
                ConfirmationPassTextBox.UseSystemPasswordChar = false;
                UsersDataGrid.Columns["Password"].Visible = false;
            }

        }

        private void PasswordCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (PasswordCheckBox.Checked)
            {

                UsersDataGrid.Columns["Password"].Visible = true;
                UsersDataGrid.Columns["Confirmation_Password"].Visible = true;
            }
            else
            {
                UsersDataGrid.Columns["Password"].Visible = false;
                UsersDataGrid.Columns["Confirmation_Password"].Visible = false;
            }
        }

        void ShowPassFalse()
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            ConfirmationPassTextBox.UseSystemPasswordChar = true;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!isFilled()) { MessageBox.Show("All the TextBox Must be Filled"); return; }
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sql = $"UPDATE users SET Username=@Username,User_Type = @User_Type,Password=@Password,Confirmation_Password=@Confirmation_Password WHERE ID=@ID";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@ID", UsersDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@Username", UserTextBox.Text);
                cmd.Parameters.AddWithValue("@User_Type", UserTypeBox.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text);
                cmd.Parameters.AddWithValue("@Confirmation_Password", ConfirmationPassTextBox.Text);



                cmd.ExecuteNonQuery();

                MessageBox.Show("Records Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update, Users Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        private void UsersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            UserTextBox.Text = UsersDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            UserTypeBox.Text = UsersDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTextBox.Text = UsersDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            ConfirmationPassTextBox.Text = UsersDataGrid.SelectedRows[0].Cells[4].Value.ToString();
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

        private void ConfirmationPassTextBox_OnIconRightClick(object sender, EventArgs e)
        {
            if (ConfirmationPassTextBox.UseSystemPasswordChar == false)
            {
                ConfirmationPassTextBox.UseSystemPasswordChar = true;
            }
            else
            {
                ConfirmationPassTextBox.UseSystemPasswordChar = false;
            }
        }
    }
}

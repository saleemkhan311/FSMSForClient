using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System;
using System.Windows.Forms;

namespace Filling_Station_Management_System
{
    public partial class LoginForm : KryptonForm
    {
        private string outputDirectory;

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

        private void LoginButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true; // Prevent normal Enter behavior.
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       



        

        

       


        /*        private void ModifyStoredProcedure(string path)
                {


                    // Define your connection string
                    //string connectionString = "Server=localhost;Database=your_database;Uid=root;Pwd=your_password;";

                    using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                    {


                        using (MySqlConnection con = new MySqlConnection(AppSettings.ConString()))
                        {
                           *//* try
                            {*//*

                                connection.Open();
                            *//*
                                                    // Check if the procedure exists
                                                    string checkProcedureQuery = @"
                                            SELECT COUNT(*) 
                                            FROM information_schema.ROUTINES 
                                            WHERE ROUTINE_SCHEMA = 'your_database' 
                                            AND ROUTINE_NAME = 'ExportAllTablesToCSV' 
                                            AND ROUTINE_TYPE = 'PROCEDURE'";

                                                    MySqlCommand checkCmd = new MySqlCommand(checkProcedureQuery, connection);
                                                    int procedureCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                                                    // Drop the procedure if it exists
                                                   // if (procedureCount > 0)
                                                    //{
                                                    //    MySqlCommand dropCmd = new MySqlCommand("DROP PROCEDURE IF EXISTS ExportAllTablesToCSV", connection);
                                                   //     dropCmd.ExecuteNonQuery();
                                                    //}
                                                   // MySqlCommand dropCmd = new MySqlCommand("DROP PROCEDURE IF EXISTS ExportAllTablesToCSV", connection);
                                                   // dropCmd.ExecuteNonQuery(); *//*

                            string path1 = path.Replace("\\", "/");


                            string q1=$"'{path1}', tableName, '.csv'' ',\r\n                            'FIELDS TERMINATED BY '','' ENCLOSED BY ''\\\"'' LINES TERMINATED BY ''\\n'' ',\r\n                            'FROM ', tableName);";
                            string conc = @" SET @query = CONCAT('SELECT * INTO OUTFILE '" + q1;
                            string createProcedureQuery = @"
        DROP PROCEDURE IF EXISTS ExportAllTablesToCSV;

        CREATE DEFINER=`root`@`localhost` PROCEDURE `ExportAllTablesToCSV`()
        BEGIN
            DECLARE done INT DEFAULT FALSE;
            DECLARE tableName VARCHAR(255);
            DECLARE cur CURSOR FOR
                SELECT table_name FROM information_schema.tables WHERE table_schema = 'filling_station_management_system1';
            DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

            OPEN cur;

            read_loop: LOOP
                FETCH cur INTO tableName;
                IF done THEN
                    LEAVE read_loop;
                END IF;



                SET @query = CONCAT('SELECT * INTO OUTFILE ''D:/new/', tableName, '.csv'' ',
                                   'FIELDS TERMINATED BY '','' ENCLOSED BY ''""'' LINES TERMINATED BY ''\n'' ',
                                   'FROM ', tableName);

                PREPARE stmt FROM @query;
                EXECUTE stmt;
                DEALLOCATE PREPARE stmt;
            END LOOP;

            CLOSE cur;
        END;";
                                MessageBox.Show(createProcedureQuery);
                                MySqlCommand createCmd = new MySqlCommand(createProcedureQuery, connection);
                                createCmd.ExecuteNonQuery();

                                MessageBox.Show("Stored procedure modified successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            *//*}
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred: {ex.Message}", "Error Po", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }*//*
                        }
                    }



                }*/
    }
}
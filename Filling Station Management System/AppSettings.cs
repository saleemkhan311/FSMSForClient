using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filling_Station_Management_System
{
    internal class AppSettings
    {
        public static int PumpSelect;
        public static string ConString()
        {
            string connectString = $"server=localhost;Database=filling_station_management_system{PumpSelect + 1};Uid=root;Pwd=''";

            return connectString;
        }

        public static string UserConString()
        {
            return "server=localhost;Database=filling_station_management_system1;Uid=root;Pwd=''";
        }


        public static string ValidateTextBoxForNumbers(BunifuTextBox textBox)
        {
            string text = textBox.Text;

            // Use a regular expression to check if the text contains numbers
            if (Regex.IsMatch(text, @"\d"))
            {
                // If it contains numbers, clear the TextBox and show a MessageBox
                textBox.Clear();
                MessageBox.Show("Invalid Entry: Contains numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the original text (even if it's cleared)
            return text;
        }

        public static string ValidateTextBoxForAlphabets(BunifuTextBox textBox)
        {
            string text = textBox.Text;


            if (Regex.IsMatch(text, "[a-zA-Z]"))
            {

                textBox.Clear();
                MessageBox.Show("Invalid Entry: Contains alphabets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return text;
        }

        public static Func<string, double> convertToDouble = (input) =>
        {
            double result;
            if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out result))
            {
                return 0.0;
            }
            else
            {
                return result;
            }
        };

        public static string RoundToString(double value, int decimals)
        {

            return Math.Round(value, decimals).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catshop
{
    public partial class formLogin: Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
        
        public string Username
        {
            get { return textUsername.Text; }
            set { textUsername.Text = value; }
        }

        public string Password
        {
            get { return textPassword.Text; }
            set { textPassword.Text = value; }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            formReg fr = new formReg();
            fr.Show();
        }
        private bool ValidateData()
        {
            string message = "";
            bool allOK = true;
            if (textUsername.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Username" + "\r\n";
                textUsername.Focus();
                allOK = false;
            }

            if (textPassword.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Password" + "\r\n";
                textPassword.Focus();
                allOK = false;
            }
            if (!allOK)
            {
                MessageBox.Show(message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return allOK;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string pass = textPassword.Text;

            if (!ValidateData())
            {
                return;
            }
            if (ValidateLogin(username, pass))
            {
                SqlConnection cnn;
                const string ConName = "ConnectionString.ini";
                string ConString = (ConString = File.ReadAllText(ConName, Encoding.GetEncoding("Windows-874")));
                using (cnn = new SqlConnection(ConString))
                {
                    cnn.Open();
                    string strSQL = "SELECT Position, Status FROM Customer WHERE Username = @Username AND Password = @Password " +
                                    "UNION ALL SELECT Position, NULL AS Status FROM Employee WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(strSQL, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Username", textUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["Position"] != DBNull.Value && row["Position"] != null && row["Position"].ToString().ToLower() == "employee")
                                {
                                    formEmployee employeeForm = new formEmployee(); // ตรวจสอบ constructor
                                    employeeForm.Show();
                                    MessageBox.Show("Login สำเร็จในฐานะ employee");
                                    this.Hide();
                                }
                                else if (row["Position"] != DBNull.Value && row["Position"] != null && row["Position"].ToString().ToLower() == "customer")
                                {
                                    if (row["Status"] != DBNull.Value && row["Status"] != null && row["Status"].ToString().ToLower() == "unlock")
                                    {
                                        formCustomer.loggedInUsername = textUsername.Text;
                                        formCustomer customerForm = new formCustomer(); // ตรวจสอบ constructor
                                        customerForm.Show();
                                        MessageBox.Show("Login สำเร็จในฐานะ customer");
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("บัญชีของคุณถูกล็อค กรุณาติดต่อเจ้าหน้าที่");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Login ล้มเหลว! กรุณาตรวจสอบ username และ password");
            }
        }

        private void checkShowpass_CheckedChanged(object sender, EventArgs e)
        {
            textPassword.PasswordChar = checkShowpass.Checked ? '\0' : '*';
        }

        private bool ValidateLogin(string username, string password)
        {
            try
            {
                SqlConnection connection;
                const string _strConnStrFileName = "ConnectionString.ini";
                string _strConnectionString = (File.ReadAllText(_strConnStrFileName, Encoding.GetEncoding("Windows-874")));
                using (connection = new SqlConnection(_strConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Position, Status FROM Customer WHERE Username = @Username AND Password = @Password " +
                                   "UNION ALL SELECT Position, NULL AS Status FROM Employee WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

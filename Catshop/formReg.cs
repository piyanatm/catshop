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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Catshop
{
    public partial class formReg: Form
    {
        const string strConnstrFileName = "ConnectionString.ini";
        string _strConnection = "";
        public formReg()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(strConnstrFileName))
                    _strConnection = File.ReadAllText(strConnstrFileName,
                                                        Encoding.GetEncoding("Windows-874"));
            }
            catch (IOException ex)
            {
                MessageBox.Show("มีปัญหาในการเชื่อมต่อไฟล์สตริง " + ex.Message, "ข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
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
            if (textFName.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก First Name" + "\r\n";
                textFName.Focus();
                allOK = false;
            }
            if (textLName.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Last Name" + "\r\n";
                textLName.Focus();
                allOK = false;
            }
            if (string.IsNullOrWhiteSpace(comboGender.Text))
            {
                message += "กรุณาเลือกเพศ" + "\r\n";
                comboGender.Focus();
                allOK = false;
            }
            if (dateDOB.Value == dateDOB.MinDate)
            {
                message += "กรุณาเลือกวันที่\n";
                dateDOB.Focus();
                allOK = false;
            }
            if (textAddress.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่" + "\r\n";
                textAddress.Focus();
                allOK = false;
            }
            if (textAddressReceipt.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่สำหรับการรับ" + "\r\n";
                textAddressReceipt.Focus();
                allOK = false;
            }
            if (textPhone.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกเบอร์โทรศัพท์" + "\r\n";
                textPhone.Focus();
                allOK = false;
            }
            if (textEmail.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Email" + "\r\n";
                textEmail.Focus();
                allOK = false;
            }
            if (!allOK)
            {
                MessageBox.Show(message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return allOK;
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateData())  // ✅ หยุดทำงานหากข้อมูลไม่ครบ
            {
                return;
            }

            try
            {
                using (SqlConnection CCon = new SqlConnection(_strConnection))
                {
                    CCon.Open();

                    string strSQL = "INSERT INTO Customer (Username,Password,FName,LName,Gender,DOB,Address,AddressFRecept,Email,Phone) " +
                                    "VALUES(@Username,@Password,@FName,@LName,@Gender,@DOB,@Address,@AddressFRecept, @Email,@Phone)";
                    string strSQL2 = @"UPDATE Customer SET Position = 'Customer', Status = 'Unlock' WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(strSQL, CCon))
                    {
                        cmd.Parameters.AddWithValue("@Username", textUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                        cmd.Parameters.AddWithValue("@FName", textFName.Text);
                        cmd.Parameters.AddWithValue("@LName", textLName.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DOB", dateDOB.Value);
                        cmd.Parameters.AddWithValue("@Address", textAddress.Text);
                        cmd.Parameters.AddWithValue("@AddressFRecept", textAddressReceipt.Text);
                        cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", textPhone.Text);

                        int rowsAffected = cmd.ExecuteNonQuery(); // ✅ เช็คว่าบันทึกข้อมูลลง Database สำเร็จหรือไม่
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("บันทึกข้อมูลสำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด: ไม่สามารถบันทึกข้อมูลได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // ออกจากฟังก์ชัน
                        }
                    }

                    using (SqlCommand cmd2 = new SqlCommand(strSQL2, CCon))
                    {
                        cmd2.Parameters.AddWithValue("@Username", textUsername.Text);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // หยุดทำงานทันที
            }

            this.Hide(); // ✅ ซ่อนฟอร์มหลังจากบันทึกข้อมูลเสร็จ
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการยกเลิกใช่หรือไม่?", "ยืนยันการยกเลิก", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // ปิดฟอร์ม
            }
            else
            {
                return;
            }
        }

        private void formReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

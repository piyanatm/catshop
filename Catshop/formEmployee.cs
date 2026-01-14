using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms.VisualStyles;
using System.Net.NetworkInformation;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Catshop
{
    public partial class formEmployee : Form
    {
        const string strConnstrFileName = "ConnectionString.ini";
        string _strConnection = "";

        SqlConnection CCon;
        SqlCommand CCom;
        SqlDataAdapter CAt;
        DataTable Cdt;

        SqlConnection ECon;
        SqlCommand ECom;
        SqlDataAdapter EAt;
        DataTable Edt;

        SqlConnection PCon;
        SqlCommand PCom;
        SqlDataAdapter PAt;
        DataTable Pdt;
        SqlCommand PCom2;

        private byte[] imageData;

        string myState;

        public formEmployee()
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

        private void SetStateEm(string appState)
        {
            myState = appState;
            switch (appState)
            {
                case "View":
                    textUserEm.ReadOnly = true;
                    textPassEm.ReadOnly = true;
                    textFNEm.ReadOnly = true;
                    textLNEm.ReadOnly = true;
                    comboGenderEm.Enabled = false;
                    dateTimeDOBEm.Enabled = false;
                    textAddressEm.ReadOnly = true;
                    textEmailEm.ReadOnly = true;
                    textPhoneEm.ReadOnly = true;
                    buttonAddEm.Enabled = true;
                    buttonUpdateEm.Enabled = true;
                    buttonSaveEm.Enabled = false;
                    buttonDeleteEm.Enabled = true;
                    buttonDoneEm.Enabled = false;
                    buttonCancelEm.Enabled = false;
                    break;
                case "Add":
                    textUserEm.ReadOnly = false;
                    textPassEm.ReadOnly = false;
                    textFNEm.ReadOnly = false;
                    textLNEm.ReadOnly = false;
                    comboGenderEm.Enabled = true;
                    dateTimeDOBEm.Enabled = true;
                    textAddressEm.ReadOnly = false;
                    textEmailEm.ReadOnly = false;
                    textPhoneEm.ReadOnly = false;
                    buttonAddEm.Enabled = false;
                    buttonUpdateEm.Enabled = false;
                    buttonSaveEm.Enabled = false;
                    buttonDeleteEm.Enabled = false;
                    buttonDoneEm.Enabled = true;
                    buttonCancelEm.Enabled = true;
                    break;
                default:
                    textUserEm.ReadOnly = false;
                    textPassEm.ReadOnly = false;
                    textFNEm.ReadOnly = false;
                    textLNEm.ReadOnly = false;
                    comboGenderEm.Enabled = true;
                    dateTimeDOBEm.Enabled = true;
                    textAddressEm.ReadOnly = false;
                    textEmailEm.ReadOnly = false;
                    textPhoneEm.ReadOnly = false;
                    buttonAddEm.Enabled = false;
                    buttonUpdateEm.Enabled = false;
                    buttonSaveEm.Enabled = true;
                    buttonDeleteEm.Enabled = false;
                    buttonDoneEm.Enabled = false;
                    buttonCancelEm.Enabled = true;
                    break;

            }
        }

        private void SetStateMem(string appState)
        {
            myState = appState;
            switch (appState)
            {
                case "View":
                    textUserMem.ReadOnly = true;
                    textPassMem.ReadOnly = true;
                    textFNMem.ReadOnly = true;
                    textLNMem.ReadOnly = true;
                    comboGenderMem.Enabled = false;
                    dateTimeDOBMem.Enabled = false;
                    textAddressMem.ReadOnly = true;
                    textAddressReceipt.ReadOnly = true;
                    textEmailMem.ReadOnly = true;
                    textPhoneMem.ReadOnly = true;
                    comboStatusMem.Enabled = false;
                    buttonAddMem.Enabled = true;
                    buttonUpdateMem.Enabled = true;
                    buttonSaveMem.Enabled = false;
                    buttonDeleteMem.Enabled = true;
                    buttonDoneMem.Enabled = false;
                    buttonCancelMem.Enabled = false;
                    break;
                case "Add":
                    textUserMem.ReadOnly = false;
                    textPassMem.ReadOnly = false;
                    textFNMem.ReadOnly = false;
                    textLNMem.ReadOnly = false;
                    comboGenderMem.Enabled = true;
                    dateTimeDOBMem.Enabled = true;
                    textAddressMem.ReadOnly = false;
                    textAddressReceipt.ReadOnly = false;
                    textEmailMem.ReadOnly = false;
                    textPhoneMem.ReadOnly = false;
                    comboStatusMem.Enabled = true;
                    buttonAddMem.Enabled = false;
                    buttonUpdateMem.Enabled = false;
                    buttonSaveMem.Enabled = false;
                    buttonDeleteMem.Enabled = false;
                    buttonDoneMem.Enabled = true;
                    buttonCancelMem.Enabled = true;
                    break;
                default:
                    textUserMem.ReadOnly = false;
                    textPassMem.ReadOnly = false;
                    textFNMem.ReadOnly = false;
                    textLNMem.ReadOnly = false;
                    comboGenderMem.Enabled = true;
                    dateTimeDOBMem.Enabled = true;
                    textAddressMem.ReadOnly = false;
                    textAddressReceipt.ReadOnly = false;
                    textEmailMem.ReadOnly = false;
                    textPhoneMem.ReadOnly = false;
                    comboStatusMem.Enabled = true;
                    buttonAddMem.Enabled = false;
                    buttonUpdateMem.Enabled = false;
                    buttonSaveMem.Enabled = true;
                    buttonDeleteMem.Enabled = false;
                    buttonDoneMem.Enabled = false;
                    buttonCancelMem.Enabled = true;
                    break;

            }
        }

        private void SetStatePro(string appState)
        {
            myState = appState;
            switch (appState)
            {
                case "View":
                    textNamePro.ReadOnly = true;
                    textQuantityPro.ReadOnly = true;
                    textPricePro.ReadOnly = true;
                    textDescriptionPro.ReadOnly = true;
                    textCostPrice.ReadOnly = true;
                    comboCategories.Enabled = false;
                    comboStatusPro.Enabled = false;
                    buttonAddPro.Enabled = true;
                    buttonUpdatePro.Enabled = true;
                    buttonSavePro.Enabled = false;
                    buttonDonePro.Enabled = false;
                    buttonCancelPro.Enabled = false;
                    buttonImport.Enabled = false;
                    break;
                case "Add":
                    textNamePro.ReadOnly = false;
                    textQuantityPro.ReadOnly = false;
                    textPricePro.ReadOnly = false;
                    textDescriptionPro.ReadOnly = false;
                    textCostPrice.ReadOnly = false;
                    comboCategories.Enabled = true;
                    comboStatusPro.Enabled = true;
                    buttonAddPro.Enabled = false;
                    buttonUpdatePro.Enabled = false;
                    buttonSavePro.Enabled = false;
                    buttonDonePro.Enabled = true;
                    buttonCancelPro.Enabled = true;
                    buttonImport.Enabled = true;
                    break;
                default:
                    textNamePro.ReadOnly = false;
                    textQuantityPro.ReadOnly = false;
                    textPricePro.ReadOnly = false;
                    textDescriptionPro.ReadOnly = false;
                    textCostPrice.ReadOnly = false;
                    comboCategories.Enabled = true;
                    comboStatusPro.Enabled = true;
                    buttonAddPro.Enabled = false;
                    buttonUpdatePro.Enabled = false;
                    buttonSavePro.Enabled = true;
                    buttonDonePro.Enabled = false;
                    buttonCancelPro.Enabled = true;
                    buttonImport.Enabled = true;
                    break;

            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            formLogin fl = new formLogin();
            fl.Show();
            this.Hide();
        }

        private void formEmployee_Load(object sender, EventArgs e)
        {
            ECon = new SqlConnection(_strConnection);
            ECon.Open();
            ECom = new SqlCommand("Select * from Employee", ECon);
            EAt = new SqlDataAdapter();
            EAt.SelectCommand = ECom;
            Edt = new DataTable();
            EAt.Fill(Edt);
            dataGridEm.DataSource = Edt;
            this.Show();
            SetStateEm("View");
            ECon.Close();
            ECon.Dispose();

            CCon = new SqlConnection(_strConnection);
            CCon.Open();
            CCom = new SqlCommand("Select * from Customer", CCon);
            CAt = new SqlDataAdapter();
            CAt.SelectCommand = CCom;
            Cdt = new DataTable();
            CAt.Fill(Cdt);
            dataGridMem.DataSource = Cdt;
            this.Show();
            SetStateMem("View");

            CCon.Close();
            CCon.Dispose();

            PCon = new SqlConnection(_strConnection);
            PCon.Open();
            PCom = new SqlCommand("Select * from Catagories", PCon);
            SqlDataReader reader = PCom.ExecuteReader();
            while (reader.Read())
            {
                comboCategories.Items.Add(reader["CatagoriesName"].ToString());
                comboProductList.Items.Add(reader["CatagoriesName"].ToString());
            }
            reader.Close();
            PCon.Close();
            PCon.Dispose();

            labelAll();
            LoadTotalProductCount();
            populate();
            SetStatePro("View");
        }

        private void labelAll()
        {
            int EmCount = 0;
            int CCount = 0;
            foreach (DataGridViewRow row in dataGridEm.Rows)
            {
                if (!row.IsNewRow)
                {
                    bool isEmptyRow = true;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isEmptyRow = false;
                            break;
                        }
                    }

                    if (!isEmptyRow)
                    {
                        EmCount++;
                    }
                }
            }
            labelEm.Text = EmCount.ToString();

            foreach (DataGridViewRow row in dataGridMem.Rows)
            {
                if (!row.IsNewRow)
                {
                    bool isEmptyRow = true;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isEmptyRow = false;
                            break;
                        }
                    }

                    if (!isEmptyRow)
                    {
                        CCount++;
                    }
                }
            }
            labelMem.Text = CCount.ToString();
        }

        private void LoadTotalProductCount()
        {
            PCon = new SqlConnection(_strConnection);
            string sql = "SELECT COUNT(*) FROM Product";
            string sql2 = "SELECT COUNT(*) FROM Product WHERE Status = 'Show'";
            PCom = new SqlCommand(sql, PCon);
            PCom2 = new SqlCommand(sql2, PCon);
            try
            {
                PCon.Open();
                int productCount = (int)PCom.ExecuteScalar();
                labelPro.Text = productCount.ToString();
                int productCountShow = (int)PCom2.ExecuteScalar();
                labelProSale.Text = productCountShow.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PCon.Close();
        }

        private void buttonAddEm_Click(object sender, EventArgs e)
        {
            SetStateEm("Add");
        }

        private void buttonUpdateEm_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, true, false))
            {
                return;
            }
            SetStateEm("Update");
        }

        private void buttonSaveEm_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, true, false))
            {
                return;
            }
            try
            {

                using (ECon = new SqlConnection(_strConnection))
                {
                    ECon.Open();
                    string Gender = comboGenderEm.SelectedItem.ToString();
                    DateTime selectedDateTime = dateTimeDOBEm.Value;
                    DataGridViewRow selectedRow = dataGridEm.SelectedRows[0];
                    string SQLUpdate = "UPDATE Employee SET Username = @Username , Password = @Password, " +
                        "FName = @FName, LName = @LName,Gender = @Gender,DOB = @DOB, Address = @Address, " +
                        "Email = @Email ,Phone = @Phone WHERE EmployeeID = '" + selectedRow.Cells["EmployeeID"].Value.ToString() + "'";

                    using (SqlCommand cmd = new SqlCommand(SQLUpdate, ECon))
                    {
                        cmd.Parameters.AddWithValue("@Username", textUserEm.Text);
                        cmd.Parameters.AddWithValue("@Password", textPassEm.Text);
                        cmd.Parameters.AddWithValue("@FName", textFNEm.Text);
                        cmd.Parameters.AddWithValue("@LName", textLNEm.Text);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", selectedDateTime);
                        cmd.Parameters.AddWithValue("@Address", textAddressEm.Text);
                        cmd.Parameters.AddWithValue("@Email", textEmailEm.Text);
                        cmd.Parameters.AddWithValue("@Phone", textPhoneEm.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ข้อมูลถูกบันทึกแล้ว", "บันทึก",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridEm.DataSource = Edt;
                    }
                    ECon.Close();
                    ECon.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStateEm("View");
        }

        private void buttonDeleteEm_Click(object sender, EventArgs e)
        {
            if (dataGridEm.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridEm.SelectedRows[0];
                string employeeID = selectedRow.Cells["EmployeeID"].Value.ToString();

                ECon = new SqlConnection(_strConnection);
                ECon.Open();
                string sql = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, ECon))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.ExecuteNonQuery();
                    }

                    dataGridEm.Rows.Remove(selectedRow);
                    ECon.Close();
                    ECon.Dispose();
                    textUserEm.Text = "";
                    textPassEm.Text = "";
                    textFNEm.Text = "";
                    textLNEm.Text = "";
                    comboGenderEm.SelectedIndex = -1;
                    dateTimeDOBEm.Value = DateTime.Now;
                    textAddressEm.Text = "";
                    textEmailEm.Text = "";
                    textPhoneEm.Text = "";

                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกแถวที่จะลบ");
            }
        }

        private void buttonDoneEm_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, true, false))
            {
                return;
            }
            try
            {
                ECon = new SqlConnection(_strConnection);
                ECon.Open();
                string strSQL = "INSERT INTO Employee (Username,Password,FName,LName,Gender,DOB,Address,Email,Phone) Values(@Username,@Password,@FName,@LName,@Gender,@DOB,@Address,@Email,@Phone)";
                string strSQL2 = @"UPDATE Employee SET Position = 'Employee' WHERE Username = @Username";
                string Gender = comboGenderEm.SelectedItem.ToString();
                DateTime selectedDateTime = dateTimeDOBEm.Value;
                using (SqlCommand cmd = new SqlCommand(strSQL, ECon))
                {
                    cmd.Parameters.AddWithValue("@Username", textUserEm.Text);
                    cmd.Parameters.AddWithValue("@Password", textPassEm.Text);
                    cmd.Parameters.AddWithValue("@FName", textFNEm.Text);
                    cmd.Parameters.AddWithValue("@LName", textLNEm.Text);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@DOB", selectedDateTime);
                    cmd.Parameters.AddWithValue("@Address", textAddressEm.Text);
                    cmd.Parameters.AddWithValue("@Email", textEmailEm.Text);
                    cmd.Parameters.AddWithValue("@Phone", textPhoneEm.Text);

                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd2 = new SqlCommand(strSQL2, ECon))
                {
                    cmd2.Parameters.AddWithValue("@Username", textUserEm.Text);

                    cmd2.ExecuteNonQuery();
                }
                ECon.Close();
                MessageBox.Show("ข้อมูลถูกเพิ่มแล้ว", "เพิ่ม",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStateEm("View");
        }

        private void buttonRefreshEm_Click(object sender, EventArgs e)
        {
            ECon = new SqlConnection(_strConnection);
            ECon.Open();
            string query = "Select * from Employee";
            SqlDataAdapter EData = new SqlDataAdapter(query, ECon);
            SqlCommandBuilder EComBui = new SqlCommandBuilder(EData);
            var Es = new DataSet();
            EData.Fill(Es);
            dataGridEm.DataSource = Es.Tables[0];
            ECon.Close();
            labelAll();
        }

        private void buttonCancelEm_Click(object sender, EventArgs e)
        {
            textUserEm.Text = "";
            textPassEm.Text = "";
            textFNEm.Text = "";
            textLNEm.Text = "";
            comboGenderEm.SelectedIndex = -1;
            dateTimeDOBEm.Value = DateTime.Now;
            textAddressEm.Text = "";
            textEmailEm.Text = "";
            textPhoneEm.Text = "";
            SetStateMem("View");
        }

        private void dataGridEm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridEm.SelectedRows.Count > 0)
            {
                MessageBox.Show("Selected");
                DataGridViewRow selectedRow = dataGridEm.SelectedRows[0];

                textUserEm.Text = selectedRow.Cells["Username"].Value.ToString();
                textPassEm.Text = selectedRow.Cells["Password"].Value.ToString();
                textFNEm.Text = selectedRow.Cells["FName"].Value.ToString();
                textLNEm.Text = selectedRow.Cells["LName"].Value.ToString();
                comboGenderEm.SelectedItem = selectedRow.Cells["Gender"].Value.ToString();
                dateTimeDOBEm.Value = (DateTime)selectedRow.Cells["DOB"].Value;
                textAddressEm.Text = selectedRow.Cells["Address"].Value.ToString();
                textEmailEm.Text = selectedRow.Cells["Email"].Value.ToString();
                textPhoneEm.Text = selectedRow.Cells["Phone"].Value.ToString();
            }
        }

        private void buttonCancelMem_Click(object sender, EventArgs e)
        {
            textUserMem.Text = "";
            textPassMem.Text = "";
            textFNMem.Text = "";
            textLNMem.Text = "";
            comboGenderMem.SelectedIndex = -1;
            dateTimeDOBMem.Value = DateTime.Now;
            textAddressMem.Text = "";
            textAddressReceipt.Text = "";
            textEmailMem.Text = "";
            textPhoneMem.Text = "";
            comboStatusMem.SelectedIndex = -1;
            SetStateMem("View");
        }

        private void buttonAddMem_Click(object sender, EventArgs e)
        {
            SetStateMem("Add");
        }

        private void buttonUpdateMem_Click(object sender, EventArgs e)
        {
            if (!ValidateData(true, false, false))
            {
                return;
            }
            SetStateMem("Update");
        }

        private void buttonDoneMem_Click(object sender, EventArgs e)
        {
            if (!ValidateData(true, false, false))
            {
                return;
            }
            try
            {
                CCon = new SqlConnection(_strConnection);
                CCon.Open();
                string strSQL = "INSERT INTO Customer (Username,Password,FName,LName,Gender,DOB,Address,AddressFRecept,Email,Phone,Status) Values(@Username,@Password,@FName,@LName,@Gender,@DOB,@Address,@AddressFRecept, @Email,@Phone,@Status)";
                string strSQL2 = @"UPDATE Customer SET Position = 'Customer' WHERE Username = @Username";
                string Gender = comboGenderMem.SelectedItem.ToString();
                string status = comboStatusMem.SelectedItem.ToString();
                DateTime selectedDateTime = dateTimeDOBMem.Value;
                using (SqlCommand cmd = new SqlCommand(strSQL, CCon))
                {
                    cmd.Parameters.AddWithValue("@Username", textUserMem.Text);
                    cmd.Parameters.AddWithValue("@Password", textPassMem.Text);
                    cmd.Parameters.AddWithValue("@FName", textFNMem.Text);
                    cmd.Parameters.AddWithValue("@LName", textLNMem.Text);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@DOB", selectedDateTime);
                    cmd.Parameters.AddWithValue("@Address", textAddressMem.Text);
                    cmd.Parameters.AddWithValue("@AddressFRecept", textAddressReceipt.Text);
                    cmd.Parameters.AddWithValue("@Email", textEmailMem.Text);
                    cmd.Parameters.AddWithValue("@Phone", textPhoneMem.Text);
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd2 = new SqlCommand(strSQL2, CCon))
                {
                    cmd2.Parameters.AddWithValue("@Username", textUserMem.Text);

                    cmd2.ExecuteNonQuery();
                }
                CCon.Close();
                MessageBox.Show("ข้อมูลถูกเพิ่มแล้ว", "เพิ่ม",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStateMem("View");
        }

        private void buttonSaveMem_Click(object sender, EventArgs e)
        {
            if (!ValidateData(true, false, false))
            {
                return;
            }
            try
            {

                using (CCon = new SqlConnection(_strConnection))
                {
                    CCon.Open();
                    string Gender = comboGenderMem.SelectedItem.ToString();
                    DateTime selectedDateTime = dateTimeDOBMem.Value;
                    string status = comboStatusMem.SelectedItem.ToString();
                    DataGridViewRow selectedRow = dataGridMem.SelectedRows[0];
                    string SQLUpdate = "UPDATE Customer SET Username = @Username , Password = @Password, " +
                        "FName = @FName, LName = @LName,Gender = @Gender,DOB = @DOB, Address = @Address, " +
                        "AddressFRecept = @AddressFRecept, Email = @Email ,Phone = @Phone ,Status = @Status WHERE CustomerID = '" + selectedRow.Cells["CustomerID"].Value.ToString() + "'";

                    using (SqlCommand cmd = new SqlCommand(SQLUpdate, CCon))
                    {
                        cmd.Parameters.AddWithValue("@Username", textUserMem.Text);
                        cmd.Parameters.AddWithValue("@Password", textPassMem.Text);
                        cmd.Parameters.AddWithValue("@FName", textFNMem.Text);
                        cmd.Parameters.AddWithValue("@LName", textLNMem.Text);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", selectedDateTime);
                        cmd.Parameters.AddWithValue("@Address", textAddressMem.Text);
                        cmd.Parameters.AddWithValue("@AddressFRecept", textAddressReceipt.Text);
                        cmd.Parameters.AddWithValue("@Email", textEmailMem.Text);
                        cmd.Parameters.AddWithValue("@Phone", textPhoneMem.Text);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ข้อมูลถูกบันทึกแล้ว", "บันทึก",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridMem.DataSource = Cdt;
                    }
                    CCon.Close();
                    CCon.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStateMem("View");
        }

        private void buttonDeleteMem_Click(object sender, EventArgs e)
        {
            if (dataGridMem.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridMem.SelectedRows[0];
                string CustomerID = selectedRow.Cells["CustomerID"].Value.ToString();

                CCon = new SqlConnection(_strConnection);
                CCon.Open();
                string sql = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, CCon))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.ExecuteNonQuery();
                    }

                    dataGridMem.Rows.Remove(selectedRow);
                    CCon.Close();
                    CCon.Dispose();
                    textUserMem.Text = "";
                    textPassMem.Text = "";
                    textFNMem.Text = "";
                    textLNMem.Text = "";
                    comboGenderMem.SelectedIndex = -1;
                    dateTimeDOBMem.Value = DateTime.Now;
                    textAddressMem.Text = "";
                    textAddressReceipt.Text = "";
                    textEmailMem.Text = "";
                    textPhoneMem.Text = "";
                    comboStatusMem.SelectedIndex = -1;

                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกแถวที่จะลบ");
            }
        }

        private void buttonRefreshMem_Click(object sender, EventArgs e)
        {
            CCon = new SqlConnection(_strConnection);
            CCon.Open();
            string query = "Select * from Customer";
            SqlDataAdapter CData = new SqlDataAdapter(query, CCon);
            SqlCommandBuilder CComBui = new SqlCommandBuilder(CData);
            var Cs = new DataSet();
            CData.Fill(Cs);
            dataGridMem.DataSource = Cs.Tables[0];
            CCon.Close();
            labelAll();
        }

        private void dataGridMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridMem.SelectedRows.Count > 0)
            {
                MessageBox.Show("Selected");
                DataGridViewRow selectedRow = dataGridMem.SelectedRows[0];

                textUserMem.Text = selectedRow.Cells["Username"].Value.ToString();
                textPassMem.Text = selectedRow.Cells["Password"].Value.ToString();
                textFNMem.Text = selectedRow.Cells["FName"].Value.ToString();
                textLNMem.Text = selectedRow.Cells["LName"].Value.ToString();
                comboGenderMem.SelectedItem = selectedRow.Cells["Gender"].Value.ToString();
                dateTimeDOBMem.Value = (DateTime)selectedRow.Cells["DOB"].Value;
                textAddressMem.Text = selectedRow.Cells["Address"].Value.ToString();
                textAddressReceipt.Text = selectedRow.Cells["AddressFRecept"].Value.ToString();
                textEmailMem.Text = selectedRow.Cells["Email"].Value.ToString();
                textPhoneMem.Text = selectedRow.Cells["Phone"].Value.ToString();
                comboStatusMem.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
            }
        }

        private void buttonAddPro_Click(object sender, EventArgs e)
        {
            textNamePro.Text = "";
            comboCategories.SelectedItem = -1;
            textQuantityPro.Text = "";
            textPricePro.Text = "";
            textCostPrice.Text = "";
            comboStatusMem.SelectedItem = -1;
            textDescriptionPro.Text = "";
            pictureProduct.Image = null;
            SetStatePro("Add");
        }

        private void buttonUpdatePro_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, false, true))
            {
                return;
            }
            SetStatePro("Update");
        }

        private void buttonSavePro_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, false, true))
            {
                return;
            }
            try
            {
                using (PCon = new SqlConnection(_strConnection))
                {
                    PCon.Open();
                    string catagories = comboCategories.SelectedItem.ToString();
                    string status = comboStatusPro.SelectedItem.ToString();
                    DataGridViewRow selectedRow = dataGridProduct.SelectedRows[0];
                    string SQLUpdate = "UPDATE Product SET Name = @Name , CatagoriesName= @CatagoriesName, " +
                        "Quantity = @Quantity, PriceSale = @PriceSale, PriceOriginal = @PriceOriginal, Status = @Status, Description = @Description, " +
                        "Picture = @Picture WHERE ProductID = '" + selectedRow.Cells["ProductID"].Value.ToString() + "'";

                    using (SqlCommand cmd = new SqlCommand(SQLUpdate, PCon))
                    {
                        cmd.Parameters.AddWithValue("Name", textNamePro.Text);
                        cmd.Parameters.AddWithValue("CatagoriesName", catagories);
                        cmd.Parameters.AddWithValue("Quantity", textQuantityPro.Text);
                        cmd.Parameters.AddWithValue("PriceSale", textPricePro.Text);
                        cmd.Parameters.AddWithValue("PriceOriginal", textCostPrice.Text);
                        cmd.Parameters.AddWithValue("Status", status);
                        cmd.Parameters.AddWithValue("Description", textDescriptionPro.Text);
                        cmd.Parameters.AddWithValue("Picture", imageData);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ข้อมูลถูกบันทึกแล้ว", "บันทึก",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridProduct.DataSource = Pdt;
                    }
                    PCon.Close();
                    PCon.Dispose();
                    textNamePro.Text = "";
                    comboCategories.SelectedItem = -1;
                    textQuantityPro.Text = "";
                    textPricePro.Text = "";
                    textCostPrice.Text = "";
                    comboStatusMem.SelectedItem = -1;
                    textDescriptionPro.Text = "";
                    pictureProduct.Image = null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStatePro("View");
        }

        private void buttonDonePro_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, false, true))
            {
                return;
            }
            try
            {
                PCon = new SqlConnection(_strConnection);
                PCon.Open();
                string strSQL = "INSERT INTO Product (Name,CatagoriesName,Quantity,PriceSale,PriceOriginal,Status,Description,Picture) " +
                    "Values(@Name,@CatagoriesName,@Quantity,@PriceSale,@PriceOriginal,@Status,@Description,@Picture)";
                string catagories = comboCategories.SelectedItem.ToString();
                string status = comboStatusPro.SelectedItem.ToString();
                using (SqlCommand cmd = new SqlCommand(strSQL, PCon))
                {
                    cmd.Parameters.AddWithValue("Name", textNamePro.Text);
                    cmd.Parameters.AddWithValue("CatagoriesName", catagories);
                    cmd.Parameters.AddWithValue("Quantity", textQuantityPro.Text);
                    cmd.Parameters.AddWithValue("PriceSale", textPricePro.Text);
                    cmd.Parameters.AddWithValue("PriceOriginal", textCostPrice.Text);
                    cmd.Parameters.AddWithValue("Status", status);
                    cmd.Parameters.AddWithValue("Description", textDescriptionPro.Text);
                    cmd.Parameters.AddWithValue("Picture", imageData);

                    dataGridProduct.DataSource = Pdt;

                    cmd.ExecuteNonQuery();
                }
                PCon.Close();
                MessageBox.Show("ข้อมูลถูกเพิ่มแล้ว", "เพิ่ม",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textNamePro.Text = "";
                comboCategories.SelectedItem = -1;
                textQuantityPro.Text = "";
                textPricePro.Text = "";
                textCostPrice.Text = "";
                comboStatusMem.SelectedItem = -1;
                textDescriptionPro.Text = "";
                pictureProduct.Image = null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStatePro("View");
        }

        private void buttonDeletePro_Click(object sender, EventArgs e)
        {
            if (dataGridProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridProduct.SelectedRows[0];
                string ProductID = selectedRow.Cells["ProductID"].Value.ToString();

                PCon = new SqlConnection(_strConnection);
                PCon.Open();
                string sql = "DELETE FROM Product WHERE ProductID = @ProductID";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, PCon))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.ExecuteNonQuery();
                    }

                    dataGridProduct.Rows.Remove(selectedRow);
                    PCon.Close();
                    PCon.Dispose();

                    textNamePro.Text = "";
                    comboCategories.SelectedItem = -1;
                    textQuantityPro.Text = "";
                    textPricePro.Text = "";
                    textCostPrice.Text = "";
                    comboStatusMem.SelectedItem = -1;
                    textDescriptionPro.Text = "";
                    pictureProduct.Image = null;

                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกแถวที่จะลบ");
            }
        }

        private void buttonCancelPro_Click(object sender, EventArgs e)
        {
            SetStatePro("View");
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureProduct.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureProduct.Image.Save(ms, pictureProduct.Image.RawFormat);
                    imageData = ms.ToArray();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            populate();
            labelAll();
            LoadTotalProductCount();
        }

        private void populate()
        {
            PCon = new SqlConnection(_strConnection);
            PCon.Open();
            string query = "SELECT * from Product";
            PAt = new SqlDataAdapter(query, PCon);
            SqlCommandBuilder PCB = new SqlCommandBuilder(PAt);
            var ps = new DataSet();
            PAt.Fill(ps);
            dataGridProduct.DataSource = ps.Tables[0];
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridProduct.Columns["Picture"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            PCon.Close();
        }

        private void fillter()
        {
            PCon = new SqlConnection(_strConnection);
            PCon.Open();
            string query = "SELECT * from Product WHERE CatagoriesName = '"+ comboProductList.SelectedItem.ToString()+"'";
            PAt = new SqlDataAdapter(query, PCon);
            SqlCommandBuilder PCB = new SqlCommandBuilder(PAt);
            var ps = new DataSet();
            PAt.Fill(ps);
            dataGridProduct.DataSource = ps.Tables[0];
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridProduct.Columns["Picture"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            PCon.Close();
        }

        private void comboProductList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillter();
        }

        private void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridProduct.SelectedRows[0];

                textNamePro.Text = selectedRow.Cells["Name"].Value.ToString();
                comboCategories.SelectedItem = selectedRow.Cells["CatagoriesName"].Value.ToString();
                textQuantityPro.Text = selectedRow.Cells["Quantity"].Value.ToString();
                textPricePro.Text = selectedRow.Cells["PriceSale"].Value.ToString();
                textCostPrice.Text = selectedRow.Cells["PriceOriginal"].Value.ToString();
                comboStatusPro.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
                textDescriptionPro.Text = selectedRow.Cells["Description"].Value.ToString();
                if (selectedRow.Cells["Picture"].Value != null && selectedRow.Cells["Picture"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])selectedRow.Cells["Picture"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureProduct.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureProduct.Image = null;
                }

            }
        }
        private bool ValidateData(bool isCustomer, bool isEmployee, bool isProduct)
        {
            string message = "";
            bool allOK = true;
            if (isCustomer && textUserMem.Text.Trim().Equals("") || isEmployee && textUserEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Username" + "\r\n";
                if (isCustomer) textUserMem.Focus();
                if (isEmployee) textUserEm.Focus();
                allOK = false;
            }

            if (isCustomer && textPassMem.Text.Trim().Equals("") || isEmployee && textPassEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Password" + "\r\n";
                if (isCustomer) textPassMem.Focus();
                if (isEmployee) textPassEm.Focus();
                allOK = false;
            }
            if (isCustomer && textFNMem.Text.Trim().Equals("") || isEmployee && textFNEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก First Name" + "\r\n";
                if (isCustomer) textFNMem.Focus();
                if (isEmployee) textFNEm.Focus();
                allOK = false;
            }
            if (isCustomer && textLNMem.Text.Trim().Equals("") || isEmployee && textLNEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Last Name" + "\r\n";
                if (isCustomer) textLNMem.Focus();
                if (isEmployee) textLNEm.Focus();
                allOK = false;
            }

            if (isCustomer && string.IsNullOrWhiteSpace(comboGenderMem.Text) || isEmployee && string.IsNullOrWhiteSpace(comboGenderEm.Text))
            {
                message += "กรุณาเลือกเพศ" + "\r\n";
                if (isCustomer) comboGenderMem.Focus();
                if (isEmployee) comboGenderEm.Focus();
                allOK = false;
            }
            if (isCustomer && dateTimeDOBMem.Value == dateTimeDOBMem.MinDate || isEmployee && dateTimeDOBEm.Value == dateTimeDOBEm.MinDate)
            {
                message += "กรุณาเลือกวันที่\n";
                if (isCustomer) dateTimeDOBMem.Focus();
                if (isEmployee) dateTimeDOBEm.Focus();
                allOK = false;
            }
            if (isCustomer && textAddressMem.Text.Trim().Equals("") || isEmployee && textAddressEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่" + "\r\n";
                if (isCustomer) textAddressMem.Focus();
                if (isEmployee) textAddressEm.Focus();
                allOK = false;
            }

            if (isCustomer && string.IsNullOrWhiteSpace(comboStatusMem.Text))
            {
                message += "กรุณาเลือก Status" + "\r\n";
                if (isCustomer) comboStatusMem.Focus();
                allOK = false;
            }
            if (isCustomer && textAddressReceipt.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่สำหรับการรับ" + "\r\n";
                if (isCustomer) textAddressReceipt.Focus();
                allOK = false;
            }
            if (isCustomer && textEmailMem.Text.Trim().Equals("") || isEmployee && textEmailEm.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Email" + "\r\n";
                if (isCustomer) textEmailMem.Focus();
                if (isEmployee) textEmailEm.Focus();
                allOK = false;
            }
            if (isCustomer && textPhoneMem.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกเบอร์โทรศัพท์" + "\r\n";
                if (isCustomer) textEmailMem.Focus();
                if (isEmployee) textPhoneMem.Focus();
                allOK = false;
            }
            if (isProduct && textNamePro.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกชื่อสินค้า" + "\r\n";
                if (isProduct) textNamePro.Focus();
                allOK = false;
            }
            if (isProduct && string.IsNullOrWhiteSpace(comboCategories.Text))
            {
                message += "กรุณาเลือกหมวดหมู่" + "\r\n";
                if (isProduct) comboStatusMem.Focus();
                allOK = false;
            }
            if (isProduct && textQuantityPro.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกปริมาณ" + "\r\n";
                if (isProduct) textQuantityPro.Focus();
                allOK = false;
            }
            if (isProduct && textPricePro.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกราคา" + "\r\n";
                if (isProduct) textPricePro.Focus();
                allOK = false;
            }
            if (isProduct && textPricePro.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกราคา" + "\r\n";
                if (isProduct) textPricePro.Focus();
                allOK = false;
            }
            if (isProduct && string.IsNullOrWhiteSpace(comboStatusPro.Text))
            {
                message += "กรุณาเลือก Status ของสินค้า" + "\r\n";
                if (isProduct) comboStatusPro.Focus();
                allOK = false;
            }
            if (isProduct && textDescriptionPro.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกคำอธิบายสินค้า" + "\r\n";
                if (isProduct) textDescriptionPro.Focus();
                allOK = false;
            }
            if (isProduct && textCostPrice.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกราคาต้นทุน" + "\r\n";
                if (isProduct) textDescriptionPro.Focus();
                allOK = false;
            }
            if (isProduct && pictureProduct.Image == null)
            {
                message += "กรุณาเลือกภาพสินค้า\n";
                pictureProduct.Focus(); // หรือวิธีที่คุณต้องการให้โฟกัส
                allOK = false;
            }
            if (!allOK)
            {
                MessageBox.Show(message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return allOK;
        }

        private void formEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

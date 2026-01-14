using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml;
using System.Data.Common;
using static Catshop.formConfirm;

namespace Catshop
{
    public partial class formCustomer: Form
    {
        const string strConnstrFileName = "ConnectionString.ini";
        string _strConnection = "";

        SqlConnection CCon;
        SqlCommand CCom;
        SqlDataAdapter CAt;
        DataTable Cdt;
        CurrencyManager CManager;

        SqlConnection PCon;
        SqlCommand PCom;
        SqlDataAdapter PAt;
        DataTable Pdt;
        SqlCommand PCom2;

        public static string loggedInUsername;
        private int customerID;

        private string mystate;
        public int id = 0;
        public int cusID = 0;

        public string tableName;
        public string imageColumn;
        public string nameColumn;
        public string priceColumn;
        public formCustomer()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadConfig();
            DisplayData();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            formLogin fl = new formLogin();
            fl.Show();
            this.Hide();
        }

        private void formCustomer_Load(object sender, EventArgs e)
        {
            PCon = new SqlConnection(_strConnection);
            PCon.Open();
            PCom = new SqlCommand("Select * from Payment", PCon);
            SqlDataReader reader = PCom.ExecuteReader();
            while (reader.Read())
            {
                comboPayment.Items.Add(reader["PaymentName"].ToString());
            }
            reader.Close();
            PCon.Close();
            PCon.Dispose();
            SetStateC("View");
            LoadProducts();
            labelPriceAll.Text = CalculateTotalPrice().ToString("C");

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

        private void DisplayData()
        {
            try
            {
                CCon = new SqlConnection(_strConnection);
                CCon.Open();

                string strSQL = $"SELECT Username,Password,FName,LName,Gender,DOB,Address,AddressFRecept," +
                    $"Email,Phone from Customer WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(strSQL, CCon))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUsername);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string fName = reader["FName"].ToString();
                            string lName = reader["LName"].ToString();
                            string gender = reader["Gender"].ToString();
                            DateTime dob = Convert.ToDateTime(reader["DOB"]);
                            string address = reader["Address"].ToString();
                            string addressFRecept = reader["AddressFRecept"].ToString();
                            string email = reader["Email"].ToString();
                            string phone = reader["Phone"].ToString();

                            textUsernameC.Text = username;
                            textPasswordC.Text = password;
                            textFNameC.Text = fName;
                            textLNameC.Text = lName;
                            comboGenderC.Text = gender;
                            dateDOBC.Value = dob;
                            textAddressC.Text = address;
                            textAddressFRC.Text = addressFRecept;
                            textEmailC.Text = email;
                            textPhoneC.Text = phone;

                            labelCustomerName.Text = fName + " " + lName;
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบผู้ใช้งาน");
                        }
                    }
                        
                }
                CCon.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetStateC(string appState)
        {
            mystate = appState;
            switch (appState)
            {
                case "View":
                    textUsernameC.ReadOnly = true;
                    textPasswordC.ReadOnly = true;
                    textFNameC.ReadOnly = true;
                    textLNameC.ReadOnly = true;
                    comboGenderC.Enabled = false;
                    dateDOBC.Enabled = false;
                    textAddressC.ReadOnly = true;
                    textAddressFRC.ReadOnly = true;
                    textEmailC.ReadOnly = true;
                    textPhoneC.ReadOnly = true;
                    buttonEdit.Enabled = true;
                    buttonSave.Enabled = false;
                    buttonCancel.Enabled = false;
                    break;
                default:
                    textUsernameC.ReadOnly = false;
                    textPasswordC.ReadOnly = false;
                    textFNameC.ReadOnly = false;
                    textLNameC.ReadOnly = false;
                    comboGenderC.Enabled = true;
                    dateDOBC.Enabled = true;
                    textAddressC.ReadOnly = false;
                    textAddressFRC.ReadOnly = false;
                    textEmailC.ReadOnly = false;
                    textPhoneC.ReadOnly = false;
                    buttonEdit.Enabled = false;
                    buttonSave.Enabled = true;
                    buttonCancel.Enabled = true;
                    break;
            }
        }
        private bool ValidateData(bool isProfile, bool isShop, bool isPayment)
        {
            string message = "";
            bool allOK = true;
            if (isProfile && textUsernameC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Username" + "\r\n";
                if (isProfile) textUsernameC.Focus();
                allOK = false;
            }

            if (isProfile && textPasswordC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Password" + "\r\n";
                if (isProfile) textPasswordC.Focus();
                allOK = false;
            }
            if (isProfile && textFNameC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก First Name" + "\r\n";
                if (isProfile) textFNameC.Focus();
                allOK = false;
            }
            if (isProfile && textLNameC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Last Name" + "\r\n";
                if (isProfile) textLNameC.Focus();
                allOK = false;
            }
            if (isProfile && string.IsNullOrWhiteSpace(comboGenderC.Text))
            {
                message += "กรุณาเลือกเพศ" + "\r\n";
                if (isProfile) comboGenderC.Focus();
                allOK = false;
            }
            if (isProfile && isProfile && dateDOBC.Value == dateDOBC.MinDate)
            {
                message += "กรุณาเลือกวันที่\n";
                if (isProfile) dateDOBC.Focus();
                allOK = false;
            }
            if (isProfile && textAddressC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่" + "\r\n";
                if (isProfile) textAddressC.Focus();
                allOK = false;
            }

            if (isProfile && textAddressFRC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกที่อยู่สำหรับการรับ" + "\r\n";
                if (isProfile) textAddressFRC.Focus();
                allOK = false;
            }
            if (isProfile && textEmailC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอก Email" + "\r\n";
                if (isProfile) textEmailC.Focus();
                allOK = false;
            }
            if (isProfile && textPhoneC.Text.Trim().Equals(""))
            {
                message += "กรุณากรอกเบอร์โทรศัพท์" + "\r\n";
                if (isProfile) textPhoneC.Focus();
                allOK = false;
            }
            if (isPayment && string.IsNullOrWhiteSpace(comboPayment.Text))
            {
                message += "กรุณาเลือกช่องทางการชำระเงิน" + "\r\n";
                if (isPayment) textFind.Focus();
                allOK = false;
            }
            if (!allOK)
            {
                MessageBox.Show(message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return allOK;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            SetStateC("Edit");
            CCon = new SqlConnection(_strConnection);
            CCon.Open();
            using (SqlCommand cmdGetCustomerID = new SqlCommand("SELECT CustomerID FROM Customer WHERE Username = @Username", CCon))
            {
                cmdGetCustomerID.Parameters.AddWithValue("@Username", textUsernameC.Text); // หรือ username ที่ต้องการแก้ไข
                using (SqlDataReader reader = cmdGetCustomerID.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerID = Convert.ToInt32(reader["CustomerID"]);
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบผู้ใช้งาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // ออกจากเมธอดถ้าไม่พบผู้ใช้
                    }
                }
            }
            CCon.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData(true, false, false))
            {
                return;
            }
            try
            {
                using (SqlConnection CCon = new SqlConnection(_strConnection))
                {
                    CCon.Open();
                    string Gender = comboGenderC.SelectedItem?.ToString(); // ใช้ ?. เพื่อป้องกัน NullReferenceException
                    DateTime selectedDateTime = dateDOBC.Value;

                    string SQLUpdate = "UPDATE Customer SET Username = @Username, Password = @Password, FName = @FName, LName = @LName, Gender = @Gender, DOB = @DOB, Address = @Address, AddressFRecept = @AddressFRecept, Email = @Email, Phone = @Phone WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmdUpdate = new SqlCommand(SQLUpdate, CCon))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Username", textUsernameC.Text);
                        cmdUpdate.Parameters.AddWithValue("@Password", textPasswordC.Text);
                        cmdUpdate.Parameters.AddWithValue("@FName", textFNameC.Text);
                        cmdUpdate.Parameters.AddWithValue("@LName", textLNameC.Text);
                        cmdUpdate.Parameters.AddWithValue("@Gender", Gender ?? ""); // ใช้ "" ถ้า Gender เป็น null
                        cmdUpdate.Parameters.AddWithValue("@DOB", selectedDateTime);
                        cmdUpdate.Parameters.AddWithValue("@Address", textAddressC.Text);
                        cmdUpdate.Parameters.AddWithValue("@AddressFRecept", textAddressFRC.Text);
                        cmdUpdate.Parameters.AddWithValue("@Email", textEmailC.Text);
                        cmdUpdate.Parameters.AddWithValue("@Phone", textPhoneC.Text);
                        cmdUpdate.Parameters.AddWithValue("@CustomerID", customerID);

                        cmdUpdate.ExecuteNonQuery();

                        MessageBox.Show("ข้อมูลถูกบันทึกแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetStateC("View");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CCon = new SqlConnection(_strConnection);
                CCon.Open();

                string strSQL = $"SELECT Username,Password,FName,LName,Gender,DOB,Address,AddressFRecept," +
                    $"Email,Phone from Customer WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(strSQL, CCon))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUsername);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string fName = reader["FName"].ToString();
                            string lName = reader["LName"].ToString();
                            string gender = reader["Gender"].ToString();
                            DateTime dob = Convert.ToDateTime(reader["DOB"]);
                            string address = reader["Address"].ToString();
                            string addressFRecept = reader["AddressFRecept"].ToString();
                            string email = reader["Email"].ToString();
                            string phone = reader["Phone"].ToString();

                            textUsernameC.Text = username;
                            textPasswordC.Text = password;
                            textFNameC.Text = fName;
                            textLNameC.Text = lName;
                            comboGenderC.Text = gender;
                            dateDOBC.Value = dob;
                            textAddressC.Text = address;
                            textAddressFRC.Text = addressFRecept;
                            textEmailC.Text = email;
                            textPhoneC.Text = phone;
                        }
                    }

                }
                CCon.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetStateC("View");
        }

        public void LoadProducts()
        {
            PCon = new SqlConnection(_strConnection);
            string tableName = "Product"; // แทนที่ด้วยชื่อตารางของคุณ
            string imageColumn = "Picture"; // แทนที่ด้วยชื่อคอลัมน์รูปภาพของคุณ
            string nameColumn = "Name"; // แทนที่ด้วยชื่อคอลัมน์ชื่อสินค้าของคุณ
            string priceColumn = "PriceSale"; // แทนที่ด้วยชื่อคอลัมน์ราคาสินค้าของคุณ
            string idColumn = "ProductID";

            try
            {
                using (PCon = new SqlConnection(_strConnection))
                {
                    PCon.Open();
                    string query = $"SELECT {idColumn},{imageColumn}, {nameColumn}, {priceColumn} FROM {tableName} Where Status = 'Show'";
                    using (PCom = new SqlCommand(query, PCon))
                    {
                        using (SqlDataReader reader = PCom.ExecuteReader())
                        {
                            flowLayoutPanel1.Controls.Clear();
                            int totalWidth = 0;
                            int totalHeight = 0;
                            int productCount = 0;

                            while (reader.Read())
                            {
                                int panelWidth = 297; // กำหนดความกว้างของ Panel สินค้า
                                int panelHeight = 300; // กำหนดความสูงของ Panel สินค้า
                                int x = (flowLayoutPanel1.ClientSize.Width - panelWidth) / 2; // คำนวณตำแหน่ง x เพื่อให้อยู่ตรงกลาง
                                int y = (flowLayoutPanel1.ClientSize.Height - panelHeight) / 2; // คำนวณตำแหน่ง y เพื่อให้อยู่ตรงกลาง

                                flowLayoutPanel1.Size = new Size(297, 525); // กำหนดขนาด Panel หลัก

                                byte[] imageData = (byte[])reader[imageColumn];
                                string productName = reader[nameColumn].ToString();
                                string productid = reader[idColumn].ToString();
                                decimal productPrice = (decimal)reader[priceColumn];

                                Panel productPanel = new Panel();
                                productPanel.Width = panelWidth;
                                productPanel.Height = panelHeight;
                                productPanel.Location = new Point(x, y);
                                flowLayoutPanel1.Controls.Add(productPanel);

                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Width = panelWidth - 10;
                                pictureBox.Height = 150;
                                pictureBox.Location = new Point(5, 10);
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                productPanel.Controls.Add(pictureBox);

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }

                                Label nameLabel = new Label();
                                nameLabel.Text = productName;
                                nameLabel.Location = new Point(10, 170);
                                nameLabel.AutoSize = true;
                                productPanel.Controls.Add(nameLabel);

                                Label IDlabel = new Label();
                                IDlabel.Text = productid;
                                IDlabel.Location = new Point(10, 220);
                                IDlabel.AutoSize = true;
                                productPanel.Controls.Add(IDlabel);

                                Label priceLabel = new Label();
                                priceLabel.Text = $"Price: {productPrice:C}";
                                priceLabel.Location = new Point(10, 190);
                                priceLabel.AutoSize = true;
                                productPanel.Controls.Add(priceLabel);

                                // เพิ่มช่องกรอกจำนวนสินค้า
                                NumericUpDown quantityNumericUpDown = new NumericUpDown();
                                quantityNumericUpDown.Location = new Point(150, 170);
                                quantityNumericUpDown.Width = 50;
                                quantityNumericUpDown.Value = 1; // ค่าเริ่มต้น
                                productPanel.Controls.Add(quantityNumericUpDown);

                                // เพิ่มปุ่ม "Add to Cart"
                                Button addToCartButton = new Button();
                                addToCartButton.Text = "Add to Cart";
                                addToCartButton.Height = 30;
                                addToCartButton.Width = 110;
                                addToCartButton.Location = new Point(150, 200);
                                addToCartButton.Click += (sender, e) =>
                                {
                                    // ตัวอย่าง: เรียกใช้เมธอด AddToCart เพื่อเพิ่มสินค้าลงในตะกร้า
                                    int quantity = (int)quantityNumericUpDown.Value;
                                    decimal totalPrice = quantity * productPrice;
                                    AddToCart(productid, productName, quantity, totalPrice);
                                };
                                productPanel.Controls.Add(addToCartButton);

                                x += panelWidth + 10;
                                productCount++;
                                if (x + panelWidth > flowLayoutPanel1.ClientSize.Width)
                                {
                                    x = 10;
                                    y += panelHeight + 10;

                                    Panel separatorPanel = new Panel();
                                    separatorPanel.Width = flowLayoutPanel1.ClientSize.Width - 20;
                                    separatorPanel.Height = 2;
                                    separatorPanel.Location = new Point(10, y - 5);
                                    separatorPanel.BackColor = Color.LightGray;
                                    flowLayoutPanel1.Controls.Add(separatorPanel);

                                    y += 10;
                                }

                                totalWidth = Math.Max(totalWidth, x);
                                totalHeight = Math.Max(totalHeight, y + panelHeight);
                            }

                            flowLayoutPanel1.AutoScrollMinSize = new Size(totalWidth + 10, totalHeight + 10);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            PCon = new SqlConnection(_strConnection);
            string tableName = "Product"; // แทนที่ด้วยชื่อตารางของคุณ
            string imageColumn = "Picture"; // แทนที่ด้วยชื่อคอลัมน์รูปภาพของคุณ
            string nameColumn = "Name"; // แทนที่ด้วยชื่อคอลัมน์ชื่อสินค้าของคุณ
            string priceColumn = "PriceSale"; // แทนที่ด้วยชื่อคอลัมน์ราคาสินค้าของคุณ
            string idColum = "ProductID";
            string searchText = textFind.Text;
            try
            {
                using (PCon = new SqlConnection(_strConnection))
                {
                    PCon.Open();
                    string query = $"SELECT {idColum}, {imageColumn}, {nameColumn}, {priceColumn} FROM {tableName} Where Status = 'Show' And {nameColumn} LIKE @SearchText";
                    using (PCom = new SqlCommand(query, PCon))
                    {
                        PCom.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        using (SqlDataReader reader = PCom.ExecuteReader())
                        {
                            flowLayoutPanel1.Controls.Clear();
                            int totalWidth = 0;
                            int totalHeight = 0;
                            int productCount = 0;

                            while (reader.Read())
                            {
                                int panelWidth = 297; // กำหนดความกว้างของ Panel สินค้า
                                int panelHeight = 300; // กำหนดความสูงของ Panel สินค้า
                                int x = (flowLayoutPanel1.ClientSize.Width - panelWidth) / 2; // คำนวณตำแหน่ง x เพื่อให้อยู่ตรงกลาง
                                int y = (flowLayoutPanel1.ClientSize.Height - panelHeight) / 2; // คำนวณตำแหน่ง y เพื่อให้อยู่ตรงกลาง

                                flowLayoutPanel1.Size = new Size(297, 525); // กำหนดขนาด Panel หลัก

                                byte[] imageData = (byte[])reader[imageColumn];
                                string productName = reader[nameColumn].ToString();
                                string productid = reader[idColum].ToString(); ;
                                decimal productPrice = (decimal)reader[priceColumn];

                                Panel productPanel = new Panel();
                                productPanel.Width = panelWidth;
                                productPanel.Height = panelHeight;
                                productPanel.Location = new Point(x, y);
                                flowLayoutPanel1.Controls.Add(productPanel);

                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Width = panelWidth - 10;
                                pictureBox.Height = 150;
                                pictureBox.Location = new Point(5, 10);
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                productPanel.Controls.Add(pictureBox);

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }

                                Label nameLabel = new Label();
                                nameLabel.Text = productName;
                                nameLabel.Location = new Point(10, 170);
                                nameLabel.AutoSize = true;
                                productPanel.Controls.Add(nameLabel);
                                productPanel.Tag = nameLabel;

                                Label IDlabel = new Label();
                                IDlabel.Text = productid;
                                IDlabel.Location = new Point(10, 220);
                                IDlabel.AutoSize = true;
                                productPanel.Controls.Add(IDlabel);

                                Label priceLabel = new Label();
                                priceLabel.Text = $"Price: {productPrice:C}";
                                priceLabel.Location = new Point(10, 190);
                                priceLabel.AutoSize = true;
                                productPanel.Controls.Add(priceLabel);
                                productPanel.Tag = priceLabel;

                                // เพิ่มช่องกรอกจำนวนสินค้า
                                NumericUpDown quantityNumericUpDown = new NumericUpDown();
                                quantityNumericUpDown.Location = new Point(150, 170);
                                quantityNumericUpDown.Width = 50;
                                quantityNumericUpDown.Value = 1; // ค่าเริ่มต้น
                                productPanel.Controls.Add(quantityNumericUpDown);
                                productPanel.Tag = quantityNumericUpDown;

                                // เพิ่มปุ่ม "Add to Cart"
                                Button addToCartButton = new Button();
                                addToCartButton.Text = "Add to Cart";
                                addToCartButton.Height = 30;
                                addToCartButton.Width = 110;
                                addToCartButton.Location = new Point(150, 200);
                                addToCartButton.Click += delegate
                                {
                                    // ตัวอย่าง: เรียกใช้เมธอด AddToCart เพื่อเพิ่มสินค้าลงในตะกร้า
                                    int quantity = (int)quantityNumericUpDown.Value;
                                    decimal totalPrice = quantity * productPrice;
                                    AddToCart(productid, productName, quantity, totalPrice);
                                };
                                productPanel.Controls.Add(addToCartButton);

                                x += panelWidth + 10;
                                productCount++;
                                if (x + panelWidth > flowLayoutPanel1.ClientSize.Width)
                                {
                                    x = 10;
                                    y += panelHeight + 10;

                                    Panel separatorPanel = new Panel();
                                    separatorPanel.Width = flowLayoutPanel1.ClientSize.Width - 20;
                                    separatorPanel.Height = 2;
                                    separatorPanel.Location = new Point(10, y - 5);
                                    separatorPanel.BackColor = Color.LightGray;
                                    flowLayoutPanel1.Controls.Add(separatorPanel);

                                    y += 10;
                                }

                                totalWidth = Math.Max(totalWidth, x);
                                totalHeight = Math.Max(totalHeight, y + panelHeight);
                            }

                            flowLayoutPanel1.AutoScrollMinSize = new Size(totalWidth + 10, totalHeight + 10);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void InitializeDataGridView()
        {
            dataGridCart.Columns.Add("ProductID", "Product ID");
            dataGridCart.Columns.Add("ProductName", "Product Name");
            dataGridCart.Columns.Add("Quantity", "Quantity");
            dataGridCart.Columns.Add("TotalPrice", "Total Price");
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridCart.Columns.Add(deleteButtonColumn);
        }

        private void AddToCart(string ProductID,string productName, int quantity,decimal totalPrice)
        {
            if (dataGridCart != null)
            {
                foreach (DataGridViewRow row in dataGridCart.Rows)
                {
                    if (row != null && row.Cells["ProductID"].Value != null)
                    {
                        if (row.Cells["ProductID"].Value.ToString() == ProductID)
                        {
                            if (row.Cells["Quantity"].Value != null) // เพิ่มการตรวจสอบ null
                            {
                                int currentQuantity;
                                if (int.TryParse(row.Cells["Quantity"].Value.ToString(), out currentQuantity)) // ใช้ TryParse()
                                {
                                    row.Cells["Quantity"].Value = currentQuantity + quantity;
                                }
                                else
                                {
                                    // จัดการกรณีที่แปลงค่าไม่ได้
                                    MessageBox.Show("Invalid Quantity format!");
                                }
                            }

                            if (row.Cells["TotalPrice"].Value != null) // เพิ่มการตรวจสอบ null
                            {
                                decimal currentTotalPrice;
                                if (decimal.TryParse(row.Cells["TotalPrice"].Value.ToString(), out currentTotalPrice)) // ใช้ TryParse()
                                {
                                    row.Cells["TotalPrice"].Value = currentTotalPrice + totalPrice;
                                }
                                else
                                {
                                    // จัดการกรณีที่แปลงค่าไม่ได้
                                    MessageBox.Show("Invalid TotalPrice format!");
                                }
                            }
                            return;
                        }
                    }
                }
                dataGridCart.Rows.Add(ProductID, productName, quantity, totalPrice);
            }
            else
            {
                MessageBox.Show("dataGridCart is null!");
            }
            labelPriceAll.Text = CalculateTotalPrice().ToString("C");
        }

        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dataGridCart.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null)
                {
                    totalPrice += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                }
            }
            return totalPrice;
        }

        private void dataGridCart_SelectionChanged(object sender, EventArgs e)
        {
            labelPriceAll.Text = CalculateTotalPrice().ToString("C");
        }

        private void dataGridCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            labelPriceAll.Text = CalculateTotalPrice().ToString("C");
        }

        private void dataGridCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridCart.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                // ลบแถวที่เลือก
                dataGridCart.Rows.RemoveAt(e.RowIndex);

                // อัปเดต label total price
                labelPriceAll.Text = CalculateTotalPrice().ToString("C");
                labelPriceAll.Refresh(); // เพิ่มการ refresh label
            }
        }

        private void dataGridCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labelPriceAll.Text = CalculateTotalPrice().ToString("C");
            labelPriceAll.Refresh(); // เพิ่มการ refresh label
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateData(false, false, true))
            {
                return;
            }
            formConfirm confirmationForm = new formConfirm();

            // ส่งข้อมูลลูกค้า
            confirmationForm.CustomerName = textFNameC.Text+" "+textLNameC.Text; // สมมติว่า txtCustomerName คือ TextBox สำหรับชื่อลูกค้า
            confirmationForm.CustomerAddress = textAddressFRC.Text; // สมมติว่า txtCustomerAddress คือ TextBox สำหรับที่อยู่ลูกค้า
            confirmationForm.PaymentName = comboPayment.SelectedItem.ToString();

            // ส่งข้อมูลสินค้า
            List<Product> products = new List<Product>();
            foreach (DataGridViewRow row in dataGridCart.Rows)
            {
                if (!row.IsNewRow &&
            row.Cells["ProductName"].Value != null &&
            row.Cells["Quantity"].Value != null &&
            row.Cells["TotalPrice"].Value != null)
                {
                    Product product = new Product();
                    product.ProductName = row.Cells["ProductName"].Value.ToString();
                    product.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    product.Price = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                    products.Add(product);
                }
            }
            confirmationForm.Products = products;

            // ส่งราคารวม
            confirmationForm.TotalPrice = CalculateTotalPrice();

            confirmationForm.Show();
            this.Hide();
        }

        private void formCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void comboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}

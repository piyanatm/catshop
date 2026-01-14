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
    public partial class formConfirm: Form
    {
        const string strConnstrFileName = "ConnectionString.ini";
        string _strConnection = "";

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public string PaymentName { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public formConfirm()
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

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            formLogin fl = new formLogin();
            fl.Show();
            this.Hide();
        }

        private void formConfirm_Load(object sender, EventArgs e)
        {
            // แสดงข้อมูลลูกค้าและราคารวม
            labelCusName.Text = CustomerName;
            labelAddress.Text = CustomerAddress;
            labelPayment.Text = PaymentName;
            labelTotalPrice.Text = TotalPrice.ToString("C");

            // แสดงรายการสินค้าเป็น Label
            if (Products != null && Products.Count > 0)
            {
                int labelY = label6.Bottom + 20; // เริ่มต้นตำแหน่ง Y หลังจาก labelTotalPrice
                foreach (Product product in Products)
                {
                    Label labelSummary = new Label();
                    labelSummary.Text = $"{product.ProductName} - Quantity: {product.Quantity}, Price: {product.Price.ToString("C")}";
                    labelSummary.Location = new Point(label6.Left+30, labelY); // ตรวจสอบ labelCusName
                    labelSummary.AutoSize = true;
                    this.Controls.Add(labelSummary);
                    labelY += labelSummary.Height + 10;
                }
            }
        }

        public class Product
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // ดึงข้อมูลจากฟอร์ม
            string customerName = labelCusName.Text;
            string customerAddress = labelAddress.Text;
            string paymentName = labelPayment.Text;
            decimal totalPrice;
            if (!decimal.TryParse(labelTotalPrice.Text.Replace("฿", ""), out totalPrice)) // แปลง labelTotalPrice.Text เป็น decimal
            {
                MessageBox.Show("Invalid total price format.");
                return;
            }

            // สร้าง SqlConnection และ SqlCommand
            using (SqlConnection connection = new SqlConnection(_strConnection))
            {
                connection.Open();

                // สร้างคำสั่ง SQL INSERT
                string query = "INSERT INTO Sale (ProductName, Quantity, PriceTotal, DOS, CustomerName, CustomerAddressFRecept, PaymentName) VALUES (@ProductName, @Quantity, @PriceTotal, @DOS, @CustomerName, @CustomerAddressFRecept, @PaymentName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (Products != null && Products.Count > 0) // เพิ่มการตรวจสอบ Products
                    {
                        foreach (Product product in Products)
                        {
                            // กำหนดค่า parameters
                            command.Parameters.Clear();
                            if (product.ProductName != null) // เพิ่มการตรวจสอบ product.ProductName
                            {
                                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ProductName", DBNull.Value);
                            }
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);
                            command.Parameters.AddWithValue("@PriceTotal", product.Price);
                            command.Parameters.AddWithValue("@DOS", DateTime.Now);
                            command.Parameters.AddWithValue("@CustomerName", customerName);
                            command.Parameters.AddWithValue("@CustomerAddressFRecept", customerAddress);
                            command.Parameters.AddWithValue("@PaymentName", paymentName);

                            // Execute คำสั่ง SQL
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Data saved successfully!");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formCustomer fc = new formCustomer();
            fc.Show();
            this.Hide();
        }

        private void formConfirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

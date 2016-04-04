using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhoneBook
{
    public partial class Add_Contact : Form
    {
        public Add_Contact()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\aarav\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook\PhoneBook.mdf';Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CONTACTS(NAME,MOBILE) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CONTACT HAS BEEN SAVED", "SREELATHA");
               }
            catch
            {
                MessageBox.Show("Mobile Number Alreayt Exists", "SREELATHA");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\aarav\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook\PhoneBook.mdf';Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM CONTACTS WHERE MOBILE ='" + textBox2.Text + "' OR NAME ='" + textBox1.Text + "'  ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("CONTACT HAS BEEN DELETED", "SREELATHA");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\aarav\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook\PhoneBook.mdf';Integrated Security=True");
           
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM CONTACTS", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow  row in  dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row["NAME"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["MOBILE"].ToString();
                       
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }    
    }
}

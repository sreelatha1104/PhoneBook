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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\aarav\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook\PhoneBook.mdf';Integrated Security=True");
               if (comboBox1.SelectedIndex == 0)
               {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM CONTACTS WHERE NAME LIKE'%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = row["NAME"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = row["MOBILE"].ToString();

                }
               }
              else
             {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM CONTACTS WHERE MOBILE LIKE '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = row["NAME"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = row["MOBILE"].ToString();
                }
            }
        }
    }
}

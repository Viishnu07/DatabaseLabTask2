using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseLabTask2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=USERS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT URole FROM [Users] Where [UName] = @UserName and [UPassword]=@Pwd", con);

            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Pwd", password);

            string role = cmd.ExecuteScalar().ToString();

            if (role != null)
            {
                if (role == "Admin")
                {
                    //show customer list form
                    CustomerListForm clf = new CustomerListForm();
                    clf.ShowDialog();
                }
                else
                {
                    //show Profile form
                    // MessageBox.Show(role);
                    ProfileForm pf = new ProfileForm(username, role);
                    pf.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username and/or password entered !!");
            }

        }
    }
}

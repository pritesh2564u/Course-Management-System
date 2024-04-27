using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystemClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.AdminServiceClient adminClient = new ServiceReference1.AdminServiceClient("NetTcpBinding_IAdminService");
            ServiceReference1.Admin admin = adminClient.GetAdminById(1) ; 

            label1.Text = admin.Username;
            label2.Text = admin.Password;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

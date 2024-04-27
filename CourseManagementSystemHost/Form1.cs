using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagementSystem;

namespace CourseManagementSystemHost
{
    public partial class Form1 : Form
    {
        ServiceHost AdminSh = null, StudentSh = null, CourseSh = null, TeacherSh = null ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // admin service 
            Uri AdminTcpa = new Uri("net.tcp://localhost:8051/TcpBinding");
            AdminSh = new ServiceHost(typeof(AdminService), AdminTcpa);

            NetTcpBinding AdminTcpb = new NetTcpBinding();
            ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();

            AdminSh.Description.Behaviors.Add(mBehave);
            AdminSh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            AdminSh.AddServiceEndpoint(typeof(IAdminService), AdminTcpb, AdminTcpa);

            // student service
            Uri StudentTcpa = new Uri("net.tcp://localhost:8052/TcpBinding");
            StudentSh = new ServiceHost(typeof(StudentService), StudentTcpa);

            NetTcpBinding StudentTcpb = new NetTcpBinding();
            ServiceMetadataBehavior mBehave2 = new ServiceMetadataBehavior();

            StudentSh.Description.Behaviors.Add(mBehave2);
            StudentSh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            StudentSh.AddServiceEndpoint(typeof(IStudentService), StudentTcpb, StudentTcpa);

            //teacher service 
            Uri TeacherTcpa = new Uri("net.tcp://localhost:8053/TcpBinding");
            TeacherSh = new ServiceHost(typeof(TeacherService), TeacherTcpa);

            NetTcpBinding TeacherTcpb = new NetTcpBinding();
            ServiceMetadataBehavior mBehave3 = new ServiceMetadataBehavior();

            TeacherSh.Description.Behaviors.Add(mBehave3);
            TeacherSh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            TeacherSh.AddServiceEndpoint(typeof(ITeacherService), TeacherTcpb, TeacherTcpa);

            // course service
            Uri CourseTcpa = new Uri("net.tcp://localhost:8054/TcpBinding");
            CourseSh = new ServiceHost(typeof(CourseService), CourseTcpa);

            NetTcpBinding CourseTcpb = new NetTcpBinding();
            ServiceMetadataBehavior mBehave4 = new ServiceMetadataBehavior();

            CourseSh.Description.Behaviors.Add(mBehave4);
            CourseSh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            CourseSh.AddServiceEndpoint(typeof(ICourseService), CourseTcpb, CourseTcpa);


            AdminSh.Open();
            StudentSh.Open();
            CourseSh.Open();
            TeacherSh.Open();

            label1.Text = "Service Running";
        }
    }
}

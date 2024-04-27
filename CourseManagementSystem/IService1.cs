using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CourseManagementSystem
{
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        Admin GetAdminByUsername(string username);

        [OperationContract]
        List<Admin> GetAllAdmins();

        [OperationContract]
        bool LoginAdmin(string username, string password);

    }

    [ServiceContract]
    public interface ICourseService
    {
        [OperationContract]
        Course GetCourseById(int id);

        [OperationContract]
        List<Course> GetAllCourses();

        [OperationContract]
        List<Course> GetAllCourseByTeacherId(int teacherId);

        [OperationContract]
        List<Course> GetAllCourseByStudentId(int studentId);

        [OperationContract]
        bool AddCourse(Course course);

        [OperationContract]
        bool UpdateCourse(Course course);

        [OperationContract]
        bool DeleteCourse(int courseId);

        [OperationContract]
        bool EnrollStudentInCourse(int studentId, int courseId);

    }

    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        Student GetStudentByUsername(string username);

        [OperationContract]
        Student GetStudentById(int studentId);

        [OperationContract]
        List<Student> GetAllStudents();

        [OperationContract] 
        bool AddStudent(Student student);

        [OperationContract] 
        bool UpdateStudent(Student student);

        [OperationContract]
        bool DeleteStudent(Student student);

        [OperationContract]
        bool LoginStudent(string username, string password);
    }

    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        Teacher GetTeacherByUsername(string username);

        [OperationContract]
        Teacher GetTeacherById(int teacherId);

        [OperationContract]
        List<Teacher> getAllTeachers();

        [OperationContract]
        bool AddTeacher(Teacher teacher);

        [OperationContract]
        bool UpdateTeacher(Teacher teacher);

        [OperationContract]
        bool DeleteTeacher(Teacher teacher);

        [OperationContract]
        bool LoginTeacher(string username, string password);

    }

    //data contracts classes
    [DataContract]
    public class Admin
    {
        [DataMember]
        public int AdminId { get; set; } 

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string CourseImage { get; set; }

        [DataMember]
        public string CourseScope { get; set; }

        [DataMember]
        public decimal Payment { get; set; }
        
        [DataMember]
        public int TeacherId { get; set; } 

        public Teacher Teacher { get; set; }
        
        public ICollection<Student> Students { get; set; }
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

    [DataContract]
    public class Teacher
    {
        [DataMember]
        public int TeacherId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}

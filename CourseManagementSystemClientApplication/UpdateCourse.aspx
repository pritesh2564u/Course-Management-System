<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCourse.aspx.cs" Inherits="CourseManagementSystemClientApplication.UpdateCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body>
    <form id="studentRegistrationForm" runat="server">
<nav class="bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
    <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
        <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
        <ul class="flex space-x-4">
            <li>
                <a href="ManageCourses.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Courses</a>
            </li>
            <li>
                <a href="ManageStudents.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Students</a>
            </li>
            <li>
                <a href="ManageTeachers.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Teachers</a>
            </li>
            <li>
                    <asp:LinkButton ID="lnkLogout" runat="server" Text="Logout" CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300" OnClick="Logout" />
            </li>
        </ul>
    </div>
</nav>


<div class="pt-20 flex justify-center items-center">
    <div class="bg-white shadow-md rounded-lg px-8 py-10 max-w-md w-full">
        <h2 class="text-center text-3xl font-bold text-gray-800 mb-8"> Update Course </h2>
  
        <div class="mb-4">
            <label for="txtName" class="block text-gray-700 text-sm font-bold mb-2">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter course name" required />
        </div>
        <div class="mb-4">
            <label for="txtDescription" class="block text-gray-700 text-sm font-bold mb-2">Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter course description" required />
        </div>
        <div class="mb-4">
            <label for="txtCourseImage" class="block text-gray-700 text-sm font-bold mb-2">Course Image:</label>
            <asp:TextBox ID="txtCourseImage" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter course image URL" required />
        </div>
        <div class="mb-4">
            <label for="txtCourseScope" class="block text-gray-700 text-sm font-bold mb-2">Course Scope:</label>
            <asp:TextBox ID="txtCourseScope" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter course scope" required />
        </div>
        <div class="mb-4">
            <label for="txtPayment" class="block text-gray-700 text-sm font-bold mb-2">Payment:</label>
            <asp:TextBox ID="txtPayment" runat="server" CssClass="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter payment amount" Required />
        </div>
        <div class="mb-4">
            <label for="txtTeacherId" class="block text-gray-700 text-sm font-bold mb-2">Teacher ID:</label>
            <asp:TextBox ID="txtTeacherId" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter teacher ID" required />
        </div>
        <div class="flex justify-center">
            <asp:Button ID="btnUpdateCourse" runat="server" Text="Update Course" CssClass="cursor-pointer bg-gradient-to-r from-blue-500 to-blue-700 hover:from-blue-700 hover:to-blue-900 text-white px-6 py-3 rounded-lg shadow-lg focus:outline-none focus:ring focus:border-blue-500 transition-all duration-300 ease-in-out" OnClick="btnUpdateCourse_Click" />
        </div>
    </div>
</div>
</form>


<footer class="bg-gradient-to-r from-blue-500 to-blue-700 py-4 mt-4">
     <div class="container mx-auto px-4">
         <div class="flex justify-between items-center">
             <p class="text-white">Course Management System &copy; 2024</p>
             <ul class="flex space-x-4">
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Privacy Policy</a>
                 </li>
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Terms of Service</a>
                 </li>
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Contact Us</a>
                 </li>
             </ul>
         </div>
     </div>
 </footer>
</body>
</html>

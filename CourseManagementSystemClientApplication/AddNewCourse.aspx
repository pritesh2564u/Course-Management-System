<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewCourse.aspx.cs" Inherits="CourseManagementSystemClientApplication.AddNewCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-gray-200">
    <nav class="fixed top-0 left-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
        <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <ul class="flex space-x-4">
                <li>
                    <a href="teacherHomePage.aspx" class="text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300"> Dashboard </a>
                </li>
                <li>
                    <a href="#" class="text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300"> Logout </a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="flex justify-center items-center pt-[85px]">
        <div class="bg-white shadow-md rounded-lg px-8 py-10 max-w-md w-full">
            <h2 class="text-center text-3xl font-bold text-gray-800 mb-8">Add New Course</h2>
            <form id="addCourseForm" runat="server">
                <div class="mb-4">
                    <label for="txtName" class="block text-gray-700 text-sm font-bold mb-2">Course Name:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter course name" Required />
                </div>
                <div class="mb-4">
                    <label for="txtDescription" class="block text-gray-700 text-sm font-bold mb-2">Description:</label>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-textarea border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter course description" Required />
                </div>
                <div class="mb-4">
                    <label for="txtCourseImage" class="block text-gray-700 text-sm font-bold mb-2">Course Image URL:</label>
                    <asp:TextBox ID="txtCourseImage" runat="server" CssClass="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter course image URL" Required />
                </div>
                <div class="mb-4">
                    <label for="txtCourseScope" class="block text-gray-700 text-sm font-bold mb-2">Course Scope:</label>
                    <asp:TextBox ID="txtCourseScope" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-textarea border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter course scope" Required />
                </div>
                <div class="mb-4">
                    <label for="txtPayment" class="block text-gray-700 text-sm font-bold mb-2">Payment:</label>
                    <asp:TextBox ID="txtPayment" runat="server" CssClass="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" Placeholder="Enter payment amount" Required />
                </div>
                <div id="successDiv" runat="server" class="success-message bg-green-200 text-green-800 border border-green-500 px-4 py-2 rounded-lg mt-4 mb-2" visible="false">
                    <span>Course added Succesfully</span>
                </div>
                <div class="flex justify-center">
                    <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="bg-gradient-to-r from-blue-500 to-blue-700 hover:from-blue-700 hover:to-blue-900 text-white px-6 py-3 rounded-lg shadow-lg focus:outline-none focus:ring focus:border-blue-500 transition-all duration-300 ease-in-out" OnClick="btnAddCourse_Click" />
                </div>
            </form>
        </div>
    </div>
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

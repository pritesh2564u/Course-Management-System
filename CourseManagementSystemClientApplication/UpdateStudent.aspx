<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudent.aspx.cs" Inherits="CourseManagementSystemClientApplication.UpdateStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha384-gKT3ykyNtYyI+YIj2NJvoa5CCz4XV7g/PRCpAAzFfDkYY0aN1OcJ8EdE7C8YjlCN" crossorigin="anonymous" />


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
            <h2 class="text-center text-3xl font-bold text-gray-800 mb-8"> Update Student </h2>
      
                <div class="mb-4">
                    <label for="txtUsername" class="block text-gray-700 text-sm font-bold mb-2">Username:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your username" required />
                </div>
                <div class="mb-4">
                    <label for="txtPassword" class="block text-gray-700 text-sm font-bold mb-2">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your password" required />
                </div>
                <div class="mb-4">
                    <label for="txtCity" class="block text-gray-700 text-sm font-bold mb-2">City:</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your city" required />
                </div>
                <div class="mb-4">
                    <label for="txtState" class="block text-gray-700 text-sm font-bold mb-2">State:</label>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your state" required />
                </div>
                <div class="mb-4">
                    <label for="txtMobileNumber" class="block text-gray-700 text-sm font-bold mb-2">Mobile Number:</label>
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" pattern="[0-9]{10}" title="Phone number must be 10 digits." inputmode="numeric" Placeholder="Enter your mobile number" required />
                </div>
                <div class="flex justify-center">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Student" CssClass="cursor-pointer bg-gradient-to-r from-blue-500 to-blue-700 hover:from-blue-700 hover:to-blue-900 text-white px-6 py-3 rounded-lg shadow-lg focus:outline-none focus:ring focus:border-blue-500 transition-all duration-300 ease-in-out" onClick="btnUpdate_click"/>
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

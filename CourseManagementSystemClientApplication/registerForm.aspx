<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerForm.aspx.cs" Inherits="CourseManagementSystemClientApplication.registerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <script>
        function togglePasswordVisibility() {
            var passwordInput = document.getElementById("password");
            passwordInput.type === "password" ? passwordInput.type = "text" : passwordInput.type = "password";
        }
    </script>
</head>
<body class="bg-gray-200">
    <nav class="fixed top-0 left-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
        <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <ul class="flex space-x-4">
                <li>
                    <a href="loginForm.aspx" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Login</a>
                </li>
                <li>
                    <a href="#" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Register</a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="pt-20 flex justify-center items-center">
        <div class="bg-white shadow-md rounded-lg px-8 py-10 max-w-md w-full">
            <h2 class="text-center text-3xl font-bold text-gray-800 mb-8"> Register </h2>
            <form id="studentRegistrationForm" runat="server">
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
                <div class="mb-4">
                    <label for="ddlRole" class="block text-gray-700 text-sm font-bold mb-2">Role:</label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" required>
                        <asp:ListItem Text="Student" Value="Student" />
                        <asp:ListItem Text="Teacher" Value="Teacher" />
                    </asp:DropDownList>
                </div>
                <div class="flex justify-center">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="cursor-pointer bg-gradient-to-r from-blue-500 to-blue-700 hover:from-blue-700 hover:to-blue-900 text-white px-6 py-3 rounded-lg shadow-lg focus:outline-none focus:ring focus:border-blue-500 transition-all duration-300 ease-in-out" onClick="btnRegister_click"/>
                </div>
            </form>
            <div class="flex justify-center mt-2">
                <span>Already have an account? <a href="loginForm.aspx" class="text-blue-800">Login now</a></span>
            </div>
            <div id="successDiv" runat="server" class="success-message bg-green-200 text-green-800 border border-green-500 px-4 py-2 rounded-lg mt-4" visible="false">
                <span>Your account has been created successfully!</span>
            </div>
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

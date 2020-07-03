#pragma checksum "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef9f038c55a23de41c8c88e07023175ea138925e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_GetAll), @"mvc.1.0.view", @"/Views/Employees/GetAll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employees/GetAll.cshtml", typeof(AspNetCore.Views_Employees_GetAll))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef9f038c55a23de41c8c88e07023175ea138925e", @"/Views/Employees/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"895987bb8142cda2ad464df8c72230632bb809aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeePortal.Models.EmployeeModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
  
    ViewData["Title"] = "GetAll";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(148, 1260, true);
            WriteLiteral(@"<style>
    .center
    {
        margin: auto;
        font-size: medium;
        width: 20%;
        padding: 10px;
    }

    input[type=text], select
    {
        width: 100%;
        padding: 6px 10px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit]
    {
        width: 100%;
        background-color: #4CAF50;
        color: white;
        padding: 7px 10px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .Table
    {
        width: 100%;
        padding: 7px 10px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }
    input[type=submit]:hover
    {
        background-color: #45a049;
    }

    div
    {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 5px;
    }

    th
    {
    ");
            WriteLiteral("    border: 1px solid #ddd;\r\n        padding: 8px;\r\n    }\r\n    th\r\n    {\r\n        padding-top: 12px;\r\n        padding-bottom: 12px;\r\n        text-align: left;\r\n        background-color: #4CAF50;\r\n        color: white;\r\n    }\r\n</style>\r\n");
            EndContext();
            BeginContext(1428, 29, true);
            WriteLiteral("<label>TotalEmployee:</label>");
            EndContext();
            BeginContext(1458, 21, false);
#line 75 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
                        Write(ViewBag.TotalEmployee);

#line default
#line hidden
            EndContext();
            BeginContext(1479, 6, true);
            WriteLiteral("<br>\r\n");
            EndContext();
#line 77 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
     foreach (var employee in ViewData["Employees"] as IList<EmployeePortal.Models.EmployeeModel>)
    {

#line default
#line hidden
            BeginContext(1613, 36, true);
            WriteLiteral("        <label>EmployeeName:</label>");
            EndContext();
            BeginContext(1650, 21, false);
#line 79 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
                               Write(employee.EmployeeName);

#line default
#line hidden
            EndContext();
            BeginContext(1671, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 80 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
    
    }

#line default
#line hidden
            BeginContext(1692, 84, true);
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1777, 46, false);
#line 86 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeId));

#line default
#line hidden
            EndContext();
            BeginContext(1823, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1879, 48, false);
#line 89 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeName));

#line default
#line hidden
            EndContext();
            BeginContext(1927, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1983, 51, false);
#line 92 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeAddress));

#line default
#line hidden
            EndContext();
            BeginContext(2034, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2090, 45, false);
#line 95 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(2135, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2191, 48, false);
#line 98 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2239, 92, true);
            WriteLiteral("\r\n            </th>\r\n            <th>Action</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 104 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(2363, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2412, 45, false);
#line 107 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmployeeId));

#line default
#line hidden
            EndContext();
            BeginContext(2457, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2513, 47, false);
#line 110 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmployeeName));

#line default
#line hidden
            EndContext();
            BeginContext(2560, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2616, 50, false);
#line 113 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmployeeAddress));

#line default
#line hidden
            EndContext();
            BeginContext(2666, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2722, 44, false);
#line 116 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayFor(modelItem => item.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(2766, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2822, 47, false);
#line 119 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.DisplayFor(modelItem => item.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2869, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2925, 66, false);
#line 122 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
           Write(Html.ActionLink("Edit", "UpdateDetail", new { id=item.EmployeeId}));

#line default
#line hidden
            EndContext();
            BeginContext(2991, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 125 "C:\Users\Keval_Kiniyara\source\repos\ITactSolutions\EmployeePortal\EmployeePortal\Views\Employees\GetAll.cshtml"
}

#line default
#line hidden
            BeginContext(3030, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeePortal.Models.EmployeeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
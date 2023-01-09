#pragma checksum "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b68659c78e7bdf3daca7406755c0dcafc9ff7ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers_Index), @"mvc.1.0.view", @"/Views/Customers/Index.cshtml")]
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
#nullable restore
#line 1 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\_ViewImports.cshtml"
using EShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\_ViewImports.cshtml"
using EShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b68659c78e7bdf3daca7406755c0dcafc9ff7ad", @"/Views/Customers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ad7cc28246796ad669746423360069dfc310f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Customers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EShop.Models.CustomerDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
  
    ViewBag.Title = "Customer";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 7 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 8 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
Write(Html.ActionLink("Create", "Create", "Customers", "", new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p><br>You don\'t have any Customer registered yet!</p>\r\n");
#nullable restore
#line 12 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table id=\"datatable\" class=\"table table-bordered\">\r\n        <thead>\r\n            <tr>\r\n                <th>");
#nullable restore
#line 18 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
               Write(Html.DisplayNameFor(Model => Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 19 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
               Write(Html.DisplayNameFor(Model => Model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 20 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
               Write(Html.DisplayNameFor(Model => Model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 21 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
               Write(Html.DisplayNameFor(Model => Model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 22 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
               Write(Html.DisplayNameFor(Model => Model.RegDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"col-lg-1\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
             foreach (var customer in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 30 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(Html.ActionLink(@customer.Name, "Edit", "Customers", new { id = customer.Id }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(customer.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(customer.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(customer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(customer.RegDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", "Customers", new { id = customer.Id }, new { @class = "btn btn-delete btn-primary", id = "btn-delete" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 40 "C:\github\EShop-Core\.vs\EShop Core\EShop\Views\Customers\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#datatable\').DataTable();\r\n    });\r\n</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EShop.Models.CustomerDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

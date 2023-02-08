#pragma checksum "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a646a38da1531029c0a3f2731554c41997036b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Login), @"mvc.1.0.view", @"/Views/Users/Login.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\github\EShop-Core\EShop\Views\_ViewImports.cshtml"
using EShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\github\EShop-Core\EShop\Views\_ViewImports.cshtml"
using EShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a646a38da1531029c0a3f2731554c41997036b6", @"/Views/Users/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ad7cc28246796ad669746423360069dfc310f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShop.Models.UserDto>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
  
    ViewBag.Title = "Log in";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h2>\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <section id=\"loginForm\">\r\n");
#nullable restore
#line 11 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
             using (Html.BeginForm("LoginViewResult", "Users", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4>Use a local account to log in.</h4>\r\n                <hr />\r\n");
#nullable restore
#line 16 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 18 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
               Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 20 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
                   Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 21 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 25 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
               Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 27 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
                   Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 28 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <input type=""submit"" value=""Log in"" class=""btn btn-default"" />
                    </div>
                </div>
                <div class=""col-md-8"">
                    ");
#nullable restore
#line 37 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
               Write(Html.ActionLink("Register", "Register", "Users", "",new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 39 "C:\github\EShop-Core\EShop\Views\Users\Login.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </section>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShop.Models.UserDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
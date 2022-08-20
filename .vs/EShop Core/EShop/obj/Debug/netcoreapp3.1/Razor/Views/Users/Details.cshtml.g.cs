#pragma checksum "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1052b1c8d2631de1f10fce719dc3d805f5d8c3d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
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
#line 1 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\_ViewImports.cshtml"
using EShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\_ViewImports.cshtml"
using EShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
using EShop.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
using ISession = EShop.Helpers.ISession;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
using AutoMapper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1052b1c8d2631de1f10fce719dc3d805f5d8c3d5", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ad7cc28246796ad669746423360069dfc310f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShop.ViewModels.UserViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var customer = Session.GetCustomer();
    var chosenCustomer = Mapper.Map<Customer>(Model.Customer);
    chosenCustomer.User = Mapper.Map<User>(Model.User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 16 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 17 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
 if (UserAccess.IsAdmin(customer) && !UserAccess.IsAdmin(chosenCustomer))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.ActionLink("Convert to Admin", "ConvertToAdmin", new { id = Model.User.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
                                                                                                                          
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\">\r\n    ");
#nullable restore
#line 22 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.Customer.Name, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 24 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.Customer.Name, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 28 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.Customer.City, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 30 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.Customer.City, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 34 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.Customer.Address, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 36 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.Customer.Address, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 40 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.User.Email, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 42 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.User.Email, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 46 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.User.RegDate, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 48 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.User.RegDate, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 52 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
Write(Html.LabelFor(m => m.User.LoginDate, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 54 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Users\Details.cshtml"
   Write(Html.TextBoxFor(m => m.User.LoginDate, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IMapper Mapper { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserAccess UserAccess { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ISession Session { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShop.ViewModels.UserViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

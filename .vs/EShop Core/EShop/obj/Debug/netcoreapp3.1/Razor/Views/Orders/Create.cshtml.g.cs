#pragma checksum "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0b72205cc8ab1331c23cf646b7d6d7df00f698e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Create), @"mvc.1.0.view", @"/Views/Orders/Create.cshtml")]
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
#line 1 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
using EShop.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
using EShop.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
using ISession = EShop.Helpers.ISession;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0b72205cc8ab1331c23cf646b7d6d7df00f698e", @"/Views/Orders/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ad7cc28246796ad669746423360069dfc310f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShop.ViewModels.OrderViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control selectpicker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
  
    ViewBag.Title = "Create Order";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var customer = Session.GetCustomer();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.1/css/bootstrap-select.css"" />
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js""></script>
<script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.bundle.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.1/js/bootstrap-select.min.js""></script>
<h2>");
#nullable restore
#line 16 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 17 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
 using (Html.BeginForm("Save", "Orders"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 21 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
   Write(Html.LabelFor(m => m.ProductList));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b72205cc8ab1331c23cf646b7d6d7df00f698e7181", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b72205cc8ab1331c23cf646b7d6d7df00f698e7453", async() => {
                    WriteLiteral("Please select");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 22 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.ProductList);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("multiple", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 22 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.Products.ConvertAll(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
#nullable restore
#line 25 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
   Write(Html.ValidationMessageFor(m => m.ProductList));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 28 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
   Write(Html.LabelFor(m => m.Order.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 30 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
         if (UserAccess.IsCustomer(customer))
        {
            if (!UserAccess.IsAdmin(customer))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>");
#nullable restore
#line 34 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
              Write(Model.Order.Customer?.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 35 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b72205cc8ab1331c23cf646b7d6d7df00f698e12488", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b72205cc8ab1331c23cf646b7d6d7df00f698e12769", async() => {
                    WriteLiteral("Please select");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 38 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Order.CustomerId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 38 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.Customers.ConvertAll(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Order.CustomerId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
                                                                   
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 47 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.LabelFor(m => m.Order.Customer.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 48 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.TextBoxFor(m => m.Order.Customer.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 49 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Order.Customer.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 52 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.LabelFor(m => m.Order.Customer.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 53 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.TextBoxFor(m => m.Order.Customer.City, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 54 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Order.Customer.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 57 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.LabelFor(m => m.Order.Customer.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 58 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.TextBoxFor(m => m.Order.Customer.Address, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 59 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Order.Customer.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 62 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.LabelFor(m => m.Order.Customer.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 63 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.TextBoxFor(m => m.Order.Customer.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 64 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Order.Customer.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 66 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 68 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
Write(Html.HiddenFor(m => m.Order.CustomerId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
Write(Html.HiddenFor(m => m.Products));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n");
#nullable restore
#line 71 "C:\Users\ttsil.VERTITECH\Documents\GitHub\EShop-Core\.vs\EShop Core\EShop\Views\Orders\Create.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShop.ViewModels.OrderViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

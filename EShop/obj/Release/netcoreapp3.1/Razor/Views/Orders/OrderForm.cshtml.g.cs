#pragma checksum "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e5cc077d42a50fb70982e05197dc42c47dc9edc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_OrderForm), @"mvc.1.0.view", @"/Views/Orders/OrderForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e5cc077d42a50fb70982e05197dc42c47dc9edc", @"/Views/Orders/OrderForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ad7cc28246796ad669746423360069dfc310f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_OrderForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShop.ViewModels.OrderViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
  
    ViewBag.Title = "Order";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 8 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 9 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
Write(Model.Order.Customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 10 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
 if (!Model.Order.Completed)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
Write(Html.ActionLink("Complete this order", "CompleteOrder", new { id = Model.Order.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
                                                                                                                             
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-bordered table-hover\">\r\n    <thead>\r\n        <tr>\r\n            <th>Product</th>\r\n            <th>Category</th>\r\n            <th>Price</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
         foreach (var orderProduct in Model.OrderProducts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 26 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
               Write(orderProduct.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
               Write(orderProduct.ProductCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
               Write(orderProduct.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</td>\r\n            </tr>\r\n");
#nullable restore
#line 30 "C:\github\EShop-Core\EShop\Views\Orders\OrderForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShop.ViewModels.OrderViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
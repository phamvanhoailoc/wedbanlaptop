#pragma checksum "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2750f506bc1459975c902948b89e138b73ca1ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NumberCart_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NumberCart/Default.cshtml")]
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
#line 1 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\_ViewImports.cshtml"
using WebLaptop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\_ViewImports.cshtml"
using WebLaptop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2750f506bc1459975c902948b89e138b73ca1ae", @"/Views/Shared/Components/NumberCart/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f36fa3a67cdd8e7b80e4dd644d25070e54132b93", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NumberCart_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebLaptop.ModelViews.CartItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml"
 if (Model != null && Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<a href=\"javascript:void(0);\" class=\"cart__toggle\">\n    <span class=\"cart__total-item\" id=\"NumberCart\" >");
#nullable restore
#line 5 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml"
                                               Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n</a>\n                <span class=\"cart__content\">\n                    <span class=\"cart__my\">My Cart:</span>\n                    <span class=\"cart__total-price\">");
#nullable restore
#line 9 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml"
                                               Write(Model.Sum(x => x.TotalMoney).ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</span>\n                </span> ");
#nullable restore
#line 10 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml"
                        }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <a href=""#"" class=""cart__toggle"">
                    <span class=""cart__total-item"">0</span>
                </a>
                                <span class=""cart__content"">
                                    <span class=""cart__my"">My Cart:</span>
                                    <span class=""cart__total-price"">0 VNĐ</span>
                                </span>");
#nullable restore
#line 19 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Shared\Components\NumberCart\Default.cshtml"
                                       }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebLaptop.ModelViews.CartItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9062289de26c302d0377e77cd5e5ddd305c7a924"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminTintucs_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminTintucs/Delete.cshtml")]
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
#line 1 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\_ViewImports.cshtml"
using WebLaptop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\_ViewImports.cshtml"
using WebLaptop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9062289de26c302d0377e77cd5e5ddd305c7a924", @"/Areas/Admin/Views/AdminTintucs/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f36fa3a67cdd8e7b80e4dd644d25070e54132b93", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminTintucs_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebLaptop.Models.Tintuc>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Tintuc</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 16 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 19 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 22 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Scontent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 25 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Scontent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 28 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 31 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 34 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Thumb));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 37 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Thumb));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 40 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Published));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 43 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Published));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 46 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 49 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 52 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 55 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 58 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 61 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 64 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 67 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 70 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsHot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 73 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsHot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 76 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsNewfeed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 79 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsNewfeed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 82 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MetaKey));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 85 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MetaKey));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 88 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MetaDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 91 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MetaDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 94 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 97 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 100 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Account));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 103 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Account.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 106 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 109 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cat.CatId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9062289de26c302d0377e77cd5e5ddd305c7a92415192", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9062289de26c302d0377e77cd5e5ddd305c7a92415459", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 114 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Areas\Admin\Views\AdminTintucs\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9062289de26c302d0377e77cd5e5ddd305c7a92417267", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebLaptop.Models.Tintuc> Html { get; private set; }
    }
}
#pragma warning restore 1591

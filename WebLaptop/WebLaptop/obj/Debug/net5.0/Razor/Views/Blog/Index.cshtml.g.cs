#pragma checksum "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af3de7cd15cca8823d05f290667f6ad4a8d1db6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
#nullable restore
#line 1 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
using PagedList.Core.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af3de7cd15cca8823d05f290667f6ad4a8d1db6f", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f36fa3a67cdd8e7b80e4dd644d25070e54132b93", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<WebLaptop.Models.Tintuc>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pager-container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::PagedList.Core.Mvc.PagerTagHelper __PagedList_Core_Mvc_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
  
    int CurrentPage = ViewBag.CurrentPage;
    int PageNext = CurrentPage + 1;
    ViewData["Title"] = "Blog Index-" + CurrentPage;
    Layout = "~/Views/Shared/_Layout.cshtml";
    List<Tintuc> IsBestSell = ViewBag.BestSell;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>

    <!-- breadcrumb area start -->
    <section class=""breadcrumb__area box-plr-75"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-xxl-12"">
                    <div class=""breadcrumb__wrapper"">
                        <nav aria-label=""breadcrumb"">
                            <ol class=""breadcrumb"">
                                <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Blog</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- breadcrumb area end -->
    <!-- blog area start -->
    <section class=""blog__area box-plr-75 pb-70"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-xxl-2 col-xl-3 col-lg-3"">
                    <div class=""sidebar__");
            WriteLiteral("widget\">\r\n                        <div class=\"sidebar__widget-item mb-35\">\r\n                            <div class=\"sidebar__search\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3de7cd15cca8823d05f290667f6ad4a8d1db6f6938", async() => {
                WriteLiteral("\r\n                                    <input type=\"text\" placeholder=\"Search posts here\">\r\n                                    <button type=\"submit\"><i class=\"far fa-search\"></i></button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                        
                        <div class=""sidebar__widget-item mb-35"">
                            <h3 class=""sidebar__widget-title mb-30"">B??i vi???t hot</h3>
                            <div class=""sidebar__post rc__post"">
                                <ul>
");
#nullable restore
#line 50 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                     if (IsBestSell != null)
                                    {
                                        foreach (var item in IsBestSell)
                                        {

                                            string url = $"/tin-tuc/{item.Alias}-{item.Id}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li>
                                                <div class=""rc__post d-flex align-items-center"">
                                                    <div class=""rc__post-thumb mr-20"">
                                                        <a href=""blog-details.html"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "af3de7cd15cca8823d05f290667f6ad4a8d1db6f9737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2824, "~/images/tintuc/", 2824, 16, true);
#nullable restore
#line 60 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 2840, item.Thumb, 2840, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 60 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 2858, item.Title, 2858, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                        </a>
                                                    </div>
                                                    <div class=""rc__post-content"">
                                                        <h3 class=""rc__post-title"">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 3226, "\"", 3237, 1);
#nullable restore
#line 65 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3233, url, 3233, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 65 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n                                                        </h3>\r\n                                                        <div class=\"rc__meta\">\r\n                                                            <span>");
#nullable restore
#line 68 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                                             Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                        </div>\r\n                                                    </div>\r\n                                                </div>\r\n                                            </li>\r\n");
#nullable restore
#line 73 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </ul>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class=""col-xxl-10 col-xl-9 col-lg-9 order-first order-lg-last"">
                    <div class=""row"">
");
#nullable restore
#line 85 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                         if (Model != null && Model.Count() > 0)
                        {
                            foreach (var item in Model)
                            {
                                string url = $"/tin-tuc/{item.Alias}-{item.Id}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-xxl-6 col-xl-6 col-lg-6 col-md-6"">
                                    <article class=""postbox__item format-image mb-50 transition-3"">
                                        <div class=""postbox__thumb w-img"">
                                            <a href=""blog-details.html"">
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "af3de7cd15cca8823d05f290667f6ad4a8d1db6f14859", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4779, "~/images/tintuc/", 4779, 16, true);
#nullable restore
#line 94 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 4795, item.Thumb, 4795, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 94 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 4813, item.Title, 4813, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            </a>
                                        </div>
                                        <div class=""postbox__content"">
                                            <h3 class=""postbox__title"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 5121, "\"", 5132, 1);
#nullable restore
#line 99 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5128, url, 5128, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 99 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                                          Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                            </h3>\r\n                                            <div class=\"postbox__meta\">\r\n                                                <p>Post Date: <span>");
#nullable restore
#line 102 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                                               Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></p>\r\n\r\n                                            </div>\r\n                                            <div class=\"postbox__text\">\r\n                                                <p>");
#nullable restore
#line 106 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                              Write(Html.Raw(item.Scontent));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                            </div>
                                            <div class=""postbox__bottom d-flex justify-content-between align-items-center"">
                                                <div class=""postbox__more"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 5889, "\"", 5900, 1);
#nullable restore
#line 110 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5896, url, 5896, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"t-y-btn t-y-btn-grey\">read more</a>\r\n                                                </div>\r\n");
            WriteLiteral("                                            </div>\r\n                                        </div>\r\n                                    </article>\r\n                                </div>\r\n");
#nullable restore
#line 119 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        <div class=""col-xxl-12"">
                            <div class=""row"">
                                <div class=""col-sm-5"">
                                    <div class=""dataTables_info"" id=""example_info"" role=""status"" aria-live=""polite"">Page ");
#nullable restore
#line 126 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
                                                                                                                    Write(CurrentPage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                </div>
                                <div class=""col-sm-7"">
                                    <div class=""dataTables_paginate paging_simple_numbers"" id=""example_paginate"">
                                        <ul class=""pagination"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3de7cd15cca8823d05f290667f6ad4a8d1db6f20889", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 131 "E:\Hoc Tap\wedLaptop\wedbanlaptop\WebLaptop\WebLaptop\Views\Blog\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.List = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("list", __PagedList_Core_Mvc_PagerTagHelper.List, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PagedList_Core_Mvc_PagerTagHelper.AspArea = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __PagedList_Core_Mvc_PagerTagHelper.AspController = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __PagedList_Core_Mvc_PagerTagHelper.AspAction = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- blog area end -->
    <!-- brand area start -->
   
    <!-- brand area end -->

</main>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<WebLaptop.Models.Tintuc>> Html { get; private set; }
    }
}
#pragma warning restore 1591

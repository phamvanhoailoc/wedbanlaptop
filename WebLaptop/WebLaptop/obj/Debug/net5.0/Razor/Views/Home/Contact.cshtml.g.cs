#pragma checksum "E:\Hoc Tap\wedLaptop\WebLaptop\WebLaptop\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9b74f93dd29cdc3d3dc35b9fec62fdd4007e381"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
#line 1 "E:\Hoc Tap\wedLaptop\WebLaptop\WebLaptop\Views\_ViewImports.cshtml"
using WebLaptop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Hoc Tap\wedLaptop\WebLaptop\WebLaptop\Views\_ViewImports.cshtml"
using WebLaptop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9b74f93dd29cdc3d3dc35b9fec62fdd4007e381", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bdaf23fcb796b740df3a8cbd3191c5b17236a2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Hoc Tap\wedLaptop\WebLaptop\WebLaptop\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Thông tin liên hệ";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>

    <!-- contact map area start -->
    <section class=""contact__area"">
        <div class=""container-fluid p-0"">
            <div class=""row gx-0"">
                <div class=""col-xxl-12"">
                    <div class=""contact__map"">
                        <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.736247097366!2d106.72386931487694!3d10.754799162533187!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3175256023554215%3A0x845701299c852f64!2zMTU2LzExIEh14buzbmggVOG6pW4gUGjDoXQsIFRhbmFoIEFiYW5nLCBRdeG6rW4gNywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1655885540268!5m2!1svi!2s"" width=""600"" height=""450"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 808, "\"", 826, 0);
            EndWriteAttribute();
            WriteLiteral(@" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- contact map area end -->
    <!-- contact area start -->
    <section class=""contact__area box-plr-90 pt-55 pb-100"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-xxl-4 col-xl-4 col-lg-5"">
                    <div class=""contact__info"">
                        

                        <div class=""contact__hotline d-flex align-items-center mb-35"">
                            <div class=""contact__hotline-icon mr-20"">
                                <i class=""fal fa-headset""></i>
                            </div>                          
                        </div>
                        <div class=""contact__address mb-20"">
                            <ul>
                               
                                        <li>
                      ");
            WriteLiteral(@"                      <p><span>Địa chỉ:</span>  </p>
                                        </li>
                                        <li>
                                            <p><span>Email:</span> </p>
                                        </li>
                                        <li>
                                            <p><span>Số điện thoại:</span> </p>
                                        </li>
                              
                            </ul>
                        </div>
                        <div class=""contact__social"">
                            <span>Social Share:</span>
                            <ul>
                                <li>
                                    <a href=""#""><i class=""fal fa-basketball-ball""></i></a>
                                </li>
                                <li>
                                    <a href=""#""><i class=""fab fa-twitter""></i></a>
                                </li>
         ");
            WriteLiteral(@"                       <li>
                                    <a href=""#""><i class=""fab fa-instagram""></i></a>
                                </li>
                                <li>
                                    <a href=""#""><i class=""fab fa-facebook-f""></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class=""col-xxl-8 col-xl-8 col-lg-7"">
                    <div class=""contact__form"">
                        <h3 class=""contact__title"">Hãy liên hệ với chúng tôi.</h3>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9b74f93dd29cdc3d3dc35b9fec62fdd4007e3817494", async() => {
                WriteLiteral(@"
                            <div class=""row"">
                                <div class=""col-xxl-6 col-xl-6 col-lg-6 col-md-6"">
                                    <div class=""contact__input"">
                                        <span>Name</span>
                                        <input type=""text"">
                                    </div>
                                </div>
                                <div class=""col-xxl-6 col-xl-6 col-lg-6 col-md-6"">
                                    <div class=""contact__input"">
                                        <span>Email</span>
                                        <input type=""email"">
                                    </div>
                                </div>
                                <div class=""col-xxl-12"">
                                    <div class=""contact__input"">
                                        <span>Phone Number</span>
                                        <input type=""tel"">
              ");
                WriteLiteral(@"                      </div>
                                </div>
                                <div class=""col-xxl-12"">
                                    <div class=""contact__input"">
                                        <span>What’s on your mind?</span>
                                        <textarea></textarea>
                                    </div>
                                </div>
                                <div class=""col-xxl-12"">
                                    <div class=""contact__btn"">
                                        <button type=""submit"" class=""t-y-btn"">send message</button>
                                    </div>
                                </div>
                            </div>
                        ");
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
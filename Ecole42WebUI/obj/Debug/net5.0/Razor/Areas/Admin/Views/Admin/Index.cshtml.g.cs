#pragma checksum "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98290bcb57daddc592191574d9363dfbfb8f8e02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98290bcb57daddc592191574d9363dfbfb8f8e02", @"/Areas/Admin/Views/Admin/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecole42Entity.Entity.Admin>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/list-user.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Admin Listele";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(" \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98290bcb57daddc592191574d9363dfbfb8f8e023455", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"
<div class=""container ml-0 mt-0"">
    <div class=""card"">
        <div class=""card-header"">
            <h4 class=""card-title"">Admin Listesi</h4>
        </div>
        <div class=""card-body"">
            <div class=""d-flex justify-content-between align-items-center mb-3"">
                <a type=""button"" href=""/admin/add-user"" class=""btn btn-primary"">Veri Ekle</a>
                <div class=""input-group search-area right d-lg-inline-flex d-none"">
                    <input type=""text"" id=""search-bar"" class=""form-control"" placeholder=""Arama..."">
                </div>
            </div>
            <div class=""table-responsive"">
                <table class=""table primary-table-bordered"">
                    <thead class=""thead-primary"">
                        <tr>
                            <th scope=""col"">Ad</th>
                            <th scope=""col"">Soyad</th>
                            <th scope=""col"">E-Posta</th>
                            <th scope=""col"">İŞLEMLER</th>
    ");
            WriteLiteral("                    </tr>\r\n                    </thead>\r\n                    <tbody id=\"table-data\">\r\n");
#nullable restore
#line 35 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                         if (Model.Count() != 0)
                        {
                            foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 41 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td> ");
#nullable restore
#line 43 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                                    Write(item.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 44 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                                    Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td>\r\n                                        <a style=\"color:white; cursor:pointer\" class=\"btnDetail btn btn-primary shadow btn-xs sharp mr-1\" data-id=\"");
#nullable restore
#line 46 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                                                                                                                                              Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fa fa-pencil\"></i></a>\r\n                                        <a style=\"color:white; cursor:pointer\" class=\"btnDelete btn btn-danger shadow btn-xs sharp mr-1\" data-id=\"");
#nullable restore
#line 47 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                                                                                                                                             Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fa fa-trash\"></i></a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 50 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Admin\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"modalContent\"></div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecole42Entity.Entity.Admin>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3599f76d0b39b60f724c84285936ec0f918b3480"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Project_Add), @"mvc.1.0.view", @"/Areas/Admin/Views/Project/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3599f76d0b39b60f724c84285936ec0f918b3480", @"/Areas/Admin/Views/Project/Add.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Project_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecole42WebUI.Areas.Admin.ViewModels.ProjectViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/myckeditor.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://cdn.ckeditor.com/ckeditor5/34.1.0/super-build/ckeditor.js\"></script>\r\n    <script src=\"/js/add-project.js\"></script>\r\n");
            }
            );
            DefineSection("heads", async() => {
                WriteLiteral(" \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3599f76d0b39b60f724c84285936ec0f918b34803978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
<div class=""container mt-0 ml-0"">
    <form action=""/admin/add-project"" id=""add-form"" enctype=""multipart/form-data"" method=""post"">
        <div class=""card"">
            <div class=""card-header"">
                <h5 class=""card-title"">Proje Ekle</h5>
            </div>
            <div class=""card-body"">

                <div class=""row"">
                    <div class=""col-12 form-group"">
                        <label for=""Title"">Proje Ad??</label>
                        <input maxlength=""100"" type=""text"" name=""Title"" class=""form-control"" required />
                    </div>
                    <div class=""col-12 form-group"">
                        <label for=""catID"">Proje Kategorisi</label>
                        <select class=""form-control"" name=""catID"">
                            <optgroup label=""Kategori se??iniz"">
");
#nullable restore
#line 30 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml"
                                 foreach (var item in Model.Categories)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 1384, "\"", 1400, 1);
#nullable restore
#line 32 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml"
WriteAttributeValue("", 1392, item.ID, 1392, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml"
                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 33 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Project\Add.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </optgroup>
                        </select>
                    </div>
                    <div class=""col-12 form-group"">
                        <label for=""ShortDescription"">K??sa A????klama</label>
                        <textarea id=""editor1"" name=""ShortDescription""></textarea>
                    </div>
                    <div class=""col-12 form-group"">
                        <label for=""Description"">A????klama</label>
                        <textarea id=""editor2"" name=""Description""></textarea>
                    </div>
                    
                </div>

            </div>
            <div class=""card-footer d-sm-flex justify-content-between align-items-center"">   
                <button type=""submit"" class=""btn btn-primary"">Ekle</button>
            </div>
        </div>
    </form>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecole42WebUI.Areas.Admin.ViewModels.ProjectViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

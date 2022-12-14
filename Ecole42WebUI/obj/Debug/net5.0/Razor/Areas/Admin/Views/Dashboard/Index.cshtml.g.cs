#pragma checksum "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71355ac3bf2a712010a7be310c95c31a855cc69b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71355ac3bf2a712010a7be310c95c31a855cc69b", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Admin Paneli";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    string name = Context.Session.GetString("Name");
    string surname = Context.Session.GetString("Surname");
    string email = Context.Session.GetString("Email");
    string image = Context.Session.GetString("Image");
    string campus = Context.Session.GetString("Campus");
    string level = Context.Session.GetString("Level");
    string afterDecimal = "";
    if (!string.IsNullOrEmpty(level))
        afterDecimal = level.Substring(level.Length - 2);
    string date = Context.Session.GetString("Date");
    string wallet = Context.Session.GetString("Wallet");
    string evaluation = Context.Session.GetString("Evaluation");
    string role = Context.Session.GetString("Role");
    string login = Context.Session.GetString("Username");
    string coalition_bg = Context.Session.GetString("CoalitionBackground");
    string coalition_name = Context.Session.GetString("CoalitionName");
    string coalition_color = Context.Session.GetString("CoalitionColor");
    string token = Context.Session.GetString("Token");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("heads", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/Admin/css/user-dashboard.css\">\r\n    <style>\r\n        b, .intra-header, .level-text{\r\n\t    color: ");
#nullable restore
#line 30 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
          Write(coalition_color);

#line default
#line hidden
#nullable disable
                WriteLiteral("!important;\r\n        }\r\n        .progress-bar{\r\n            background-color: ");
#nullable restore
#line 33 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                         Write(coalition_color);

#line default
#line hidden
#nullable disable
                WriteLiteral("!important;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 44 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
 if (role == "USER")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card intra-profile\"");
            BeginWriteAttribute("style", " style=\"", 1582, "\"", 1644, 5);
            WriteAttributeValue("", 1590, "background:", 1590, 11, true);
            WriteAttributeValue(" ", 1601, "url(", 1602, 5, true);
#nullable restore
#line 46 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 1606, coalition_bg, 1606, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1619, ");background-size:", 1619, 18, true);
            WriteAttributeValue(" ", 1637, "cover;", 1638, 7, true);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-4"">
                    <div class=""card text-white bg-primary"">
                        <div class=""card-body"">
                             <div id=""info-row"" class=""row justify-content-between"">
                                <div class=""col-12 py-2"">
                                    <b class=""h4"">Kullan??c?? Ad??: </b>
                                    <span class=""ml-1 h4 text-white"">");
#nullable restore
#line 55 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                Write(login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <div class=\"col-12 py-2\">\r\n                                    <b class=\"h4\">C??zdan: </b>\r\n                                    <span class=\"ml-1 h4 text-white\">");
#nullable restore
#line 59 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                Write(wallet);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ???</span>\r\n                                </div>\r\n                                <div class=\"col-12 py-2\">\r\n                                    <b class=\"h4\">Evaluation Puan??: </b>\r\n                                    <span class=\"ml-1 h4 text-white\">");
#nullable restore
#line 63 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                Write(evaluation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <div class=\"col-12 py-2\">\r\n                                    <b class=\"h4\">Koalisyon: </b>\r\n                                    <span class=\"ml-1 h4 text-white\">");
#nullable restore
#line 67 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                Write(coalition_name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div class=""col-md-8"">
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""card text-white bg-primary align-items-center"">
                                <div class=""card-header"">
                                    <h4 class=""text-white intra-header"">Kamp??s</h4>                             
                                </div>
                                <div class=""card-body"">
                                    <h3 class=""text-white text-center"" id=""campus"">");
#nullable restore
#line 82 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                              Write(campus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                </div>
                            </div>
                        </div>
                         <div class=""col-6"">
                            <div class=""card text-white bg-primary align-items-center"">
                                <div class=""card-header card-block text-center"">
                                    <h4 class=""text-white intra-header"">Blackhole Tarihi</h4>                             
                                </div>
                                <div class=""card-body"">
                                    <h3 class=""text-white text-center"" id=""blackhole"">");
#nullable restore
#line 92 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                                 Write(date);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                </div>
                            </div>
                        </div>
                        <div class=""col-12"">
                            <div class=""card text-white bg-primary"">
                                <div class=""card-header align-self-center"">
                                    <h4  class=""text-white intra-header"">Seviye</h4>                             
                                </div>
                                <div class=""card-body pt-3"">
                                <h4 class=""text-white mt-auto text-center"">");
#nullable restore
#line 102 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                      Write(level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <div class=\"progress\" style=\"height: 40px;\">\r\n                                    <div id=\"level-bar\" class=\"progress-bar progress-animated\"");
            BeginWriteAttribute("style", " style=\"", 5117, "\"", 5160, 4);
            WriteAttributeValue("", 5125, "width:", 5125, 6, true);
#nullable restore
#line 104 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
WriteAttributeValue(" ", 5131, afterDecimal, 5132, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5145, "%;", 5145, 2, true);
            WriteAttributeValue(" ", 5147, "height:40px;", 5148, 13, true);
            EndWriteAttribute();
            WriteLiteral(@" role=""progressbar"">                                      
                                    </div>
                                </div>                               
                            </div>                           
                            </div>
                        </div>       
                    </div>
                </div>
            </div>
        </div>
</div>
");
#nullable restore
#line 115 "C:\Users\x\Desktop\42BilgiDeposu\Ecole42WebUI\Areas\Admin\Views\Dashboard\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b9cb353b0c14de79ea88a0997426487d7fe75ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bitacora_Index), @"mvc.1.0.view", @"/Views/Bitacora/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bitacora/Index.cshtml", typeof(AspNetCore.Views_Bitacora_Index))]
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
#line 1 "D:\projects\CowSystem\CowSystem\Views\_ViewImports.cshtml"
using CowSystem;

#line default
#line hidden
#line 2 "D:\projects\CowSystem\CowSystem\Views\_ViewImports.cshtml"
using CowSystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b9cb353b0c14de79ea88a0997426487d7fe75ec", @"/Views/Bitacora/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f7601d16adc3c9a2a4d16d4cc5e2211634519ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Bitacora_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BitacoraViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAll", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-title", new global::Microsoft.AspNetCore.Html.HtmlString("¿Limpiar la bitacora?"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block delete btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-title", new global::Microsoft.AspNetCore.Html.HtmlString("¿Eliminar este elemento?"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
  
    ViewData["Title"] = "Bitácora";

#line default
#line hidden
            BeginContext(83, 200, true);
            WriteLiteral("    <div class=\"content-section\">\r\n        <div class=\"content-section-head\">\r\n            <div class=\"row justify-content-between\">\r\n                <div class=\"col-6 col-sm-4\">\r\n                    ");
            EndContext();
            BeginContext(284, 17, false);
#line 9 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
               Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(301, 92, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-6 col-sm-2\">\r\n                    ");
            EndContext();
            BeginContext(393, 151, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22008538b93e48639e1419faba29bbdb", async() => {
                BeginContext(494, 46, true);
                WriteLiteral("<i class=\"lni lni-trash\"></i> Limpiar Bitácora");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(544, 512, true);
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""content-section-body"">
            <div class=""row justify-content-center"">

                <div class=""col-12"">
                    <div class=""table-responsive"">
                        <table id=""tablaBitacora"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
                            <thead>
                                <tr>
                                    <th>");
            EndContext();
            BeginContext(1057, 42, false);
#line 24 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Ganado));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1147, 41, false);
#line 25 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Gasto));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1236, 47, false);
#line 26 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.TipoBalance));

#line default
#line hidden
            EndContext();
            BeginContext(1283, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1331, 43, false);
#line 27 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Usuario));

#line default
#line hidden
            EndContext();
            BeginContext(1374, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1422, 49, false);
#line 28 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.FechaRegistro));

#line default
#line hidden
            EndContext();
            BeginContext(1471, 178, true);
            WriteLiteral("</th>\r\n                                    <th>Eliminar</th>\r\n                                </tr>\r\n                            </thead>\r\n\r\n                            <tbody>\r\n");
            EndContext();
#line 34 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(1746, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1867, 41, false);
#line 38 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Ganado));

#line default
#line hidden
            EndContext();
            BeginContext(1908, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2036, 40, false);
#line 41 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Gasto));

#line default
#line hidden
            EndContext();
            BeginContext(2076, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2204, 46, false);
#line 44 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.TipoBalance));

#line default
#line hidden
            EndContext();
            BeginContext(2250, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2378, 42, false);
#line 47 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Usuario));

#line default
#line hidden
            EndContext();
            BeginContext(2420, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2548, 48, false);
#line 50 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FechaRegistro));

#line default
#line hidden
            EndContext();
            BeginContext(2596, 112, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td style=\"text-align:center;\">");
            EndContext();
            BeginContext(2708, 156, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9291ae4ffe26460a9092834ae3f0c371", async() => {
                BeginContext(2831, 29, true);
                WriteLiteral("<i class=\"lni lni-trash\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                                                                                                                                                WriteLiteral(item.IdRegistro);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2864, 46, true);
            WriteLiteral("</td>\r\n                                </tr>\r\n");
            EndContext();
#line 54 "D:\projects\CowSystem\CowSystem\Views\Bitacora\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(2945, 204, true);
            WriteLiteral("\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n        </div>\r\n    </div>\r\n    \r\n    ");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BitacoraViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

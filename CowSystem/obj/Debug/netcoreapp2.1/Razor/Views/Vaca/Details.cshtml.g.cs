#pragma checksum "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3eed911e6aa859a3b5cc9695c867d772504fdaa6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vaca_Details), @"mvc.1.0.view", @"/Views/Vaca/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vaca/Details.cshtml", typeof(AspNetCore.Views_Vaca_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eed911e6aa859a3b5cc9695c867d772504fdaa6", @"/Views/Vaca/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f7601d16adc3c9a2a4d16d4cc5e2211634519ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Vaca_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CowSystem.Models.VacaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "History", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Sell", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Death", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
  
    ViewData["Title"] = "Detalles";

#line default
#line hidden
            BeginContext(85, 327, true);
            WriteLiteral(@"
    <div class=""row justify-content-center"">
        <div class=""col-12 col-sm-4"">
            <div class=""content-section"">
                <div class=""content-section-head"">
                    <div class=""row justify-content-between"">
                        <div class=""col-6 col-sm-4"">
                            ");
            EndContext();
            BeginContext(413, 17, false);
#line 13 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(430, 525, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""content-section-body"">
                    <div class=""row justify-content-center"">
                        <div class=""col-10"">
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <table class=""table  table-sm"">
                                        <tr>
                                            <th scope=""row"">");
            EndContext();
            BeginContext(956, 42, false);
#line 24 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.Codigo));

#line default
#line hidden
            EndContext();
            BeginContext(998, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(1054, 38, false);
#line 25 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.Codigo));

#line default
#line hidden
            EndContext();
            BeginContext(1092, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(1253, 48, false);
#line 28 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.EstadoString));

#line default
#line hidden
            EndContext();
            BeginContext(1301, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(1357, 44, false);
#line 29 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.EstadoString));

#line default
#line hidden
            EndContext();
            BeginContext(1401, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(1562, 48, false);
#line 32 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.PartosString));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(1666, 44, false);
#line 33 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.PartosString));

#line default
#line hidden
            EndContext();
            BeginContext(1710, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(1871, 46, false);
#line 36 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.EdadString));

#line default
#line hidden
            EndContext();
            BeginContext(1917, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(1973, 42, false);
#line 37 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.EdadString));

#line default
#line hidden
            EndContext();
            BeginContext(2015, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(2176, 57, false);
#line 40 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.FechaNacimientoString));

#line default
#line hidden
            EndContext();
            BeginContext(2233, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(2289, 53, false);
#line 41 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.FechaNacimientoString));

#line default
#line hidden
            EndContext();
            BeginContext(2342, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(2503, 54, false);
#line 44 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.FechaIngresoString));

#line default
#line hidden
            EndContext();
            BeginContext(2557, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(2613, 50, false);
#line 45 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.FechaIngresoString));

#line default
#line hidden
            EndContext();
            BeginContext(2663, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(2824, 53, false);
#line 48 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.FechaSalidaString));

#line default
#line hidden
            EndContext();
            BeginContext(2877, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(2933, 49, false);
#line 49 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.FechaSalidaString));

#line default
#line hidden
            EndContext();
            BeginContext(2982, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(3143, 46, false);
#line 52 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.PesoString));

#line default
#line hidden
            EndContext();
            BeginContext(3189, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(3245, 42, false);
#line 53 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.PesoString));

#line default
#line hidden
            EndContext();
            BeginContext(3287, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(3448, 51, false);
#line 56 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.ValorPesoString));

#line default
#line hidden
            EndContext();
            BeginContext(3499, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(3555, 47, false);
#line 57 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.ValorPesoString));

#line default
#line hidden
            EndContext();
            BeginContext(3602, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(3763, 47, false);
#line 60 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.ValorString));

#line default
#line hidden
            EndContext();
            BeginContext(3810, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(3866, 43, false);
#line 61 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.ValorString));

#line default
#line hidden
            EndContext();
            BeginContext(3909, 160, true);
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(4070, 47, false);
#line 64 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.MadreString));

#line default
#line hidden
            EndContext();
            BeginContext(4117, 57, true);
            WriteLiteral("</th>\r\n                                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4174, "\"", 4222, 1);
#line 65 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
WriteAttributeValue("", 4181, Html.DisplayFor(model => model.MadreUrl), 4181, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4223, 22, true);
            WriteLiteral(" class=\"btn btn-link\">");
            EndContext();
            BeginContext(4246, 43, false);
#line 65 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                                                    Write(Html.DisplayFor(model => model.MadreString));

#line default
#line hidden
            EndContext();
            BeginContext(4289, 164, true);
            WriteLiteral("</a></td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(4454, 47, false);
#line 68 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.PadreString));

#line default
#line hidden
            EndContext();
            BeginContext(4501, 57, true);
            WriteLiteral("</th>\r\n                                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4558, "\"", 4606, 1);
#line 69 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
WriteAttributeValue("", 4565, Html.DisplayFor(model => model.PadreUrl), 4565, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4607, 22, true);
            WriteLiteral(" class=\"btn btn-link\">");
            EndContext();
            BeginContext(4630, 43, false);
#line 69 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                                                    Write(Html.DisplayFor(model => model.PadreString));

#line default
#line hidden
            EndContext();
            BeginContext(4673, 164, true);
            WriteLiteral("</a></td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th scope=\"row\">");
            EndContext();
            BeginContext(4838, 55, false);
#line 72 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                       Write(Html.DisplayNameFor(model => model.UltimaActualizacion));

#line default
#line hidden
            EndContext();
            BeginContext(4893, 55, true);
            WriteLiteral("</th>\r\n                                            <td>");
            EndContext();
            BeginContext(4949, 51, false);
#line 73 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.UltimaActualizacion));

#line default
#line hidden
            EndContext();
            BeginContext(5000, 941, true);
            WriteLiteral(@"</td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class=""col-12 col-sm-5"">
            <div class=""content-section"">
                <div class=""content-section-head"">
                    <div class=""row justify-content-between"">
                        <div class=""col-6 col-sm-9"">
                            Eventos relacionados
                        </div>
                        
                    </div>
                </div>
                <div class=""content-section-body"">
                    <div class=""row justify-content-center"">
                        <div class=""col-10"">
                            <ul class=""list-group list-group-flush"">
");
            EndContext();
#line 99 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                 foreach (var item in Model.EventList)
                                {

#line default
#line hidden
            BeginContext(6048, 66, true);
            WriteLiteral("                                    <li class=\"list-group-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6114, "\"", 6130, 1);
#line 101 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
WriteAttributeValue("", 6121, item.Url, 6121, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6131, 22, true);
            WriteLiteral(" class=\"btn btn-link\">");
            EndContext();
            BeginContext(6154, 16, false);
#line 101 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                                    Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(6170, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 102 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                }

#line default
#line hidden
            BeginContext(6216, 592, true);
            WriteLiteral(@"                            </ul>
                           
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class=""col-12 col-sm-3"">
            <div class=""content-section"">
                <div class=""content-section-head"">
                    <div class=""row justify-content-between"">
                        <div class=""col-12 col-sm-6"">
                            Acciones
                        </div>
                        <div class=""col-6 col-sm-6"">
                            ");
            EndContext();
            BeginContext(6808, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b52a53aa2e147518afda2490df3375b", async() => {
                BeginContext(6863, 48, true);
                WriteLiteral("<i class=\"lni lni-arrow-left-circle\"></i> Volver");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6915, 280, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""content-section-body"">
                    <div class=""row justify-content-center"">
                        <div class=""col-11"">

                                ");
            EndContext();
            BeginContext(7195, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43a4cdbaad34407aaba530d2b92fc428", async() => {
                BeginContext(7284, 52, true);
                WriteLiteral("<i class=\"lni lni-revenue\"></i> Historial Financiero");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 128 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                            WriteLiteral(Model.IdGanado);

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
            BeginContext(7340, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(7374, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f3f25941f484dc58dc9a68d09c07cc3", async() => {
                BeginContext(7460, 46, true);
                WriteLiteral("<i class=\"lni lni-revenue\"></i> Declarar venta");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 129 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                         WriteLiteral(Model.IdGanado);

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
            BeginContext(7510, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(7544, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "640adec33cfa4e28bcf529d7694d40b5", async() => {
                BeginContext(7630, 46, true);
                WriteLiteral("<i class=\"lni lni-target\"></i> Declarar muerte");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 130 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                         WriteLiteral(Model.IdGanado);

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
            BeginContext(7680, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(7714, 134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04ccdb8e2199436694fc58c56bd725f2", async() => {
                BeginContext(7800, 44, true);
                WriteLiteral("<i class=\"lni lni-pencil-alt\"></i> Modificar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 131 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
                                                                                         WriteLiteral(Model.IdGanado);

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
            BeginContext(7848, 182, true);
            WriteLiteral("\r\n                              \r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n    \r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8048, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 146 "D:\projects\CowSystem\CowSystem\Views\Vaca\Details.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CowSystem.Models.VacaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

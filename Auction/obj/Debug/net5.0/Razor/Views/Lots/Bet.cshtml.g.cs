#pragma checksum "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\Bet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dfb03fcba48395749b69ec54b10169b528a46b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lots_Bet), @"mvc.1.0.view", @"/Views/Lots/Bet.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dfb03fcba48395749b69ec54b10169b528a46b0", @"/Views/Lots/Bet.cshtml")]
    public class Views_Lots_Bet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\Bet.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""banner-area organic-breadcrumb"">
    <div class=""container"">
        <div class=""breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end"">
            <div class=""col-first"">
                <h1>Добавление в БД</h1>
                <nav class=""d-flex align-items-center"">
                    <a");
            BeginWriteAttribute("asp-area", " asp-area=\"", 381, "\"", 392, 0);
            EndWriteAttribute();
            WriteLiteral(" asp-controller=\"Lots\" asp-action=\"Index\">Главная<span class=\"lnr lnr-arrow-right\"></span></a>\r\n                    <a");
            BeginWriteAttribute("asp-area", " asp-area=\"", 511, "\"", 522, 0);
            EndWriteAttribute();
            WriteLiteral(@" asp-controller=""Lots"" asp-action=""Bet"">Ставка</a>
                </nav>
            </div>
        </div>
    </div>
</section>
<section class=""contact_area section_gap_bottom"">
		<div class=""container"">
        <div>
            <form method=""post"">
                <input type=""hidden"" value=""1"" name=""ProfileId""/>
                <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 889, "\"", 922, 1);
#nullable restore
#line 25 "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\Bet.cshtml"
WriteAttributeValue("", 897, ViewBag.lotId.ToString(), 897, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""LotId""/>
                <table>
                    <tr>
                        <td>Введите вашу ставку</td>
                        <td><input type=""text"" name=""Bet""/></td>
                    </tr>
                    <tr>
                        <td><input type=""submit"" value=""Отправить""/></td>
                    </tr>
                </table>
            </form>
        </div>
        </div>
</section>");
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

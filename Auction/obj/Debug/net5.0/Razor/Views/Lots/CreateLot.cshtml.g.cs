#pragma checksum "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\CreateLot.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "162a311f34489976658b5667a9b05b7a040ab596"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lots_CreateLot), @"mvc.1.0.view", @"/Views/Lots/CreateLot.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"162a311f34489976658b5667a9b05b7a040ab596", @"/Views/Lots/CreateLot.cshtml")]
    public class Views_Lots_CreateLot : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\CreateLot.cshtml"
  
    ViewBag.Title = "title";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<form method=\"post\">\r\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 123, "\"", 149, 1);
#nullable restore
#line 9 "C:\Users\nanan\RiderProjects\Auction\Auction\Views\Lots\CreateLot.cshtml"
WriteAttributeValue("", 131, ViewBag.LastLotId, 131, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""Id""/>
    <input type=""hidden"" value=""0"" name=""SoldOut""/>
    <table>
        <tr>
            <td>Введите имя лота</td>
            <td><input type=""text"" name=""Name""/></td>
        </tr>
        <tr>
            <td>Введите описание лота</td>
            <td><input type=""text"" name=""Description""/></td>
        </tr>
        <tr>
            <td>Введите ссылку на фотографию</td>
            <td><input type=""text"" name=""Image""/></td>
        </tr>
        <tr>
            <td>Введите начальную цену</td>
            <td><input type=""text"" name=""StartPrice""/></td>
        </tr>
        <tr>
            <td>Введите дату окончания аукциона</td>
            <td><input type=""text"" name=""EndOfAuctionDate""/></td>
        </tr>


        <tr>
            <td><input type=""submit"" value=""Отправить""/></td>
        </tr>
    </table>
</form>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

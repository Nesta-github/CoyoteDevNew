#pragma checksum "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\GetTela.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b2d9896ae5b2fddd4b22545f98ec242228dfb1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_GetTela), @"mvc.1.0.view", @"/Views/Login/GetTela.cshtml")]
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
#line 1 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\_ViewImports.cshtml"
using WebNesta.Coyote.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\_ViewImports.cshtml"
using WebNesta.Coyote.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b2d9896ae5b2fddd4b22545f98ec242228dfb1a", @"/Views/Login/GetTela.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da64e788ddf03f5467cf3c41f48b81377d6dfc93", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_GetTela : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\GetTela.cshtml"
  
   
   

    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    .coyote-table {
        border-collapse: collapse;
        margin: 25px 0;
        font-size: 1em;
        border-radius: 5px 5px 0 0;
        overflow: hidden;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
        width: 100%;
        cursor: default;
    }

        .coyote-table thead tr {
            background-color: #82BBEF;
            color: #fff;
            text-align: left;
        }

        .coyote-table th,
        .coyote-table td {
            padding: 10px 15px;
            font-weight: 100;
        }

        .coyote-table tbody tr {
            border-bottom: 1px solid #dddddd;
        }

            .coyote-table tbody tr:nth-of-type(even) {
                background-color: #EDEDEF;
            }

            .coyote-table tbody tr:last-of-type {
                border-bottom: 2px solid #82BBEF;
            }

            .coyote-table tbody tr:hover {
                color: #3B95E5;
            }

</style>

<div class=""row"" style");
            WriteLiteral(@"=""margin-left: 2px;"">
    <div class=""col-1"" style=""border-bottom: 1px solid #C8C8C8; padding: 1vh; color: #959595; text-align: center; cursor: pointer;"">Recebidas</div>
    <div class=""col-1"" style=""border-bottom: 2px solid #3B95E5; padding: 1vh; color: #3B95E5; text-align: center; cursor: pointer;"">Enviadas</div>
</div>

<table class=""coyote-table"">
    <thead>
        <tr>
            <th>Enviado em</th>
            <th>Destinatário</th>
            <th>Mensagem</th>
            <th>Lido em</th>
            <th>Ações</th>
        </tr>
    </thead>

    <tbody>
        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>Checar vencimento do Contrato.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr c");
            WriteLiteral(@"lass=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>Jorge Siqueira</td>
            <td>Tarefa DATA DE ENCERRAMENTO DO CONTRATO do imóvel precisa ser revisada.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>Teste mensagem.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr class=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>Jonathan Miller</td>
            <td>DATA DE ENCE");
            WriteLiteral(@"RRAMENTO DO CONTRATO do imóvel precisa ser revisada.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>Checar aditamento do Contrato 16790-12.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr class=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>Jorge Siqueira</td>
            <td>Tarefa DATA DE ENCERRAMENTO DO CONTRATO do imóvel 009F-13.</td>
            <td>01/02/22 - 10:54</td>
            <td>");
            WriteLiteral(@"
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>DATA DE ADITAMENTO DO CONTRATO - Boleta 780-1H.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr class=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>MASTER</td>
            <td>DATA DE ENCERRAMENTO DO CONTRATO do galpão H098H-001 precisa ser revisada.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas f");
            WriteLiteral(@"a-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>Checar aditamento do Contrato.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr class=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>MASTER</td>
            <td>DATA DE ENCERRAMENTO DO CONTRATO do galpão H098H-001 precisa ser revisada.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td");
            WriteLiteral(@">
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <td>Checar aditamento do Contrato.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr class=""active-row"">
            <td>15/02/22 - 15:20</td>
            <td>MASTER</td>
            <td>DATA DE ENCERRAMENTO DO CONTRATO do galpão H098H-001 precisa ser revisada.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>

        <tr>
            <td>31/01/22 - 12:33</td>
            <td>MASTER</td>
            <");
            WriteLiteral(@"td>Checar aditamento do Contrato.</td>
            <td>01/02/22 - 10:54</td>
            <td>
                <i class=""fas fa-trash-alt font-hover-red""></i>
                <i class=""fas fa-eye font-hover-blue ml-2""></i>
                <i class=""fas fa-pen font-hover-blue ml-2""></i>
            </td>
        </tr>
    </tbody>
</table>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

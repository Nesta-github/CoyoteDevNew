
const discountCellTemplate = function (container, options) {
    $('<div/>').dxBullet({
        onIncidentOccurred: null,
        size: {
            width: 150,
            height: 35,
        },
        margin: {
            top: 5,
            bottom: 0,
            left: 5,
        },
        showTarget: false,
        showZeroLevel: true,
        value: options.value * 100,
        startScaleValue: 0,
        endScaleValue: 100,
        tooltip: {
            enabled: true,
            font: {
                size: 18,
            },
            paddingTopBottom: 2,
            customizeTooltip() {
                return { text: options.text };
            },
            zIndex: 5,
        },
    }).appendTo(container);
};

let collapsed = false;

var messages =
{
    hfValidacaoPreenchaCampos: '#hfValidacaoPreenchaCampos',
    hfPageHeaderTitle: '#hfPageHeaderTitle',
    hfPageHeaderSubTitle: '#hfPageHeaderSubTitle',
    hfPageHeaderTitleDesc: '#hfPageHeaderTitleDesc',
    hfPesquisarComponent: '#hfPesquisarComponent',
    hfGridComponentId: '#hfGridComponentId',
    hfGridComponentComponente: '#hfGridComponentComponente',
    hfGridComponentClasse: '#hfGridComponentClasse',
    hfGridComponentAcoes: '#hfGridComponentAcoes',
    hfGridComponent: '#hfGridComponent',
    hfDesejaExcluir: '#hfDesejaExcluir'
}
var componentUrl =
{
    getDataGridComponent: '/component/GetAllComponent',
    getData: '/component/GetData',
    getDataSearch: 'component/search',
    postDataComponent: '/component',
    putDataComponent: '/component',
    deleteDataComponent: 'component/delete'
}

var uiComponentViewModel =
{
    btnOpenModalInsertEditComponent: '#btnOpenModalInsertEditComponent',
    modal: {
        modalInsertEditComponent: "#modalInsertEditComponent",
        btnCloseInsertComponent: '#btnCloseInsertComponent',
        btnInsertComponent: '#btnInsertComponent',
        popupComponent: '#popupComponent'
    },
    dvLoading: "#dvLoading",
    gridContainer: "#gridContainer"
}

var viewModelComponent =
{
    txtComponentId: '#txtComponentId',
    cbModelo: '#cbModelo',
    txtComponenteDescricao: '#txtComponenteDescricao',
    cbComponenteClasse: '#cbComponenteClasse',
}

//VIEW
var componentView = {
    FillForm: function (id, modeloId, componenteDescr, classeId) {
        $(viewModelComponent.txtComponentId).text(id);
        $(viewModelComponent.txtComponentId).val(id);

        $(viewModelComponent.cbModelo).val(modeloId);
        $(viewModelComponent.cbComponenteClasse).val(classeId);

        $(viewModelComponent.txtComponenteDescricao).text(componenteDescr);
        $(viewModelComponent.txtComponenteDescricao).val(componenteDescr);
    },
    ClearForm: function () {
        $(viewModelComponent.txtComponentId).text('');
        $(viewModelComponent.txtComponentId).val('');

        $(viewModelComponent.cbModelo).val(0);
        $(viewModelComponent.cbComponenteClasse).val(0);

        $(viewModelComponent.txtComponenteDescricao).text('');
        $(viewModelComponent.txtComponenteDescricao).val('');
    },
}

//MODEL 
var componentModel = {
    ValidateForm: function (event) {
        var isFormValid =
            util.Validate.FieldIsNotEmpy(viewModelComponent.txtComponenteDescricao) &&
            util.Validate.FieldIsNotEmpy(viewModelComponent.cbModelo) &&
            util.Validate.FieldIsNotEmpy(viewModelComponent.cbComponenteClasse);
      
        return isFormValid;
    }
}
//CONTROLLER
var componentController = {
    RegisterEvents: async function (event) {

        $(uiComponentViewModel.modal.btnInsertComponent).click(function (event) {
            if (componentModel.ValidateForm()) {
                $(uiComponentViewModel.dvLoading).show();
                if (crudMode.isInsert)
                    componentController.PostData(event);
                else
                    componentController.PutData(event);
            }
            else {
                modal.validate.ShowModal(false, $(messages.hfValidacaoPreenchaCampos).val());
            }
        });

        $(uiComponentViewModel.modal.btnCloseInsertComponent)
            .click(function (event) { $(uiComponentViewModel.modal.modalInsertEditComponent).modal('hide'); });

        $(uiComponentViewModel.btnOpenModalInsertEditComponent).click(function (event) {
           
            crudMode.isInsert = true;
            crudMode.editedId = 0;
            componentView.ClearForm();
            $(uiComponentViewModel.modal.popupComponent).text('Componente');
            $(uiComponentViewModel.modal.modalInsertEditComponent).modal('show');
        });
       

        $(masterPageViewModel.txtSerchComponent).keyup(function (event) {
            if (event.keyCode === 13) {
                componentController.Search(event);
            }

            else {
                if ($(masterPageViewModel.txtSerchComponent).val().length > 1) {
                    $(uiComponentViewModel.dvLoading).show();
                    componentController.Search(event);
                }
            }
        });

        footerGridCallback.RefreshGrid = async function (event) { componentController.Search(event); }
        footerGridCallback.ExportGrid = async function (event) { componentController.ExportGrid(event); }

        footerGridEvents.Init(event);
        $(modal.decision.btnCancelDecision).click(async function () {
            console.log('btnCancelDecision')
            $(modal.decision.id).modal('hide');

        });
        $(modal.decision.btnOkDecision).click(async function () {
            componentController.DeleteData($(modal.decision.hfDecisionId).val());
        });

    },
    GetData: async function (event) {
        await util.Request.GetRequest(event, componentUrl.getData + "?lang=" + globalModal.lang, function (data) {
            $(uiComponentViewModel.dvLoading).hide();
            var responseComponentCallback = util.Request.ParseResponse(data);
            componentController.CreateGrid(responseComponentCallback.result.componentes);
            util.Html.FillCombo(event, viewModelComponent.cbModelo, responseComponentCallback.result.modelos)
            util.Html.FillCombo(event, viewModelComponent.cbComponenteClasse, responseComponentCallback.result.classes)
        });
    },
    ExportGrid: async function (event) {


        var workbook = new ExcelJS.Workbook();
        var worksheet = workbook.addWorksheet('Main sheet');

        exportDataGrid({
            component: $(uiComponentViewModel.gridContainer).dxDataGrid("instance"),
            worksheet: worksheet,
            topLeftCell: { row: 7, column: 1 },
            customizeCell: function (options) {

            }
        }).then(function () {
            workbook.xlsx.writeBuffer().then(function (buffer) {
                saveAs(new Blob([buffer], { type: "application/octet-stream" }), "DataGrid.xlsx");
            });
        });



        // /* ********************************** */
        // console.log('ExportGrid');
        // window.jsPDF = window.jspdf.jsPDF;
        //// applyPlugin(window.jsPDF);
        // var pdfDoc = new jsPDF();
        // console.log(pdfDoc);
        // //var doc = new jsPDF();
        // var grid = $("#gridContainer").dxDataGrid("instance");
        // //console.log(grid);
        //

        //const options = {
        //    pdfDoc: pdfDoc,
        //    component: grid,
        //    customizeCell: (pdfCell, gridCell) => {
        //        if (gridCell.rowType === 'header') {
        //            if (gridCell.column.caption === 'Area') {
        //                pdfCell.content = "";
        //                pdfCell.customDrawCell = (data) => {
        //                    const padding = data.cell.styles.cellPadding;
        //                    const x = data.cell.x + padding;
        //                    const y = data.cell.y + padding;
        //                    const w = data.cell.width - padding * 2;
        //                    const opts = {
        //                        maxWidth: data.cell.width,
        //                        align: data.cell.styles.halign,
        //                        baseline: 'top'
        //                    };
        //                    pdfDoc.text('Area, km', x + w - 5, y, opts);
        //                    pdfDoc.setFontSize(8);
        //                    pdfDoc.text('2', x + w, y - 2, opts);
        //                };
        //            }
        //        }
        //    },
        //    autoTableOptions: {
        //        columnStyles: {
        //            7: { cellWidth: 200 }
        //        },
        //        tableWidth: 'wrap',
        //        margin: 20
        //    }
        //};

        //exportDataGrid(options).then(() => {
        //    pdfDoc.save("filePDF.pdf");
        //});
        //DevExpress.pdfExporter.exportDataGrid({
        //    jsPDFDocument: pdfDoc,
        //    component: grid
        //}).then(function () {
        //    doc.save('Customers.pdf');
        //});
        // exportDataGridToPdf({
        //     jsPDFDocument: pdfDoc,
        //     component: grid,
        //     autoTableOptions: {
        //         styles: {
        //             font: 'PTSans-Regular' // this is a part I forgot about before
        //         }
        //     }
        // }).then(() => {
        //     doc.save('Customers.pdf');
        // })

    },
    CreateGrid: function (dataSource) {
       
        $(uiComponentViewModel.gridContainer).dxDataGrid({
            /* loadingTimeout: null,  */
            allowColumnReordering: true, //SE O USUÁRIO PODE REORDENAR A COLUNA
            allowColumnResizing: true, //SE O USUÁRIO PODE REDIMENSIONAR A LARGURA DA COLUNA
            autoNavigateToFocusedRow: true,//COMPATIVEL COM MODO DE SCROOL INFINITO, QD FOCUSEDROWKEY É ALTERADO
            cacheEnabled: true,//RESULTADO EM CACHE PARA EXECUTAR OPERAÇÕES, grid.reload();para atualziar o cache após pesquisa
            cellHintEnabled: true, //HABILITA UMA DICA QD O USUÁRIO PASSA O MOUSE EM UMA CELULAR COM O CONTEÚDO TRUNCADO
            columnAutoWidth: true, //AJUSTA A LARGURA AUTOMATICAMENTE
            columnChooser: true,//PERMITE HABILITAR E DESBILITAR COLUNAS EM TEMPO DE EXECUÇÃO
            //columnFixing: QUANDO COLUNA EXCEDE O TAMANHO PODEW SELECIONAR NO MENU PARA SE AJUSTAR
            dataSource: dataSource,
            export: true,
            /*{
                enabled: true,
                fileName: "Employees",
                allowExportSelectedData: true
            },*/
            paging: { enabled: false },
            paginate: false,
            remoteOperations: false,
            searchPanel: {
                visible: false,
                highlightCaseSensitive: false,
            },
            groupPanel: { visible: false },
            grouping: {
                autoExpandAll: false,
            },

            rowAlternationEnabled: true,
            showBorders: false,

            //editing: {
            //    mode: 'row',
            //    allowUpdating: true,
            //    allowDeleting(e) {
            //        return !isChief(e.row.data.Position);
            //    },
            //    useIcons: true,
            //},
            /*hfGridComponentId
hfGridComponentComponente
hfGridComponentClasse
hfGridComponentAcoes
hfGridComponent
*/
            columns: [
                {
                    dataField: 'chidcodi',
                    caption: $(messages.hfGridComponentId).val(),
                },
                {
                    dataField: 'chdsdecr',
                    caption: $(messages.hfGridComponentComponente).val(),
                },
                {
                    dataField: 'chdsobsr',
                    caption: $(messages.hfGridComponentClasse).val(),
                },
                {
                    type: 'buttons',
                    caption: $(messages.hfGridComponentAcoes).val(),
                    dataField: 'customDataField',
                    width: 100,
                    buttons: ['edit', {
                        //hint: 'Edit',
                        //icon: 'edit',
                        cssClass: 'dx-datagrid-table-edit',
                        visible(e) {
                            return !e.row.isEditing;
                        },
                        disabled(e) {
                            return isChief(e.row.data.Position);
                        },
                        onClick(e) {
                            crudMode.isInsert = false;
                            crudMode.editedId = e.row.data.chidcodi;

                            $(uiComponentViewModel.modal.popupComponent).text(e.row.data.chdsdecr)

                            componentView.FillForm(
                                e.row.data.chidcodi,
                                e.row.data.chflsimp,
                                e.row.data.chdsdecr,
                                e.row.data.cmidcodi
                            );
                            /*cmidcodi as 'CLASSE',
                                    chflsimp as 'MODELO', */


                            $("#modalInsertEditComponent").modal('show');

                        },
                    }, 'delete', {
                            cssClass: 'dx-datagrid-table-delete',
                            visible(e) {
                                return !e.row.isEditing;
                            },
                            disabled(e) {
                                return isChief(e.row.data.Position);
                            },
                            onClick(e) {
                                
                             /*componentController.DeleteData(e.row.data.chidcodi);*/
                                $(modal.decision.hfDecisionId).val(e.row.data.chidcodi)
                             modal.decision.ShowModal('error', $(messages.hfDesejaExcluir).val());
                              
                            },
                        }],
                },
            ]
        });
    },
    PostData: function (event) {

        var viewModelComponentPost =
        {
            "id": $(viewModelComponent.txtComponentId).val(),
            "modelo": $(viewModelComponent.cbModelo).val(),
            "descricao": $(viewModelComponent.txtComponenteDescricao).val(),
            "classe": $(viewModelComponent.cbComponenteClasse).val()
        }

        util.Request.PostRequest(event, componentUrl.postDataComponent, viewModelComponentPost,
            function (data) {
              
                console.log('callback');
                console.log(data);
                $(uiComponentViewModel.dvLoading).hide();
                if (data.isValid) {
                    $(uiComponentViewModel.modal.modalInsertEditComponent).modal('hide');
                }
                modal.validate.ShowModal(data.isValid, data.message);
            });
    },
    PutData: function (event) {

        var viewModelComponentPost =
        {
            "id": $(viewModelComponent.txtComponentId).val(),
            "modelo": $(viewModelComponent.cbModelo).val(),
            "descricao": $(viewModelComponent.txtComponenteDescricao).val(),
            "classe": $(viewModelComponent.cbComponenteClasse).val()
        }
      
        util.Request.PutRequest(event, componentUrl.putDataComponent, viewModelComponentPost,
            function (data) {
                $(uiComponentViewModel.dvLoading).hide();
                console.log(data)
                if (data.isValid) {
                    $(uiComponentViewModel.modal.modalInsertEditComponent).modal('hide');
                }

                modal.validate.ShowModal(data.isValid, data.message);
            });
    },
    DeleteData: function (id) {

        var viewModelComponentPost =
        {
            "id": id,
        }
        console.log('viewModelComponentPost');
        console.log(viewModelComponentPost);
        console.log(componentUrl.deleteDataComponent)
        util.Request.GetRequest(event, componentUrl.deleteDataComponent + "?id=" + id,
            function (data) {
                $(uiComponentViewModel.dvLoading).hide();
                data = JSON.parse(data)
                console.log(data)
                if (data.isValid) {
                    $(modal.decision.id).modal('hide');
                }

                modal.validate.ShowModal(data.isValid, data.message);
            });
    },
    Search: async function (event) {
        await util.Request.GetRequest(event, componentUrl.getDataSearch + "?term=" + $(masterPageViewModel.txtSerchComponent).val(), function (data) {

            var responseComponentCallback = util.Request.ParseResponse(data);

            componentController.CreateGrid(responseComponentCallback.result);
            $(uiComponentViewModel.dvLoading).hide();
        });
    }
}

//EVENTS
var componentEvents =
{
    Init: async function (event) {

        masterPageController.SetPageHeader(
            $(messages.hfPageHeaderTitle).val(),
            $(messages.hfPageHeaderSubTitle).val(),
            $(messages.hfPageHeaderTitleDesc).val(),
            $(messages.hfPesquisarComponent).val());

        $(uiComponentViewModel.dvLoading).show();

        $(document).ready(function (event) {
            componentController.RegisterEvents(event)
            componentController.GetData(event);
        });
    }


}

componentEvents.Init(event);
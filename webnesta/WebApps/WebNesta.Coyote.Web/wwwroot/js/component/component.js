
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

var componentUrl =
{
    getDataGridComponent: '/component/GetAllComponent',
    getData: '/component/GetData',
    getDataSearch: 'component/search',
    postDataComponent: '/component'
}

var uiComponentViewModel =
{
    btnOpenModalInsertEditComponent: '#btnOpenModalInsertEditComponent',
    modal: {
        modalInsertEditComponent: "#modalInsertEditComponent",
        btnCloseInsertComponent: '#btnCloseInsertComponent',
        btnInsertComponent: '#btnInsertComponent'
    },
    dvLoading: "#dvLoading",
    txtSerchComponent: "#txtSerchComponent"
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
        var isFormValid = util.Validate.FieldIsNotEmpy(viewModelComponent.txtComponenteDescricao);
        console.log('isFormValid: ' + isFormValid);
        return isFormValid;
    }
}
//CONTROLLER
var componentController = {
    RegisterEvents: async function (event) {

        $(uiComponentViewModel.modal.btnInsertComponent).click(function (event) {
            if (componentModel.ValidateForm()) {
                componentView.LoadingComponent(event, true);
                model.PostData(event);
            }
            else {
                modal.validate.ShowModal(false, 'preencha os campos');
            }
        });

        $(uiComponentViewModel.modal.btnCloseInsertComponent)
            .click(function (event) { $(uiComponentViewModel.modal.modalInsertEditComponent).modal('hide'); });

        $(uiComponentViewModel.btnOpenModalInsertEditComponent).click(function (event) {

            crudMode.isInsert = true;
            crudMode.editedId = 0;
            componentView.ClearForm();
            $(uiComponentViewModel.modal.modalInsertEditComponent).modal('show');
        });

        $(uiComponentViewModel.txtSerchComponent).keyup(function (event) {
            if (event.keyCode === 13) {
                componentController.Search(event);
            }
        });

        footerGridCallback.RefreshGrid = async function (event) { console.log('RefreshGrid'); componentController.Search(event); }
        footerGridCallback.ExportGrid = async function (event) { console.log('ExportGrid'); componentController.ExportGrid(event); }

        footerGridEvents.Init(event);
    },
    GetData: async function (event) {
        await util.Request.GetRequest(event, componentUrl.getData, function (data) {
            $(uiComponentViewModel.dvLoading).hide();
            var responseComponentCallback = util.Request.ParseResponse(data);
            componentController.CreateGrid(responseComponentCallback.result.componentes);
            // util.Html.FillCombo(event, viewModelComponent.cbModelo, responseComponentCallback.result.modelos)
            // util.Html.FillCombo(event, viewModelComponent.cbComponenteClasse, responseComponentCallback.result.classes)
            // util.Loading(event, false);
        });
    },
    ExportGrid: async function (event) {
        console.log('ExportGrid');
        window.jsPDF = window.jspdf.jsPDF;
        applyPlugin(window.jsPDF);

        var doc = new jsPDF();
        var grid = $("#gridContainer").dxDataGrid("instance");

        DevExpress.pdfExporter.exportDataGrid({
            jsPDFDocument: doc,
            component: grid
        }).then(function () {
            doc.save('Customers.pdf');
        });
    },
    CreateGrid: function (dataSource) {
        $('#gridContainer').dxDataGrid({
            allowColumnReordering: true, //SE O USUÁRIO PODE REORDENAR A COLUNA
            allowColumnResizing: true, //SE O USUÁRIO PODE REDIMENSIONAR A LARGURA DA COLUNA
            autoNavigateToFocusedRow: true,//COMPATIVEL COM MODO DE SCROOL INFINITO, QD FOCUSEDROWKEY É ALTERADO
            cacheEnabled: true,//RESULTADO EM CACHE PARA EXECUTAR OPERAÇÕES, grid.reload();para atualziar o cache após pesquisa
            cellHintEnabled: true, //HABILITA UMA DICA QD O USUÁRIO PASSA O MOUSE EM UMA CELULAR COM O CONTEÚDO TRUNCADO
            columnAutoWidth: true, //AJUSTA A LARGURA AUTOMATICAMENTE
            columnChooser: true,//PERMITE HABILITAR E DESBILITAR COLUNAS EM TEMPO DE EXECUÇÃO
            //columnFixing: QUANDO COLUNA EXCEDE O TAMANHO PODEW SELECIONAR NO MENU PARA SE AJUSTAR
            dataSource: dataSource,
            //export: { enabled: true },
            export: {
                enabled: true,
                formats: ['pdf'],
                allowExportSelectedData: true,
            },
            onExporting(e) {
                window.jsPDF = window.jspdf.jsPDF;
                applyPlugin(window.jsPDF);

                const doc = new jsPDF();

                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: window.jspdf.jsPDF,
                    component: e.component,
                    indent: 5,
                }).then(() => {
                    doc.save('Companies.pdf');
                });
            },
            //{
            //    store: {
            //        type: 'odata',
            //        url: 'https://localhost:44325/component/GetAllComponent',
            //        key: 'chidcodi',
            //        beforeSend(request) {
            //            //parametros
            //            //request.params.startDate = '2020-05-10';

            //            //request.params.endDate = '2020-05-15';
            //        },
            //    },
            //},
            //paging: {
            //    pageSize: 10,
            //},
            paging: { enabled: false },
            paginate: false,
            remoteOperations: false,
            searchPanel: {
                visible: false,
                highlightCaseSensitive: true,
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
            columns: [
                //allowExporting: false,
                //{
                //    type: 'buttons',
                //    width: 15,
                //    buttons: ['delete', {
                //        //hint: 'DELETE',
                //        //icon: 'delete',
                //        cssClass:'dx-datagrid-table-delete',
                //        visible(e) {
                //            return !e.row.isEditing;
                //        },
                //        disabled(e) {
                //            return isChief(e.row.data.Position);
                //        },
                //        onClick(e) {
                //            console.log('click delete');
                //           // const clonedItem = $.extend({}, e.row.data, { ID: maxID += 1 });
                //           //
                //           // employees.splice(e.row.rowIndex, 0, clonedItem);
                //           // e.component.refresh(true);
                //           // e.event.preventDefault();
                //        },
                //    }],
                //},
                {
                    dataField: 'chidcodi',
                    caption: 'ID',
                },
                {
                    dataField: 'chdsdecr',
                    caption: 'Component',
                },
                {
                    dataField: 'chdsobsr',
                    caption: 'Classe',
                },
                {
                    type: 'buttons',
                    caption: 'Ações',
                    dataField:'customDataField',
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
                            console.log(e.row.data);
                            crudMode.isInsert = false;
                            crudMode.editedId = e.row.data.chidcodi;
                            componentView.FillForm(
                                e.row.data.chidcodi,
                                e.row.data.crnumcap,
                                e.row.data.chdsdecr,
                                e.row.data.crnumcap
                            )
                            console.log('click edit');
                            console.log(e.row.data.chidcodi);
                            $("#modalInsertEditComponent").modal('show');
                            /*const clonedItem = $.extend({}, e.row.data, { ID: maxID += 1 });

                            employees.splice(e.row.rowIndex, 0, clonedItem);
                            e.component.refresh(true);
                            e.event.preventDefault();*/
                        },
                    }, 'delete', {
                            //hint: 'DELETE',
                            //icon: 'delete',
                            cssClass: 'dx-datagrid-table-delete',
                            visible(e) {
                                return !e.row.isEditing;
                            },
                            disabled(e) {
                                return isChief(e.row.data.Position);
                            },
                            onClick(e) {
                                model.validate.ShowModal(false, "V")
                                console.log('click delete');
                                // const clonedItem = $.extend({}, e.row.data, { ID: maxID += 1 });
                                //
                                // employees.splice(e.row.rowIndex, 0, clonedItem);
                                // e.component.refresh(true);
                                // e.event.preventDefault();
                            },
                        }],
                },
            ],

            //summary: {
            //    totalItems: [{
            //        name: 'SelectedRowsSummary',
            //        showInColumn: 'customDataField',
            //        displayFormat: 'Sum: {0}',
            //        valueFormat: 'currency',
            //        summaryType: 'custom',
            //    },
            //    ],
            //    calculateCustomSummary(options) {
            //        if (options.name === 'SelectedRowsSummary') {
            //            if (options.summaryProcess === 'start') {
            //                options.totalValue = 0;
            //            }
            //            if (options.summaryProcess === 'calculate') {
            //                if (options.component.isRowSelected(options.value.ID)) {
            //                    options.totalValue += options.value.SaleAmount;
            //                }
            //            }
            //        }
            //    },
            //},

            onContentReady(e) {
                if (!collapsed) {
                    collapsed = true;
                    e.component.expandRow(['EnviroCare']);
                }
            },
        });
    },
    PostData: function (event) {

        var viewModelComponent =
        {
            "id": viewModelComponent.txtComponentId,
            "modelo": viewModelComponent.cbModelo,
            "descricao": viewModelComponent.txtComponenteDescricao,
            "classe": viewModelComponent.cbComponenteClasse
        }

        util.Request.PostRequest(event, componentUrl.postDataComponent, viewModelComponent,
            function (data) {

                if (data.isSuccess == false) {
                    view.ShowModal(false, data.message);
                }
                else {


                }
            });
    },
    Search: async function (event) {
        await util.Request.GetRequest(event, componentUrl.getDataSearch + "?term=" + $(uiComponentViewModel.txtSerchComponent).val(), function (data) {

            var responseComponentCallback = util.Request.ParseResponse(data);

            componentController.CreateGrid(responseComponentCallback.result);
            util.Loading(event, false);
        });
    }
}

//EVENTS
var componentEvents =
{
    Init: async function (event) {

        util.Loading(event, true);

        $(document).ready(function (event) {
            componentController.RegisterEvents(event)
            componentController.GetData(event);
        });
    }
}

componentEvents.Init(event);
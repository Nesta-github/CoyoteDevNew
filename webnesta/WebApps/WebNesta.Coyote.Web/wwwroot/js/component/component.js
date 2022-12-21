
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
    getDataComponent: '/component/GetAllComponent',
    postDataComponent: '/component'
}

var uiComponentViewModel =
{
    btnOpenModalInsertEditComponent:  '#btnOpenModalInsertEditComponent',
    modal: {
        modalInsertEditComponent: "#modalInsertEditComponent",
        btnCloseInsertComponent: '#btnCloseInsertComponent',
        btnInsertComponent: '#btnInsertComponent'
    },
    dvLoading: "#dvLoading",
}

var viewModelComponent =
{
    txtComponentId: '#txtComponentId',
    cbModelo: '#cbModelo',
    txtComponenteDescricao: '#txtComponenteDescricao',
    cbComponenteClasse: '#cbComponenteClasse',
}

//VIEW
var componentView =
{
    LoadingComponent:
        function (event, isShow) {
            if (isShow) {
                $(uiComponentViewModel.dvLoading).show()
            }
            else {
                $(uiComponentViewModel.dvLoading).hide()
            }
        },
}

//MODEL 
var componentModel = {
    ValidateForm: function (event) {
        var isFormValid =
            (util.Validate.FieldIsNotEmpy(viewModelComponent.txtComponentId) &&
                util.Validate.FieldIsNotEmpy(txtComponenteDescricao.senha));

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
                modal.validate.ShowModal(event, false, 'preencha os campos');
            }

        });

        $(uiComponentViewModel.modal.btnCloseInsertComponent)
            .click(function (event) { $(uiComponentViewModel.modal.modalInsertEditComponent).modal('hide'); });

        $(uiComponentViewModel.btnOpenModalInsertEditComponent).click(function (event) {
            $(uiComponentViewModel.modal.modalInsertEditComponent).modal('show');
        });

    },
    GetData: async function (event) {
        await util.Request.GetRequest(event, componentUrl.getDataComponent, function (data) {

            var responseComponentCallback = util.Request.ParseResponse(data);
            console.log(responseComponentCallback.result)
            componentController.CreateGrid(responseComponentCallback.result);
        });
    },
    CreateGrid: function (dataSource) {
        $('#gridContainer').dxDataGrid({
            allowColumnReordering: false, //SE O USUÁRIO PODE REORDENAR A COLUNA
            allowColumnResizing: true, //SE O USUÁRIO PODE REDIMENSIONAR A LARGURA DA COLUNA
            autoNavigateToFocusedRow: true,//COMPATIVEL COM MODO DE SCROOL INFINITO, QD FOCUSEDROWKEY É ALTERADO
            cacheEnabled: true,//RESULTADO EM CACHE PARA EXECUTAR OPERAÇÕES, grid.reload();para atualziar o cache após pesquisa
            cellHintEnabled: true, //HABILITA UMA DICA QD O USUÁRIO PASSA O MOUSE EM UMA CELULAR COM O CONTEÚDO TRUNCADO
            columnAutoWidth: true, //AJUSTA A LARGURA AUTOMATICAMENTE
            columnChooser: true,//PERMITE HABILITAR E DESBILITAR COLUNAS EM TEMPO DE EXECUÇÃO
            //columnFixing: QUANDO COLUNA EXCEDE O TAMANHO PODEW SELECIONAR NO MENU PARA SE AJUSTAR


            dataSource: dataSource,

            //dataSource:

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
            showBorders: true,

            //editing: {
            //    mode: 'row',
            //    allowUpdating: true,
            //    allowDeleting(e) {
            //        return !isChief(e.row.data.Position);
            //    },
            //    useIcons: true,
            //},
            columns: [

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
                            console.log('click edit');
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
                    view.ShowModal(event, false, data.message);
                }
                else {


                }
            });
    }
}

//EVENTS
var componentEvents =
{
    Init: function (event) {

        //view.LoadingComponent(event, true);

        $(document).ready(function (event) {
            componentController.RegisterEvents(event);

            componentController.GetData(event);
        });
    }
}

componentEvents.Init(event);
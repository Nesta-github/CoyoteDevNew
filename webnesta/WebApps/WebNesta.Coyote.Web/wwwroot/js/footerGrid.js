var uiFooterGridViewModel =
{
    btnExportGrid: '#btnExportGrid',
    btnRefreshGrid: '#btnRefreshGrid'
}

var footerGridCallback =
{
    RefreshGrid: null,
    ExportGrid: null
}

var footerGridController =
{
    RegisterEvents: async function (event) {
        console.log('controller RegisterEvents');
        $(uiFooterGridViewModel.btnExportGrid).click(function (event) {
            console.log('click btnExportGrid');
            footerGridCallback.ExportGrid(event);
        });

        $(uiFooterGridViewModel.btnRefreshGrid).click(function (event) {
            console.log('click btnRefreshGrid');
            footerGridCallback.RefreshGrid(event);
        });
    }
}

var footerGridEvents =
{
    Init: async function (event) {
        footerGridController.RegisterEvents(event);
    }
}


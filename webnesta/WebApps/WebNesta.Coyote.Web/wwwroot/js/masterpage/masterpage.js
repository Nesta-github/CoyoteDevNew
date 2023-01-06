var globalModelMasterPage = {
    theme: 1
}

var masterPageViewModel = {
    headerMasterPage: '#headerMasterPage',
    subheaderMasterPage: '#subheaderMasterPage',
    pageSubHeaderDescr: '#pageSubHeaderDescr',
    txtSerchComponent: '#txtSerchComponent'
}


var masterPageController = {
    Init: function (event) {
        masterPageController.LoadThemeStyle(event);
    },
    RegisterEvents: function (event) {

    },
    LoadThemeStyle: function (event) {

        //if (globalModelMasterPage.theme == 1) {
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleCoyotte.css"         });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/Site.css"                 });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/SiteResponsivo.css"       });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleDashBoard.css"       });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleEditorDEX.css"       });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleFloatingDev.css"     });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleGridView.css"        });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/StyleMenuDEX.css"         });
        //    $('<link>', { rel: 'stylesheet', type: 'text/css', href: "~/css/Tema1/pretty-checkbox.min.css" });
        //}

    },
    SetPageHeader: function (header, subHeader, headerDescr, serchTextbox) {
       
        $(masterPageViewModel.headerMasterPage).text(header);
        $(masterPageViewModel.subheaderMasterPage).text(subHeader);
        $(masterPageViewModel.pageSubHeaderDescr).text(headerDescr);
        $(masterPageViewModel.txtSerchComponent).attr("placeholder", serchTextbox);
    }
}

var events =
{
    Init: function (event) {
        //  view.LoadingComponent(event, true);

        $(document).ready(function (event) {
            masterPageController.Init(event);
            masterPageController.RegisterEvents(event);
        });
    }
}

events.Init(event);
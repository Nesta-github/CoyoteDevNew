var globalModelMasterPage = {
    theme: 1
}

var model = {}

var view = {}

var controller = {
    Init: function (event) {
        controller.LoadThemeStyle(event);
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
           
    }
}

var events =
{
    Init: function (event) {
      //  view.LoadingComponent(event, true);

        $(document).ready(function (event) {
            controller.Init(event);
            controller.RegisterEvents(event);
        });
    }
}

events.Init(event);
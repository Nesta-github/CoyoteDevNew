
var viewModel = {
    usuario: "#txtLogin",
    senha: "#txtPassword"
}

var uiViewModel = {
    btnLogin: "#btnLogin",
    dvLoading: "#dvLoading",
    modal: {
        myModal: "#myModal",
        dvModalSuccess: "#dvModalSuccess",
        dvModalError: "#dvModalError",
        dvModalMessageSuccess: "#dvModalMessageSuccess",
        dvModalMessageError: "#dvModalMessageError",
        dvModalTitleSuccess: "#dvModalTitleSuccess",
        dvModalTitleError: "#dvModalTitleError",
    },
    Valida: false,
    Key_2FA_Google: "",
    chkRemember: "#chkRemember"
}

var url = {
    getDataLogin: '/Login/GetDataLogin'
}

var util =
{
    Request: {
        GetRequest: function (event, url, callback) {

            return new Promise((resolve, reject) => {
                let xhr = new XMLHttpRequest();
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == XMLHttpRequest.DONE) {
                        if (callback !== undefined && callback != null) {

                            resolve(callback(xhr.responseText));
                        }
                        else {

                            resolve(xhr.responseText);
                        }
                    }
                }
                xhr.open('GET', url, true);
                xhr.send(null);

            })

        },
        GetRequestAwait: function (event, url) {
            const req = new Promise((resolve, reject) => {
                let xhr = new XMLHttpRequest();
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == XMLHttpRequest.DONE) {

                        resolve(xhr.responseText);
                    }
                }
                xhr.open('GET', url, true);
                xhr.send(null);

            });
            return req;
        },
        ParseResponse: function (response) {
            var objectParsed = null;

            if (response !== undefined && response.length > 0) {
                objectParsed = JSON.parse(response);
            }

            return objectParsed;
        }
    },
    Validate:
    {
        FieldIsNotEmpy: function (field) { return ($(field).val().length > 0); },
        FieldMaxLength: function (max, field) {
            var isValidFieldLength = true;

            if (field !== undefined) {

                if (max !== undefined && max != null) {

                    if ($(field).val().length > max) {
                        isValidFieldLength = false;
                    }
                }
            } else {
                isValidFieldLength = false;
            }

            return isValidFieldLength
        },
        FieldEnable: function (isEnable, field) {
            if (isEnable) {
                $(field).removeAttr("disabled");
            } else {
                $(field).attr("disabled", true);
            }
        },
        FieldMaskLength: function (field, max) {
            $(field).keyup(function () {

                if ($(field).val().length > max) {
                    $(field).val($(field).val().substring(0, max));
                }
            });
        }
    },

}

var view = {
    LoadingComponent: function (event, isShow) { if (isShow) { $(uiViewModel.dvLoading).show() } else { $(uiViewModel.dvLoading).hide() } },
    ShowModal: function (event, isSuccess, message) {

        $(uiViewModel.modal.dvModalMessageSuccess).hide();
        $(uiViewModel.modal.dvModalMessageError).hide();
        $(uiViewModel.modal.dvModalSuccess).hide();
        $(uiViewModel.modal.dvModalError).hide();
        $(uiViewModel.modal.dvModalTitleSuccess).hide();
        $(uiViewModel.modal.dvModalTitleError).hide();

        $(uiViewModel.modal.myModal).modal('show');

        setTimeout(function (event) {

            if (isSuccess) {
                $(uiViewModel.modal.dvModalSuccess).show();
                $(uiViewModel.modal.dvModalMessageSuccess).text(message);
                $(uiViewModel.modal.dvModalTitleSuccess).fadeIn('slow', 'linear');
                $(uiViewModel.modal.dvModalMessageSuccess).fadeIn('slow', 'linear');

            }
            else {
                $(uiViewModel.modal.dvModalError).show();
                $(uiViewModel.modal.dvModalMessageError).text(message);
                $(uiViewModel.modal.dvModalTitleError).fadeIn('slow', 'linear');
                $(uiViewModel.modal.dvModalMessageError).fadeIn('slow', 'linear');
            }
        }, 200)
    }
}

var model = {
    ValidateForm: function (event) {
        var isFormValid =
            (util.Validate.FieldIsNotEmpy(viewModel.usuario) &&
                util.Validate.FieldMaxLength(10, viewModel.usuario) &&
                util.Validate.FieldIsNotEmpy(viewModel.senha) &&
                util.Validate.FieldMaxLength(10, viewModel.senha));

        return isFormValid;
    },
    Login: function (event) {

        view.LoadingComponent(event, true);

        //EXIBIR MODAL
        if (!model.ValidateForm(event)) {
            view.LoadingComponent(event, false);
            view.ShowModal(event, false, "Usuário e Senha inválidos.");
        }
        else {
            //POST
            view.LoadingComponent(event, false);
            view.ShowModal(event, true, "Usuário e senha válidos");
        }
    },
    DataLoadCallback: function (data) {

        var responseObject = util.Request.ParseResponse(data)

        if (responseObject != null) {

            uiViewModel.Valida = responseObject.valida;
            uiViewModel.Key_2FA_Google = responseObject.key_2FAGoogle;

            if (uiViewModel.Valida) {
                util.Validate.FieldEnable(false, uiViewModel.chkRemember)
                util.Validate.FieldEnable(false, uiViewModel.btnLogin)
            }
            else {
                util.Validate.FieldEnable(true, uiViewModel.chkRemember)
                util.Validate.FieldEnable(true, uiViewModel.btnLogin)
            }
        }

        view.LoadingComponent(event, false);
    }
}

var controller = {
    Init: function (event) { controller.GetDataLogin(event); },
    GetDataLogin: function (event) {
        util.Request.GetRequest(event, url.getDataLogin, model.DataLoadCallback);
    },
    RegisterEvents: function (event) {

        $(uiViewModel.btnLogin).click(function (event) { model.Login(event); });
        util.Validate.FieldMaskLength(viewModel.usuario, 10);
        util.Validate.FieldMaskLength(viewModel.senha, 10);
    }
}

var events =
{
    Init: function (event) {
        view.LoadingComponent(event, true);

        $(document).ready(function (event) {
            controller.Init(event);
            controller.RegisterEvents(event);
        });
    }
}

events.Init(event);

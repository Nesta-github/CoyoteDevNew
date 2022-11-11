
var viewModel = {
    usuario: "#txtLogin",
    senha: "#txtPassword"
}

var viewModelEsqueciSenha = {
    emailRecoveryPassword: "#txtEmailRecuperarSenha"
}

var uiViewModel = {
    btnLogin: "#btnLogin",
    btnEsqueciMinhaSenha: "#btnEsqueciMinhaSenha",
    dvLoading: "#dvLoading",
    modal: {
        myModal: "#myModal",
        dvModalSuccess: "#dvModalSuccess",
        dvModalError: "#dvModalError",
        dvModalMessageSuccess: "#dvModalMessageSuccess",
        dvModalMessageError: "#dvModalMessageError",
        dvModalTitleSuccess: "#dvModalTitleSuccess",
        dvModalTitleError: "#dvModalTitleError",
        modalRecoveryPassword: '#modalRecoveryPassword'
    },
    Valida: false,
    Key_2FA_Google: "",
    chkRemember: "#chkRemember",
    pageVersion: "#dvPageVersion",
    btnCancelarRecuperarSenha: "#btnCancelarRecuperarSenha",
    btnRecuperarSenha: "#btnRecuperarSenha"
}

var url = {
    getDataLogin: '/login/GetDataLogin',
    postDataLogin: '/login/Autentica',
    getRecoveryPassword: '/login/RecoveryPassword'
}

var util =
{
    Request: {
        GetRequest: async function (event, url, callback) {
            console.log('url: ' + url);
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
        },
        PostRequest: async function (event, url, model, callback) {

            $.ajax({
                url: url,
                type: "POST",
                datatype: "json",
                data: model,
                contentType: 'application/x-www-form-urlencoded',
                //contentType: "application/json;",
                success: callback,
                error: function (error) {
                    $(uiViewModel.dvLoading).hide()
                }
            });
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
        },
        FieldEmail: function (field) {
            var emailValue = $(field).val();
            const emailRegexp = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
            return emailRegexp.test(emailValue);
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
    },
    ShowModalRecoveryPassword: function (event) {
        console.log('view - ShowModalRecoveryPassword')
        $(uiViewModel.modal.modalRecoveryPassword).modal('show');
    },
    CloseModalRecoveryPassword: function (event) {
        console.log('view - CloseModalRecoveryPassword')
        $(uiViewModel.modal.modalRecoveryPassword).modal('toggle');
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
    Login: async function (event) {
        ////EXIBIR MODAL
        if (!model.ValidateForm(event)) {
            view.LoadingComponent(event, false);
            view.ShowModal(event, false, "Usuário e Senha inválidos.");
        }
        else {
            //POST

            await controller.PostDataLogin(event);
        }
    },
    RecoveryPassword: async function (event) {
        console.log('model - ShowModalRecoveryPassword');
        ////EXIBIR MODAL
        if (!model.ValidateFormRecoveryPassword(event)) {
            view.LoadingComponent(event, false);
            view.ShowModal(event, false, "E-mail deve ser preenchido.");
        }
        else {
            if (!util.Validate.FieldEmail(viewModelEsqueciSenha.emailRecoveryPassword)) {
                view.LoadingComponent(event, false);
                view.ShowModal(event, false, "Formato de email inválido.");
            }
            else
                //POST
                await controller.PostDataRecoveryPassword(event);
        }
    },
    DataLoadCallback: function (data) {

        var responseObject = util.Request.ParseResponse(data)

        if (responseObject != null) {

            uiViewModel.Valida = responseObject.valida;
            uiViewModel.Key_2FA_Google = responseObject.key_2FAGoogle;

            console.log(uiViewModel.pageVersion);
            console.log(responseObject);

            $(uiViewModel.pageVersion).text(responseObject.telaVersion);

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
    },
    ValidateFormRecoveryPassword: function (event) {
        var isFormValidRecoveryPassword =
            util.Validate.FieldIsNotEmpy(viewModelEsqueciSenha.emailRecoveryPassword);

        return isFormValidRecoveryPassword;
    },
}

var controller = {
    Init: function (event) { controller.GetDataLogin(event); },
    GetDataLogin: async function (event) {
        await util.Request.GetRequest(event, url.getDataLogin, model.DataLoadCallback);
    },
    RegisterEvents: async function (event) {

        $(uiViewModel.btnLogin).click(function (event) { model.Login(event); });
        $(uiViewModel.btnEsqueciMinhaSenha).click(function (event) { console.log('RecoveryPassword'); view.ShowModalRecoveryPassword(event); });
        $(uiViewModel.btnRecuperarSenha).click(function (event) { console.log('enviar RecoveryPassword'); model.RecoveryPassword(event); });
        $(uiViewModel.btnCancelarRecuperarSenha).click(function (event) { console.log('enviar view.CloseModalRecoveryPassword(event);'); view.CloseModalRecoveryPassword(event); });

        util.Validate.FieldMaskLength(viewModel.usuario, 10);
        util.Validate.FieldMaskLength(viewModel.senha, 10);
        util.Validate.FieldMaskLength(viewModelEsqueciSenha.emailRecoveryPassword, 120);

    },
    PostDataLogin: function (event) {
        var model = { "username": $(viewModel.usuario).val(), "password": $(viewModel.senha).val() };

        util.Request.PostRequest(event, url.postDataLogin, model,
            function (data) {

                setTimeout(function () {
                    view.LoadingComponent(event, false);

                }, 600);
                console.log('data.title')
                console.log(data.title)
                if (data.title == 'OK') {
                    view.ShowModal(event, true, data.title);
                }
                else
                    view.ShowModal(event, false, data.title);

            });
    },
    PostDataRecoveryPassword: function (event) {
        var model = { "emailRecoveryPassword": $(viewModelEsqueciSenha.emailRecoveryPassword).val() };

        util.Request.PostRequest(event, url.getRecoveryPassword, model,
            function (data) {

                setTimeout(function () {
                    view.LoadingComponent(event, false);

                }, 600);

                if (data.title == "E-mail deve ser preenchido.") {
                    view.ShowModal(event, false, data.title);
                } if (data.title == "Email não cadastrado.") {
                    view.ShowModal(event, false, data.title);
                } if (data.title == "Enviado e-mail com senha temporária.") {
                    view.ShowModal(event, true, data.title);
                }
             

            });
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

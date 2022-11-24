﻿var globalModal = {
    lang: navigator.language
}

var viewModel = {
    usuario: "#txtLogin",
    senha: "#txtPassword",
    remember: "#chkRemember"
}

var viewModelEsqueciSenha = {
    emailRecoveryPassword: "#txtEmailRecuperarSenha"
}

var modalTutorialNavBar =
{
    isLoaded: false,
    navbarNavAltMarkup: "#navbarNavAltMarkup .navbar-nav",
    dvContentTutorial: "#dvContentTutorial",
    htmlNavBarTemplate:
        '<div id="{6}" class="col-sm-12 col-md-6 col-lg-6 card bg-transparent card_tutorial border-0" {5}>' +
        '<div class= "card-header bg-transparent border-0 pl-0" >' +
        '<span class="badge badge-secondary" style="color: #fff; background-color: #6c757d; width: 24px; height: 24px; line-height: 15px;">'
        + "{0}" +
        '</span >' +
        '<span class="ml-2">' +
        "{1}" +
        '</span>' +
        '</div>' +
        '<div class="card-body">' +
        '<label class="ml-3">' + "{2}" + '</label>' +
        '</div>' +
        '<div class= "card-footer bg-transparent border-0">' +
        "{3}" +
        "{4}" +
        '</div>' +
        '<hr/>' +
        '</div >'
}

var uiViewModel = {
    btnLogin: "#btnLogin",
    btnEsqueciMinhaSenha: "#btnEsqueciMinhaSenha",
    btnAjudaLogin: "#btnAjudaLogin",
    dvLoading: "#dvLoading",
    modal: {
        myModal: "#myModal",
        dvModalSuccess: "#dvModalSuccess",
        dvModalError: "#dvModalError",
        dvModalMessageSuccess: "#dvModalMessageSuccess",
        dvModalMessageError: "#dvModalMessageError",
        dvModalTitleSuccess: "#dvModalTitleSuccess",
        dvModalTitleError: "#dvModalTitleError",
        modalRecoveryPassword: '#modalRecoveryPassword',
        modalTutorial: '#modalTutorial',
        popupTutorialTitle: '#popupTutorialTitle',
        popupTutorialTitleDescription: '#popupTutorialTitleDescription'
    },
    captcha:
    {
        lkbRefreshCaptcha: "#lkbRefreshCaptcha",
        dvCaptcha: "#dvCaptcha",
        imgCaptcha: "#imgCaptcha",
        txtCaptcha: "#txtCaptcha",
        btnEntraCaptcha: "#btnEntraCaptcha",
        btnCancelarCaptcha: "#btnCancelarCaptcha"
    },
    Valida: false,
    Key_2FA_Google: "",
    chkRemember: "#chkRemember",
    pageVersion: "#dvPageVersion",
    btnCancelarRecuperarSenha: "#btnCancelarRecuperarSenha",
    btnRecuperarSenha: "#btnRecuperarSenha",
    lblRemember: "#lblRemember",
    storage: {
        catpchaCodeKey: '#hfCatpchaCodeKey'
    }
}

var url = {
    getDataLogin: '/login/GetDataLogin',
    postDataLogin: '/login/Autentica',
    getRecoveryPassword: '/login/RecoveryPassword',
    getRefreshCaptcha: '/login/RefreshCaptcha',
    getValidateCaptcha: "login/ValidateCaptcha",
    getTutorial: "login/Tutorial"
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
    Session: {
        setLocalStorageItem: function (key, value) {
            localStorage.setItem(key, value);

        },
        getLocalStorageItem: function (key) {
            return localStorage.getItem(key);
        },
        removeLocalStorageItem: function (key) {
            return localStorage.removeItem(key);
        }
    }
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
        $(uiViewModel.modal.modalRecoveryPassword).modal('show');
    },
    CloseModalRecoveryPassword: function (event) {
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
        console.log(responseObject);
        if (responseObject != null) {

            uiViewModel.Valida = responseObject.valida;
            uiViewModel.Key_2FA_Google = responseObject.key_2FAGoogle;

            $(uiViewModel.pageVersion).text(responseObject.telaVersion);

            if (responseObject.userName !== undefined && responseObject.userName != null
                && responseObject.userName.length > 0) {
                $(viewModel.usuario).text(responseObject.userName);
                $(viewModel.usuario).val(responseObject.userName);
            }

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
    ValidateCaptchaForm: function (event) {
        var isFormValidRecoveryPassword =
            util.Validate.FieldIsNotEmpy(uiViewModel.captcha.txtCaptcha);

        return isFormValidRecoveryPassword;
    },
    CaptchaCallBack: function (data) {
        $(uiViewModel.captcha.txtCaptcha).text('');


        $(uiViewModel.captcha.dvCaptcha).show();


        $(uiViewModel.btnLogin).hide();
        $(uiViewModel.captcha.btnEntraCaptcha).show();
        $(uiViewModel.captcha.btnCancelarCaptcha).show();
    },
    RefreshCaptchaCallback: function (data) {

        data = JSON.parse(data);

        util.Session.removeLocalStorageItem($(uiViewModel.storage.catpchaCodeKey).val());

        $(uiViewModel.storage.catpchaCodeKey).val(data.fileNameCaptcha);
        util.Session.setLocalStorageItem(data.fileNameCaptcha, data.captchaCode)
        $(uiViewModel.captcha.txtCaptcha).text('');
        $(uiViewModel.captcha.imgCaptcha).css({
            "background-image": "url(" + data.captchaImagePath + ")",
            "height": "40px",
            "width": "33%",
            "background-repeat": "no-repeat",
            "border-radius": "8px",
            "margin-top": "3%",
            "margin-left": "33%",
            "margin-bottom": "3%"
        });
    }
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

        $(uiViewModel.captcha.lkbRefreshCaptcha).click(async function (event) {
            await util.Request.GetRequest(event, url.getRefreshCaptcha + "?oldCaptcha=" + $(uiViewModel.storage.catpchaCodeKey).val()
                , model.RefreshCaptchaCallback);
        });

        $(uiViewModel.captcha.btnEntraCaptcha).click(async function (event) {

            var codeCaptcha =
                util.Session.getLocalStorageItem($(uiViewModel.storage.catpchaCodeKey).val());
            if (model.ValidateCaptchaForm(event)) {

                if ($(uiViewModel.captcha.txtCaptcha).val() == codeCaptcha) {
                    await util.Request.GetRequest(event, url.getValidateCaptcha + "?oldCaptcha=" + $(uiViewModel.storage.catpchaCodeKey).val()
                        , function (data) {
                            util.Session.removeLocalStorageItem($(uiViewModel.storage.catpchaCodeKey).val());
                            $(uiViewModel.storage.catpchaCodeKey).val('');
                            view.ShowModal(event, true, "O código está validado.");
                        });

                }
                else {
                    await util.Request.GetRequest(event, url.getRefreshCaptcha + "?oldCaptcha=" + $(uiViewModel.storage.catpchaCodeKey).val()
                        , model.RefreshCaptchaCallback);
                    view.ShowModal(event, false, "O campo do código captcha informado é  diferente.");
                }
            }
            else {
                view.ShowModal(event, false, "O campo do código deve ser preenchido.");
            }
        })

        $(uiViewModel.captcha.btnCancelarCaptcha).click(async function (event) {

            util.Session.removeLocalStorageItem($(uiViewModel.storage.catpchaCodeKey).val());
            $(uiViewModel.storage.catpchaCodeKey).val('');
            $(uiViewModel.captcha.btnEntraCaptcha).hide();
            $(uiViewModel.captcha.btnCancelarCaptcha).hide();
            $(uiViewModel.captcha.dvCaptcha).fadeOut('slow', 'linear');
            $(uiViewModel.captcha.imgCaptcha).attr('src', '');
            $(uiViewModel.captcha.txtCaptcha).text('');
            $(uiViewModel.lblRemember).show();
            $(uiViewModel.btnEsqueciMinhaSenha).show();
            $(uiViewModel.btnLogin).show();


        });

        $(uiViewModel.btnAjudaLogin).click(async function (event) {

            $(uiViewModel.dvLoading).show();

            if (!modalTutorialNavBar.isLoaded) {

                await util.Request.GetRequest(event, url.getTutorial + "?lang=" + globalModal.lang
                    , function (data) {
                        data = JSON.parse(data);
                        console.log(data)
                        if (data.tutostep !== undefined && data.tutostep != null && data.tutostep.length > 0) {

                            var isFirstArrayElement = true;
                            var isFirstElementOfSequence = true;
                            var countNavItem = 1;
                            for (var index = 0; index < data.tutostep.length; index++) {

                                if (data.tutostep[index].tutottst != null && data.tutostep[index].tutottst.length > 0) {

                                    if (isFirstElementOfSequence == true) {

                                        var aNavBar = document.createElement('a');
                                        aNavBar.href = '#';
                                        aNavBar.innerText = countNavItem;
                                        aNavBar.className = "nav-item nav-link nav-link-custom" + ((index == 0) ? " border-bottom-blue" : "");
                                        aNavBar.style = "width:40px !important;";
                                        aNavBar.id = "lbkTutorialMenu" + index;

                                        $(modalTutorialNavBar.navbarNavAltMarkup).append(aNavBar);
                                        countNavItem = countNavItem + 1;
                                    }

                                    isFirstElementOfSequence = !isFirstElementOfSequence;

                                    if (isFirstArrayElement == true && index > 1) {
                                        isFirstArrayElement = false;
                                    }

                                    var video = ''

                                    if (data.tutostep[index].tutovide !== undefined && data.tutostep[index].tutovide != null &&
                                        data.tutostep[index].tutovide.length > 0) {
                                        if (data.tutostep[index].tutovide.indexOf("watch?v=")) {
                                            video = '<iframe width="350" height="150" src="https://www.youtube.com/embed/' + data.tutostep[index].tutovide.split('=')[1] + '" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
                                        } else {
                                            video = '<iframe width="350" height="150" src="https://www.youtube.com/embed/' + data.tutostep[index].tutovide.split('/')[data.tutostep[index].tutovide.split('/').Length - 1] + '" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
                                        }
                                    }

                                    $(modalTutorialNavBar.dvContentTutorial).append(modalTutorialNavBar.htmlNavBarTemplate
                                        .replace("{0}", data.tutostep[index].tutostep)
                                        .replace("{1}", data.tutostep[index].tutottst)
                                        .replace("{2}", data.tutostep[index].tutodsst)
                                        .replace("{3}",
                                            (data.tutostep[index].tutoiimg !== undefined && data.tutostep[index].tutoiimg != null &&
                                                data.tutostep[index].tutoiimg.length > 0) ?
                                                '<img src="data:image/png;base64, ' + data.tutostep[index].tutoiimg + '" class="img_tutorial" />' : '')
                                        .replace("{4}", video)
                                        .replace("{5}", !isFirstArrayElement ? 'style="display:none;"' : '')
                                        .replace("{6}", 'dvTutorial' + index));
                                }
                            }
                        }

                        $('.navbar-nav a').click(function (event) {
                            var selectedNavId = this.id;
                            var selectedIndex = '';
                            $('.navbar-nav a').each(function (i, obj) {
                               
                                $("#" + obj.id).removeClass('nav-link-custom-active');
                                $("#" + obj.id).removeClass('border-bottom-blue');

                                if (obj.id == selectedNavId) {
                                    $("#" + obj.id).addClass('nav-link-custom-active');
                                    selectedIndex = selectedNavId.replace('lbkTutorialMenu', '');
                                    $('#dvTutorial' + i.toString()).hide()
                                }
                            });

                            $("#dvContentTutorial div").each(function (i, obj) {
                                $("#dvTutorial" + i.toString()).hide();
                            });

                            $("#dvTutorial" + selectedIndex.toString()).fadeIn('slow', 'linear');
                            $("#dvTutorial" + (parseInt(selectedIndex) + 1).toString()).fadeIn('slow', 'linear');

                        });
                        modalTutorialNavBar.isLoaded = true;
                        $(uiViewModel.dvLoading).hide();
                        $(uiViewModel.modal.modalTutorial).modal('show');
                    });
            } else {
                $(uiViewModel.dvLoading).hide();
                $(uiViewModel.modal.modalTutorial).modal('show');
            }
        })
    },
    PostDataLogin: function (event) {
        var model = {
            "username": $(viewModel.usuario).val(),
            "password": $(viewModel.senha).val(),
            "remember": $(viewModel.remember).is(":checked"),
            "lang": globalModal.lang
        };

        util.Request.PostRequest(event, url.postDataLogin, model,
            function (data) {
                
                if (data.isValid == false) {
                    view.ShowModal(event, false, data.message);
                }
                else {
                    $(uiViewModel.captcha.txtCaptcha).text('');

                    $(uiViewModel.captcha.imgCaptcha).css({
                        "background-image": "url(" + data.captchaImagePath + ")",
                        "height": "40px",
                        "width": "33%",
                        "background-repeat": "no-repeat",
                        "border-radius": "8px",
                        "margin-top": "3%",
                        "margin-left": "33%",
                        "margin-bottom": "3%"
                    });

                    $(uiViewModel.captcha.txtCaptcha).text('');
                    $(uiViewModel.storage.catpchaCodeKey).val(data.fileNameCaptcha);
                    util.Session.setLocalStorageItem(data.fileNameCaptcha, data.captchaCode)
                    $(uiViewModel.captcha.dvCaptcha).fadeIn('slow', 'linear');
                    $(uiViewModel.lblRemember).hide();
                    $(uiViewModel.btnEsqueciMinhaSenha).hide();
                    $(uiViewModel.btnLogin).hide();
                    $(uiViewModel.captcha.btnEntraCaptcha).fadeIn('slow', 'linear');
                    $(uiViewModel.captcha.btnCancelarCaptcha).fadeIn('slow', 'linear');
                }
            });
    },
    PostDataRecoveryPassword: function (event) {
        var model = { "emailRecoveryPassword": $(viewModelEsqueciSenha.emailRecoveryPassword).val() };

        util.Request.PostRequest(event, url.getRecoveryPassword, model,
            function (data) {
                data = JSON.parse(data);
                setTimeout(function () {
                    view.LoadingComponent(event, false);

                    if (data !== undefined && data.isValid !== undefined && data.isValid != null) {
                        view.ShowModal(event, data.isValid, data.message);

                        if (data.isValid) {
                            view.CloseModalRecoveryPassword(event);
                        }
                    }
                }, 800);
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

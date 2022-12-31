var util =
{
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
        },
        setCookie: function (name, value, days) {
            var expires = "";
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toUTCString();
            }
            document.cookie = name + "=" + (value || "") + expires + "; path=/";
        },
        getCookie: function (name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        },
        eraseCookie: function (name) {
            document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        },

    },
    Request: {
        GetRequest: async function (event, url, callback) {

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

                }
            });
        }
    },
    Loading: function (event, isShow) {
                if (isShow) {
                    $("#dvLoading").show()
                }
                else {
                    $("#dvLoading").hide()
                }
    },
    Html: {
        FillCombo: function (event, comboId, dataSource) {
         
            console.log(dataSource)
            $.each(dataSource, function (key, value) {
                
                $(comboId).append($("<option></option>").val(value.id).html(value.descricao));
            });
        }
    }
}

var modal =
{
    validate:
    {
        id: '#myModal',
        dvModalSuccess: '#dvModalSuccess',
        dvModalTitleSuccess: '#dvModalTitleSuccess',
        dvModalMessageSuccess: '#dvModalMessageSuccess',
        dvModalError: '#dvModalError',
        dvModalTitleError: '#dvModalTitleError',
        dvModalMessageError: '#dvModalMessageError',
        ShowModal: function (isSuccess, message) {

            $(modal.validate.dvModalMessageSuccess).hide();
            $(modal.validate.dvModalMessageError).hide();
            $(modal.validate.dvModalSuccess).hide();
            $(modal.validate.dvModalError).hide();
            $(modal.validate.dvModalTitleSuccess).hide();
            $(modal.validate.dvModalTitleError).hide();

            $(modal.validate.id).modal('show');

            setTimeout(function (event) {
                console.log(modal.validate);
                if (isSuccess) {
                    $(modal.validate.dvModalSuccess).show();
                    $(modal.validate.dvModalMessageSuccess).html(message);
                    $(modal.validate.dvModalTitleSuccess).fadeIn('slow', 'linear');
                    $(modal.validate.dvModalMessageSuccess).fadeIn('slow', 'linear');

                }
                else {
                    $(modal.validate.dvModalError).show();
                    $(modal.validate.dvModalMessageError).html(message);
                    $(modal.validate.dvModalTitleError).fadeIn('slow', 'linear');
                    $(modal.validate.dvModalMessageError).fadeIn('slow', 'linear');
                }
            }, 200)
        },
        ShowModalDecision: function (isSuccess, headerLabel, successCallback) {
            
        }
    }

}

var crudMode =
{
    isInsert: true,
    editedId: 0
}
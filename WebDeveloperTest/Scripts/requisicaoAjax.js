(function (root, window, document, undefined) {
    var requisicaoAjax = root.requisicaoAjax = function (type, datatype, url, json) {
        var dados;
        $.ajax({
            type: type,
            url: url,
            data: json,
            datatype: datatype,
            async: false,
            success: function (data) {
                dados = data;
                if (datatype.toUpperCase() === "HTML") {
                    var index = data.indexOf('/Autenticacao/Autenticar');
                    if (index >= 0) {
                        url = urlbase + 'Autenticacao/Autenticar';
                        $(location).attr('href', url);
                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                debugger;
            }
        });
        return dados;
    }
    var requisicaoAjaxNoGlobal = root.requisicaoAjaxNoGlobal = function (type, datatype, url, json) {
        var dados;
        $.ajax({
            type: type,
            url: url,
            data: json,
            datatype: datatype,
            async: false,
            global: false,
            success: function (data) {
                dados = data;
                if (datatype.toUpperCase() === "HTML") {
                    var index = data.indexOf('/Autenticacao/Autenticar');
                    if (index >= 0) {
                        url = urlbase + 'Autenticacao/Autenticar';
                        $(location).attr('href', url);
                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                debugger;
            }
        });
        return dados;
    }
    var requisicaoAjaxAsync = root.requisicaoAjaxAsync = function (type, datatype, url, json, success, errorF) {
        var dados;
        $.ajax({
            type: type,
            url: url,
            data: json,
            contentType: datatype,
            async: true,
            success: function (data) {
                success(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (errorF !== undefined)
                    if (XMLHttpRequest.responseJSON !== undefined)
                        errorF(XMLHttpRequest.responseJSON);
                    else {
                        errorF();
                        toastr.error("Ocorreu um erro ao realizar operação.");
                        fecharLoading();
                    }
            }
        });
    }
    var requisicaoAjaxAsyncNoGlobal = root.requisicaoAjaxAsyncNoGlobal = function (type, datatype, url, json, success) {
        var dados;
        $.ajax({
            type: type,
            url: url,
            data: json,
            datatype: datatype,
            async: true,
            global: false,
            success: function (data) {
                success(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }
    var requisicaoAjaxPutAsync = root.requisicaoAjaxPutAsync = function (type, datatype, url, json, success) {
        var dados;
        $.ajax({
            type: type,
            url: url,
            data: json,
            headers: { "X-HTTP-Method-Override": "PUT" },
            datatype: datatype,
            async: true,
            success: function (data) {
                success(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }

    abrirLoading = function (msg) {
        $('#divLoading').show();

        if (msg)
            $('.msg-loading', $('#divLoading')).html(msg);
    }
    fecharLoading = function (msg) {
        $('#divLoading').hide();

        $('.msg-loading', $('#divLoading')).html('');
    }
    String.format = function () {
        // The string containing the format items (e.g. "{0}")
        // will and always has to be the first argument.
        var theString = arguments[0];

        // start with the second argument (i = 1)
        for (var i = 1; i < arguments.length; i++) {
            // "gm" = RegEx options for Global search (more than one instance)
            // and for Multiline search
            var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
            theString = theString.replace(regEx, arguments[i]);
        }

        return theString;
    }
})(this.window, this.window, this.window.document);
jQuery(".phone")
    .ready(function () {
        var phone;
        $(".phone").each(function () {
            phone = $(this).val();
            if (phone.length > 10) {
                $(this).mask("(99) 99999-999?9");
            } else {
                $(this).mask("(99) 9999-9999?9");
            }
        });
    })
    .focusout(function (event) {
        var target, phone, element;
        target = (event.currentTarget) ? event.currentTarget : event.srcElement;
        phone = target.value.replace(/\D/g, '');
        element = $(target);
        element.unmask();
        if (phone.length > 10) {
            element.mask("(99) 99999-999?9");
        } else {
            element.mask("(99) 9999-9999?9");
        }
    });

jQuery("input.zipcode").mask("99.999-999");

function SearchZipCode() {
    $(document).ready(function () {

        function clear_fields() {
            $("#Address_Street").val("");
            $("#Address_Neighborhood").val("");
            $("#Address_City").val("");
            $("#Address_State").val("");
        }

        $("#Address_ZipCode").blur(function () {
            var zipcode = $(this).val().replace(/\D/g, '');

            if (zipcode != "") {
                var checkzipcode = /^[0-9]{8}$/;

                if (checkzipcode.test(zipcode)) {
                    $("#Address_Street").val("...");
                    $("#Address_Neighborhood").val("...");
                    $("#Address_City").val("...");
                    $("#Address_State").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + zipcode + "/json/?callback=?",
                        function (data) {
                            if (!("erro" in data)) {
                                $("#Address_Street").val(data.logradouro);
                                $("#Address_Neighborhood").val(data.bairro);
                                $("#Address_City").val(data.localidade);
                                $("#Address_State").val(data.uf);
                            }
                            else {
                                clear_fields();
                                alert("CEP não encontrado.");
                            }
                        });
                }
                else {
                    clear_fields();
                    alert("Formato de CEP inválido.");
                }
            }
            else {
                clear_fields();
            }
        });
    });
}

function ConfirmDeletion(id, name) {
    $(document).ready(function () {
        $(".nameContact").text(name);
        $(".modal").modal();

        $(".btnDelete").on('click', function () {
            $.ajax({
                url: 'Contacts/Delete',
                method: 'POST',
                data: { id: id },
                success: function (data) {
                    location.reload(true);
                }
            });
        });

        $(".btnClose").on('click', function () {
            id = null;
            name = null;
            $(".modal").modal('hide');
        });
    });
}
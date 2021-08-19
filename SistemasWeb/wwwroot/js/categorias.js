
class Categorias {

    RegistrarCategoria() {
        $.post(
            "SaveCategorias",
            $(".formCategoria").serialize(),
            (response) => {
                try {
                    var item = JSON.parse(response);
                    if (item.Code == 'Done') {
                        window.location.href = "Index";
                    }
                    else {
                        document.getElementById("message").innerHTML = item.Description
                    }
                } catch (e) {
                    document.getElementById("message").innerHTML = response;
                    console.log(response);
                }
            }
        );
    }

    SeleccionarRegistros(val) {
        debugger;
        window.location.href = "Index/?records=" + parseInt($("#selectRecords").val());
    }
}

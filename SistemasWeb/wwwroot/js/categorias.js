
class Categorias {

    RegistrarCategoria() {
        debugger;
        $.post(
            "SaveCategorias",
            $(".formCategoria").serialize(),
            (response) => {
                debugger;
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
}

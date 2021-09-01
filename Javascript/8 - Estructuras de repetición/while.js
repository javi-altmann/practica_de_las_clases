mostrarNumerosDel1Al10 = () =>  {
    var text = "";
    var i = 1;
    while (i <= 10) {
        text+= "<br> El numero es " + i;
        i++;
        document.getElementById("numeros").innerHTML = text;
    }
}


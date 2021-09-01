var autos = ["BMW", "Volvo", "Ford", "Fiat"];

var i = 0;
var text = "";
for (let i = 0; i < autos.length; i++) {
     text += autos[i] + "<br>";
    document.getElementById("texto").innerHTML = text;
}
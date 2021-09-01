var autos = ["BMW", "Volvo", "Ford", "Fiat"];

var text = "";


autos.forEach(function(element) { //función anonima
    //Por cada iteración le pasa a la función anonima el elemento
    console.log(element);
});

//Función annima arrow function: () => 20 + 100;


autos.forEach(imprimir, this); //Llama a la función imprimir y el this sería el elemento actual

function imprimir(element) {
    alert(element);
    console.log(element);
}
/*autos.forEach(element => {
    console.log(element);
});
*/
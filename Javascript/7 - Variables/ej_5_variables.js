//Ejemplo de var: Debe dar un error ya que no se puede declarar 2 veces la misma variable. 
let pais = 'Mexico';
let pais = 'Argentina'; 
console.log(pais);

//Ejemplo de let: Va a dar un error ya que no se puede declarar 2 veces la misma variable. 
let pais = 'Mexico';
let pais = 'Argentina'; 
console.log(pais);
// Se debería hacer de las siguiente forma
let pais = 'Mexico';
pais = 'Argentina'; //Una asignación

//Ejemplo constante: //Va a dar error ya que valor de la constante no debe cambiar. 
const nombre = 'Javi';
nombre = 'Juan'; 
console.log(nombre);

//Ejemplo de const en array que permite agregr datos a la constante
const paises = ['Argentina', 'Uruguay'];
paises.push('Colombia');
console.log(paises);


//Ejemplos de creación de variables String, double, array, boolean
var nombre = 'Pedro';
var edad = 30;
var estatura = 1.70;
var animales = ["Perro", "Gato"];
var tieneCasa = true;

//Ejemplo de creación de un objeto
var coche = {
    ruedas: 4,
    color: 'Rojo',
    max_velocidad: 12,
    combustible: 'Diesel'
};

console.log(coche.ruedas);
//alert(nombre);


//Antiguamente se concatenaba de esta forma: 
var nombre = "Juan";
console.log('¡Hola !' + nombre);


//Pero con la interpolación de cadenas se puede hacer de la siguiente manera:  
var nombre = "Juan";
console.log(`¡Hola ${nombre}!`);


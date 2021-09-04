using System.Collections.Generic;
using System.Linq;

namespace Linq_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NOTA_PROMOCIONADO = 7;
            const int NOTA_APROBADO = 4;
            
            var alumnos = new List<Alumno> {
                new Alumno {
                    Nombre = "Javi",
                    Edad = 10,
                    Nota = 4
                },
                new Alumno {
                    Nombre = "Juan",
                    Edad = 20,
                    Nota = 7
                }
            };

//Where: Nos permite seleccionar una colección a partir de otra con los objetos que cumplan las condiciones especificadas
            var alumnosPromocionados = alumnos.Where(alumno => alumno.Nota >= 7 && alumno.Nombre == "Javi").ToList();

            var primerAlumno = alumnos.Where(alumno => alumno.Nota >= 7).FirstOrDefault();
//OrderBy: Nos permite ordenar de menoR a mayor la colección
            var notaDeMenorAmayor = alumnos.OrderBy(alumno => alumno.Nota).ToList();

//OrderByDesc: Nos permite ordenar de mayor a menor la colección
            var notaDemayorAMenor = alumnos.OrderByDescending(alumno => alumno.Nota).ToList();

//Nos permite sumar el total del atributo elegido de la colección
            var totalSumas = alumnos.Sum(x=> x.Nota);

//Max: Obtiene el valor máximo de la colección
            var notaMaxima = alumnos.Max(x=> x.Nota);

//Min: Obtiene el valor minimo de la colección            
            var notaMinimaa = alumnos.Min(x=> x.Nota);

//All: Si todos los valores cumplen con la condición devuelve true
            var todosPromocionados = alumnos.All(x=> x.Nota >= NOTA_PROMOCIONADO);

            var todosAprobados = alumnos.All(x=> x.Nota >= NOTA_APROBADO);

//Any: Si al menos un valor cumple con la condición devuelve true
            var algunAprobado = alumnos.Any(x=> x.Nota >= NOTA_APROBADO);

//Select: Nos permite hacer una selección sobre la colección de datos, ya sea seleccionándolos todos, solo una parte o transformándolos:
            List<string> nombres = alumnos.Select(x => x.Nombre).ToList();

//Select con lista de tipo anonimo
             var nombreYnotas = alumnos.Select(x => new {
               x.Nombre, 
               x.Nota
               }).ToList();

//Select a nuevo tipo de dato 
            var nombresYEdades = alumnos.Select(x => new AlumnoYEdad {
               Edad = x.Edad, 
               Nombre = x.Nombre
               }).ToList();



        }
    }
}

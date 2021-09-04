namespace Linq_Lambda
{
    public class Alumno
    {
        //Propiedades autoimplementadas: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public string Nombre { get; set; }
        public int Nota { get; set; }

      // Atributos privados con _ adelante 

        private int _edad;

        public int Edad {
            get {
                return _edad;
            }

            set {
                _edad = value;
            }
        }
    }
}
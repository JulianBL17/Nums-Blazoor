using System;
using Logica;

namespace Presentacion {
    class Program {
        static NumerosConn nums = new NumerosConn ();

        static void Main (string[] args) {
            Console.WriteLine ("El listado de numeros es: ");
            var values = nums.Cargar ();

            for (int i = 0; i < values.Count; i++) {
                Console.WriteLine (values[i].ToString ());
            }
            // --------------------------------------------------------------------------

            Console.WriteLine ("Ingresar un muevo registro");
            Console.WriteLine ("Ingrese un numero: ");
            int x = int.Parse (Console.ReadLine ());
            Console.WriteLine ("Ingrese su representacion en romanos: ");
            string r = Console.ReadLine();

            if (nums.Insertar (x, r))
                Console.WriteLine ("El numero {0}, se inserto correctamente", x);
            else
                Console.WriteLine ("No se pudo insertar, contacte a soporte tecnico");


            // --------------------------------------------------------------------------
            Console.WriteLine ("El listado actulizado de numeros es: ");
            values = nums.Cargar ();

            for (int i = 0; i < values.Count; i++) {
                Console.WriteLine (values[i].ToString ());
            }
        }
    }
}
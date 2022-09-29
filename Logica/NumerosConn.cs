using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class NumerosConn 
    {
        public List<Numero> Cargar()
        {            
            List<Numero> Numeros = new List<Numero>();

            // Instanciar un objeto de la clase conexión
            Conexion conn =  new Conexion();

            // Abrir la conexión
            conn.conectar();

            // Establecemos la consulta que se va a realizar
            var reader = conn.ejecutarQuery("SELECT * FROM numeros");

            // Se recuperan los registros recibidos de da base de datos
            // Uno a uno, se convierten a objetos de Numero, y se adicionan a la lista
            while (reader.Read())
            {
                int value = int.Parse(reader.GetString(0));
                string romano = reader.GetString(1);
                {
                    Numero n = new Numero(value, romano);
                    Numeros.Add(n);
                }                        
            }
            // Cerramos la conexión para liberar recursos
            conn.cerrar();
            
            // Retornamos la lista con los valores recurerados (List<Nuemro>)
            return Numeros;
        }

        public bool Insertar(int valor, string romano)
        {
            string sql = "INSERT INTO numeros (numero, romano) ";
            sql += $"VALUES ({valor}, upper('{romano}'))";
            // Si se requiere inter un valor string (cadena)
            // sql += string.Format("VALUES ({0}, \"{1}\")", id, Nombre);
            // UPPER(cadena) --> convierte a mayusculas la cadena pasada como parametro

            // Instanciar un objeto de la clase conexión
            Conexion conn =  new Conexion();

            // Abrir la conexión
            conn.conectar();

            // Establecemos la consulta que se va a realizar
            var resultado = conn.ejecutarInstruccion(sql);

            conn.cerrar();

            return resultado;
        }

        public bool Eliminar(int valor){
           //sql  
        string sql="DELETE FROM numeros WHERE numero="+valor;
 
        //instancia de la clase conexion //
        Conexion conn=new Conexion();

        //llama metodo conectar de la clase conexion//
        conn.conectar();

        //ejecuta sql//
        var resultado=conn.ejecutarInstruccion(sql);
        conn.cerrar();

        return resultado;


        }
    }
}

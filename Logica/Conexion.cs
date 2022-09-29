using Microsoft.Data.Sqlite;
using System.Data;

namespace Logica
{    
    public class Conexion
    {
        private static SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
        private SqliteConnection conexion;
 
        public Conexion()
        {
            connectionStringBuilder.DataSource = "../Data/DataBase.db3";
            conexion = new SqliteConnection(connectionStringBuilder.ConnectionString);
        }
 
        internal void conectar()
        {
             if (conexion.State != ConnectionState.Open)
                this.conexion.Open();
        }
 
        internal void cerrar()
        {
            this.conexion.Close();
        }
 
        internal string[] getSingleRow(string sql)
        {
            conectar();

            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = this.conexion;
            cmd.CommandText = @sql;
 
            SqliteDataReader dr = cmd.ExecuteReader();
 
            string[] valores = new string[dr.FieldCount];
 
            if (dr.Read())
            {
                for (int i = 0; i < valores.Length; i++)
                {
                    valores[i] = dr.GetValue(i).ToString();
                }
            }

            cerrar();

            return valores;
        }
        
        internal SqliteDataReader ejecutarQuery(string query)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = this.conexion;
            cmd.CommandText = query;
 
            SqliteDataReader dr = cmd.ExecuteReader();

            if(dr.FieldCount > 0)
                return dr;

            else
                return null;
        }
 
        internal bool ejecutarInstruccion(string instruccion)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = this.conexion;
            cmd.CommandText = @instruccion;
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
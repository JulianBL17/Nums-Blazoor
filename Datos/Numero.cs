namespace Datos
{
    public class Numero
    {
        public int Num { get; set; }
        public string Romano { get; set; }

        public Numero()
        {
            Num = 0;
            Romano = string.Empty;
        }

        public Numero(int n, string romano)
        {
            Num = n;
            Romano = romano;
        }

        public override string ToString()
        {
            return $"El Numero: {Num}, corresponde a {Romano} en romanos";
        }  
    }
}
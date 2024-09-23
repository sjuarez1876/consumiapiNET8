namespace WebPersonas.Models
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public Exception Ex { get; set; }

       public Personas2 personas { get; set; }
        public string Message { get; set; }
        public string codeMessage { get; set; }
    }


}

public class Personas2
{
    public int id_persona { get; set; }
    public string Nombre { get; set; }
    public string Edad { get; set; }
    public string Email { get; set; }


}

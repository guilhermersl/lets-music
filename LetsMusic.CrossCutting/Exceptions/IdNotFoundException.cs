namespace LetsMusic.CrossCutting.Exceptions
{
    public class IdNotFoundException : Exception
    {

        public IdNotFoundException(string entity) : base($"Id de {entity} não localizado") { }
    }
}

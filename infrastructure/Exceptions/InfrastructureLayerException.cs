namespace infrastructure.Exceptions
{    
    public class InfrastructureLayerException : Exception
    {
        public InfrastructureLayerException()
        {
        }

        public InfrastructureLayerException(string? message) : base(message)
        {
        }
    }
}
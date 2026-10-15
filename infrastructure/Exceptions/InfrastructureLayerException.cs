namespace infrastructure.Exceptions
{
    [Serializable]
    internal class InfrastructureLayerException : Exception
    {
        public InfrastructureLayerException()
        {
        }

        public InfrastructureLayerException(string? message) : base(message)
        {
        }
    }
}
namespace WebapiProject.Exception
{
    public class OrderQuantityExceded : ApplicationException
    {
        public OrderQuantityExceded() { }
        public OrderQuantityExceded(string msg) : base(msg) { }
    }
}

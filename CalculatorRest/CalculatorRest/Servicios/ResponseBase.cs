namespace CalculatorRest.Servicios
{
    public class ResponseBase<T>
    {
        public int Code { get; internal set; }
        public string Message { get; internal set; }
        public object Data { get; internal set; }
    }
}
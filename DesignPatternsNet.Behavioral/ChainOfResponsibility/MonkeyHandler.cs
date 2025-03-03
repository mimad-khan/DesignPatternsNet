namespace DesignPatternsNet.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// All Concrete Handlers either handle a request or pass it to the next handler
    /// in the chain.
    /// </summary>
    public class MonkeyHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request == "Banana")
            {
                return $"Monkey: I'll eat the {request}.";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}

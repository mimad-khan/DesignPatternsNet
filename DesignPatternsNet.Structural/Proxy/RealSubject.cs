using System.Threading;

namespace DesignPatternsNet.Structural.Proxy
{
    /// <summary>
    /// The RealSubject contains some core business logic. Usually, RealSubjects are
    /// capable of doing some useful work which may also be very slow or sensitive -
    /// e.g. correcting input data. A Proxy can solve these issues without any
    /// changes to the RealSubject's code.
    /// </summary>
    public class RealSubject : ISubject
    {
        public string Request()
        {
            // For demonstration purposes, let's simulate a heavy operation
            // by adding a small delay
            Thread.Sleep(1000);
            
            return "RealSubject: Handling Request";
        }
    }
}

using System.Text;

namespace DesignPatternsNet.Structural.Facade
{
    /// <summary>
    /// The Facade class provides a simple interface to the complex logic of one or
    /// several subsystems. The Facade delegates the client requests to the
    /// appropriate objects within the subsystem. The Facade is also responsible for
    /// managing their lifecycle. All of this shields the client from the undesired
    /// complexity of the subsystem.
    /// </summary>
    public class Facade
    {
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            _subsystem1 = subsystem1;
            _subsystem2 = subsystem2;
        }

        // The Facade's methods are convenient shortcuts to the sophisticated
        // functionality of the subsystems. However, clients get only to a fraction
        // of a subsystem's capabilities.
        public string Operation()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Facade initializes subsystems:");
            result.AppendLine(_subsystem1.Operation1());
            result.AppendLine(_subsystem2.Operation1());
            result.AppendLine("Facade orders subsystems to perform the action:");
            result.AppendLine(_subsystem1.OperationN());
            result.AppendLine(_subsystem2.OperationZ());
            return result.ToString();
        }
    }
}

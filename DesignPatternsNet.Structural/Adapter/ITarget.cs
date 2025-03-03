namespace DesignPatternsNet.Structural.Adapter
{
    /// <summary>
    /// Target interface that the client expects to work with
    /// </summary>
    public interface ITarget
    {
        string GetRequest();
    }
}

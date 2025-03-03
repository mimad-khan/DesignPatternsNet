namespace DesignPatternsNet.Behavioral.Mediator
{
    /// <summary>
    /// The Base Component provides the basic functionality of storing a mediator's
    /// instance inside component objects.
    /// </summary>
    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

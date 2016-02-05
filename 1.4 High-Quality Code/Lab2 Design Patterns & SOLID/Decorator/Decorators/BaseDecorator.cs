namespace _9.Decorator.Decorators
{
    using Interfaces;

    public abstract class BaseDecorator : IValidator
    {
        protected IValidator validator;

        protected BaseDecorator(IValidator validator)
        {
            this.validator = validator;
        }

        public abstract bool Validate(string input);
    }
}

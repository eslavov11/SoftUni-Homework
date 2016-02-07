namespace AirConditionerTesterSystem.Exceptions
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException(string msg) : base(msg)
        {
        }
    }
}

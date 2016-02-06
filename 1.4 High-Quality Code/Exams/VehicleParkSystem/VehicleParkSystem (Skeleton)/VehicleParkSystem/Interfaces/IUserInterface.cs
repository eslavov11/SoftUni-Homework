namespace VehicleParkSystem.Interfaces
{
    interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format, params string[] args);
    }

    // TODO: Documente esta contrato
}
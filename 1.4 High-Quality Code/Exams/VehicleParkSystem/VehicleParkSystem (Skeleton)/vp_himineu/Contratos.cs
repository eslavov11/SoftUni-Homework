using System;



using System.Collections.Generic;
using VehiclePark3;






                                                       // Don't touch - I like it centered!
                        interface IUserInterface{string ReadLine();void WriteLine(string format, params string[] args);}





// TODO: Documente esta contrato
interface IVehiclePark
{
    // TODO: Documentar esse método
    string InsertCar(Carro car, int sector, int placeNumber, DateTime startTime);
    // TODO: Documentar esse método
    string InsertMotorbike(Moto motorbike, int sector, int placeNumber, DateTime startTime);
    // TODO: Documentar esse método
    string InsertTruck(Caminhão truck, int sector, int placeNumber, DateTime startTime);
    // TODO: Documentar esse método
    string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);
    // TODO: Documentar esse método
    string GetStatus();
    // TODO: Documentar esse método
    string FindVehicle(string licensePlate);
    // TODO: Documentar esse método
    string FindVehiclesByOwner(string owner);
}

public interface IComando {string nome{get;}IDictionary<string,string>parâmetros{get;}}

interface IMecanismo {
    void Runrunrunrunrun();
}
























public interface IVehicle
{











    string 
    LicensePlate
    { get; }
    string 
    Owner
    { get; }
    decimal
    RegularRate 
    { get; }
    decimal
    OvertimeRate 
    { get; }
    int 
    ReservedHours
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    { get; }
}


using System;


using System.Collections;


using System.Collections.Generic;


using System.CodeDom;


using System.ComponentModel;


using System.Configuration;


using System.Xml;


using v = vp_system_himineu.v;

namespace Comandos {

    using System.Web;
    
    
    using System.Net;
    
    
    using System.Reflection;
    
    
    using Microsoft.CSharp.RuntimeBinder;
    
    
    using MS.Internal.Xml.XPath;
    
    
    using System.Security.Authentication;
    
    
    using System.Security.Claims;

    using System.IO.IsolatedStorage;

    using System.IO.Ports;
    using vp_system_himineu;
    using System.Web.Script.Serialization;
    
    class exec {

        public class comando : IComando {
            public string nome { get; set; }
            public IDictionary<string, string> parâmetros { get; set; }

            public comando(string str) {
                nome = str.Substring(0, str.IndexOf(' ')); parâmetros = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
            }
        }
        v VehiclePark { get; set; }
        public string execução(IComando c) {




            if (c.nome != "SetupPark" && VehiclePark == null) return "The vehicle park has not been set up";
            switch (c.nome) {
            case "SetupPark":
            //This doesnot work!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // I donot know why!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



            //VehiclePark=new VehiclePark(c.Parameters["sectors"]+1,c.Parameters["placesPerSector"]);
            return "Vehicle park created";
            case "Рark":
            switch (c.parâmetros["type"]) {
            case "car":return VehiclePark.InsertCar(new VehiclePark3.Carro(c.parâmetros["licensePlate"],c.parâmetros["owner"],int.Parse(c.parâmetros["hours"])),int.Parse(c.parâmetros["sector"]),int.Parse(c.parâmetros["place"]),DateTime.Parse(c.parâmetros["time"],null,System.Globalization.DateTimeStyles.RoundtripKind));//why round trip kind??
            case "motorbike":return VehiclePark.InsertMotorbike(new VehiclePark3.Moto(c.parâmetros["licensePlate"],c.parâmetros["owner"],int.Parse(c.parâmetros["hours"])),int.Parse(c.parâmetros["sector"]),int.Parse(c.parâmetros["place"]),DateTime.Parse(c.parâmetros["time"],null,System.Globalization.DateTimeStyles.RoundtripKind));//stack overflow says this
            case "truck":return VehiclePark.InsertTruck(new VehiclePark3.Caminhão(c.parâmetros["licensePlate"],c.parâmetros["owner"],int.Parse(c.parâmetros["hours"])),int.Parse(c.parâmetros["sector"]),int.Parse(c.parâmetros["place"]),DateTime.Parse(c.parâmetros["time"],null, System.Globalization.DateTimeStyles.RoundtripKind));//I wanna know
            }
            break;
            
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                                                                    case "Exit":return VehiclePark.ExitVehicle(c.parâmetros["licensePlate"], DateTime.Parse(c.parâmetros["time"], null, System.Globalization.DateTimeStyles.RoundtripKind), decimal.Parse(c.parâmetros["money"]));
                                                                    case "Status":return VehiclePark.GetStatus();
                                                                    case "FindVehicle":return VehiclePark.FindVehicle(c.parâmetros["licensePlate"]);
                                                                    case "VehiclesByOwner":return VehiclePark.FindVehiclesByOwner(c.parâmetros["owner"]);
                                                                    default:throw new IndexOutOfRangeException("Invalid command.");
            
            
            
            
            }

            
            
            return "";
        
        
        }
    
    
    }

}
















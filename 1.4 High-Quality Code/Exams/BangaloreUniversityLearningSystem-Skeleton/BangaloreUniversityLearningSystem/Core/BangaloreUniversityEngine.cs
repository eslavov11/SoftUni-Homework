namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Data;
    using Interfaces;
    using Models;

    public class BangaloreUniversityEngine : IEngine
    {
        private readonly IBangaloreUniversityDate database;
        private User user;
        private string commandLine;

        public BangaloreUniversityEngine()
        {
            this.database = new BangaloreUniversityDate();
            this.user = null;
        }

        public void Run()
        {
            this.commandLine = Console.ReadLine();

            while (this.commandLine != null)
            {
                var route = new Route(this.commandLine);
                var controllerType =
                    Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator
                    .CreateInstance(controllerType, this.database, this.user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] commandParams = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, commandParams) as IView;
                    Console.WriteLine(view.Display());
                    this.user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

                this.commandLine = Console.ReadLine();
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            return int.Parse(route.Parameters[p.Name]);
                        }

                        return route.Parameters[p.Name];
                    }).ToArray();
        }
    }
}

namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Enums;
    using Interfaces;
    using Models;
    using Utilities;

    public abstract class Controller
    {
        public User User { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.User != null;
            }
        }

        protected IBangaloreUniversityDate Data { get; set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var u in this.Data.Users.GetAll())
            {
                if (!roles.Any(role => this.User.IsInRole(role)))
                {
                    throw new DivideByZeroException(
                        "The current user is not authorized to perform this operation.");
                }
            }
        }
    }
}

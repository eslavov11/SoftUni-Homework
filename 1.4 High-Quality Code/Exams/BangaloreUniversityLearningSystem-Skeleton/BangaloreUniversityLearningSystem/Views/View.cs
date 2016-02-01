namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;
    using Interfaces;

    public abstract class View : IView
    {
        protected View(object model)
        {
            this.Model = model;
        }

        public object Model { get; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        protected abstract void BuildViewResult(StringBuilder viewResult);
    }
}

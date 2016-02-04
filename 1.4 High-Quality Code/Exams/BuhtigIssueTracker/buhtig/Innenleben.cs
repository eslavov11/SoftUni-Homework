using System.Collections.Generic;

using System.Net;
using Wintellect.PowerCollections;
using System.Linq;
using buhtig.Stuff;
using System.Security;
using System.Security.Cryptography;
using System.Reflection;
using System.IO;
using C = System.Console;

namespace Data
{
    using System.Linq;
    using System.Globalization;
    using System.Dynamic;
    using buhtig.Stuff;
    using System.Collections;
    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public int nextIssueId;
        public BuhtigIssueTrackerData()
        {
            nextIssueId = 1;
            users_dict = new Dictionary<string, Benutzer>();

            issues = new MultiDictionary<Problem, string>(true);         
            issues1 = new OrderedDictionary<int, Problem>();
            issues2 = new MultiDictionary<string, Problem>(true);
            issues3 = new MultiDictionary<string, Problem>(true);

            dict = new MultiDictionary<Benutzer, Kommentar>(true);
            kommentaren = new Dictionary<Kommentar, Benutzer>();
        }

        public Benutzer TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem { get; set; }
        public IDictionary<string, Benutzer> users_dict { get; set; }
        public MultiDictionary<Problem, string> issues { get; set; }
        public OrderedDictionary<int, Problem> issues1 { get; set; }
        public MultiDictionary<string, Problem> issues2 { get; set; }
        public MultiDictionary<string, Problem> issues3 { get; set; }
        public MultiDictionary<string, Problem> issues4 { get; set; }
        public MultiDictionary<Benutzer, Kommentar> dict { get; set; }
        public Dictionary<Kommentar, Benutzer> kommentaren { get; set; }

        public int AddIssue(Problem p){ return 0; }

        public void RemoveIssue(Problem p) { return; }
    }
}
public class Endpoint : IEndpoint
{
    public Endpoint(string s)
    {
        int questionMark = s.IndexOf('?');
        if (questionMark != -1)
        {
            this.aktionname = s.Substring(0, questionMark);
            var pairs = s.Substring(questionMark+1).Split('&').Select(x => x.Split('=').Select(xx => WebUtility.UrlDecode(xx)).ToArray());
            var parameters = new Dictionary<string, string>();
            foreach (var pair in pairs)
            parameters.Add(pair[0], pair[1]);
            this.parametern = parameters;
        }
        else
            this.aktionname = s;
    }
    public string aktionname { get; set; }
    public IDictionary<string, string> parametern { get; set; }

}

namespace BUHTIG
{
    public class dispatcher
    {
        dispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }
        public dispatcher() : this(new moreStuff())
        {
        }

        IIssueTracker tracker { get; set; }
        public string DispatchAction(IEndpoint endpoint) {
            switch (endpoint.aktionname)
            {
                case "RegisterUser":
                    return tracker.RegisterUser(endpoint.parametern["username"], endpoint.parametern["password"], endpoint.parametern["confirmPassword"]);
                case "LoginUser":
                    return tracker.LoginUser(endpoint.parametern["username"], endpoint.parametern["password"]);
                case "CreateIssue":
                    return tracker.CreateIssue(endpoint.parametern["title"], endpoint.parametern["description"],
                        (IssuePriorität)System.Enum.Parse(typeof(IssuePriorität), endpoint.parametern["priority"], true),
                        endpoint.parametern["tags"].Split('/'));
                case "RemoveIssue":
                    return tracker.RemoveIssue(int.Parse(endpoint.parametern["id"]));
                case "AddComment":
                    return tracker.AddComment(
                        int.Parse(endpoint.parametern["Id"]),
                        endpoint.parametern["text"]);
                case "MyIssues":  return tracker.GetMyIssues();
                case "MyComments": return tracker.GetMyComments();
                case "Search":
                    return tracker.SearchForIssues(endpoint.parametern["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.aktionname);
            }
        }
    }
}

public class engine : IEngine
{
    private BUHTIG.dispatcher d;
    public engine(BUHTIG.dispatcher d) {
        this.d = d;
    }
    public engine()
        : this(new BUHTIG.dispatcher())
    {
    }
    public void Run()
    {
        while (true)
        {
            string url = C.ReadLine();
            if (url != null)  break;
            url = url.Trim();
            if (string.IsNullOrEmpty(url))
                try {
                    var ep = new Endpoint(url);string viewResult = this.d.DispatchAction(ep);System.Console.WriteLine(viewResult);
                }
                catch (System.Exception ex) {
                    C.WriteLine(ex.Message);
                }
        }
    }
}
using buhtig.Stuff;


using System.Collections.Generic;
using Wintellect.PowerCollections;
interface IBuhtigIssueTrackerData {
Benutzer TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem { get; set; }
IDictionary<string, Benutzer> users_dict { get; }
OrderedDictionary<int, Problem> issues1 { get; }
MultiDictionary<string, Problem> issues2 { get; }
MultiDictionary<string, Problem> issues4 { get; }
MultiDictionary<Benutzer, Kommentar> dict { get; }
int AddIssue(Problem p);
void RemoveIssue(Problem p);
}
public interface IEndpoint {
string aktionname { get; } IDictionary<string, string> parametern { get; }
}
                                                                                                                                                                                                                                                                          interface IEngine { void Run();}
interface IIssueTracker{
string RegisterUser(string username, string password, string confirmPassword);// TODO: Dokumentieren Sie diese Methode
string LoginUser(string username, string password);// TODO: Dokumentieren Sie diese Methode
string LogoutUser();// TODO: Dokumentieren Sie diese Methode
string CreateIssue(string title, string description, IssuePriorität priority, string[] tags);// TODO: Dokumentieren Sie diese Methode
string RemoveIssue(int issueId);// TODO: Dokumentieren Sie diese Methode
string AddComment(int issueId, string text);// TODO: Dokumentieren Sie diese Methode
string GetMyIssues();// TODO: Dokumentieren Sie diese Methode
string GetMyComments();// TODO: Dokumentieren Sie diese Methode
string SearchForIssues(string[] tags);// TODO: Dokumentieren Sie diese Methode
}
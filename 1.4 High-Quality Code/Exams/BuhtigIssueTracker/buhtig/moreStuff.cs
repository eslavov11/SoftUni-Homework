using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Xml;
using buhtig.Stuff;
using Data;


namespace BUHTIG {
    public class moreStuff : IIssueTracker
    {
        moreStuff(IBuhtigIssueTrackerData data)
        {
            Data = data as BuhtigIssueTrackerData;
        }
        public moreStuff()
            : this(new Data.BuhtigIssueTrackerData()) { }
        BuhtigIssueTrackerData Data { get; set; }
        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is already a logged in user");
            if (password != confirmPassword)
                return string.Format("The provided passwords do not match", username);
            if (Data.users_dict.ContainsKey(username))
                return string.Format("A user with username {0} already exists", username);
            var user = new buhtig.Stuff.Benutzer(username, password); Data.users_dict.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }
        public string LoginUser(string username, string password) {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is already a logged in user");
            if (!Data.users_dict.ContainsKey(username))
                return string.Format("A user with username {0} does not exist", username);
            var user = Data.users_dict[username];
            if (user.Passwort_hash != Benutzer.HashPassword(password))
                return string.Format("The password is invalid for user {0}", username);
            Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem = user;



            return string.Format("User {0} logged in successfully", username);
        }
        public string LogoutUser() {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return string.Format("There is no currently logged in user");
            }
            string username = Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name;
            Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem = null;
            return string.Format("User {0} logged out successfully", username);
        }
        public string CreateIssue(string title, string description, IssuePriorität priority, string[] strings) {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is no currently logged in user");

            var issue = new Problem(title, description, priority, strings.Distinct().ToList()); issue.Id = Data.nextIssueId; Data.issues1.Add(issue.Id, issue); Data.nextIssueId++;
            Data.issues2[Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name].Add(issue);
            foreach (var tag in issue.Tags)
            Data.issues4[tag].Add(issue);
            return string.Format("Issue {0} created successfully.", issue.Id);
        }
        public string RemoveIssue(int issueId) {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is no currently logged in user");
            if (!Data.issues1.ContainsKey(issueId))
                return string.Format("There is no issue with ID {0}", issueId);
            var issue = Data.issues1[issueId];
            if (!Data.issues2[Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name].Contains(issue))
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name);

            Data.issues2[Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name].Remove(issue);
            foreach (var tag in issue.Tags)
                Data.issues4[tag].Remove(issue);
            Data.issues1.Remove(issue.Id);
            return string.Format("Issue {0} removed", issueId);
        }
        public string AddComment(int intValue, string stringValue) {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return string.Format("There is no currently logged in user");
            }
            if (!Data.issues1.ContainsKey(intValue + 1))
            {
                return string.Format("There is no issue with ID {0}", intValue + 1);
            }
            var issue = Data.issues1[intValue];
            var comment = new Kommentar(Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem, stringValue);
            issue.AddComment(comment);
            Data.dict[Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }
        public string GetMyIssues() {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is no currently logged in user");

            var issues = Data.issues2[Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                var result = "";
                foreach (var i in Data.issues2)
                result += i.Value.Select(iss => iss.Comments.Select(c => c.Text)).ToString();
                return "No issues";
            }
            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
        public string GetMyComments() {
            if (Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
                return string.Format("There is no currently logged in user");
            var comments = new List<Kommentar>();
            Data.issues1.Select(i => i.Value.Comments).ToList()
                .ForEach(item => comments.AddRange(item));
            var resultComments = comments
                .Where(c => c.Author.Benutzer_name == Data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.Benutzer_name)
                .ToList();
            var strings = resultComments
                .Select(x => x.ToString());
            if (!strings.Any()) return "No comments";
            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] strings) {
            if (strings.Length < 0)
                return "There are no tags provided";

            var i = new List<Problem>();
            foreach (var t in strings)
                i.AddRange(Data.issues4[t]);
            if (!i.Any())
                return "There are no issues matching the tags provided";
            var newi = i.Distinct();
            if (!newi.Any())
            {
                return "No issues";
            }
            return string.Join(Environment.NewLine, newi.OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => string.Empty));
        }
    }
}

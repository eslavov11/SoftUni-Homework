namespace BuhtigIssueTracker.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuhtigIssueTracker.Data;
    using BuhtigIssueTracker.Enums;
    using Interfaces;
    using Models;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.UsersByUsername.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (!this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersByUsername[username];
            if (user.PasswordHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = this.Data.CurrentUser.Username;
            this.Data.CurrentUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(
            string title,
            string description,
            IssuePriority priority,
            string[] tags)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            issue.Id = this.Data.nextIssueId;
            this.Data.IssuesById.Add(issue.Id, issue);
            this.Data.nextIssueId++;
            this.Data.IssuesByUsername[this.Data.CurrentUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesByTag[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.Data.CurrentUser.Username].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.Data.CurrentUser.Username);
            }

            this.Data.IssuesByUsername[this.Data.CurrentUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesByTag[tag].Remove(issue);
            }

            this.Data.IssuesById.Remove(issue.Id);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int id, string text)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(id))
            {
                return string.Format("There is no issue with ID {0}", id);
            }

            var issue = this.Data.IssuesById[id];
            var comment = new Comment(this.Data.CurrentUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.CurrentUser].Add(comment);
            this.Data.UsersByComments[comment] = this.Data.CurrentUser;

            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var newIssues = this.Data.IssuesByUsername[this.Data.CurrentUser.Username];
            if (!newIssues.Any())
            {
                // BOTTLENECK: Unnecessary foreachloop which is never used.
                return "No issues";
            }

            return string.Join(
                Environment.NewLine, 
                newIssues
                    .OrderByDescending(issue => issue.Priority)
                    .ThenBy(issue => issue.Title));
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var comm = this.Data.UsersByComments.Where(issue => issue.Value == this.Data.CurrentUser);

            //// TODO BOTTLENECK
            //var comments = new List<Comment>();
            //this.Data.IssuesById.Select(issue => issue.Value.Comments)
            //    .ToList()
            //    .ForEach(item => comments.AddRange(item));

            //// TODO BOTTLENECK
            //var resultComments =
            //    comments.Where(
            //        comment =>
            //        comment.Author.Username
            //        == this.Data.CurrentUser.Username).ToList();

            //var commentsAsString = resultComments.Select(x => x.ToString());
            var commentsAsString = comm.ToList().Select(x => x.ToString().Substring(1,x.ToString().Length-34));
            if (!commentsAsString.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, commentsAsString);
        }

        public string SearchForIssues(string[] tags)
        {
            if (!tags.Any())
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var t in tags)
            {
                issues.AddRange(this.Data.IssuesByTag[t]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var distinctIssues = issues.Distinct();
            if (!distinctIssues.Any())
            {
                return "No issues";
            }

            // TODO check if this works.
            return string.Join(
                Environment.NewLine,
                distinctIssues
                .OrderByDescending(issue => issue.Priority)
                .ThenBy(issue => issue.Title));
            //.Select(issue => string.Empty));
        }
    }
}

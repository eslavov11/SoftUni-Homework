namespace BuhtigIssueTracker.Data
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        // TODO
        public int nextIssueId;

        public BuhtigIssueTrackerData()
        {
            this.nextIssueId = 1;
            this.UsersByUsername = new Dictionary<string, User>();

            // TODO is issues needed?
            this.Issues = new MultiDictionary<Issue, string>(true);
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.Issues3 = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<User, Comment>(true);
            this.UsersByComments = new Dictionary<Comment, User>();
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; set; }

        public MultiDictionary<Issue, string> Issues { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> Issues3 { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> CommentsByUser { get; set; }

        public Dictionary<Comment, User> UsersByComments { get; set; }

        public int AddIssue(Issue p)
        {
            return 0;
        }

        public void RemoveIssue(Issue p)
        {
            return;
        }
    }
}
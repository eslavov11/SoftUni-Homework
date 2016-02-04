using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using S = System.Text.StringBuilder;

namespace buhtig.Stuff
{
public class Problem
{
    public int Id { get; set; }
    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value == null||value == ""||value.Length < 3)
            {
                throw new ArgumentException("The title must be at least 3 symbols long");
            }
            this.title = value;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            if (value == null||value == ""||value.Length < 5)
            {
                throw new ArgumentException("The description must be at least 5 symbols long");
            }
            description = value;
        }
    }
    public Problem(string title, string description, IssuePriorität priority, List<string> tags)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Tags = tags;
    }
    public IssuePriorität Priority { get; set; }
    public IList<string> Tags { get; set; }
    public IList<Kommentar> Comments { get; set; }
    public void AddComment(Kommentar comment)
    {
        this.Comments.Add(comment);
    }
    public override string ToString()
    {
        var issue = new S();
        issue.AppendLine(this.Title).AppendFormat("Priority: {0}", this.GetPriorityAsString()).AppendLine().AppendLine(this.Description);
        if (this.Tags.Count > 0)
            issue.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();

        if (this.Comments.Count > 0) {
            issue.AppendFormat("Comments:{0}{1}", Environment.NewLine, string.Join(Environment.NewLine, this.Comments)).AppendLine();
        }
        return issue.ToString().Trim();
    }

    private string GetPriorityAsString()
    {
        switch (this.Priority)
        {
            case IssuePriorität.Showstopper: return "****"; case IssuePriorität.High: return "***";
            case IssuePriorität.Medium: return "**";

            case IssuePriorität.Low: return "*";
            default: throw new InvalidOperationException("The priority is invalid");
        }
    }

    private string title;
    private string description;
}
public class Benutzer
{
    public string Benutzer_name { get; set; }
    public string Passwort_hash { get; set; }
    public static string HashPassword(string password)
    {
        return string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
    }
    public Benutzer(string username, string password)
    {
        Benutzer_name = username;
        Passwort_hash = HashPassword(password);
    }}
public enum IssuePriorität
{
    Showstopper = 4,
    High = 3,
    Medium = 2,
    Low = 1
}
public class Kommentar
{
    string text;
    public Kommentar(Benutzer author, string text)
    {
        this.Author = author;
        this.Text = text;
    }
    public Benutzer Author { get; set; }
    public string Text
    {
        get {
            return this.text;
        }
        set {
            if (value == null||value == ""||value.Length<2) {
                throw new ArgumentException("The text must be at least 2 symbols long");
            }
            this.text = value;
        }
    }
    public override string ToString()
    {
        return new S().AppendLine(Text).AppendFormat("-- {0}", Author.Benutzer_name).AppendLine().ToString().Trim();
    }
}}
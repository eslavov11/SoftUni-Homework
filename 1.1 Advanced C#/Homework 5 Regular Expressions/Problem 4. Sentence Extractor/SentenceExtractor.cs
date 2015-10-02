using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_4.Sentence_Extractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            string matchWord = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = string.Format(@"(?<=\s|^)[^!.?]*\b{0}\b[^!.?]*[!.?]", matchWord);
            MatchCollection sentences = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
            foreach (Match sentence in sentences)
            {
                Console.WriteLine(sentence.Groups[0]);
            }
        }
    }
}

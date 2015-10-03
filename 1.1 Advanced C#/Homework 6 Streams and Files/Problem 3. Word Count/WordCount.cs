using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_3.Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            StreamReader wordReader = new StreamReader("words.txt");
            StreamReader textReader = new StreamReader("text.txt");
            StreamWriter resultWriter = new StreamWriter("result.txt");
            Dictionary<string, string> words = new Dictionary<string, string>();
            using (wordReader)
            {
                string wordInput = wordReader.ReadLine();
                while (wordInput != null)
                {
                    words[wordInput] = "0";
                    wordInput = wordReader.ReadLine();
                }
            }
            using (textReader)
            {
                string[] textWords = textReader.ReadLine().Trim(',', '!', '.', '?', '-').Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                while (textWords != null)
                {
                    foreach (var word in words.ToList())
                    {
                        int wordCount = Convert.ToInt32(words[word.Key]);
                        foreach (var textWord in textWords)
                        {
                            if (word.Key == textWord)
                            {
                                wordCount++;
                            }
                        }
                        words[word.Key] = Convert.ToString(wordCount);
                    }
                    try
                    {
                        
                    textWords = textReader.ReadLine().ToLower().Trim(',', '!', '.', '?','-').Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

            }
            using (resultWriter)
            {
                foreach (var word in words)
                {
                    Console.WriteLine(word.Key + "-" + word.Value);
                }
            }
        }
    }
}

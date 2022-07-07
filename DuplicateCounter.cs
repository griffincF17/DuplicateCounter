using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DuplicateCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string sentence;

            //Asks user to enter a sentence
            Console.Write("Enter a sentence: ");
            sentence = Console.ReadLine();

            //Creates an array of words from the sentence
            string[] words = sentence.Split(' ');

            //Ignores all punctuation
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Regex.Replace(words[i], @"[^\w\s\d]", "");

            }

            //Counts the duplicates
            int duplicates = 0;
            foreach (string word in words)
            {
                if (!dict.ContainsKey(word.ToUpper()))
                {
                    dict.Add(word.ToUpper(), 1);
                }
                else
                {
                    dict[word.ToUpper()]++;
                    duplicates++;

                }
            }

            //Prints the words and occurrences
            Console.WriteLine("Word:\tOccurrences:");
            foreach (string word in dict.Keys)
            {
                Console.WriteLine($"{word}\t{dict[word]}");
            }

            //Prints the total number of duplicates
            Console.WriteLine($"\nDuplicates: {duplicates}");
        }
    }
}
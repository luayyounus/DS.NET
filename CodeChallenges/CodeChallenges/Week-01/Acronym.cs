using System;

namespace CodeChallenges
{
    class Acronym
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter a phrase to get acronym.");
            string userInput = Console.ReadLine();
            string result = GetAcronym(userInput.ToUpper());
            Console.WriteLine("Result is: {0}",result);
            Console.ReadLine();
        }

        static string GetAcronym(string phrase)
        {
            if (String.IsNullOrEmpty(phrase)) return null;
            string acronym = "";

            string[] wordsArray = phrase.Split(" ");
            string[] predicateArray = {"a", "for", "an", "and", "of", "or", "the", "to", "with"};

            foreach (var word in wordsArray)
            {
                bool matchFound = false;
                foreach (var p in predicateArray)
                {
                    matchFound = false;
                    if (word.ToLower() != p) continue;
                    matchFound = true;
                    break;
                }
                if (matchFound) continue;
                acronym += char.ToUpper(word[0]);
            }
            return acronym;
        }
    }
}

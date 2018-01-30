using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AmazonPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie mOne = new Movie() {Name = "Titanic", Rate = 3};
            Movie mTwo = new Movie() {Name = "OfferUp", Rate = 5};
            Movie mThree = new Movie() {Name = "Crackers", Rate = 4};
            Movie mFour = new Movie() {Name = "Lions king", Rate = 4};

            List<Movie> list = new List<Movie>();
            
            list.Add(mOne);
            list.Add(mTwo);
            list.Add(mThree);
            list.Add(mFour);

            HashSet<Movie> mySet = list.OrderByDescending(m => m.Rate).Take(3).ToHashSet();
            //SortedSet<>
            //SortedDictionary<>

            string oh = "423";
            
            Dictionary<string, int> ss = new Dictionary<string, int>();

            foreach (Movie m in mySet)
            {
                //Console.WriteLine(m.Name + m.Rate);
            }

            string sad = "hello";
            char wow = sad.ElementAt(0);
            Console.WriteLine(wow);

            // 10 
            //Console.WriteLine(MissingNumber(new []{0,1,2,3,5,6}));

            // 9 sliding window

            // 8 nested Dictionaries - pretty print
            //NestetedDictionaryOfferUp();

            // 7 - Nested Array - check if banana exists more than once
            //"banana", "peach", { "potato", "banana" }, "pine", "apple"
            List<string> one = new List<string> {"tomato"};
            List<string> two = new List<string> { "peach" };
            List<string> three = new List<string> { "potato", "banana" };
            List<string> four = new List<string> { "pine" };
            List<string> five = new List<string> { "apple" };

            List<List<string>> gro = new List<List<string>>() {one, two, three, four, five};
            var doubleGro = NestedList(gro);

            // 6 - Sum linked lists
            var sum1 = MaximumSizeSubarraySumEqualsK.MaxSubArrayLen(new[] { 1, -1, 5, -2, 3 }, 3);
            // Another solution but Faster with one loop
            var sum2 = MaximumSizeSubarraySumEqualsK.MaxSubArrayLengthFaster(new[] { 1, -1, 5, -2, 3 }, 3);

            // 5  - Compare version
            int result4 = CompareVersion("1.01", "1.0");

            // 4 - Number to Words
            string resultWords = NumberToWords(500);

            // 3 - Reverse Words in String in O(1) no extra space
            string a = "Hello World!";
            char[] result3 = ReverseWords(a.ToCharArray());

            // 2 - Reverse a string
            string result2 = ReverseString("Hello");

            // 1 - First Unique Character in a String
            int result = ReturnFirstUniqueChar("hello");

            Console.ReadLine();
        }


        public void Notes()
        {
            // ---------------- NOTES ----------------
            // return comparetor result 1 if positive OR -1 if negative OR 0 if they equal to zero
            int v1 = -23;
            int v2 = 543;
            int compare = Math.Sign(v1.CompareTo(v2));
            int result = (((v1 - v2) >> 0x1F) | (int)((uint)(-(v1 - v2)) >> 0x1F));


            // playing with numbers after the the dot 13.53 - remaining
            double temp = 332.23;
            double mo = temp % 1;
            int afterDot = (int)(mo * 100);

            // playing with Split
            string s = "1,5,7";
            string[] resul = s.Split(',');


            // playing with obj
            object obj = new List<int>();

            // checking if the objectg is a list
            if (obj is IList && obj.GetType().IsGenericType &&
                obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                Console.WriteLine("it is !!!");
            }


            // Seperating strings by space or coma space
            List<string> names = new List<string>() { "John", "Anna", "Monica" };
            var delimitedString = String.Join(", ", names.ToArray());
        }

        // 10 - find missing number 1 2 3 5 6 7
        public static int MissingNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result ^= i;
                result ^= nums[i];
            }
            result ^= nums.Length;
            return result;
        }

        // 9
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            // calculate the ending array size using "nums length - k + 1" equation
            int[] resultsArray = new int[nums.Length - k + 1];


            List<int> checkingAgainst = new List<int>();
            int j = 0;
            for (j = 0; j < k; j++)
            {
                checkingAgainst.Add(nums[j]);
            }
            for (int i = 0; i < resultsArray.Length; i++)
            {
                int max = checkingAgainst.Max();
                resultsArray[i] = max;
                checkingAgainst.RemoveAt(1);
                j++;
                checkingAgainst.Add(nums[j]);
            }
            return resultsArray;
        }

        // 8 nested dictionary pretty print
        private static void NestetedDictionaryOfferUp()
        {
            Dictionary<string, object> students = new Dictionary<string, object>();

            Dictionary<string, object> nestedStudent = new Dictionary<string, object>();
            nestedStudent.Add("Best Actor", 2018);

            students.Add("Luay", 1);
            students.Add("Brandon", nestedStudent);
            students.Add("Ariel", 77);

            Console.WriteLine("[");
            foreach (KeyValuePair<string, object> student in students)
            {
                if (student.Value is Dictionary<string, object>)
                {
                    Dictionary<string, object> nesteDictionary = (Dictionary<string, object>)student.Value;
                    Console.Write($"{student.Key}  : [ \n \t   \"{nesteDictionary.FirstOrDefault().Key} : " +
                                  $"{nesteDictionary.FirstOrDefault().Value}\" \n \t   ]");
                }
                else
                {
                    Console.Write($"{student.Key} \t : {student.Value}");
                }
                if (!students[student.Key].Equals(students.Last().Value))
                {
                    Console.Write(",\n");
                }
            }

            Console.Write("\n]");
        }

        // 7 - Nested List { {"banana"}, {"apple"}, { "peach", "pine" }, {"apple"}, {"banana"}}
        public static bool NestedList(List<List<string>> grocerry)
        {
            bool isRepeated = false;
            Queue<string> q = new Queue<string>();

            // Flattening the nested list (2D list into one queue)
            foreach (List<string> innerList in grocerry)
            {
                if (innerList.Count > 1)
                {
                    foreach (string fruit in innerList)
                    {
                        q.Enqueue(fruit);
                    }
                }
                else
                {
                    q.Enqueue(innerList[0]);
                }
            }

            while (q.Any())
            {
                string tempFruit = q.Dequeue();
                if (tempFruit != "banana") continue;
                isRepeated = true;
                break;
            }
            return isRepeated;
        }

        // 5 - compare program version 1.0 bigger than 1.3 and so....
        public static int CompareVersion(string version1, string version2)
        {
            string[] versionOne = version1.Split('.');
            string[] versionTwo = version2.Split('.');

            int length = Math.Max(versionOne.Length, versionTwo.Length);
            for (int i = 0; i < length; i++)
            {
                string v1 = i < versionOne.Length ? versionOne[i] : "0";
                string v2 = i < versionTwo.Length ? versionTwo[i] : "0";

                for (int j = 0; j < v1.Length; j++)
                {
                    int one = (int)char.GetNumericValue(v1[j]);
                    //int two = (int)char.GetNumericValue(v2[j]);
                    //if (one > two) return 1;
                    //if (one < two) return -1;
                }
            }

            return 0;
        }

        // 4 - Number to Words
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }


        // 3 - Took me 7 Minutes
        public static char[] ReverseWords(char[] str)
        {
            int[] s = new int[3];
            str = ReverseString3(str);
            int i = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ' ')
                {
                    ReversePartial(str, i, j - 1);
                    i = j + 1;
                }
            }
            ReversePartial(str, i, str.Length - 1);
            return str;
        }
        public static void ReversePartial(char[] p, int i, int j)
        {
            while (i < j)
            {
                char temp = p[i];
                p[i] = p[j];
                p[j] = temp;
                i++;
                j--;
            }
        }

        // 2 - Took me 5 minutes
        public static string ReverseString(string input)
        {
            char[] reverseArray = new char[input.Length];
            for (int i = input.Length - 1, j = 0; j < input.Length; i--, j++)
            {
                reverseArray[i] = input[j];
            }
            return new string(reverseArray);
        }
        // 2 - Another way to do it - 2 minutes
        public static string ReverseString2(string input)
        {
            string reversed = "";
            for (int i = input.Length - 1; i >= 0; i--)
                reversed += input[i];
            return reversed;
        }
        // 2 - Another char array solution
        public static char[] ReverseString3(char[] input)
        {
            for (int i = 0, j = input.Length - 1; i < input.Length / 2; i++, j--)
            {
                char temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }
            return input;
        }


        // 1 - Took me 12 minutes
        static int ReturnFirstUniqueChar(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c)) charCount.Add(c, 1);
                else charCount[c] += 1;
            }
            for (int i = 0; i < s.Length; i++)
                if (charCount[s[i]] == 1)
                    return i;
            return -1;
        }
    }
}

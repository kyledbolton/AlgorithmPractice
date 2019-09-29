using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    public class ArraysAndStrings
    {
        public static void PrintListValues(IEnumerable myList)
        {
            //foreach (object i in myList)
            //{
            //    Debug.WriteLine(i);
            //}
        }

        public static string JoinStrings(string[] words)
        {
            string sentence = "";
            foreach (string s in words)
            {
                sentence = $"{sentence}{s}";
            }

            return sentence;
        }

        public static string StringBuilder(string[] words)
        {
            StringBuilder sentence = new StringBuilder();

            foreach (string s in words)
            {
                sentence.Append(s);
            }

            return sentence.ToString();
        }

        //1.1 Is Unique

        //public static bool UniqueCharacters(string word)
        //{
        //    char[] characterArray = word.ToCharArray();
        //    char testCharacter; // = characterarray[0];
        //    int arrayLength = word.Length;
        //    int count = 1;

        //    foreach (char c in characterArray)
        //    {
        //        testCharacter = c;

        //        for (int i = count; i < arrayLength; i++)
        //        {
        //            if (testCharacter == characterArray[i])
        //            {
        //                return false;
        //            }
        //        }

        //        count++;
        //    }

        //    return true;
        //}

        public static bool UniqueCharacters(string word)
        {
            char[] characterArrayCheck = new char[word.Length];
            char[] wordCharacterArray = word.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                if (characterArrayCheck.Contains(wordCharacterArray[i]))
                {
                    return false;
                }

                characterArrayCheck[i] = wordCharacterArray[i];
            }

            return true;
        }

        //1.2 Check Permutation
        public static bool WordPermutationCharacterCheck(string firstWord, string secondWord)
        {
            if (firstWord.Length != secondWord.Length)
            {
                return false;
            }

            Hashtable firstWordHash = new Hashtable();
            Hashtable secondWordHash = new Hashtable();

            char[] firstWordCharacterArray = firstWord.ToCharArray();
            char[] secondWordCharacterArray = secondWord.ToCharArray();

            foreach (char c in firstWordCharacterArray)
            {
                if (firstWordHash.ContainsKey(c))
                {
                    int value = (int)firstWordHash[c];
                    firstWordHash[c] = value + 1;
                }
                else
                {
                    firstWordHash.Add(c, 1);
                }
            }

            foreach (char c in secondWordCharacterArray)
            {
                if (secondWordHash.ContainsKey(c))
                {
                    int value = (int)secondWordHash[c];
                    secondWordHash[c] = value + 1;
                }
                else
                {
                    secondWordHash.Add(c, 1);
                }
            }

            foreach (char key in firstWordHash.Keys)
            {
                if (secondWordHash.ContainsKey(key))
                {
                    if ((int)firstWordHash[key] != (int)secondWordHash[key])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static bool WordPermutationCharacterCheckBetter(string firstWord, string secondWord)
        {
            if (firstWord.Length != secondWord.Length)
            {
                return false;
            }

            Hashtable wordHash = new Hashtable();

            char[] firstWordCharacterArray = firstWord.ToCharArray();
            char[] secondWordCharacterArray = secondWord.ToCharArray();

            foreach (char c in firstWordCharacterArray)
            {
                if (wordHash.ContainsKey(c))
                {
                    int value = (int)wordHash[c];
                    wordHash[c] = value + 1;
                }
                else
                {
                    wordHash.Add(c, 1);
                }
            }

            foreach (char c in secondWordCharacterArray)
            {
                if (wordHash.ContainsKey(c))
                {
                    int value = (int)wordHash[c];
                    wordHash[c] = value - 1;
                }
                else
                {
                    return false;
                }

                if ((int)wordHash[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool WordPermutationSort(string firstWord, string secondWord)
        {
            char[] firstWordCharacterArray = firstWord.ToCharArray();
            char[] secondWordCharacterArray = secondWord.ToCharArray();

            Array.Sort(firstWordCharacterArray);
            Array.Sort(secondWordCharacterArray);

            return firstWordCharacterArray.SequenceEqual(secondWordCharacterArray);
        }

        //1.3 URLify
        public static string urlIfyList(string word)
        {
            //char[] URLstring = word.ToCharArray();
            int wordLength = word.Length;
            List<char> urlArrayList = word.ToList<char>();

            for (int i = 0; i < wordLength; i++)
            {
                if (urlArrayList[i] == ' ')
                {
                    urlArrayList[i] = '%';
                    urlArrayList.Insert(i + 1, '2');
                    urlArrayList.Insert(i + 2, '0');
                }
                //Debug.WriteLine(i);
            }

            char[] wordCharacterArray = urlArrayList.ToArray();

            string transformedURL = new string(wordCharacterArray);
            return transformedURL;
        }

        public static string urlIfy(string word)
        {
            char[] wordInput = word.ToCharArray();
            int spaceCount = 0;

            foreach (char c in wordInput)
            {
                if (c == ' ')
                {
                    spaceCount++;
                }
            }

            char[] transformedInput = new char[(word.Length + spaceCount * 2)];
            int transformedInputTracker = transformedInput.Length - 1;

            for (int i = wordInput.Length - 1; i >= 0; i--)
            {
                if (wordInput[i] == ' ')
                {
                    transformedInput[transformedInputTracker] = '0';
                    transformedInput[transformedInputTracker - 1] = '2';
                    transformedInput[transformedInputTracker - 2] = '%';

                    transformedInputTracker -= 3;
                }
                else
                {
                    transformedInput[transformedInputTracker] = wordInput[i];
                    transformedInputTracker--;
                }
            }

            return new string(transformedInput);
        }

        //1.4 Palindrome Permutation
        public static bool PalindromePermutation(string word)
        {
            char[] wordCharacterArray = word.ToCharArray();
            Hashtable characterStorage = new Hashtable();

            foreach (char c in wordCharacterArray)
            {
                if (characterStorage.ContainsKey(c))
                {
                    int value = (int)characterStorage[c];
                    characterStorage[c] = value + 1;
                }
                else
                {
                    characterStorage.Add(c, 1);
                }
            }

            int oddNumberCount = 0;

            foreach (char key in characterStorage.Keys)
            {
                if ((int)characterStorage[key] % 2 == 1 && key != ' ')
                {
                    oddNumberCount++;
                }

                if (oddNumberCount > 1)
                {
                    return false;
                }
            }

            return true;
        }

        //1.5 One Away --this is not even close to correct
        public static bool OneEditAway(string firstWord, string secondWord)
        {
            int DifferenceCount = 0;

            //replace
            if (firstWord.Length == secondWord.Length)
            {
                char[] firstWordCharacterArray = firstWord.ToCharArray();
                char[] secondWordCharacterArray = secondWord.ToCharArray();

                for (int i = 0; i < firstWord.Length; i++)
                {
                    if (firstWordCharacterArray[i] != secondWordCharacterArray[i])
                    {
                        DifferenceCount++;
                    }
                }

                if (DifferenceCount == 1)
                {
                    Debug.WriteLine("Replace");
                    return true;
                }
                else
                {
                    return false;
                }

            }

            char[] longerWordCharacterArray;
            char[] shorterWordCharacterArray;

            if (firstWord.Length > secondWord.Length)
            {
                longerWordCharacterArray = firstWord.ToCharArray();
                shorterWordCharacterArray = secondWord.ToCharArray();
            }
            else
            {
                longerWordCharacterArray = secondWord.ToCharArray();
                shorterWordCharacterArray = firstWord.ToCharArray();
            }

            int firstTraverseKey = 0;
            int secondTraverseKey = 0;

            //insert
            for (int i = 0; i < shorterWordCharacterArray.Length; i++)
            {
                if (longerWordCharacterArray[firstTraverseKey] != shorterWordCharacterArray[secondTraverseKey])
                {
                    DifferenceCount++;
                }
                else
                {
                    secondTraverseKey++;
                }

                firstTraverseKey++;

            }

            if (firstTraverseKey == secondTraverseKey)
            {
                DifferenceCount++;
            }

            if (DifferenceCount == 1)
            {
                Debug.WriteLine("Insert");
                return true;
            }
            else
            {
                DifferenceCount = 0;
                secondTraverseKey = 0;
            }

            //remove
            for (int i = 0; i < longerWordCharacterArray.Length; i++)
            {
                if (longerWordCharacterArray[i] != shorterWordCharacterArray[secondTraverseKey])
                {
                    DifferenceCount++;
                    secondTraverseKey--;
                }
                secondTraverseKey++;
            }

            if (DifferenceCount == 1)
            {
                Debug.WriteLine("Remove");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

//base libraries
using System;
using System.Text;
using System.Collections.Generic;

//added imports

namespace WebSample.BLL.Utilities
{

    public class StringUtility
    {
        public StringUtility()
        {

        }


        //static method to truncate descriptions to a certain size
        public static String truncateDescription(String description, int strLenght)
        {
            if (description == null || description.Equals(""))
                return ""; //return the empty string

            if (description.Length <= strLenght)
                return description;


            //get the first N chars and count the words
            String first_N_Chars = description.Substring(0, strLenght);

            List<String> word_list = SplitIntoWords(first_N_Chars, false);

            int trucateLimit =
                first_N_Chars.LastIndexOf(word_list[word_list.Count - 1], StringComparison.OrdinalIgnoreCase);

            first_N_Chars = first_N_Chars.Substring(0, trucateLimit);

            //add three dots and return the string
            return first_N_Chars + " ... ";
        }


        private static List<String> SplitIntoWords(String compoundWords, bool areKeywords)
        {
            if (String.IsNullOrEmpty(compoundWords))
                return new List<String>();

            //replace all punctuation with spaces
            StringBuilder compoundWordsBuilder = new StringBuilder(compoundWords);
            compoundWordsBuilder.Replace(",", " ");

            if (!areKeywords)
                compoundWords = compoundWords.Replace(";", " ");

            //BUG FIX: stop removing dots to allow keywords such as asp.net
            //compoundWordsBuilder.Replace(".", " ");
            //added in extra to corporate content to remove quatation marks
            compoundWordsBuilder.Replace("\"", "");
            //compoundWordsBuilder.Replace("'", "");
            compoundWordsBuilder.Replace("!", " ");
            compoundWordsBuilder.Replace("?", " ");
            compoundWordsBuilder.Replace("%", " ");
            compoundWordsBuilder.Replace("\t", " ");
            compoundWordsBuilder.Replace("\n", " ");
            compoundWordsBuilder.Replace("\r\n", " ");

            //replace double spaces with singe space
            compoundWordsBuilder.Replace("  ", " ");

            String[] words;
            if (areKeywords)
                words = compoundWordsBuilder.ToString().Split(';');
            else
                words = compoundWordsBuilder.ToString().Split(' ');

            List<String> word_list = new List<String>();

            //eliminate the empty words
            foreach (String word in words)
            {
                if (!word.Trim().Equals(""))
                {
                    //verify that the word is not already present in the list
                    if (!word_list.Contains(word.Trim().ToLower()))
                    {
                        //append the word
                        word_list.Add(word.Trim().ToLower());
                    }
                }
            }

            return word_list;
        }
    }
}
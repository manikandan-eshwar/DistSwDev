using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Iveonik.Stemmers;

namespace Stemming
{
   
    public class Service1 : IService1
    {
        //Creating an instance of EnglishStemmer
        IStemmer stemmer = new EnglishStemmer();

        //This operation stems the english words to its root word
        public String Stemming(String input)
        {
            String output = null;
            try
            {
                if (input == null)
                {
                    return "Invalid Input";
                }
                //Spliting words if there are more than one word
                String[] words = input.Split(' ');

                //Hanlding special case of words ending with 'ying'
                String temp = null;
                foreach (String word in words)
                {
                    //Calling the Porter Stemmer Implementation of Package 'StemmersNet'
                    temp = stemmer.Stem(word.Trim());

                    //Storing the word along with its stemmed root to be returned
                    output += word + "----->" + temp + "<br/>";
                }
            }
            catch (Exception ae)
            {
                output = "Invalid or Null Input";
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
            finally
            {

            }
            return output;
        } 
    }
}

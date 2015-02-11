using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace WordFilter
{

    public class Service1 : IService1
    {
       //This operation 
       public String WordFilter(String inputText)
        {
            String outputText = null;
            HashSet<String> stopWords = new HashSet<string>();
            stopWords.Add("a");
            stopWords.Add("an");
            stopWords.Add("in");
            stopWords.Add("on");
            stopWords.Add("the");
            stopWords.Add("is");
            stopWords.Add("are");
            stopWords.Add("am");
            if (inputText == null) return "Input Cannot be Empty";
            String TempText= Regex.Replace(inputText, "<.*?>", string.Empty);
            String[] words = TempText.Split(' ');
            
            foreach(String word in words)
            {
                if (!stopWords.Contains(word))
                {
                    outputText = outputText +" "+ word;
                }
            }
            return outputText;
        }
    }
}

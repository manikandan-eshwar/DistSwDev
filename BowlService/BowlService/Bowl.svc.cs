using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace BowlService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<string> bowl = new List<string>();
        static string filePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath+"\\";

        
        public string addToBowl(string item,string username)
        {
            try
            {
                string result = null;
                loadFromFile(username);
                bowl.Add(item);
                saveToFile(username);
                loadFromFile(username);
                foreach(string res in bowl) {
                    if(!res.Equals("empty"))
                    result = res + ","+result;
                }
                return result;
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
            return "failed";
        }

        public string removeFromBowl(string item,string username)
        {
            try
            {
                string result = null;
                loadFromFile(username);
                bowl.Remove(item);
                saveToFile(username);
                loadFromFile(username);
                foreach (string res in bowl)
                {
                    if (!res.Equals("empty"))
                    result = res + "," + result;
                }
                return result;
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
            return "failed";
        }

        public Boolean checkOutConfirm(String username)
        {
            try
            {
                loadFromFile(username);
                List<string> temp=new List<string>();
                temp.Add("empty");
                bowl = temp;
                saveToFile(username);
                return true;
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
            return false;
        }

        void saveToFile(String username)
        {
            //storing the registered user to file
            using (Stream stream = File.Open(filePath+username+".bin", FileMode.Create))
            {
                var toFile = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                toFile.Serialize(stream, bowl);
            }
        }

        void loadFromFile(String username)
        {
            //retrieving values from file
            if (File.Exists(filePath + username+".bin"))
            {
                using (Stream stream = File.Open(filePath + username+".bin", FileMode.Open))
                {
                    var fromFile = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bowl = (List<string>)fromFile.Deserialize(stream);
                }
            }
            else
            {
                using (Stream stream = File.Open(filePath + username+".bin", FileMode.Create))
                {
                    var toFile = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    toFile.Serialize(stream, bowl);
                }
            }
        }
    }
}

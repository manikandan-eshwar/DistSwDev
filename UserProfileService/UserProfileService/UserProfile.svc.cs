using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace UserProfileService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Dictionary<String, String> loginTable = new Dictionary<string, string>();
        Dictionary<String, Register> registerTable = new Dictionary<string, Register>();
        string filePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath+"\\registerTable.bin";

        public Boolean login(string username, string password)
        {
            try
            {
                loadFromFile();
                //Checking if already logged in the same session
                if (!loginTable.ContainsKey(username))
                {
                    //checking if already registered
                    if (registerTable.ContainsKey(username))
                    {
                        Register res = new Register();
                        res = registerTable[username];
                        
                        //Checking if the password is matching
                        if (res.password.Equals(password))
                        {
                            loginTable.Add(username, password);
                            return true;
                        }
                    }
                }
               
            }

            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred:" + ae.StackTrace);
            }
            return false;
        }

        public Boolean register(string username, string password, string email, string mobile, string location)
        {
            try
            {
                //Initilaizing values from file
                loadFromFile();
                Register reg = new Register();
                reg.username = username;
                reg.password = password;
                reg.email = email;
                reg.mobile = mobile;
                reg.location = location;
                if (!registerTable.ContainsKey(username))
                {
                    registerTable.Add(username, reg);
                    saveToFile();
                    return true;
                }

            }

           catch (Exception ae)
            {
                   Console.WriteLine("Exception Occurred:" + ae.StackTrace);
            }
            return false;
        }

        public string[] getMembersList()
        {
           
            int i=0;
            try
            {
                loadFromFile();
                
                string[] members = new string[registerTable.Count];
                foreach(string s in registerTable.Keys) {
                    Register reg=registerTable[s];
                    members[i] = reg.username + ", " + reg.email + ", " + reg.mobile;
                    i++;
                }
                return members;
            }
            catch (Exception ae)
            {
                  Console.WriteLine("Exception Occurred: "+ae. StackTrace);
            }
            return null;
        }
        void saveToFile()
        {
            //storing the registered user to file
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var toFile = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                toFile.Serialize(stream, registerTable);
            }
        }

        void loadFromFile()
        {
            //retrieving values from file
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var fromFile = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                 registerTable = (Dictionary<string,Register>)fromFile.Deserialize(stream);
            }
        }
    }

    [Serializable]
    public class Register
    {
        public Register()
        {
        }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string location { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace CardinalsHBS
{
    public class BankService
    {
        public static Dictionary<string, string> accountregister = new Dictionary<string, string>();//it is used as a bank register having account holders name and respective account number
        public static Random rng = new Random();
        /// <summary>
        /// the method generates a credit card number for the travel agency parameter
        /// if the travelagency has an account it will return the account number else 
        /// a new number is generated
        /// </summary>
        /// <param name="TAname"></param>
        /// <returns>credit card no as string</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]   
        public static string generatecardno(string TAname)//generating an 8-digit credit card no
        {
           if (accountregister.ContainsKey(TAname))
            {
                return accountregister[TAname];
               
            }
            else
            {
                int[] numberarray = new int[5];
                int p = rng.Next(12345678,87654321);
                accountregister.Add(TAname, p.ToString());
                return p.ToString();
            }
        }

        /// <summary>
        /// This method returns the encrypted card no.
        /// </summary>
        /// <param name="TAname"></param>
        /// <returns>encrypted credit card no.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string EncryptCardNo(String cardNum)
        {
            CardEncryptionService.Service myencryptionservice = new CardEncryptionService.Service();
               string encryptedCNo = myencryptionservice.Encrypt(cardNum);
               return encryptedCNo;

        }

        /// <summary>
        /// method to check if the credit card no of the travel agency TAname is valid
        /// </summary>
        /// <param name="TAname"></param>
        /// <param name="encryptedcno"></param>
        /// <returns>true or false</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool verifyaccount(string TAname, String encryptedcno)
        {

            CardEncryptionService.Service myencryptionservice = new CardEncryptionService.Service();
            String decryptedcno = myencryptionservice.Decrypt(encryptedcno);
            if (accountregister.ContainsKey(TAname))
            {
                if (accountregister[TAname].Equals(decryptedcno))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}

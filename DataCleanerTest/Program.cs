using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataCleanerTest
{
    public class Program
    {
        
        public static List<string> emails = new List<string>()
            {
                "ozancelik1919@hotmail.com",
                "ozançelik1919@hotmail.com",
                "ozancelik1919[at]hotmail.com",
                "ozancelik@hotmail com",
                " ozancelik1919@hotmail.com mozancelik@ggmail.com",
                "emreabdik@yahoo_com",
                "ahmet.s @ttnet.net.tr",
                "ahmet.ülker@mfa.gov.tr",
                "ahmetkeskings@gmail.com",
                "ahmetkeskings@gnail.com",
                "ahmetege007@@hotmail.com",
                "AHMETAŞKINGS@GMAİL.COM",
                " ",
                "efecan2@gmail.com",
                "                                                            ",
                "guideahmet68@yahoo.com",
                "nazliulker@superonline.com; ülkernazlı@süperonline.cım",
                "usmangil@yandex.com",
                "email vermek istemiyor",
                "h245kac@tbmm.gov.tr",
                "ahmet.topcuoglu@kcc.com(Maili",
                "ahmetmert05@yahoo.com,mert.aydogdu@gmail.com",
                "<mert.aydogdu@gmail.com>",
                "Gönen Eren <mert.aydogdu@gmail.com>",
                "",
            };

        public static List<string> PhoneNumbers = new List<string>()
        {

            "535638467;05336230764",
            "5326904697",
            "005334275574",
            "5423480284-5556214541",
            "5335409150",
            "+9713528713966",
            "9713528713966",
            "5336559665",
            "5352171969",
            "+1 8128560309",
            "212-317 57 53 - 656",
            "2742250660",
            "216 5445227",
            "001 7736220",
            "Telefon vermek istemiyo",
            "2165711652 ",
            "0216 4593451",
            "90533 7644168",
            " 2165702323",
            "216 333 71 00 (dhl 7563)",
            "- -",
            "  ",
            "5336230795",


        };
       

        static List<string> GsmNumbers = new List<string>()
        {
            "530",
            "532",
            "533",
            "534",
            "535",
            "536",
            "537",
            "538",
            "539​",
            "540",
            "541",
            "542",
            "543",
            "544",
            "545",
            "546",
            "547",
            "548",
            "549",
            "505",
            "506",
            "507",
            "551",
            "552",
            "553",
            "554",
            "555",
            "556",
            "557",
            "558",
            "559​",
​
        };

        private static List<string> PrefixNumbers = new List<string>()
        {


            "322",
            "416",
            "272",
            "472",
            "382",
            "358",
            "312",
            "242",
            "478",
            "466",
            "256",
            "266",
            "378",
            "488",
            "458",
            "228",
            "426",
            "434",
            "374",
            "248",
            "224",
            "286",
            "376",
            "364",
            "258",
            "412",
            "380",
            "284",
            "424",
            "446",
            "442",
            "222",
            "342",
            "454",
            "456",
            "438",
            "326",
            "476",
            "246",
            "324",
            "212",
            "216",
            "232",
            "370",
            "338",
            "474",
            "366",
            "352",

            "318",
            "288",
            "386",
            "348",
            "344",
            "262",
            "332",
            "274",
            "422",
            "236",
            "482",
            "252",
            "436",
            "384",
            "388",
            "452",
            "328",
            "464",
            "264",
            "362",
            "484",
            "368",
            "346",
            "414",
            "486",
            "282",
            "356",
            "462",
            "428",
            "276",
            "432",
            "226",
            "354",
            "372",
            "392",







        };


        static List<string> RootDomainNames= new List<string>()
        {
            "com",
            "com.tr",
            "fr",
            "co",
            "gov.tr",
        };
        static List<string> DomainNames = new List<string>()
        {
            "gmail.com",
            "yahoo.com",
            "superonline.com",
            "yandex.com",
            "tbmm.gov.tr",
            "hotmail.com",
            "ttnet.net.tr",


        };
        static List<string> PhoneStartsCode = new List<string>()
        {
            
           
            "90",
            "0",
            "00",
            "9",
            "+90",
            "+",
             "+9",

            


        }; 


        static void Main(string[] args)
        {
            // Check The Email
            //---------------------------------------------------
            foreach(string email in emails)
            {
                CheckEmail(email);
            }
            // Check The PhoneNumber
            //---------------------------------------------------
            foreach (string PhoneNumber in PhoneNumbers)
            {
                CheckPhoneNumber(PhoneNumber);
            }


            // End of the program
            //---------------------------------------------------
            Console.WriteLine("Program Terminated");
            Console.ReadLine();
        }

        private static void CheckPhoneNumber(string PhoneNumber)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------");
            Console.WriteLine(PhoneNumber);


            Console.ForegroundColor = ConsoleColor.Magenta;
            // Check if null or empty
            //---------------------------------------------------
            if (String.IsNullOrEmpty(PhoneNumber))
            {
                Console.WriteLine("NumberIsNull");
                return;
            }
            // Trim 
            //---------------------------------------------------

            string result = PhoneNumber.Trim();

            // Check if null or empty Result
            //---------------------------------------------------
            if (String.IsNullOrEmpty(result))
            {
                Console.WriteLine("NumberIsNull");
                return;
            }
            
            // Check - - signs
            //---------------------------------------------------
            if (result.Contains("-"))
            {
         
                Console.WriteLine("AutoCorrectionHas-Signe");
                result = result.Replace("-","");
               

            }


            // Trim the phone
            //---------------------------------------------------
            if (result.Contains("("))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split('(').First();
            }
            if (result.Contains(";"))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split(';').First();
                result = result.Replace(";", "");
            }
          
            // Check white space
            //---------------------------------------------------
            if (result.Contains(" "))
            {
                Console.WriteLine("AutoCorrectionWhiteSpace");
                result = result.Replace(" ", "");
            }
            //Check Phone number format 
            Reg = new Regex(@"^\[1-9]{1}[0-9]{3,14}$");

            if (!Reg.IsMatch(result))
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                

                //Check Phone number Lenght
                if ( result.Length < 10)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                

                    Console.WriteLine("PhoneNumberHaveMissingPart");


                }
                if (result.Length > 14)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("PhoneNumberHaveExcessPart");
                    

                }



                //Check Phone number FirstChars

                bool isStartingWithAGoodCharacter = false;
                foreach (string firstChar in PhoneStartsCode)
                {
                    if (result.StartsWith(firstChar))
                    {
                        isStartingWithAGoodCharacter = true;
                        if (result.StartsWith("+90"))
                        {
                            result=result.Substring(3);
                        }
                        if (result.StartsWith("90"))
                        {
                           result=result.Substring(2);
                        }
                        if (result.StartsWith("00"))
                        {
                            result=result.Substring(2);
                        }
                        if (result.StartsWith("0"))
                        {
                            result =result.Substring(1);
                        }
                        if (result.StartsWith("9"))
                        {
                            result =result.Substring(1);
                        }
                        if (result.StartsWith("+"))
                        {
                           result= result.Substring(1);
                        }



                        Console.WriteLine("AutoCorrection:PhoneNumberToBeThrownTurkishCountryCode");
                 

                    }

                    if (!result.StartsWith(firstChar))
                    {

                        if (result.StartsWith("5") && result.Length == 10)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("PhoneNumberIsaGSM");


                        }
                        else if ((!result.StartsWith("5")) && result.Length == 10)
                        {

                            bool isStartingWithAPrefixCode = false;
                            foreach (string firstC in PrefixNumbers)
                            {
                                if (result.StartsWith(firstC))
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("PhoneNumberIsaTurkishPrefixTelephone");

                                }
                            }

                        }

                    }




                }
                
            }
                  
           

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.WriteLine(" "); 
        }

        private static void CheckEmail(string email)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------");
            Console.WriteLine(email);


            Console.ForegroundColor = ConsoleColor.Yellow;

            // Check if null or empty
            //---------------------------------------------------
            if (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("EmailIsNull");
                return;
            }
            // Trim 
            //---------------------------------------------------

            string result = email.Trim();

            // Check if null or empty
            //---------------------------------------------------
            if (String.IsNullOrEmpty(result))
            {
                Console.WriteLine("EmailIsEmpty");
                return;
            }


            // Check < > signs
            //---------------------------------------------------
            if(result.ToCharArray()[0]=='<')
            {
               // Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("EmailStartWith<");
                Console.WriteLine("AutoCorrectionStartWith<");
                result = result.Replace("<", "");
                result = result.Replace(">", "");
                Console.ForegroundColor = ConsoleColor.Green;
              
                
            }


            // Trim the email
            //---------------------------------------------------
            if (result.Contains(","))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split(',').First();
            }
            if (result.Contains(";"))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split(';').First();
                result = result.Replace(";", "");
            }
            if (result.Contains(" "))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split(' ').First();
            }
            if (result.Contains("("))
            {
                Console.WriteLine("ContainsSeperatorTakingFirstItem");
                result = result.Split('(').First();
                result = result.Replace("(", "");
            }
   
            // Check at sign
            //---------------------------------------------------

            if (!result.Contains("@"))
            {
               
                if (result.Contains("[at]"))
                {
                    Console.WriteLine("AutoCorrectionAtSign");
                    result = result.Replace("[at]", "@");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EmailDoesNotContainAtSign");
                    return;
                }
            }


            // Check e-mail mutliple at sign
            
            //---------------------------------------------------
            Reg = new Regex(@"^([\w\.\-]+)@([\w\.\-]+)$");
            if (!Reg.IsMatch(result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EmailDoesMutlipleAtSign");
                Console.WriteLine("AutoCorrectionMultipleAtSign");
                result = result.Replace("@@", "@");
                
            }

            //Check e-mail format 
            Reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!Reg.IsMatch(result))
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EmailDoesNotBasicFormat");
                
                if (result.Contains("_"))
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AutoCorrectionBasicFormat");
                    result = result.Replace("_", ".");
                }

               

            }
             
            // Check white space
            //---------------------------------------------------
            if (result.Contains(" "))
            {
                Console.WriteLine("AutoCorrectionWhiteSpace");
                result = result.Replace(" ", "");
            }
            //---------------------------------------------------

            // To Lower
            Reg = new Regex(@"(?-i:\b\p{Lu}+\b)");
            if (Reg.IsMatch(result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EmailDoesContainUpperCase");
               // Console.ForegroundColor = ConsoleColor.Gray;
                //Console.WriteLine("AutoCorrectionUpperCaseToLowerCase");
                result = result.ToLower();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);

            }
         
            //---------------------------------------------------



            // Check non unicode
            Reg = new Regex(@"[^\x00-\x7F]");
            if(Reg.IsMatch(result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EmailDoesNotUnicode");
                result = result.Replace("ç", "c").Replace("ı", "i").Replace("ü", "u").Replace("ö", "o").Replace("ğ", "g").Replace("ş", "s");
                Console.WriteLine("AutoCorrectionNonUnicode");


            }
          

           


            // Check root domain
            //---------------------------------------------------
            bool isEndingWithAGoodRootDomainName = false;
            foreach (string rootDomainName in RootDomainNames)
            {
                if (result.EndsWith(rootDomainName))
                {
                    isEndingWithAGoodRootDomainName = true;
                }
            }
            if (!isEndingWithAGoodRootDomainName)
            {
                Console.WriteLine("WarningEmailIsNotEndingWithAGoodRootDomainName");
            
            }

            // Check domain name
            //---------------------------------------------------
            bool isEndingWithAGoodDomainName = false;
            foreach (string rootDomainName in DomainNames)
            {
                if (result.EndsWith(rootDomainName))
                {
                    isEndingWithAGoodDomainName = true;
                }
            }
            if (!isEndingWithAGoodDomainName)
            {
                Console.WriteLine("WarningEmailIsNotEndingWithAGoodDomainName");

            }

            // Check typo errors
            //---------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.WriteLine(" ");
        }

        public static Regex Reg { get; set; }

        static void DisplayResult(string item, string result, string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(string.Format("{0} ", item));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Format("{0} ", result));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(string.Format("{0} ", message));
            Console.WriteLine("\n");
        }
    }
}

using System;
using System.Linq;
using System.Text;

    class Hash
    {
       public static void Main(string[] args)
        {
           //Write your code here and do not change the class name.
            int start= 5;
            int end =10;
            string inpVal= args[0];
            int num;

            byte inpValSalt= Convert.ToByte(inpVal, 16);

            byte[] inpValSaltyyy= new byte[]{inpValSalt};

            string resultas;
            string rstring;


            IDictionary<string, string> iVal= new Dictionary<string, string>() ;

            for (num= 0; num<= 1000000; num++){
                rstring= sClass(10) ;
                byte[] rb1= Encoding.UTF8.GetBytes(rstring);

                List<byte> myList= new List<byte>();
                byte[] newArr;

                myList.AddRange(rb1);
                myList.AddRange(inpValSaltyyy);

                newArr= myList.ToArray() ;

                resultas= myMD5(newArr);

                string mdResult= resultas.Substring(0,2);

                iVal.Add(rstring, mdResult);

            }



            var searcha= iVal.GroupBy(y=> y.Value).Where(y=> y.Count()>1);

            string[] ANSWERS;

            num=0;

            foreach(var choice in searcha){
                if( num ==0){
                    var kVal= choice.Aggregate("", (u,p)=> u+","+p);
                    var kVal2= kVal;

                    ANSWERS= kVal2.Split(",");

                    string[] ansToArray= ANSWERS.ToArray();
                    string a1= ansToArray[1];

                    a1= a1.Remove(0,1);

                    string a2= ansToArray[3];
                    
                    a2= a2.Remove(0,1 );
                    

                    Console.WriteLine(a1+","+a2);
                }
                num++;
            }

            
            static string sClass(int lVal){

                Random yu= new Random();
                const string possRange= "0123456789ABCEDFGHIJKLMNOPQRSTUVWXYZabcedfghijklmnopqurstuvwxyz";
                var sClassVals= Enumerable.Range(0, lVal).Select(x => possRange[yu.Next(0, possRange.Length)]) ;

                return new string(sClassVals.ToArray() );

            }


            static string myMD5(byte[] mdVal){
                using (System.Security.Cryptography.MD5 md= System.Security.Cryptography.MD5.Create()){

                    byte[] hby= md.ComputeHash(mdVal);

                    return Convert.ToHexString(hby);
                }
            }












        }
    }


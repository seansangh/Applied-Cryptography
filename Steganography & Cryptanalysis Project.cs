using System;
using System.IO;
using System.Collections;


    class Steganography
    {


       public static void Main(string[] args)
        {
           //Write your code here and do not change the class name.
           byte[] bmpBytes = new byte[] {
                0x42,0x4D,0x4C,0x00,0x00,0x00,0x00,0x00,
                0x00,0x00,0x1A,0x00,0x00,0x00,0x0C,0x00,
                0x00,0x00,0x04,0x00,0x04,0x00,0x01,0x00,
                0x18,0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,
                0x00,0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,
                0x00,0x00,0xFF,0x00,0x00,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,
                0x00,0x00
            };


            byte[] myByte= new byte[26];

            Buffer.BlockCopy(bmpBytes, 0, myByte, 0, 26) ;

            int x;
            int exchange;
            int myCounter= 26;

            string inp= args[0];
            

            string[] myAns= inp.Split(' ');
            List<byte> myList= new List<byte>() ;
            myList.AddRange(myByte );
            foreach( var opt in myAns){
                exchange= 0;
                
                byte b1= Convert.ToByte(opt,16);
                var b1S= Convert.ToString(b1,2);
                if(b1S.Length< 8){
                    b1S= b1S.PadLeft( (8), '0');
                }
                for(x=1; x<b1S.Length; x++){
                    if(x% 2 != 0){
                        char a= b1S[x];
                        string aa= Char.ToString(a);
                        char b= b1S[x- 1];
                        string bb= Char.ToString(b);
                        string bbaa= bb+ aa;

                        int iByte= Convert.ToByte(bbaa, 2);
                        var choose= bmpBytes.Skip(myCounter).Take(4).ToArray() ;
                        var chooseByte= choose.GetValue(exchange) ;

                        int mapVal= Convert.ToInt32(chooseByte);

                        byte ans= (byte)(mapVal^ iByte);
                        byte[] ansa= new byte[]{ans};

                        myList.AddRange(ansa);
                        
                        exchange= exchange+ 1;
                    }
                }
                myCounter= myCounter+ 4;



            }



            Console.WriteLine(BitConverter.ToString(myList.ToArray()).Replace("-", " "));

        }
    }














Expected Output:
42 4D 4C 00 00 00 00 00 00 00 1A 00 00 00 0C 00 00 00 04 00 04 00 01 00 18 00 02 03 FF FD FD FE 00 00 FE FE FF FE FC FC FC 00 01 03 FF FE FD 01 02 03 FF 00 00 FF FF FC FC 01 03 FC FC FF FE FC FE 00 02 02 FF FC FD 02 00 03


dotnet run "B1 FF FF CC 98 80 09 EA 04 48 7E C9"


E7 44 D7 EF AF 5D FA 28 3A C7 C8 23







dotnet run “Hello World” “RgdIKNgHn2Wg7jXwAykTlA==”







using System;
using System.Security.Cryptography;

public class Cryptanalysis
{
    public static void Main(string[] args)
        {
          //Write your code here and do not change the class name.

            DateTime endTime= new DateTime(2020, 7, 3, 11, 0, 0);
            TimeSpan startTime= endTime.Subtract(new DateTime(1970, 1, 1)) ;
            
            int tDifference= (int)startTime.TotalMinutes;

            string plaintextString= args[0];
            string cipherString= args[1];

            int x= 0;
            Random rVal= new Random((int) tDifference);
            byte[] kVal= BitConverter.GetBytes(rVal.NextDouble());
            //60*60*24/60= 1440 
            for(x=0; x<= 1440; x++){
                rVal= new Random((int) tDifference);
                kVal= BitConverter.GetBytes(rVal.NextDouble());

                if( cipherString == Encrypt(kVal, plaintextString)){
                    Console.WriteLine(tDifference);

                    break;

                }

                else{
                    tDifference= tDifference+ 1;

                }


            }

            static string Encrypt(byte[] kVal, string plaintextString){
                DESCryptoServiceProvider csp= new DESCryptoServiceProvider();
                MemoryStream ms= new MemoryStream();
                CryptoStream cs= new CryptoStream(ms,csp.CreateEncryptor(kVal, kVal), CryptoStreamMode.Write);
                StreamWriter sw= new StreamWriter(cs);
                sw.Write(plaintextString);
                sw.Flush();
                cs.FlushFinalBlock();
                sw.Flush();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }

        









        }
  
  
}





























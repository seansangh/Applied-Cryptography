using System;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;


    class DiffieHellman
    {


       public static void Main(string[] args)
        {
           //Write your code here and do not change the class name.

          /* string testInput= "A2 2D 93 61 7F DC 0D 8E C6 3E A7 74 51 1B 24 B2" 251 465 255 1311
2101864342
8995936589171851885163650660432521853327227178155593274584417851704581 358902
"F2 2C 95 FC 6B 98 BE 40 AE AD 9C 07 20 3B B3 9F F8 2F 6D 2D 69 D6 5D 40 0A 75 45 80 45
F2 DE C8 6E C0 FF 33 A4 97 8A AF 4A CD 6E 50 86 AA 3E DF"
AfYw7Z6RzU9ZaGUloPhH3QpfA1AXWxnCGAXAwk3f6MoTx */
           string expectedOutput="uUNX8P03U3J91XsjCqOJ0LVqt4I4B2ZqEBfX1gCGBH4hH,3D E9 B7 31 42 D7 54 D8 96 12 C9 97 01 12 78 F7 A2 4F 69 1A FF F4 42 99 13 A1 BD 73 52 E5 48 63 33 7A 39 BF C5 25 AD 53 26 53 0D E4 81 51 D1 3E";
        
           string ivVal= args[0];
           string geVal= args[1];
           string gcVal= args[2];

           string neVal= args[3];
           string ncVal= args[4];

           string xVal= args[5];
           string gyModNVal= args[6];

           string cipherVal= args[7];
           string plainVal= args[8];

           List<byte> firstList= new List<byte>() ;

           List<byte> secondList= new List<byte>();


           int xVal2= Int32.Parse(xVal);
           int neVal2= Int32.Parse(neVal);

           string[] ivVal2= ivVal.Split(' ');

           string[] cipherVal2= cipherVal.Split(' ') ;

           BigInteger gyModNVal2= BigInteger.Parse(gyModNVal);
           BigInteger bigncVal= BigInteger.Parse(ncVal);
           BigInteger neVal3= BigInteger.Pow(2, neVal2) ;

           neVal3= neVal3- bigncVal;

           BigInteger keyVal= BigInteger.ModPow(gyModNVal2, xVal2, neVal3);

           byte[] keyAsBytes= keyVal.ToByteArray();

           foreach(var val in ivVal2){

            byte valToBytes= Convert.ToByte(val, 16);
            byte[] valToBytes2= new byte[] {valToBytes};

            firstList.AddRange(valToBytes2);
           }

           foreach(var val in cipherVal2){

            byte valToBytes= Convert.ToByte(val, 16);
            byte[] valToBytes2= new byte[] {valToBytes};

            secondList.AddRange(valToBytes2) ;
           }

           byte[] firstList1= firstList.ToArray();
           byte[] secondList1= secondList.ToArray();

           string ptextVal;

           ptextVal= DecryptionF(secondList1, keyAsBytes, firstList1);

           byte[] encryptionVal;

           encryptionVal= EncryptionF(plainVal, keyAsBytes, firstList1);

           Console.WriteLine(ptextVal + "," + BitConverter.ToString(encryptionVal).Replace("-", " "));





           static string DecryptionF(byte[] aVal, byte[] kVal, byte[] cVal){
            string ptextVal= null;

            using(AesManaged aesM= new AesManaged()){
                ICryptoTransform myDecryptor= aesM.CreateDecryptor(kVal, cVal) ;
                
                using(MemoryStream mStream= new MemoryStream(aVal)){

                    using(CryptoStream cStream= new CryptoStream(mStream, myDecryptor, CryptoStreamMode.Read)){
                        using(StreamReader mReader= new StreamReader(cStream))
                        ptextVal= mReader.ReadToEnd();
                        
                    }
                }
            }

            return ptextVal;

           }


           static byte[] EncryptionF(String pVal, byte[] kVal, byte[] cVal){
            byte[] eVal;

            using(AesManaged aesM= new AesManaged()){

                ICryptoTransform myEncryptor= aesM.CreateEncryptor(kVal, cVal);
                using(MemoryStream mStream= new MemoryStream()){

                    using(CryptoStream cStream= new CryptoStream(mStream, myEncryptor, CryptoStreamMode.Write)){
                        using(StreamWriter sWriter= new StreamWriter(cStream))
                        sWriter.Write(pVal);

                        eVal= mStream.ToArray();
                    }

                }
            }


            return eVal;

           }



        }
    }


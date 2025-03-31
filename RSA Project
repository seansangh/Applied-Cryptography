using System;
using System.Text;
using System.Numerics;

using System.Security.Cryptography;


    class RSA
    {


       public static void Main(string[] args)
        {
           //Write your code here and do not change the class name.
           string peVal= args[0];
           string pcVal= args[1];

           string qeVal= args[2];
           string qcVal= args[3];

           string cipherVal= args[4];
           string plainVal= args[5];

           BigInteger eVal= 65537;

           int peVal2= Int32.Parse(peVal);
           BigInteger pcVal2= BigInteger.Parse(pcVal);

           int qeVal2= Int32.Parse(qeVal);
           BigInteger qcVal2= BigInteger.Parse(qcVal);

           BigInteger cipherVal2= BigInteger.Parse(cipherVal) ;
           BigInteger plainVal2= BigInteger.Parse(plainVal);


           BigInteger qVal= BigInteger.Pow(2, qeVal2);
           qVal= qVal- qcVal2;

           BigInteger pVal= BigInteger.Pow(2, peVal2);
           pVal= pVal- pcVal2;


           BigInteger nVal= pVal* qVal; //N=p*q
           BigInteger phiNVal= (pVal- 1) * (qVal- 1);   //phiN=(p-1)*(q-1)


           BigInteger dVal;
           BigInteger d2Val;

           BigInteger d3Val= 0;


           for(int x=0; x< 1000000; x++){

            dVal= ((phiNVal* x)+ 1)/ eVal;
            d2Val= (eVal* dVal) % phiNVal;

            if(d2Val == 1){
                d3Val= dVal;
            }
           }

           BigInteger EncryptVal= BigInteger.ModPow(plainVal2, eVal, nVal);

           BigInteger DecryptVal= BigInteger.ModPow(cipherVal2, d3Val, nVal) ;


           Console.WriteLine(DecryptVal + "," + EncryptVal);




        }
    }


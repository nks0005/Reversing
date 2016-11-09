using System;

public class RijndaelSimpleTest
{
    [STAThread]
    private static void Main(string[] args)
    {
        string plainText = "";
        string cipherText = "BnCxGiN4aJDE+qUe2yIm8Q==";
        string passPhrase = "^F79ejk56$\x00a3";
        string saltValue = "DHj47&*)$h";
        string hashAlgorithm = "MD5";
        int passwordIterations = 0x400;
        string initVector = "&!\x00a3$%^&*()CvHgE!";
        int keySize = 0x100;
        RijndaelSimple.Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
        plainText = RijndaelSimple.Decrypt(cipherText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    Label_0056:
        Console.WriteLine(plainText);
        Console.WriteLine("Please enter the password: ");
        if (Console.ReadLine() == plainText)
        {
            Console.WriteLine("Well Done! You cracked it!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Bad Luck! Try again!");
            goto Label_0056;
        }
    }
}


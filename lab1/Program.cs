using System;

public class Tape
{
    int[] tape;
    int length;

    public Tape(int length)
    {
        this.length = length;
        this.tape = new int[this.length];
    }

    public void StoreValue(int[] binaryNumber)
    {

        if (binaryNumber.Length > this.length)
            throw new Exception("Oops, Binary number is too long!");

        foreach (int b in binaryNumber)
        {
            if (b != 0 && b != 1)
                throw new Exception("Binary number contains invalid values. U can enter only 0 or 1!");
        }

        for (int i = 0; i < binaryNumber.Length; i++)
            this.tape[i] = binaryNumber[i];
    }

    public int[] JustAdd(int[] binaryNumber1, int[] binaryNumber2)
    {
        int[] res = new int[this.length];
        for (int i = 0; i < binaryNumber1.Length; i++)
        {
            int sum = binaryNumber1[i] + binaryNumber2[i];
            res[i] = sum;
        }
        return res;

    }
    public int[] Add(int[] binaryNumber1, int[] binaryNumber2)
    {
        
        int[] result = new int[this.length];

        int carry = 0;
        for (int i = 0; i < this.length; i++)
        {
            int sum = binaryNumber1[i] + binaryNumber2[i] + carry;

            if (sum == 0 || sum == 1)
            {
            result[i] = sum;
            carry = 0;
        }
            else if (sum == 2)
        {
            result[i] = 0;
            carry = 1;
        }
        else
        {
            result[i] = 1;
            carry = 1;
        }
    }

        return result;
    }

    public int[] Deduct(int[] binaryNumber1, int[] binaryNumber2)
    {
        int[] res = new int[this.length];
        for (int i = 0; i < binaryNumber1.Length; i++)
        {
            int div = binaryNumber1[i] - binaryNumber2[i];
            res[i] = div;
 
        }
        return res;

    }



}




public class Program
{
    public static void Main(String[] args)
    {
        Tape tape = new Tape(8);
        int[] binaryNumber1 = { 1, 0, 1, 1, 0, 0, 1, 1 };
        int[] binaryNumber2 = { 1, 0, 1, 0, 1, 0, 0, 1 };

        tape.StoreValue(binaryNumber1);
        tape.StoreValue(binaryNumber2);
        int[] res1 = tape.Add(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the addition with remainder is: {0}", string.Join("", res1));
        int[] res2 = tape.JustAdd(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the simple addition is: {0}", string.Join("", res2));
        int[] res3 = tape.Deduct(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the deduction is: {0}", string.Join("", res3));
        
    }
}
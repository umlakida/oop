using System;

public class Tape
{
    int[] tape;
    int length;
    private static int count = 0;

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public static int Count
    {
        get { return count; }
    }

    public Tape(int length)
    {
        this.length = length;
        this.tape = new int[this.length];
        count++;
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
        count++;
    }

    public int[] JustAdd(int[] binaryNumber1, int[] binaryNumber2)
    {
        int[] res = new int[this.length];

        for (int i = binaryNumber1.Length-1; i>=0 ; i--)
        {
            int sum = binaryNumber1[i] + binaryNumber2[i];
            res[i] = sum;
        }
        return res;

    }
    public int[] Add(int[] binaryNumber1, int[] binaryNumber2)
    {
        
        int[] result = new int [this.length];

        int carry = 0;
        for (int i = binaryNumber1.Length-1; i >= 0; i--)
        {
            int sum = binaryNumber1[i] + binaryNumber2[i] + carry;

            if ( sum == 1)
            {
            result[i] = sum;
            carry = 0;
        }
            else if(sum == 0)
            {
                result[i] = 0;
                carry = 0;
            }
            else if (sum == 2 )
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
        if (carry == 1)
        {
            int[] newR= new int[result.Length + 1];
            newR[0] = 1;
            Array.Copy(result, 0, newR, 1, result.Length);
            result = newR;
        }
        return result;
        
       
    }

    public int[] Deduct(int[] binaryNumber1, int[] binaryNumber2)
    {
        int[] res = new int[this.length];
        for (int i = binaryNumber1.Length-1; i >= 0; i--)
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

      
        Console.WriteLine("Binary number 1: {0}", string.Join("", binaryNumber1));
        Console.WriteLine("Binary number 2: {0}", string.Join("", binaryNumber2));
       

        tape.StoreValue(binaryNumber1);
        tape.StoreValue(binaryNumber2);
        int[] res1 = tape.Add(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the addition with remainder is: {0}", string.Join("", res1));
        int[] res2 = tape.JustAdd(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the simple addition is: {0}", string.Join("", res2));
        int[] res3 = tape.Deduct(binaryNumber1, binaryNumber2);
        Console.WriteLine("The result of the deduction is: {0}", string.Join("", res3));

        tape.Length = 10;
        Console.WriteLine("Length of new tape: {0}", tape.Length);

        int count = Tape.Count;
        Console.WriteLine("Amount of created tapes: {0}", count);
    }
}

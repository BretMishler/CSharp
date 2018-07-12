using System;

namespace RandomStuff
{
    public class ExceptionHandling
    {
        public static void Program()
        {
            try
            {
                System.Console.WriteLine(Arthimetic(4, 2));
            }
            catch(NumDenoEqualException nEx)
            {
                Console.WriteLine(1);
            }
            catch (DivideByZeroException dEx)
            {
                Console.WriteLine("Divide by zero not possible.");
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine("Cannot divide by zero");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Thanks for using the divide calculator!");
            }

            Test(null);
        }

        public static void Test(string y)
        {
            try
            {
                y += "z";
            }
            catch
            {
                throw;
            }
        }

        // EXCEPTION PROPAGATES
        // Main Caller
        // ^
        // Arithmetic
        // ^
        // Divide

        private static int Arthimetic(int num1, int num2)
        {
            try
            {
                int value = Divide(num1, num2);
                return value;  
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static int Divide(int num1, int num2)
        {
            if (num1 == num2)
            {
                throw new NumDenoEqualException("Num and Den are the same.");
            }
            if (num1 < 0 || num2 < 0)
            {
                throw new Exception("Negative numbers not allowed.");
            }
            int num3 = (num1 / num2);
            return num3;
        }
        public class NumDenoEqualException : Exception
        {
            public NumDenoEqualException(string message) : base(message)
            {
                
            }
        }
    }
}
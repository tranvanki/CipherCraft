using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CipherCraft
{
    class StringProcessing
    {
        //properties
        private string inputString { get; set; }
        private int inputNumber { get; set; }
        public StringProcessing(string inputString, int inputNumber)
        {
            //phân biệt giữa thuộc tính của lớp vs  các tham số được truyền vào phương thức
            this.inputString = inputString;
            this.inputNumber = inputNumber;
        }
        public string Encode(string inputString, int inputNumber)
        {
            string result = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                char C = (char)(inputString[i] + inputNumber);
                if (C > 'Z')
                {

                    C = (char)(C - 26);
                }
                if(C <'A')
                {
                    C = (char)(C + 26);
                }
                result += C;
            }
            return result;
        }
        //method is only used within the class itself
        private int[] InputCode(string inputString)
        {
            int[] asciiValues = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                asciiValues[i] = (int)inputString[i];
            }
            return asciiValues;
        }
        //r ASCII values of output string.
        private int[] OutputCode()
        {
            string encodedString = Encode(inputString, inputNumber);
            int[] outputArray = new int[encodedString.Length];
            for (int i =0; i < encodedString.Length; i++)
            {
                outputArray[i] = (int)encodedString[i];
            }
            return  outputArray;
        }
        // Method to sort the input string
        private string Sort(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }
        public string Print()
        {
            string encodedString = Encode(inputString, inputNumber);
            string sortedString = Sort(inputString); // Assuming Sort() returns a string
            int[] inputCodeArray = InputCode(inputString); 
            int[] outputCodeArray = OutputCode();
            return $"Encoded String: {encodedString}\n" +
                   $"Sorted String: {sortedString}\n" +
                   $"Input ASCII Codes: {string.Join(", ", inputCodeArray)}\n" +
                   $"Output ASCII Codes: {string.Join(", ", outputCodeArray)}";

        }
     

        // Method to validate inputs
        public void ValidateInputs(string inputString, int inputNumber)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentException("Input string cannot be empty.");
            }
            if (inputString.Any(c => !char.IsUpper(c)))
            {
                throw new ArgumentException("Only uppercase letters (A-Z) are allowed.");
            }
            if (inputString.Length > 40)
            {
                throw new ArgumentException("Input string must be less than or equal to 40 characters.");
            }
            if (inputNumber < -25 || inputNumber > 25)
            {
                throw new ArgumentException("Input number must be between -25 and 25.");
            }
        

    }
}
    }

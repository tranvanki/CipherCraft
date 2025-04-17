using System;
using System.Text;

namespace CipherCraft
{
    // Abstract class for string processing
    abstract class AbstractStringProcessing
    {
        public abstract int[] InputCode();
        public abstract int[] OutputCode();
        public abstract string Encode();
        public abstract string Sort();
    }

    // Enum for encryption types
    enum EncryptionType
    {
        CaesarCipher,
        Base64
        // RSA can be added later
    }

    class StringProcessing : AbstractStringProcessing
    {
        private string inputString { get; set; }
        private int inputNumber { get; set; }
        private EncryptionType encryptionType { get; set; }

        public StringProcessing(string inputString, int inputNumber, EncryptionType encryptionType)
        {
            ValidateInputs(inputString, inputNumber);
            this.inputString = inputString;
            this.inputNumber = inputNumber;
            this.encryptionType = encryptionType;
        }

        public override string Encode()
        {
            if (encryptionType == EncryptionType.CaesarCipher)
            {
                // Perform Caesar Cipher encoding
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < inputString.Length; i++)
                {
                    char C = (char)(inputString[i] + inputNumber);
                    if (C > 'Z') C = (char)(C - 26);
                    if (C < 'A') C = (char)(C + 26);
                    result.Append(C);
                }
                return result.ToString();
            }
            else if (encryptionType == EncryptionType.Base64)
            {
                // Perform Base64 encoding
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                return Convert.ToBase64String(bytes);
            }

            return string.Empty; // Placeholder for other encryption methods
        }

        public override int[] InputCode()
        {
            int[] asciiValues = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                asciiValues[i] = (int)inputString[i];
            }
            return asciiValues;
        }

        public override int[] OutputCode()
        {
            string encodedString = Encode();
            int[] asciiValues = new int[encodedString.Length];
            for (int i = 0; i < encodedString.Length; i++)
            {
                asciiValues[i] = (int)encodedString[i];
            }
            return asciiValues;
        }

        public override string Sort()
        {
            char[] charArray = inputString.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        public string Print()
        {
            string encodedString = Encode();
            string sortedString = Sort(); 
            int[] inputCodeArray = InputCode();
            int[] outputCodeArray = OutputCode();
            return $"Encoded String: {encodedString}\n" +
                   $"Sorted String: {sortedString}\n" +
                   $"Input ASCII Codes: {string.Join(", ", inputCodeArray)}\n" +
                   $"Output ASCII Codes: {string.Join(", ", outputCodeArray)}";
        }

        // Validate inputs
        private void ValidateInputs(string inputString, int inputNumber)
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string (max 40 uppercase letters): ");
            string inputString = Console.ReadLine();

            Console.Write("Enter shift value (-25 to 25, ignored for Base64): ");
            int inputNumber = ReadValidInteger();

            Console.WriteLine("Choose encryption type: 1 for Caesar Cipher, 2 for Base64");
            int choice = int.Parse(Console.ReadLine());
            EncryptionType encryptionType = choice == 1 ? EncryptionType.CaesarCipher : EncryptionType.Base64;

            StringProcessing processor = new StringProcessing(inputString, inputNumber, encryptionType);

            Console.WriteLine("\n--- OUTPUT ---");
            Console.WriteLine(processor.Print());
        }

        // Get a valid integer input
        public static int ReadValidInteger()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < -25 || result > 25)
            {
                Console.WriteLine("Invalid input! Please enter an integer in the range [-25, 25].");
            }
            return result;
        }
    }
}

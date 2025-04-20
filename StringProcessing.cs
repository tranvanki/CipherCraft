using System;
using System.Text;

namespace CipherCraft
{
    abstract class AbstractStringProcessing
    {
        public abstract int[] InputCode();
        public abstract int[] OutputCode();
        public abstract string Encode();
        public abstract string Sort();
    }

    enum encodingType
    {
        Caesar,
        Base64,
        
    }

    class StringProcessing : AbstractStringProcessing
    {
        private string inputString;
        private int inputNumber;
        private encodingType type;

        public StringProcessing(string inputString, int inputNumber, 
            encodingType type = encodingType.Caesar)
        {
            ValidateInputs(inputString, inputNumber, type);
            this.inputString = inputString;
            this.inputNumber = inputNumber;
            this.type = type;
        }
        //public StringProcessing(string inputString, int inputNumber,
        //encodingType type = encodingType.Caesar)
        public override string Encode()
        {
            switch (type)
            {
                case encodingType.Caesar:
                    return CaesarEncoder();
                case encodingType.Base64:
                    return Base64Encoder();
                default:
                    throw new InvalidOperationException("Unknown encoding type.");
            }
        }

        private string CaesarEncoder()
        {
            char[] charArray = inputString.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];
                if (c >= 'A' && c <= 'Z')
                {
                    char shifted = (char)(c + inputNumber);
                    if (shifted > 'Z') shifted = (char)(shifted - 26);
                    if (shifted < 'A') shifted = (char)(shifted + 26);
                    charArray[i] = shifted;
                }
            }
            return new string(charArray);
        }


        private string Base64Encoder()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            return Convert.ToBase64String(bytes);
        }

        

        public override int[] InputCode()
        {
            int[] codes = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                codes[i] = (int)inputString[i];
            }
            return codes;
        }

        public override int[] OutputCode()
        {
            string encoded = Encode();
            int[] codes = new int[encoded.Length];
            for (int i = 0; i < encoded.Length; i++)
            {
                codes[i] = (int)encoded[i];
            }
            return codes;
        }

        public override string Sort()
        {
            char[] chars = inputString.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        public string Print()
        {
            string encoded = Encode();
            string sorted = Sort();
            int[] inputCodes = InputCode();
            int[] outputCodes = OutputCode();
            //instance của StringBuilder là mutable (có khả năng thay đổi),
            //sau khi tạo chúng ta có thể tạo ra bất cứ thao tác nào thay đổi
            //nó ở trong memory như mở rộng, xóa… mà chỉ tạo duy nhất một instance.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Encoding Method: " + type);
            sb.AppendLine("Input String: " + inputString);
            sb.AppendLine("Encoded String: " + encoded);
            sb.AppendLine("Sorted String: " + sorted);
            sb.Append("Input ASCII Codes: ");
            for (int i = 0; i < inputCodes.Length; i++)
            {
                sb.Append(inputCodes[i]);
                if (i < inputCodes.Length - 1) sb.Append(", ");
            }
            sb.AppendLine();
            sb.Append("Output ASCII Codes: ");
            for (int i = 0; i < outputCodes.Length; i++)
            {
                sb.Append(outputCodes[i]);
                if (i < outputCodes.Length - 1) sb.Append(", ");
            }
            return sb.ToString();
        }

        public void ValidateInputs(string inputString, int inputNumber, encodingType type)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new ArgumentException("Input string cannot be empty.");

            if (type == encodingType.Caesar)
            {
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (inputString[i] < 'A' || inputString[i] > 'Z')
                        throw new ArgumentException("Only uppercase letters (A-Z) are allowed " +
                            "for Caesar.");
                }

                if (inputNumber < -25 || inputNumber > 25)
                    throw new ArgumentException("Caesar shift must be between -25 and 25.");
            }

            if (inputString.Length > 40)
                throw new ArgumentException("Input string must be 40 characters or fewer.");
        }
    }
}

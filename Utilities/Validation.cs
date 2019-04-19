using System;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Validation
    {
        public bool isValidCC(string cardNumber)
        {
            if (cardNumber.Length == 16)
            {
                foreach(char c in cardNumber)
                {
                    if (c < '0' || c > '9')
                        return false;     
                }
                return true;
            }
            return false;
        }

        //return true if a string is blank
        public bool isBlank(string s)
        {
            if (s == "")
                return true;
            return false;
        }

        public bool isValidNumber(char c)
        {
            int i;
            if (int.TryParse(c.ToString(), out i))
                return true;
            return false;
        }

        public bool isValidNumber(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return true;
            return false;
        }

        public bool isValidNumberOverZero(string s)
        {
            if (isValidNumber(s))
            {
                if (int.Parse(s) > 0)
                    return true;
            }
            return false;
        }

        public bool isValidDouble(string s)
        {
            double num;
            if (double.TryParse(s, out num))
            {
                if (double.Parse(s) >= 0)
                    return true;
            }
            return false;
        }

        public bool isValidDoubleOverZero(string s)
        {
            if (isValidDouble(s))
            {
                if (double.Parse(s) > 0)
                    return true;
            }
            return false;
        }

        public bool hasWhiteSpace(string s)
        {
            return s.Any(char.IsWhiteSpace);
        }

        public bool hasLettersorWhiteSpaceOnly(string s)
        {
            return s.All(x => char.IsLetter(x) || x == ' ');
        }

        public bool hasLettersOnly(string s)
        {
            return s.All(x => char.IsLetter(x));
        }

        public bool hasEmailTraits(string s)
        {
            return s.All(x => char.IsLetter(x) || x == ' ' || x == '@' || x == '.') || s.All(char.IsDigit);
        }

        public string APIKeyGen(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
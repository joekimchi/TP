﻿using System.Linq;

namespace Utilities
{
    public class Validation
    {
        //return true if a string is blank
        public bool isBlank(string s)
        {
            if (s == "")
                return true;
            return false;
        }

        //return true if string is a number
        public bool isNum(string s)
        {
            return s.All(char.IsDigit);
        }

        public bool isValidNumber(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return true;
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

        public bool isValidNumOverZero(string s)
        {
            if (isValidNumber(s))
            {
                if (int.Parse(s) > 0)
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

        public bool isValidAge(string s)
        {
            if (isValidDouble(s))
            {
                if (double.Parse(s) <= 122.0)
                    return true;
            }
            return false;
        }

        public bool isValidPct(string s)
        {
            if (isValidDouble(s))
            {
                if (double.Parse(s) <= 100)
                    return true;
            }
            return false;
        }
    }
}
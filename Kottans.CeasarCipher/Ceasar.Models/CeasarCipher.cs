using System;
using System.Linq;

namespace Ceasar.Models
{
    public class CeasarCipher
    {
        private readonly int _offset;
        private readonly char _startSymbol;
        private const char SpaceSymbol = ' ';
        private readonly char _endSymbol;
        private readonly int _alphabetLength;

        public CeasarCipher(int offset)
        {
            _offset = offset;
            _startSymbol = (char)33;
            _endSymbol = (char)126;
            _alphabetLength = _endSymbol - _startSymbol;
        }

        private void ValidateInput(string input, out char[] validated)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Hey dude, " + nameof(input) + " cannot be null.");
            validated = input.ToCharArray();

            if (validated.Any(t => (t > _endSymbol || t < _startSymbol) && !t.Equals(SpaceSymbol)))
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Your input has some invalid symbols.");
            }
        }
        
        public string Encrypt(string text)
        {
            return RunCipherMechanism(EncryptCharWithOffset, text);
        }

        public string Decrypt(string ciphertext)
        {
            return RunCipherMechanism(DecryptCharWithOffset, ciphertext);
        }

        private string RunCipherMechanism(Func<char, char> mechanism, string text)
        {
            char[] workingSet;
            ValidateInput(text, out workingSet);

            if (_offset == 0) return text;

            for (var i = 0; i < workingSet.Length; i++)
            {
                if (workingSet[i] != SpaceSymbol) workingSet[i] = mechanism(workingSet[i]);
            }

            return new string(workingSet);
        }

        private char EncryptCharWithOffset(char inputChar)
        {
            var delta = _offset % _alphabetLength;
            var overflow = inputChar + delta > _endSymbol;
            if (!overflow) return (char) (inputChar + delta);

            var leftToEnd = _endSymbol - inputChar;
            delta = leftToEnd == 0 ? delta : delta % leftToEnd;
            return (char)(_startSymbol + delta - 1);
        }

        private char DecryptCharWithOffset(char inputChar)
        {
            var delta = _offset % _alphabetLength;
            var overflow = inputChar - delta < _startSymbol;
            if (!overflow) return (char) (inputChar - delta);

            var leftToStart = inputChar - _startSymbol;
            delta = leftToStart == 0 ? delta : delta % leftToStart;
            return (char)(_endSymbol - delta + 1);
        }
    }
}

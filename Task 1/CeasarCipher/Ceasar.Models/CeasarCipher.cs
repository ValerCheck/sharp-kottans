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
        private char[] _workingSet;

        public CeasarCipher(int offset)
        {
            _offset = offset;
            _startSymbol = (char)33;
            _endSymbol = (char)126;
            _alphabetLength = _endSymbol - _startSymbol;
        }

        private void ValidateInput(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Hey dude, " + nameof(input) + " cannot be null.");
            _workingSet = input.ToCharArray();

            if (_workingSet.Any(t => (t > _endSymbol || t < _startSymbol) && !t.Equals(SpaceSymbol)))
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Your input has some invalid symbols.");
            }
        }
        
        public string Encrypt(string text)
        {
            ValidateInput(text);

            if (_offset == 0) return text;

            for (var i = 0; i < _workingSet.Length; i++)
            {
                if (_workingSet[i] != SpaceSymbol)
                    _workingSet[i] = EncryptCharWithOffset(_workingSet[i]);
            }

            return _workingSet.Aggregate("", (current, sym) => current + sym);
        }

        public string Decrypt(string ciphertext)
        {
            ValidateInput(ciphertext);

            if (_offset == 0) return ciphertext;

            for (var i = 0; i < _workingSet.Length; i++)
            {
                if (_workingSet[i] != SpaceSymbol)
                    _workingSet[i] = DecryptCharWithOffset(_workingSet[i]);
            }

            return _workingSet.Aggregate("", (current, sym) => current + sym);
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

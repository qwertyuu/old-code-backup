using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;

namespace SimpleCSConsole
{
    class Picker<T>
    {
        Random _random;
        IList<T> _pool;

        public IEnumerable<T> Pool
        {
            get
            {
                foreach (T item in _pool)
                    yield return item;
            }
        }

        public Picker(Random random, IEnumerable<T> collection)
        {
            _random = random;
            _pool = new List<T>(collection);
        }

        public T Pick()
        {
            return _pool[_random.Next(_pool.Count)];
        }
    }

    class ScoreBoard<T>
    {
        IList<T> _pool;

        public ScoreBoard(IEnumerable<T> collection)
        {
            _pool = new List<T>(collection);
        }

        public bool IsAllCrossedOff
        {
            get { return _pool.Count == 0; }
        }

        public void CrossOff(T value)
        {
            if (_pool.Contains(value))
                _pool.Remove(value);
        }
    }

    class Program
    {
        Picker<char> _lowerCase;
        Picker<char> _upperCase;
        Picker<char> _digits;
        Picker<char> _symbols;
        Picker<Picker<char>> _charClasses;
        ScoreBoard<char> _bingoBoard;

        Program()
        {
            Random random = new Random();

            _lowerCase = new Picker<char>(random, GetCharsFromRange('a', 'z'));
            _upperCase = new Picker<char>(random, GetCharsFromRange('A', 'Z'));
            _digits = new Picker<char>(random, GetCharsFromRange('0', '9'));
            _symbols = new Picker<char>(random, GetSymbols());

            _charClasses = new Picker<Picker<char>>(random, new Picker<char>[] { _lowerCase, _upperCase, _digits, _symbols });

            _bingoBoard = BuildBingoBoardFromCharClasses(_charClasses);
        }

        IEnumerable<char> GetCharsFromRange(char lower, char upper)
        {
            for(char c = lower; c <= upper; c++)
                yield return c;
        }

        IEnumerable<char> GetSymbols()
        {
            var symbols = new char [] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

            foreach(char c in symbols)
                yield return c;
        }

        ScoreBoard<char> BuildBingoBoardFromCharClasses(Picker<Picker<char>> charClasses)
        {
            IEnumerable<char> allSymbols = null;

            foreach (var charPicker in charClasses.Pool)
            {
                if (allSymbols == null)
                    allSymbols = charPicker.Pool;
                else
                    allSymbols = allSymbols.Concat(charPicker.Pool);
            }

            return new ScoreBoard<char>(allSymbols);
        }

        string CreatePassword(int length)
        {
            string password = "";

            for (int i = 0; i < length; i++)
                password += _charClasses.Pick().Pick();
            return password;
        }

        void Run(int length)
        {
            int iter = 0;

            while (!_bingoBoard.IsAllCrossedOff)
            {
                ++iter;
                string password = CreatePassword(length);

                foreach (char c in password)
                    _bingoBoard.CrossOff(c);

                Console.WriteLine("{0}: {1}", iter, password);
            }
        }

        static void Main()
        {
            new Program().Run(10);
            Console.ReadLine();
        }
    }
}


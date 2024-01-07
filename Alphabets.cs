using System;
using System.Collections.ObjectModel;

namespace ROT1_Converter
{
    public enum Alphabets
    {
        None,
        English,
        Spanish,
        Russian,
        Max,
    }

    public static class AlphabetData
    {
        public static Alphabets GetAlphabet(string obj)
        {
            if (uint.TryParse(obj, out uint ui))
            {
                while (ui >= (uint)Alphabets.Max)
                    ui -= (uint)Alphabets.Max - 1;
                return (Alphabets)ui;
            }
            else
            {
                if (Enum.TryParse(obj, true, out Alphabets res))
                    return res;
            }

            return Alphabets.None;
        }

        public static ReadOnlyCollection<char> GetAlphabetSymbols(Alphabets alphabet)
        {
            switch (alphabet)
            {
                case Alphabets.English: return English;
                case Alphabets.Spanish: return Spanish;
                case Alphabets.Russian: return Russian;
            }
            return null;
        }



        /*
        public static readonly ReadOnlyCollection<char> AlphabetName = new ReadOnlyCollection<char>(new char[]
           {
           }); 
        */

        public static readonly ReadOnlyCollection<char> Spanish = new ReadOnlyCollection<char>(new char[]
        {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        });

        public static readonly ReadOnlyCollection<char> Russian = new ReadOnlyCollection<char>(new char[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            });

        public static readonly ReadOnlyCollection<char> English = new ReadOnlyCollection<char>(new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j','k', 'l', 'm', 'n', 'o', 'p', 'q','r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            });
    }
}

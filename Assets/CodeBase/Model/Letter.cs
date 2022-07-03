using System;

namespace Assets.CodeBase.Model
{
    public class Letter
    {
        private static readonly string _symbols = "abcdefghijklmnopqrstuvwxyz";

        private Letter(string litera)
        {
            Litera = litera;
        }

        public string Litera { get; }

        internal static Letter GetRandom(Random _random)
        {
            int index = _random.Next(_symbols.Length);
            return new Letter(_symbols[index].ToString());
        }
    }
}
using Assets.CodeBase.Data;
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
        public Vector3Data Position { get; set; }
        
        internal static Letter GetRandom(Random _random)
        {
            int index = _random.Next(_symbols.Length);
            return new Letter(_symbols[index].ToString());
        }
    }
}
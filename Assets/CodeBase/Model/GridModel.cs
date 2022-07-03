using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Model
{
    public class GridModel
    {
        private readonly List<Letter> _letters;
        private readonly Random _random;

        public GridModel()
        {
            _letters = new List<Letter>();
            _random = new Random();
        }

        public event Action<IReadOnlyList<Letter>> Changed;

        internal void Mix()
        {
            Letter temp;
            int count = _letters.Count;
            for (int i = 0; i < count - 1; i++)
            {
                int index = _random.Next(i + 1, count);
                temp = _letters[index];
                _letters[index] = _letters[i];
                _letters[i] = temp;
            }

            Changed?.Invoke(_letters);
        }

        internal void Generate(int width, int height)
        {
            _letters.Clear();

            int count = width * height;
            for (int i = 0; i < count; i++)
                _letters.Add(Letter.GetRandom(_random));

            Changed?.Invoke(_letters);
        }
    }
}
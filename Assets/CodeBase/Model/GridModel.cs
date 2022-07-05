using Assets.CodeBase.Data;
using Assets.CodeBase.Model.MixingStrategy;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Model
{
    public class GridModel : IGridModel
    {
        private readonly List<Letter> _letters;
        private readonly Random _random;
        private int _width;
        private int _height;
        private readonly IMixStrategy _mixer;

        public GridModel(IMixStrategy mixStrategy)
        {
            _mixer = mixStrategy;

            _letters = new List<Letter>();
            _random = new Random();
        }

        public event Action<IReadOnlyList<ILetter>, int, int, Action<Vector3Data[]>> Generated;
        public event Action Mixed;

        public void Mix()
        {
            _mixer.Mix(randomizer: _random, collection: _letters);

            Mixed?.Invoke();
        }

        public void Generate(int width, int height)
        {
            _letters.Clear();
            _width = width;
            _height = height;

            int count = width * height;
            for (int i = 0; i < count; i++)
                _letters.Add(Letter.GetRandom(_random));

            Generated?.Invoke(_letters, _width, _height, SetPositions);
        }

        private void SetPositions(Vector3Data[] datasPos)
        {
            for (int i = 0; i < _letters.Count; i++)
                _letters[i].Position = datasPos[i];
        }
    }
}
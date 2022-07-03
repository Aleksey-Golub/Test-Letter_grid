using Assets.CodeBase.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.View
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private PositiveIntInputField _width;
        [SerializeField] private PositiveIntInputField _height;
        [SerializeField] private Button _generateButton;
        [SerializeField] private Button _mixButton;

        public event Action<int, int> NeedGenerate;
        public event Action NeedMix;

        private void OnEnable()
        {
            _generateButton.onClick.AddListener(() => NeedGenerate?.Invoke(_width.Value, _height.Value));
            _mixButton.onClick.AddListener(() => NeedMix?.Invoke());
        }

        internal void Show(IReadOnlyList<Letter> letters)
        {
            Debug.Log(letters.Count);

            foreach (var letter in letters)
            {
                Debug.Log(letter.Litera);
            }
        }
    }
}
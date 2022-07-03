using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.View
{
    public class GridView : MonoBehaviour, IGridView
    {
        [SerializeField] private PositiveIntInputField _width;
        [SerializeField] private PositiveIntInputField _height;
        [SerializeField] private Button _generateButton;
        [SerializeField] private Button _mixButton;
        [SerializeField] private LettersContainer _container;

        private IUIFactory _factory;
        private List<LetterView> _lettersView;

        public event Action<int, int> NeedGenerate;
        public event Action NeedMix;

        public void Construct(IUIFactory factory)
        {
            _factory = factory;
            _lettersView = new List<LetterView>();

            _generateButton.onClick.AddListener(() => NeedGenerate?.Invoke(_width.Value, _height.Value));
            _mixButton.onClick.AddListener(() => NeedMix?.Invoke());
        }

        public void Show(IReadOnlyList<Letter> letters, int width, int height)
        {
            // взять нужное количество LetterView
            // расставить их сеткой Width х Height
            // отступы зависят от: ширина контейнера/высота, размер

            HideAll();

            float xSize = _container.RectTransform.sizeDelta.x / width;
            float ySize = _container.RectTransform.sizeDelta.y / height;
            float size = Mathf.Min(xSize, ySize);
            _container.GridLayoutGroup.cellSize = new Vector2(size, size);
            _container.GridLayoutGroup.enabled = true;

            foreach (var letter in letters)
            {
                LetterView newLetterView = _factory.GetLetter(at: _container.RectTransform, symbol: letter.Litera, textSize: size);
                _lettersView.Add(newLetterView);
            }

            //_container.GridLayoutGroup.enabled = false;
        }

        private void HideAll()
        {
            foreach (var view in _lettersView)
                _factory.Recycle(view);

            _lettersView.Clear();
        }
    }
}
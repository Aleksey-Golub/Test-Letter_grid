using Assets.CodeBase.Services;
using Assets.CodeBase.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.CodeBase.Data;

namespace Assets.CodeBase.View
{
    public class GridView : MonoBehaviour, IGridView
    {
        [SerializeField] private PositiveIntInputField _width;
        [SerializeField] private PositiveIntInputField _height;
        [SerializeField] private Button _generateButton;
        [SerializeField] private Button _mixButton;
        [SerializeField] private LettersContainer _container;
        [SerializeField, Min(0f)] private float _durationOfMixAnimation = 2f;

        private IUIFactory _factory;
        private List<LetterView> _lettersView;

        public event Action<int, int> NeedGenerate;
        public event Action NeedMix;

        public bool Interactable { get; private set; } = true;

        public void Construct(IUIFactory factory)
        {
            _factory = factory;
            _lettersView = new List<LetterView>();
            _container.Construct();

            _generateButton.onClick.AddListener(() => NeedGenerate?.Invoke(_width.Value, _height.Value));
            _mixButton.onClick.AddListener(() => NeedMix?.Invoke());
        }

        public void ShowMix()
        {
            StartCoroutine(ShowMixRoutine());
        }

        public void ShowGenerated(IReadOnlyList<Letter> letters, int width, int height)
        {
            StartCoroutine(ShowGeneratedRoutine(letters, width, height));
        }

        private IEnumerator ShowMixRoutine()
        {
            Interactable = false;

            float timer = 0;

            foreach (var view in _lettersView)
                view.RememberStartPosition();

            while (timer < _durationOfMixAnimation)
            {
                timer += Time.deltaTime;
                if (timer >= _durationOfMixAnimation)
                    timer = _durationOfMixAnimation;

                float t = timer / _durationOfMixAnimation;

                foreach (var view in _lettersView)
                    view.MoveToNewPosition(t);

                yield return null;
            }

            Interactable = true;
        }

        private IEnumerator ShowGeneratedRoutine(IReadOnlyList<Letter> letters, int width, int height)
        {
            Interactable = false;

            HideAll();
            _container.SetLayout(true);
            _container.RectTransform.sizeDelta = _container.DefaultSize;

            float size = CalculateElementSize(width, height);

            _container.RectTransform.sizeDelta = new Vector2(size * width, _container.RectTransform.sizeDelta.y);
            _container.GridLayoutGroup.cellSize = new Vector2(size, size);
            
            GenerateViews(letters, size);

            yield return null;

            _container.SetLayout(false);

            yield return null;
            CalculateAndSavePosition(letters);

            Interactable = true;
        }

        private void GenerateViews(IReadOnlyList<Letter> letters, float size)
        {
            for (int i = 0; i < letters.Count; i++)
            {
                LetterView newLetterView = _factory.GetLetter(at: _container.RectTransform, model: letters[i], textSize: size);
                _lettersView.Add(newLetterView);
            }
        }

        private float CalculateElementSize(int width, int height)
        {
            float xSize = _container.RectTransform.sizeDelta.x / width;
            float ySize = _container.RectTransform.sizeDelta.y / height;
            float size = Mathf.Min(xSize, ySize);
            return size;
        }

        private void CalculateAndSavePosition(IReadOnlyList<Letter> letters)
        {
            for (int i = 0; i < _lettersView.Count; i++)
            {
                Vector3 pos = _lettersView[i].RectTransform.localPosition;
                _lettersView[i].RectTransform.SetAnchors(at: 0.5f);
                _lettersView[i].RectTransform.localPosition = pos;

                letters[i].Position = _lettersView[i].RectTransform.localPosition.AsVectorData();
            }
        }

        private void HideAll()
        {
            foreach (var view in _lettersView)
                _factory.Recycle(view);

            _lettersView.Clear();
        }
    }
}
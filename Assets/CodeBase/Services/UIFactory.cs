using Assets.CodeBase.Model;
using Assets.CodeBase.View;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    [CreateAssetMenu]
    public class UIFactory : ScriptableObject, IUIFactory
    {
        [SerializeField] private LetterView _prefab;

        private readonly Stack<LetterView> _pool = new Stack<LetterView>();

        public LetterView GetLetter(RectTransform at, ILetter model, float textSize)
        {
            LetterView newLetterView;
            if (_pool.Count > 0)
                newLetterView = _pool.Pop();
            else
                newLetterView = Instantiate(_prefab);
            
            newLetterView.gameObject.SetActive(true);
            newLetterView.transform.SetParent(at, false);

            newLetterView.Construct(model, textSize);

            return newLetterView;
        }

        public void Recycle(LetterView view)
        {
            view.transform.SetParent(null, false);
            view.gameObject.SetActive(false);

            _pool.Push(view);
        }
    }
}
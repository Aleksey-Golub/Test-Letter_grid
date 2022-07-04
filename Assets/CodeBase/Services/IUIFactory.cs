using Assets.CodeBase.Model;
using Assets.CodeBase.View;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public interface IUIFactory
    {
        void Recycle(LetterView view);
        LetterView GetLetter(RectTransform at, Letter model, float textSize);
    }
}
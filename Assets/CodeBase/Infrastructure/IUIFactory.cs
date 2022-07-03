using Assets.CodeBase.View;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public interface IUIFactory
    {
        void Recycle(LetterView view);
        LetterView GetLetter(RectTransform at, string symbol, float textSize);
    }
}
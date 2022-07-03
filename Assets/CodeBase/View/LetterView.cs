using TMPro;
using UnityEngine;

namespace Assets.CodeBase.View
{
    public class LetterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Construct(string symbol, float textSize)
        {
            _text.text = symbol;
            _text.fontSize = textSize;
        }
    }
}
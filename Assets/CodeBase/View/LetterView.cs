using Assets.CodeBase.Data;
using Assets.CodeBase.Model;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.View
{
    public class LetterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private ILetter _model;
        private Vector3 _startPosition;

        [field: SerializeField] public RectTransform RectTransform { get; private set; }

        public void Construct(ILetter model, float textSize)
        {
            _model = model;
            _text.text = _model.Litera;
            _text.fontSize = textSize;
        }

        internal void RememberStartPosition()
        {
            _startPosition = RectTransform.localPosition;
        }

        internal void MoveToNewPosition(float t)
        {
            RectTransform.localPosition = Vector3.Lerp(_startPosition, _model.Position.AsUnityVector(), t);
        }
    }
}
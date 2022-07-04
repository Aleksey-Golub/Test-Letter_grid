using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.View
{
    public class LettersContainer : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public GridLayoutGroup GridLayoutGroup { get; private set; }

        public Vector2 DefaultSize { get; private set; }

        public void Construct()
        {
            DefaultSize = RectTransform.sizeDelta;
        }

        public void SetLayout(bool value)
        {
            GridLayoutGroup.enabled = value;
        }
    }
}
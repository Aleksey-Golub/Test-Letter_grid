using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.View
{
    public class LettersContainer : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public GridLayoutGroup GridLayoutGroup { get; private set; }
    }
}
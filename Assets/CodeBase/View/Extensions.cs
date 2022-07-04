using UnityEngine;

namespace Assets.CodeBase.View
{
    public static class Extensions
    {
        public static void SetAnchors(this RectTransform rectTransform, float at)
        {
            rectTransform.anchorMin = new Vector2(at, at);
            rectTransform.anchorMax = new Vector2(at, at);
        }
    }
}

using UnityEngine;
using TMPro;

namespace Assets.CodeBase.View
{
    internal class PositiveIntInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        public int Value { get; private set; }

        private void OnEnable() =>
            _inputField.onEndEdit.AddListener(ValidateInput);

        private void OnDisable() =>
            _inputField.onEndEdit.RemoveListener(ValidateInput);

        private void ValidateInput(string input)
        {
            if (int.TryParse(input, out int result))
            {
                if (result > 0)
                {
                    Value = result;
                    return;
                }
            }

            _inputField.text = "1";
            Value = 1;
        }
    }
}
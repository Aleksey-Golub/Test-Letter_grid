using Assets.CodeBase.Data;
using Assets.CodeBase.Model;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.View
{
    public interface IGridView
    {
        bool Interactable { get; }

        event Action<int, int> NeedGenerate;
        event Action NeedMix;

        void Construct(IUIFactory factory);
        void ShowGenerated(IReadOnlyList<ILetter> letters, int width, int height, Action<Vector3Data[]> callback);
        void ShowMix();
    }
}
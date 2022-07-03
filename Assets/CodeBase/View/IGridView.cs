using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Model;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.View
{
    public interface IGridView
    {
        event Action<int, int> NeedGenerate;
        event Action NeedMix;

        void Construct(IUIFactory factory);
        void Show(IReadOnlyList<Letter> letters, int width, int height);
    }
}
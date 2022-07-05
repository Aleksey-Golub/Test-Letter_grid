using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Model
{
    public interface IGridModel
    {
        event Action<IReadOnlyList<ILetter>, int, int, Action<Vector3Data[]>> Generated;
        event Action Mixed;

        void Generate(int width, int height);
        void Mix();
    }
}
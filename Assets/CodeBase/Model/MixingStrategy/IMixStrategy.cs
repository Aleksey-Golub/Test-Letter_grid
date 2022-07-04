using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Model.MixingStrategy
{
    public interface IMixStrategy
    {
        void Mix(Random randomizer, List<Letter> collection);
    }
}
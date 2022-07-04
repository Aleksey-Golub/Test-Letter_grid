using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Model.MixingStrategy
{
    public class MixStrategy : IMixStrategy
    {
        public void Mix(Random randomizer, List<Letter> collection)
        {
            Letter temp;
            int count = collection.Count;

            for (int i = 0; i < count; i++)
            {
                int index = randomizer.Next(count);
                temp = collection[i];
                Vector3Data tempPosI = collection[i].Position;
                Vector3Data tempPosIndex = collection[index].Position;

                collection[i] = collection[index];
                collection[i].Position = tempPosI;

                collection[index] = temp;
                collection[index].Position = tempPosIndex;
            }
        }
    }
}
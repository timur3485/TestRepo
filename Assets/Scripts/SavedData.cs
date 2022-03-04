using UnityEngine;

namespace Geekbrains
{
    public sealed class SavedData<TParameter>
    {
        public int Bonuses;
        public TParameter Id;

    }

    public class Base<T>
    {
        public T Field;
    }
}
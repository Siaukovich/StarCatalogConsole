using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarCatalog
{
    public class MyCollection<T> : IList<T>
    {
        #region Private Fields

        private int _count;
        private T[] _items;

        #endregion

        #region Public Propereties

        public int Count => _count;
        public bool IsReadOnly => false;

        #endregion

        #region Constructor and Indexator

        public MyCollection(int capacity = 10)
        {
            _count = 0;
            _items = new T[capacity];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || _count <= index)
                throw new ArgumentOutOfRangeException(nameof(index));

            Remove(_items[index]);
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                    return _items[index];

                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (index >= 0 && index < _count)
                    _items[index] = value;

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        #endregion

        #region Implementations of Interfaces

        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Array.IndexOf(_items, item);
        }

        public void Insert(int index, T item)
        {
            if (_items.Length == _count)
                Array.Resize(ref _items, _items.Length * 2);

            for (var i = index; i < _count; i++)
            {
                _items[i + 1] = _items[i];
            }

            _items[index] = item;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);

            if (this.Contains(item))
                return;

            _items[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
            const int capacity = 10;
            _items = new T[capacity];
        }

        public bool Contains(T item) =>
            _items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "array is null.");

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "arrayIndex must be positive.");

            if (_count > array.Length - arrayIndex + 1)
                throw new ArgumentException("Array have fewer elements than the collection.");

            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            var numIndex = Array.IndexOf(_items, item);
            if (numIndex == -1)
                return false;

            for (var i = numIndex; i < _count - 1; ++i)
                _items[i] = _items[i + 1];

            // newSize = oldSize - 1
            _count--;

            return true;
        }

        public IEnumerator<T> GetEnumerator() => new CollectionEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new CollectionEnumerator(this);

        #endregion

        #region Custom Methods

        /// <summary>
        /// Creates a string that contains list of fields you need.
        /// </summary>
        /// <param name="fieldToString">Gets fields value as string.</param>
        /// <returns>String containing lit of fields.</returns>
        public string GetStringOfFields(Func<T, string> fieldToString)
        {
            if (this._count == 0)
                return "None";

            var returnString = new StringBuilder();
            for (var i = 0; i < _count; ++i)
            {
                var field = fieldToString(_items[i]);
                returnString.Append($"{i + 1}) {field}\n");
            }

            return returnString.ToString();
        }

        #endregion

        private class CollectionEnumerator : IEnumerator<T>
        {
            private readonly MyCollection<T> _this;
            private int _position = -1;

            public CollectionEnumerator(MyCollection<T> myCollection) => _this = myCollection;

            public T Current => _this._items[_position];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                _position++;

                return _position < _this.Count;
            }

            public void Reset() => _position = -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace lab4
{
    /// <summary>     /// Параметризованный класс для хранения набора объектов от интерфейса ITransport     /// </summary>     /// <typeparam name="T"></typeparam> 
    public class Depo<T> : IEnumerator<T>, IEnumerable<T>
        where T : class, ITransport
    {         /// <summary>         /// Массив объектов, которые храним         /// </summary>         
		private readonly List<T> _places;

        private readonly int _maxCount;

        /// <summary>         /// Ширина окна отрисовки         /// </summary>         
        private readonly int pictureWidth;

        /// <summary>         /// Высота окна отрисовки         /// </summary>         
        private readonly int pictureHeight;

        /// <summary>         /// Размер парковочного места (ширина)         /// </summary>         
        private readonly int _placeSizeWidth = 310;

        /// <summary>         /// Размер парковочного места (высота)         /// </summary>         
        private readonly int _placeSizeHeight = 100;


        private int _currentIndex;
        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];

        public Depo(int picWidth, int picHeight)
        {
            this.pictureWidth = picWidth;
            this.pictureHeight = picHeight;
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            _places = new List<T>();
            _currentIndex = -1;

        }

        public static bool operator +(Depo<T> p, T locomotive)
        {
            if (p._places.Count >= p._maxCount)
            {
                throw new DepoOverflowException();
            }

            if (p._places.Contains(locomotive))
            {
                throw new DepoAlreadyHaveThisLocomotiveException();
            }
            p._places.Add(locomotive);
            return true;
        }


        public static T operator -(Depo<T> p, int index)
        {
            if (index < -1 || index > p._places.Count)
            {
                throw new DepoNotFoundException(index);
            }
            T locomotive = p._places[index];
            p._places.RemoveAt(index);
            return locomotive;
        }

        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i)
            {
                _places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 15, i % 5 * _placeSizeHeight + 40, pictureWidth, pictureHeight);
                _places[i].DrawLocomotive(g);
            }
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {
                    g.DrawLine(pen, i * _placeSizeWidth, (j) * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth / 2, (j) * _placeSizeHeight);
                }

                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }

        public T GetNext(int index)
        {
            if (index < 0 || index >= _places.Count)
            {
                return null;
            }
            return _places[index];
        }
        public void Sort() => _places.Sort((IComparer<T>)new LocomotiveComparer());

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return (_currentIndex < _places.Count);
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }

}

using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private List<T> MyList = new List<T>();
        private int back = -1;
        private int front = 0;

        public bool IsEmpty()
        {
            if (MyList.Count == 0) return true;

            return back < front;
        }

        public void Enqueue(T data)
        {
            MyList.Add(data);
            back++;
        }

        public T GetFront()
        {
            if (IsEmpty()) throw new MyQueueEmptyException();

            return MyList[front];
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new MyQueueEmptyException();

            T result = MyList[front];
            front++;

            return result;
        }

        public void Clear()
        {
            MyList.Clear();
            back = -1;
            front = 0;
        }

    }
}
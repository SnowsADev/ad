using System;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY + 1];
            size = 0;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            array = new T[DEFAULT_CAPACITY + 1];
            size = 0;
        }

        public void Add(T x)
        {
            if (size + 1 == array.Length)
                DoubleArray();

            size++;
            int hole = size;
            array[0] = x;

            for (; x.CompareTo(array[hole / 2]) < 0; hole /= 2)
                array[hole] = array[hole / 2];

            array[hole] = x;
        }

        private void DoubleArray()
        {
            int CurrentArraySize = array.Length;
            T[] newArray = new T[CurrentArraySize * 2];
            
            for (int i = 1; i <= size; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (size == 0) throw new PriorityQueueEmptyException();

            T MinItem = Element();
            array[1] = array[size--];
            PercolateDown(1);

            return MinItem;
        }

        private void PercolateDown(int hole)
        {
            int child;
            T tmp = array[hole];

            for (; hole * 2 <= size; hole = child)
            {
                child = hole * 2;
                if (child != size && array[child + 1].CompareTo(array[child]) < 0)
                    child++;

                if (array[child].CompareTo(tmp) < 0)
                    array[hole] = array[child];
                else
                    break;
            }

            array[hole] = tmp;
        }

        private T Element()
        {
            if (array.Length == 0) throw new NullReferenceException("No elements in PriorityQueue");
            return array[1];
        }

        public override string ToString()
        {
            if (size == 0) return string.Empty;

            string sResult = "";
            for (int i = 1; i <= size; i++)
                sResult += $"{array[i]} ";

            return sResult.Trim();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            array[size + 1] = x;
            size++;
        }

        public void BuildHeap()
        {
            for (int i = size / 2; i > 0; i--)
                PercolateDown(i);
        }

    }
}

using System.Diagnostics;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        //Big-Oh = n
        public MyArrayList(int capacity)
        {
            if (capacity < 1) return;

            this.size = capacity;
            this.data = new int[size];
        }

        //Big-Oh = n^2
        public void Add(int n)
        {
            if (data.Length < size && n > 0) return;

            int index = 0;
            bool isFull = true;
            for(int i =0; i < data.Length; i++)
            {
                if (data[i] == 0)
                {
                    index = i;
                    isFull = false;
                    break;
                }
            }

            if (isFull) throw new MyArrayListFullException();
            data[index] = n;
        }

        //Big-Oh = n^2 + n^2?
        public int Get(int index)
        {
            int Capacity = this.Capacity();
            if (Capacity == 0)
            {
                if (index < 0 || index >= Capacity) throw new MyArrayListIndexOutOfRangeException();
                if (Size() == 0) throw new MyLinkedListEmptyException();
            }

            if (index < 0 || index > Capacity || Size() <= index)
                throw new MyArrayListIndexOutOfRangeException();

            return data[index];
        }

        //Big-Oh = n^2
        public void Set(int index, int n)
        {
            if (Size() == 0 || index < 0 || index > Capacity() || index > Size() -1) throw new MyArrayListIndexOutOfRangeException();

            data[index] = n;
        }

        //Big-Oh = n
        public int Capacity()
        {
            return data.Length;
        }

        //Big-Oh = n^2
        public int Size()
        {
            int count = 0;

            foreach (int e in data)
            {
                if (e == 0) break;
                count++;
            }

            return count;
        }

        //Big-Oh = n
        public void Clear()
        {
            this.data = new int[size];
        }

        //Big-Oh = n^2
        public int CountOccurences(int n)
        {
            int count = 0;

            foreach (int e in this.data)
            {
                if (n == e) count++;
            }

            return count;
        }

        //Big-Oh = n^2
        public override string ToString()
        {
            int ArraySize = Size();

            if (ArraySize == 0) return "NIL";


            string result = "[";
            for(int i=0; i<ArraySize; i++)
            {
                result += data[i].ToString();

                if(i != ArraySize - 1)
                {
                    result += ",";
                }
            }
            return result + "]";
        }
    }
}

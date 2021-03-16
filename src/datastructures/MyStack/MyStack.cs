namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        private MyLinkedList<T> myLinkedList = new MyLinkedList<T>();

        public bool IsEmpty()
        {
            return myLinkedList.Size() == 0 ? true : false;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new MyStackEmptyException();

            T Result = myLinkedList.GetFirst();
            myLinkedList.RemoveFirst();

            return Result;
        }

        public void Push(T data)
        {
            myLinkedList.AddFirst(data);
        }

        public T Top()
        {
            if (IsEmpty()) throw new MyStackEmptyException();

            return myLinkedList.GetFirst();
        }
    }
}

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> head;
        private int size;

        public MyLinkedList()
        {
            size = 0;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>()
            {
                data = data,
                next = head
            };

            //list is empty
            if (head == null)
            {
                head = newNode;
                size++;
                return;
            }

            //list is NOT empty
            size++;
            head = newNode;
        }

        private MyLinkedListNode<T> GetTail()
        {
            if (size == 0 && head == null) throw new MyLinkedListIndexOutOfRangeException();
            if (size == 1) return head;

            //find tail
            MyLinkedListNode<T> node = GetLinkedListNode(size - 1);

            return node;
        }

        public T GetFirst()
        {
            if (head == null) throw new MyLinkedListEmptyException();
            return head.data;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new MyLinkedListEmptyException();

            head = head.next;
            size--;

            if (size == 0) head = null;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            //list is already empty
            if (head == null) return;

            MyLinkedListNode<T> node = head;
            MyLinkedListNode<T> currentNode;


            for(int i =0; i< size; i++){ 
                currentNode = node;
                node = node.next;

                currentNode.next = null;
            }
            size = 0;
        }
        private MyLinkedListNode<T> GetLinkedListNode(int index)
        {
            if (head == null) throw new MyLinkedListEmptyException();
            if (index < 0 || index > Size() - 1) throw new MyLinkedListIndexOutOfRangeException();

            MyLinkedListNode<T> result = head;
            for (int i = 0; i < index; i++)
            {
                result = result.next;
            }

            return result;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 ) throw new MyLinkedListIndexOutOfRangeException();
            if (index > Size())
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }
            //create
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>()
            {
                data = data,
                //reference
                next = null
            };

            if(size == 0 && index == 0)
            {
                head = newNode;
                head.next = newNode;
                size++;
                return;
            } else if(size < index)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            //replace old reference
            int indexBeforeNode = index - 1;
            if (indexBeforeNode < 0)
            {
                MyLinkedListNode<T> Tail = GetTail();
                Tail.next = newNode;
                newNode.next = head;
                head = newNode;
            } else {
                MyLinkedListNode<T> n = GetLinkedListNode(indexBeforeNode);
                newNode.next = n.next;
                n.next = newNode;
            }
            size++;
        }

        public override string ToString()
        {
            if (size == 0) return "NIL";

            string Result = "[";

            MyLinkedListNode<T> MyNode = head;
            for(int i =0; i<size; i++)
            //while(MyNode.next != head)
            {
                Result += MyNode.data.ToString() ;

                if (MyNode.next != null) { 
                    MyNode = MyNode.next;
                    Result += ",";
                }
            }

            return Result + "]";

        }
    }
}
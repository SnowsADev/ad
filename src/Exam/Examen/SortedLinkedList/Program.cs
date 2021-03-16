namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedLinkedList list = new SortedLinkedList();
            System.Console.WriteLine(list.ToString());
            System.Console.WriteLine(list.ToStringSorted());
            list.AddFirst(3);
            list.AddFirst(7);
            list.AddFirst(1);
            list.AddFirst(4);
            System.Console.WriteLine(list.ToString());
            System.Console.WriteLine(list.ToStringSorted());
        }
    }
}

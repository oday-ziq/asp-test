class Program
{
    static void Main()
    {
        var bst = new BST();
        int[] values = { 10, 5, 15, 3, 7, 12, 18 };

        foreach (var val in values)
            bst.Insert(val);

        Console.WriteLine("Ascending Order:");
        foreach (var item in bst.EnumerateSorted())
            Console.Write(item + " ");

        Console.WriteLine("\nDescending Order:");
        foreach (var item in bst.EnumerateSorted(desc: true))
            Console.Write(item + " ");
    }
}
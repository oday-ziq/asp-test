using System;

class Program
{
    static void Main()
    {
        var bst = new BST();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);
        bst.Insert(4);

        Console.WriteLine("BST Contains Tests:");
        Console.WriteLine($"Contains 2? {bst.Contains(2)}"); // True
        Console.WriteLine($"Contains 1? {bst.Contains(1)}"); // True
        Console.WriteLine($"Contains 4? {bst.Contains(4)}"); // True
        Console.WriteLine($"Contains 0? {bst.Contains(0)}"); // False
    }
}

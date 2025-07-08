public class BST
{
    public Node? Root;

    public BST()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        Node current = Root;
        while (true)
        {
            if (value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(value);
                    return;
                }
                current = current.Left;
            }
            else if (value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = new Node(value);
                    return;
                }
                current = current.Right;
            }
            else
            {
                return;
            }
        }
    }

    public IEnumerable<int> EnumerateSorted(bool desc = false)
    {
        return desc ? EnumerateDescending(Root) : EnumerateAscending(Root);
    }

    private IEnumerable<int> EnumerateAscending(Node? node)
    {
        var stack = new Stack<Node>();
        Node? current = node;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            yield return current.Value;
            current = current.Right;
        }
    }

    private IEnumerable<int> EnumerateDescending(Node? node)
    {
        var stack = new Stack<Node>();
        Node? current = node;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Right;
            }

            current = stack.Pop();
            yield return current.Value;
            current = current.Left;
        }
    }
}
public class BST
{
    public Node Root;

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
                // Value already exists
                return;
            }
        }
    }

    public bool Contains(int target)
    {
        Node current = Root;
        while (current != null)
        {
            if (current.Value == target) return true;
            current = target < current.Value ? current.Left : current.Right;
        }
        return false;
    }
}
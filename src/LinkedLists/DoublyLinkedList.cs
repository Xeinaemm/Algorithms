namespace Algorithms.LinkedLists;
public class DoublyLinkedList
{
    public required Node? Head { get; set; }
    public required Node? Tail { get; set; }

    // O(1) time | O(1) space
    public void SetHead(Node node)
    {
        if (Head == null)
        {
            Head = node;
            Tail = node;
            return;
        }
        InsertBefore(Head, node);
    }

    // O(1) time | O(1) space
    public void SetTail(Node node)
    {
        if (Tail == null)
        {
            SetHead(node);
            return;
        }
        InsertAfter(Tail, node);
    }

    // O(1) time | O(1) space
    public void InsertBefore(Node node, Node nodeToInsert)
    {
        if (nodeToInsert == Head && nodeToInsert == Tail)
            return;
        Remove(nodeToInsert);
        nodeToInsert.Prev = node.Prev;
        nodeToInsert.Next = node;
        if (node.Prev == null)
            Head = nodeToInsert;
        else
            node.Prev.Next = nodeToInsert;
        node.Prev = nodeToInsert;
    }

    // O(1) time | O(1) space
    public void InsertAfter(Node node, Node nodeToInsert)
    {
        if (nodeToInsert == Head && nodeToInsert == Tail)
            return;
        Remove(nodeToInsert);
        nodeToInsert.Prev = node;
        nodeToInsert.Next = node.Next;
        if (node.Next == null)
            Tail = nodeToInsert;
        else
            node.Next.Prev = nodeToInsert;
        node.Next = nodeToInsert;
    }

    // O(p) time | O(1) space
    public void InsertAtPosition(int position, Node nodeToInsert)
    {
        if (position == 1)
        {
            SetHead(nodeToInsert);
            return;
        }
        var node = Head;
        var currentPosition = 1;
        while (node != null && currentPosition++ != position)
            node = node.Next;
        if (node != null)
            InsertBefore(node, nodeToInsert);
        else
            SetTail(nodeToInsert);
    }

    // O(n) time | O(1) space
    public void RemoveNodesWithValue(int value)
    {
        var node = Head;
        while (node != null)
        {
            var toRemove = node;
            node = node.Next;
            if (toRemove.Value == value)
                Remove(toRemove);
        }
    }

    // O(1) time | O(1) space
    public void Remove(Node node)
    {
        if (node == Head)
            Head = Head.Next;
        if (node == Tail)
            Tail = Tail.Prev;
        RemoveNodeBindings(node);
    }

    // O(n) time | O(1) space
    public bool ContainsNodeWithValue(int value)
    {
        var node = Head;
        while (node != null && node.Value != value)
            node = node.Next;
        return node != null;
    }

    public static void RemoveNodeBindings(Node node)
    {
        if (node.Prev != null)
            node.Prev.Next = node.Next;
        if (node.Next != null)
            node.Next.Prev = node.Prev;
        node.Prev = null;
        node.Next = null;
    }
}
public class Node(int value)
{
    public int Value { get; } = value;
    public Node? Prev { get; set; }
    public Node? Next { get; set; }
}

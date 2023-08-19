using Algorithms.Structures;

namespace Algorithms.LinkedLists;

public static class RemoveDuplicatesLinkedList
{
    // O(n) time | O(1) space
    public static LinkedList First(LinkedList linkedList)
    {
        var currentNode = linkedList;
        while (currentNode != null)
        {
            var distinctNode = currentNode.Next;
            while (distinctNode != null && currentNode.Value == distinctNode.Value)
                distinctNode = distinctNode.Next;
            currentNode.Next = distinctNode;
            currentNode = distinctNode;
        }
        return linkedList;
    }

    // O(n) time | O(1) space
    public static LinkedList Second(LinkedList linkedList)
    {
        var currentNode = linkedList;
        while (currentNode != null && currentNode.Next != null)
            if (currentNode.Value == currentNode.Next.Value)
                currentNode.Next = currentNode.Next.Next;
            else
                currentNode = currentNode.Next;
        return linkedList;
    }
}

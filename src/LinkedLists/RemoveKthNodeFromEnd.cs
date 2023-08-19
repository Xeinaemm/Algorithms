using Algorithms.Structures;

namespace Algorithms.LinkedLists;
public static class RemoveKthNodeFromEnd
{
    // O(n) time | O(1) space
    public static void First(LinkedList head, int k)
    {
        if (head == null)
            return;
        var leftPtr = head;
        var rightPtr = head;
        for (var i = 0; i < k; i++)
            rightPtr = rightPtr?.Next;
        if (rightPtr == null)
        {
            head.Value = head.Next.Value;
            head.Next = head.Next.Next;
            return;
        }
        while (rightPtr.Next != null)
        {
            rightPtr = rightPtr.Next;
            leftPtr = leftPtr?.Next;
        }
        leftPtr.Next = leftPtr.Next?.Next;
    }
}

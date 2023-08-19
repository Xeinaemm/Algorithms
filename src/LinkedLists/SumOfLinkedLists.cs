using Algorithms.Structures;

namespace Algorithms.LinkedLists;
public static class SumOfLinkedLists
{
    // O(max(m, n)) time | O(max(m, n)) space
    public static LinkedList? First(LinkedList linkedListOne, LinkedList linkedListTwo)
    {
        var dummy = new LinkedList(0);
        var currentNode = dummy;
        var nodeOne = linkedListOne;
        var nodeTwo = linkedListTwo;
        var carry = 0;
        while (carry != 0 || nodeOne != null || nodeTwo != null)
        {
            var valueOne = nodeOne != null ? nodeOne.Value : 0;
            var valueTwo = nodeTwo != null ? nodeTwo.Value : 0;
            var sum = valueOne + valueTwo + carry;
            currentNode.Next = new LinkedList(sum % 10);
            currentNode = currentNode.Next;
            carry = sum / 10;
            nodeOne = nodeOne?.Next;
            nodeTwo = nodeTwo?.Next;
        }
        return dummy.Next;
    }
}

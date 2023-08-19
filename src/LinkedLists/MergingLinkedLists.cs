using Algorithms.Structures;

namespace Algorithms.LinkedLists;
internal class MergingLinkedLists
{
    // O(m+n) time | O(1) space
    public static LinkedList? First(LinkedList linkedListOne, LinkedList linkedListTwo)
    {
        var counterOne = 0;
        var counterTwo = 0;
        var nodeOne = linkedListOne;
        var nodeTwo = linkedListTwo;
        while (nodeOne != null)
        {
            counterOne++;
            nodeOne = nodeOne.Next;
        }
        while (nodeTwo != null)
        {
            counterTwo++;
            nodeTwo = nodeTwo.Next;
        }
        nodeOne = linkedListOne;
        nodeTwo = linkedListTwo;
        if (counterOne > counterTwo)
            for (var i = 0; i < counterOne - counterTwo; i++)
                nodeOne = nodeOne?.Next;
        else
            for (var i = 0; i < counterTwo - counterOne; i++)
                nodeTwo = nodeTwo?.Next;
        while (nodeOne != null && nodeTwo != null)
        {
            if (nodeOne.Value == nodeTwo.Value)
                return nodeOne;
            nodeOne = nodeOne.Next;
            nodeTwo = nodeTwo.Next;
        }
        return null;
    }

    // O(m+n) time | O(1) space
    public LinkedList? Second(LinkedList linkedListOne, LinkedList linkedListTwo)
    {
        var nodeOne = linkedListOne;
        var nodeTwo = linkedListTwo;
        while (nodeOne != nodeTwo)
        {
            nodeOne = nodeOne == null ? linkedListTwo : nodeOne.Next;
            nodeTwo = nodeTwo == null ? linkedListOne : nodeTwo.Next;
        }
        return nodeOne;
    }
}

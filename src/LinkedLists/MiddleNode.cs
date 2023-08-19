using Algorithms.Structures;

namespace Algorithms.LinkedLists;
public static class MiddleNode
{
    // O(n) time | O(1) space
    public static LinkedList? First(LinkedList? linkedList)
    {
        var count = 0;
        var currentNode = linkedList;
        while (currentNode != null)
        {
            currentNode = currentNode.Next;
            count++;
        }
        var midNode = Math.Ceiling((double)(count / 2));
        currentNode = linkedList;
        for (var i = 0; i < midNode; i++)
            currentNode = currentNode?.Next;

        return currentNode;
    }
}

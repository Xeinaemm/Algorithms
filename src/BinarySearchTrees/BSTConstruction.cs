using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;

public static class BstConstruction
{
    public class Bst(int value)
    {
        public int Value { get; set; } = value;
        public Bst? Left { get; set; }
        public Bst? Right { get; set; }

        // Average: O(log(n)) time | O(1) space
        // Worst: O(n) time | O(1) space
        public Bst? Insert(int value)
        {
            var currentNode = this;
            while (true)
            {
                if (currentNode.Value <= value)
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Bst(value);
                        break;
                    }
                    else
                        currentNode = currentNode.Right;
                else
                    if (currentNode.Left == null)
                {
                    currentNode.Left = new Bst(value);
                    break;
                }
                else
                    currentNode = currentNode.Left;
            }

            return this;
        }

        // Average: O(log(n)) time | O(1) space
        // Worst: O(n) time | O(1) space
        public bool Contains(int value)
        {
            var currentNode = this;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                    return true;
                else
                    currentNode = currentNode.Value < value ? currentNode.Right : currentNode.Left;
            }
            return false;
        }

        // Average: O(log(n)) time | O(1) space
        // Worst: O(n) time | O(1) space
        public Bst? Remove(int value)
        {
            _ = Remove(value, null);
            return this;
        }

        public Bst? Remove(int value, Bst? parentNode)
        {
            var currentNode = this;
            while (currentNode != null)
            {
                if (value > currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }
                else if (value < currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Left != null && currentNode.Right != null)
                    {
                        currentNode.Value = currentNode.Right.GetMinValue();
                        _ = currentNode.Right.Remove(currentNode.Value, currentNode);
                    }
                    else if (parentNode == null)
                    {
                        if (currentNode.Left != null)
                        {
                            currentNode.Value = currentNode.Left.Value;
                            currentNode.Right = currentNode.Left.Right;
                            currentNode.Left = currentNode.Left.Left;
                        }
                        else if (currentNode.Right != null)
                        {
                            currentNode.Value = currentNode.Right.Value;
                            currentNode.Right = currentNode.Right.Right;
                            currentNode.Left = currentNode.Right.Left;
                        }
                    }
                    else if (parentNode.Left == currentNode)
                        parentNode.Left = currentNode.Left ?? currentNode.Right;
                    else if (parentNode.Right == currentNode)
                        parentNode.Right = currentNode.Left ?? currentNode.Right;
                    break;
                }
            }
            return this;
        }
        public int GetMinValue() => Left?.GetMinValue() ?? Value;
    }
}

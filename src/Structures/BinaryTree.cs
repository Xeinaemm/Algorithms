namespace Algorithms.Structures;
public class BinaryTree
{
    public int Value { get; set; }
    public BinaryTree? Left { get; set; }
    public BinaryTree? Right { get; set; }

    public BinaryTree? Parent { get; set; }

    public BinaryTree(int value) => Value = value;
}

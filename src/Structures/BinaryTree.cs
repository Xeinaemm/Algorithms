namespace Algorithms.Structures;
public class BinaryTree(int value)
{
    public int Value { get; set; } = value;
    public BinaryTree? Left { get; set; }
    public BinaryTree? Right { get; set; }

    public BinaryTree? Parent { get; set; }
}

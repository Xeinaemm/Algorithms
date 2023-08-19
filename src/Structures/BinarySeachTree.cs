namespace Algorithms.Structures;
public class BinarySeachTree
{
    public int Value { get; set; }
    public BinarySeachTree? Left { get; set; }
    public BinarySeachTree? Right { get; set; }

    public BinarySeachTree(int value) => Value = value;
}

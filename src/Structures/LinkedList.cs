namespace Algorithms.Structures;
public class LinkedList
{
    public int Value { get; set; }
    public LinkedList? Next { get; set; }

    public LinkedList(int value) => Value = value;
}

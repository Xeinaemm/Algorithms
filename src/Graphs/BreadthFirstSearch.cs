namespace Algorithms.Graphs;
public class BreadthFirstSearch
{
    // BFS requires a queue. Perform tasks on value, and then enqueues all children.
    public class Node
    {
        public string Name { get; }
        public List<Node> Children { get; } = new();

        public Node(string name) => Name = name;

        // O(v + e) time | O(v) space
        public List<string> BreadthFirstSearch(List<string> array)
        {
            var remainingNodes = new Queue<Node>();
            remainingNodes.Enqueue(this);

            while (remainingNodes.Count != 0)
            {
                var node = remainingNodes.Dequeue();
                array.Add(node.Name);
                node.Children.ForEach(remainingNodes.Enqueue);
            }
            return array;
        }

        public Node AddChild(string name)
        {
            var child = new Node(name);
            Children.Add(child);
            return this;
        }
    }
}

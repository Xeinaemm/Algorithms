﻿namespace Algorithms.Graphs;
public class DepthFirstSearch
{
    // O(v + e) time | O(v) space
    public class Node(string name)
    {
        public string Name { get; set; } = name;
        public List<Node> Children { get; set; } = new();

        public List<string> DepthFirstSearch(List<string> array)
        {
            array.Add(Name);
            return DepthFirstSearchRecursion(Children, array);
        }

        public List<string> DepthFirstSearchRecursion(List<Node> children, List<string> array)
        {
            foreach (var child in children)
            {
                array.Add(child.Name);
                _ = DepthFirstSearchRecursion(child.Children, array);
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

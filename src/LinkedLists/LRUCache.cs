namespace Algorithms.LinkedLists;
public class Program
{
    public class LruCache(int maxSize)
    {
        public Dictionary<string, DoublyLinkedListNode> Cache { get; private set; } = [];
        public int MaxSize { get; private set; } = maxSize > 1 ? maxSize : 1;
        public int CurrentSize { get; private set; } = 0;
        public DoublyLinkedList ListOfMostRecent { get; private set; } = new();

        public void InsertKeyValuePair(string key, int value)
        {
            if (!Cache.ContainsKey(key))
            {
                if (CurrentSize == MaxSize)
                    EvictLeastRecent();
                else
                    CurrentSize++;
                Cache.Add(key, new DoublyLinkedListNode(key, value));
            }
            else
                ReplaceKey(key, value);
            ListOfMostRecent.SetHeadTo(Cache[key]);
        }

        public LruResult GetValueFromKey(string key)
        {
            if (!Cache.TryGetValue(key, out var value))
                return new LruResult(false, -1);
            ListOfMostRecent.SetHeadTo(value);
            return new LruResult(true, value.Value);
        }

        public string GetMostRecentKey() =>
            ListOfMostRecent.Head == null ?
            string.Empty :
            ListOfMostRecent.Head.Key;

        public void EvictLeastRecent()
        {
            var keyToRemove = ListOfMostRecent.Tail.Key;
            ListOfMostRecent.RemoveTail();
            Cache.Remove(keyToRemove);
        }

        public void ReplaceKey(string key, int value)
        {
            if (!Cache.TryGetValue(key, out _))
                return;
            Cache[key].Value = value;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode? Head { get; private set; }
        public DoublyLinkedListNode? Tail { get; private set; }

        public void SetHeadTo(DoublyLinkedListNode node)
        {
            if (Head == node)
                return;
            else if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else if (Head == Tail)
            {
                Tail.Prev = node;
                Head = node;
                Head.Next = Tail;
            }
            else
            {
                if (Tail == node)
                    RemoveTail();
                node.RemoveBindings();
                Head.Prev = node;
                node.Next = Head;
                Head = node;
            }
        }

        public void RemoveTail()
        {
            if (Tail == null)
                return;
            if (Tail == Head)
            {
                Head = null;
                Tail = null;
                return;
            }
            Tail = Tail.Prev;
            Tail.Next = null;
        }
    }

    public class DoublyLinkedListNode(string key, int value)
    {
        public string Key { get; set; } = key;
        public int Value { get; set; } = value;
        public DoublyLinkedListNode? Prev { get; set; }
        public DoublyLinkedListNode? Next { get; set; }

        public void RemoveBindings()
        {
            if (Prev != null)
                Prev.Next = Next;
            if (Next != null)
                Next.Prev = Prev;
            Prev = null;
            Next = null;
        }
    }

    public class LruResult(bool found, int value)
    {
        public bool Found { get; } = found;
        public int Value { get; } = value;
    }
}


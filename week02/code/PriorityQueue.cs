public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();
    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority) =>
        _queue.Add(new PriorityItem(value, priority));

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Locate first item with the highest priority.
        int highPriIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriIndex].Priority)
                highPriIndex = i;
        }

        var value = _queue[highPriIndex].Value;
        _queue.RemoveAt(highPriIndex);          // <-- actually remove it
        return value;
    }

    public override string ToString() =>
        $"[{string.Join(", ", _queue)}]";
}

internal class PriorityItem
{
    internal string Value { get; }
    internal int Priority { get; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString() => $"{Value} (Pri:{Priority})";
}

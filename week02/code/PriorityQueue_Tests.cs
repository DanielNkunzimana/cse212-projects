using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    
    [TestMethod]
    // Scenario: Enqueue three items A(1), B(5), C(3) then dequeue all.
    // Expected Result: First Dequeue -> "B" (highest pri 5)
    //                  Second Dequeue -> "C" (next highest 3)
    //                  Third Dequeue -> "A" (lowest 1)
    // Defect(s) Found:   • Dequeue loop ignored last element (off‑by‑one). 
    //                    • Did not remove the element from the list.
    //                    • FIFO rule for equal priorities not yet tested here.
    public void TestPriorityQueue_PriorityOrder()
    {
        var q = new PriorityQueue();
        q.Enqueue("A", 1);
        q.Enqueue("B", 5);
        q.Enqueue("C", 3);

        Assert.AreEqual("B", q.Dequeue());
        Assert.AreEqual("C", q.Dequeue());
        Assert.AreEqual("A", q.Dequeue());
    }

    [TestMethod]
    // Scenario: Two items have the same highest priority.  Enqueue X(7) then Y(7).
    // Expected Result: Dequeue returns "X" first (FIFO for equal priorities) then "Y".
    // Defect(s) Found:   • Original code used '>=' so the *last* highest item
    //                      was chosen instead of the first.
    public void TestPriorityQueue_FifoForEqualPriority()
    {
        var q = new PriorityQueue();
        q.Enqueue("X", 7);
        q.Enqueue("Y", 7);

        Assert.AreEqual("X", q.Dequeue());
        Assert.AreEqual("Y", q.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue on an empty queue should throw.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None – message already correct.
    public void TestPriorityQueue_Empty()
    {
        var q = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => q.Dequeue(),
            "The queue is empty.");
    }
}

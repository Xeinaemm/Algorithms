namespace Algorithms.GreedyAlgorithms;

public static class OptimalFreelancing
{
    // O(n) time | O(1) space
    public static int First(Dictionary<string, int>[] jobs)
    {
        var payment = new int[7];
        for (var i = 0; i < jobs.Length; i++)
        {
            var deadline = jobs[i]["deadline"];
            if (deadline > 7)
                deadline = 7;
            var currentPayment = jobs[i]["payment"];
            for (var j = deadline - 1; j >= 0; j--)
                if (payment[j] < currentPayment && currentPayment != 0)
                    (payment[j], currentPayment) = (currentPayment, payment[j]);
        }
        return payment.Sum();
    }
}

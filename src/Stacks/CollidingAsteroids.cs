namespace Algorithms.Stacks;
public static class CollidingAsteroids
{
    // O(n) time | O(n) space
    public static int[] First(int[] asteroids)
    {
        var stack = new Stack<int>();
        foreach (var asteroid in asteroids)
        {
            if (stack.Count == 0 || asteroid > 0 || stack.Peek() < 0)
            {
                stack.Push(asteroid);
                continue;
            }
            while (stack.Count > 0)
            {
                if (stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                    break;
                }
                var asteroidSize = Math.Abs(asteroid);
                if (stack.Peek() > asteroidSize)
                    break;
                if (stack.Peek() == asteroidSize)
                {
                    _ = stack.Pop();
                    break;
                }
                _ = stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(asteroid);
                    break;
                }
            }
        }
        return stack.Reverse().ToArray();
    }
}

public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        foreach (var edge in invocations)
        {
            int from = edge[0];
            int to = edge[1];

            if (!graph.ContainsKey(from))
            {
                graph[from] = new List<int>();
            }

            graph[from].Add(to);
        }

        
        HashSet<int> suspicious = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(k);

        while (stack.Count > 0)
        {
            int current = stack.Pop();

            if (suspicious.Contains(current))
                continue;

            suspicious.Add(current);

            if (graph.ContainsKey(current))
            {
                foreach (int next in graph[current])
                {
                    stack.Push(next);
                }
            }
        }

        foreach (var edge in invocations)
        {
            int from = edge[0];
            int to = edge[1];

            if (!suspicious.Contains(from) && suspicious.Contains(to))
            {
                List<int> allMethods = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    allMethods.Add(i);
                }

                return allMethods;
            }
        }

        
        List<int> answer = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (!suspicious.Contains(i))
            {
                answer.Add(i);
            }
        }

        return answer;
    }
}
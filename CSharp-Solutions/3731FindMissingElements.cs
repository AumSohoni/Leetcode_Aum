public class Solution
{
    public IList<int> FindMissingElements(int[] nums)
    {
        int min = nums[0];
        int max = nums[0];

        HashSet<int> range = new HashSet<int>();
        List<int> ans = new List<int>();

        foreach (int num in nums)
        {
            range.Add(num);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min)
            {
                min = nums[i];
            }

            if (nums[i] > max)
            {
                max = nums[i];
            }
        }

        for (int i = min; i <= max; i++)
        {
            if (!range.Contains(i))
            {
                ans.Add(i);
            }
        }

        return ans;
    }
}
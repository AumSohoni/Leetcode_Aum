public class Solution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            // Add current number
            if (!frequency.ContainsKey(nums[right]))
            {
                frequency[nums[right]] = 0;
            }

            frequency[nums[right]]++;

            // Shrink window if frequency is too high
            while (frequency[nums[right]] > k)
            {
                frequency[nums[left]]--;
                left++;
            }

            // Update longest valid window
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
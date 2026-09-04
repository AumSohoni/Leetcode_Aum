public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length, last = n - 1;
        int[] maxSoFar = new int[n];
        int[] minSoFar = new int[n];
        maxSoFar[0] = nums[0];
        minSoFar[last] = nums[last];

        for(int i=1; i<nums.Length; i++){
            maxSoFar[i] = Math.Max(nums[i], maxSoFar[i-1]);
            int fromLast = last - i;
            minSoFar[fromLast] = Math.Min(nums[fromLast], minSoFar[fromLast+1]);
        }

        for(int i=0; i<nums.Length; i++){
            int instabilityScore = maxSoFar[i] - minSoFar[i];

            if(instabilityScore <= k){
                return i;
            }
        }

        return -1;
    }
}
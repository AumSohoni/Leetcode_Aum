public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        int n = nums1.Length;
        int m = nums2.Length;
        int[] merged = new int[nums1.Length + nums2.Length];
        int totalelements = nums1.Length + nums2.Length;

         int k = 0;
        for (int i = 0; i < n; i++) {
            merged[k++] = nums1[i];
        }
        for (int i = 0; i < m; i++) {
            merged[k++] = nums2[i];
        }

        Array.Sort(merged);




        if (totalelements % 2 == 0)
{
    int middle1 = merged[totalelements / 2 - 1];
    int middle2 = merged[totalelements / 2];

    return (middle1 + middle2) / 2.0;
}
else
{
    return merged[totalelements / 2];
}





    }
}
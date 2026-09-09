public class Solution {
    public long CountCommas(long n, long commas = 999) => n > commas
        ? CountCommas(n, commas * 1000 + 999) + n - commas
        : 0;
}
public class Solution {
    public string LexPalindromicPermutation(string s, string target) {
        int n = s.Length;
        int[] a = new int[26];
        for (int i = 0; i < n; i++) a[s[i] - 'a']++;
        int odd = 0;
        int oddc = -1;
        for (int i = 0; i < 26; i++) if ((a[i] & 1) == 1) { odd++; oddc = i; }
        if ((n & 1) == 0) { if (odd != 0) return ""; } else { if (odd != 1) return ""; }
        int k = n / 2;
        int[] half = new int[26];
        for (int i = 0; i < 26; i++) half[i] = a[i] / 2;
        StringBuilder pref = new StringBuilder();
        for (int pos = 0; pos < k; pos++)
        {
            bool placed = false;
            for (int c = 0; c < 26; c++)
            {
                if (half[c] == 0) continue;
                int[] tmp = (int[])half.Clone();
                tmp[c]--;
                StringBuilder leftMin = new StringBuilder();
                leftMin.Append(pref);
                leftMin.Append((char)('a' + c));
                for (int x = 0; x < 26; x++) for (int cnt = 0; cnt < tmp[x]; cnt++) leftMin.Append((char)('a' + x));
                StringBuilder leftMax = new StringBuilder();
                leftMax.Append(pref);
                leftMax.Append((char)('a' + c));
                for (int x = 25; x >= 0; x--) for (int cnt = 0; cnt < tmp[x]; cnt++) leftMax.Append((char)('a' + x));
                StringBuilder fullMax = new StringBuilder();
                fullMax.Append(leftMax);
                if ((n & 1) == 1) fullMax.Append((char)('a' + oddc));
                for (int i = leftMax.Length - 1; i >= 0; i--) fullMax.Append(leftMax[i]);
                if (string.CompareOrdinal(fullMax.ToString(), target) <= 0) continue;
                pref.Append((char)('a' + c));
                half[c]--;
                placed = true;
                break;
                }
            if (!placed) return "";
            }
        StringBuilder left = pref;
        StringBuilder full = new StringBuilder();
        full.Append(left);
        if ((n & 1) == 1) full.Append((char)('a' + oddc));
        for (int i = left.Length - 1; i >= 0; i--) full.Append(left[i]);
        string res = full.ToString();
        if (string.CompareOrdinal(res, target) > 0) return res;
        return "";
    }
}
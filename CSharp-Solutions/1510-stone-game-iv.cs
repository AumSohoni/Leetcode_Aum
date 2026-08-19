public class Solution {
    public bool WinnerSquareGame(int n) {
        bool[] dp = new bool[n + 1];

        for (int stones = 1; stones <= n; stones++) {
            for (int i = 1; i * i <= stones; i++) {
                if (!dp[stones - i * i]) {
                    dp[stones] = true;
                    break;
                }
            }
        }

        return dp[n];
    }
}
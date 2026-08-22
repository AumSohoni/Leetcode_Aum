public class Solution {

    public int[] SumDigits(int n){
        int sum = 0;
        int product = 1;

        while(n>0){
            int rem = n%10;
            sum +=rem;
            product *= rem;
            n/=10;
        }

        return new int[] {sum,product};
    }

    public bool CheckDivisibility(int n) {

        var result = SumDigits(n);
        return n%(result[0]+result[1])==0;
    }
}
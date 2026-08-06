public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        int current = n;

        while (true)
        {
            int product = 1;
            int num = current;

            
            if (num == 0)
            {
                product = 0;
            }
            else
            {
                while (num > 0)
                {
                    int digit = num % 10;
                    product *= digit;
                    num /= 10;
                }
            }

            if (product % t == 0)
            {
                return current;
            }

            current++;
        }
    }
}

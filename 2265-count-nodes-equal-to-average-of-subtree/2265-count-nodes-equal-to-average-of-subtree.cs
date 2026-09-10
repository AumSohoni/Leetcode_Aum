public class Solution {
    // State representation aggregating bottom-up subproblem data
    private class Subtree {
        public TreeNode Root;
        public int Sum;
        public int Sz;
        
        public Subtree(TreeNode root, int sum, int sz) {
            Root = root;
            Sum = sum;
            Sz = sz;
        }
    }

    public int AverageOfSubtree(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int validSubtreeCnt = 0;

        // 1. Initialize iterative post-order traversal stack
        Stack<Subtree> subtrees = new Stack<Subtree>();
        subtrees.Push(new Subtree(root, root.val, 1));

        while (subtrees.Count > 0) {
            Subtree curr = subtrees.Peek();

            // 2. Traverse left subtree and sever link to mark as visited
            if (curr.Root.left != null) {
                subtrees.Push(new Subtree(curr.Root.left, curr.Root.left.val, 1));
                curr.Root.left = null;
            // 3. Traverse right subtree and sever link to mark as visited
            } else if (curr.Root.right != null) {
                subtrees.Push(new Subtree(curr.Root.right, curr.Root.right.val, 1));
                curr.Root.right = null;
            // 4. Evaluate average condition for the fully processed subtree
            } else {
                if (curr.Sum / curr.Sz == curr.Root.val) {
                    validSubtreeCnt++;
                }

                subtrees.Pop();

                if (subtrees.Count == 0) {
                    continue;
                }
                
                // 5. Propagate current subtree aggregate data to parent node
                Subtree parent = subtrees.Peek();
                parent.Sum += curr.Sum;
                parent.Sz += curr.Sz;
            }
        }

        return validSubtreeCnt;
    }
}
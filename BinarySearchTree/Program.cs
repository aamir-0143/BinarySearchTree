using BST;

class program
{
	public static void Main(string[] args)
	{
		BinarySearchTree tree = new BinarySearchTree();
		tree.insert(50);
		tree.insert(30);
		tree.insert(70);
		tree.modifyBST(tree.root);
		// print inorder traversal of the modified BST
		tree.inorder();



	}
}
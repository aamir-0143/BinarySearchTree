using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
	// A binary tree node
	public class Node
	{

		public int data;
		public Node left, right;

		public Node(int d)
		{
			data = d;
			left = right = null;
		}
	}

	public class BinarySearchTree
	{

		// Root of BST
		public Node root;

		// Constructor
		public BinarySearchTree()
		{
			root = null;
		}

		// Inorder traversal of the tree
		public virtual void inorder()
		{
			inorderUtil(this.root);
		}

		// Utility function for inorder traversal of
		// the tree
		public virtual void inorderUtil(Node node)
		{
			if (node == null)
			{
				return;
			}

			inorderUtil(node.left);
			Console.Write(node.data + " ");
			inorderUtil(node.right);
		}

		// adding new node
		public virtual void insert(int data)
		{
			this.root = this.insertRec(this.root, data);
		}

		/* A utility function to insert a new node with
		given data in BST */
		public virtual Node insertRec(Node node, int data)
		{
			/* If the tree is empty, return a new node */
			if (node == null)
			{
				this.root = new Node(data);
				return this.root;
			}

			/* Otherwise, recur down the tree */
			if (data <= node.data)
			{
				node.left = this.insertRec(node.left, data);
			}
			else
			{
				node.right = this.insertRec(node.right, data);
			}
			return node;
		}

		// This class initialises the value of sum to 0
		public class Sum
		{
			private readonly BinarySearchTree outerInstance;

			public Sum(BinarySearchTree outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public int sum = 0;
		}

		// Recursive function to add all greater values in
		// every node
		public virtual void modifyBSTUtil(Node node, Sum S)
		{
			// Base Case
			if (node == null)
			{
				return;
			}

			// Recur for right subtree
			this.modifyBSTUtil(node.right, S);

			// Now *sum has sum of nodes in right subtree, add
			// root->data to sum and update root->data
			S.sum = S.sum + node.data;
			node.data = S.sum;

			// Recur for left subtree
			this.modifyBSTUtil(node.left, S);
		}

		// A wrapper over modifyBSTUtil()
		public virtual void modifyBST(Node node)
		{
			Sum S = new Sum(this);
			this.modifyBSTUtil(node, S);
		}
	}
}
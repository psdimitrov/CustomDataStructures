namespace CustomDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            if (this.root == null)
            {
                this.root = new BinaryTreeNode<T>(value);

                return true;
            }

            return this.Insert(value, this.root);
        }

        private bool Insert(T value, BinaryTreeNode<T> node)
        {
            var currentNode = node;
            var newNode = new BinaryTreeNode<T>(value);

            while (currentNode != null)
            {
                var compareTo = value.CompareTo(currentNode.Value);
                
                if (compareTo < 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        newNode.Parent = currentNode;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else if (compareTo > 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        newNode.Parent = currentNode;
                        break;                        
                    }

                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public bool Contains(T value)
        {
            var isContained = this.Find(value) != null;

            return isContained;
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = this.Find(value);
            if (nodeToDelete == null)
            {
                return;
            }

            this.Remove(nodeToDelete);
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                BinaryTreeNode<T> replacement = node.RightChild;
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }
                node.Value = replacement.Value;
                node = replacement;
            }

            BinaryTreeNode<T> theChild = node.LeftChild ?? node.RightChild;

            if (theChild != null)
            {
                theChild.Parent = node.Parent;

                if (node.Parent == null)
                {
                    this.root = theChild;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                if (node.Parent == null)
                {
                    this.root = null;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = null;
                    }
                    else
                    {
                        node.Parent.RightChild = null;
                    }
                }
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            if (this.root == null)
            {
                yield break;
            }

            foreach (var item in this.root)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class BinaryTreeNode<T> : IEnumerable<T>
        {
            public BinaryTreeNode(T value)
            {
                this.Value = value;
                this.Parent = null;
                this.LeftChild = null;
                this.RightChild = null;
            }

            public T Value { get; set; }

            public BinaryTreeNode<T> Parent { get; set; }

            public BinaryTreeNode<T> LeftChild { get; set; }

            public BinaryTreeNode<T> RightChild { get; set; }

            public IEnumerator<T> GetEnumerator()
            {
                if (this.LeftChild != null)
                {
                    foreach (var item in this.LeftChild)
                    {
                        yield return item;
                    }
                }

                yield return this.Value;

                if (this.RightChild == null)
                {
                    yield break;
                }

                foreach (var item in this.RightChild)
                {
                    yield return item;
                }
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}

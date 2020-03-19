using Amazon.EC2;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AVLTree
{
    public class AVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable
    {
        AVLTree<TNode> _tree;

        AVLTreeNode<TNode> _left;
        AVLTreeNode<TNode> _right;

        #region Конструктор
        public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
        {
            Value = value;
            Parent = parent;
            _tree = tree;
        }
        #endregion
        #region Свойства
        public AVLTreeNode<TNode> Left
        {
            get
            {
                return _left;
            }
            internal set
            {
                _left = value;
                if (_left != null)
                {
                    _left.Parent = this;
                }
            }
        }
        public AVLTreeNode<TNode> Right
        {
            get
            {
                return _right;
            }
            internal set
            {
                _right = value;
                if (_right != null)
                {
                    _right.Parent = this;
                }
            }
        }
        public AVLTreeNode<TNode> Parent
        {
            get;
            internal set;
        }
        public TNode Value
        {
            get;
            private set;
        }
        #endregion
        #region Compare To
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
        #endregion
        #region Balance
        internal void Balance()
        {
            if(State == TreeState.RightHeavy)
            {
                if(Right != null && Right.BalanceFactor <0)
                {
                    LeftRightRotaion();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if(State == TreeState.LeftHeavy)
            {
                if(Left != null && Left.BalanceFactor >0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }
        private int MaxChildHeight(AVLTreeNode<TNode> node)
        {
            if(node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }
        private int LeftHeight
        {
            get
            {
                return MaxChildHeight(Left);
            }
        }
        private int RightHeight
        {
            get
            {
                return MaxChildHeight(Right);
            }
        }
        private TreeState State
        {
            get
            {
                if(LeftHeight - RightHeight >1)
                {
                    return TreeState.LeftHeavy;
                }
                if(RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }
                return TreeState.Balanced;
            }
        }
        private int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }
        enum TreeState
        {
            Balanced,
            LeftHeavy, 
            RightHeavy
        }
        #endregion
        #region LeftRotation
        private void LeftRotation()
        {
            AVLTreeNode<TNode> newRoot = Right;
            ReplaceRoot(newRoot);
            Right = newRoot.Left;
            newRoot.Left = this;
        }
        #endregion
        #region RightRotation
        private void RightRotation()
        {
            AVLTreeNode<TNode> newRoot = Left;
            ReplaceRoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
        }
        #endregion
        #region LeftRightRotation
        public void LeftRightRotaion()
        {
            Left.LeftRotation();
            RightRotation();
        }
        #endregion
        #region RightLeftRotation
        public void RightLeftRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }
        #endregion
        #region Перемещение корня
        private void ReplaceRoot(AVLTreeNode<TNode> newRoot)
        {
            if(this.Parent != null)
            {
                if(this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                else if(this.Parent.Right == this)
                {
                    this.Parent.Right = newRoot;
                }
            }
            else
            {
                _tree.Head = newRoot;
            }
            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
        }
        #endregion
    }
}

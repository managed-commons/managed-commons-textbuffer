//
//  TreeNode.cs
//  managed-commons-textbuffer
//
//  Created by Rafael Teixeira on 2020-03-28.
//  Copyright 2020 Rafael Teixeira, Managed Commons
//
//  Permission is hereby granted, free of charge, to any person obtaining
//  a copy of this software and associated documentation files (the
//  "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish,
//  distribute, sublicense, and/or sell copies of the Software, and to
//  permit persons to whom the Software is furnished to do so, subject to
//  the following conditions:
//
//  The above copyright notice and this permission notice shall be
//  included in all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//  MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//  LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//  WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Commons.TextBuffer
{
    /// <summary>
    /// Color for a node in a Red/Black Tree
    /// </summary>
    public enum NodeColor
    {
        /// <summary>
        /// Black node (color of the root node)
        /// </summary>
        Black,

        /// <summary>
        /// Red node
        /// </summary>
        Red
    }

    /// <summary>
    /// Red/Black Tree Node
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        ///  Color of this node
        /// </summary>
        public NodeColor Color;

        /// <summary>
        /// Line feeds count in the NodeLeft subtree (not in order)
        /// </summary>
        public int LeftLineFeeds;

        /// <summary>
        /// Size of the NodeLeft subtree (not in order)
        /// </summary>
        public int LeftSize;

        /// <summary>
        /// Child node in the NodeLeft if it exists
        /// </summary>
        public TreeNode? NodeLeft;

        /// <summary>
        /// Parent node
        /// </summary>
        public TreeNode? NodeParent;

        /// <summary>
        /// Child node in the NodeRight if it exists
        /// </summary>
        public TreeNode? NodeRight;

        /// <summary>
        /// Piece
        /// </summary>
        public Piece Piece;

        /// <summary>
        /// Build a new TreeNode around a piece with some color for balancing
        /// </summary>
        /// <param name="piece">Piece</param>
        /// <param name="color">Node color</param>
        /// <param name="parent">Parent node</param>
        public TreeNode(Piece piece, NodeColor color, TreeNode? parent) {
            Piece = piece;
            Color = color;
            LeftSize = 0;
            LeftLineFeeds = 0;
            NodeParent = parent;
            NodeLeft = null;
            NodeRight = null;
        }

        /// <summary>
        /// Calculate the number of linefeeds in all content under this node
        /// </summary>
        /// <param name="node">Node to calculate</param>
        /// <returns>Total number of linefeeds on this node piece and its left and right subtrees</returns>
        public static int CalculateLF(TreeNode? node) => node is null ? 0 : node.LeftSize + node.Piece.LineFeedCount + CalculateLF(node.NodeRight);

        /// <summary>
        /// Calculate the size of all content under this node
        /// </summary>
        /// <param name="node">Node to calculate</param>
        /// <returns>Total number of bytes on this node piece and its left and right subtrees</returns>
        public static int CalculateSize(TreeNode? node) => node is null ? 0 : node.LeftSize + node.Piece.Length + CalculateSize(node.NodeRight);

        /// <summary>
        /// Next node in the tree
        /// </summary>
        /// <returns>Node or null</returns>
        public TreeNode? Next() {
            if (!(NodeRight is null)) {
                return Leftest(NodeRight);
            }

            var node = this;

            while (!(node.NodeParent is null)) {
                if (node.NodeParent.NodeLeft == node) {
                    break;
                }

                node = node.NodeParent;
            }

            return node.NodeParent;
        }

        /// <summary>
        /// Previous node in the tree
        /// </summary>
        /// <returns>Node or null</returns>
        public TreeNode? Previous() {
            if (!(NodeLeft is null)) {
                return Rightest(NodeLeft);
            }

            var node = this;

            while (!(node.NodeParent is null)) {
                if (node.NodeParent.NodeRight == node) {
                    break;
                }

                node = node.NodeParent;
            }

            return node.NodeParent;
        }

        private static TreeNode Leftest(TreeNode node) {
            while (!(node.NodeLeft is null)) {
                node = node.NodeLeft;
            }
            return node;
        }

        private static TreeNode Rightest(TreeNode node) {
            while (!(node.NodeRight is null)) {
                node = node.NodeRight;
            }
            return node;
        }
    }
}

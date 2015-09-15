using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TreeViewLegacy
{
    public class TreeViewPalabrasClaveOpciones
    {
        private static IList<TreeNode> _nodes = new List<TreeNode>();

        public static IList<TreeNode> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
    }
}
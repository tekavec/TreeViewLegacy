using System.Web.UI.WebControls;
using NUnit.Framework;

namespace TreeViewLegacy.Tests
{
    [TestFixture]
    public class TreeViewBinderShould
    {
        private TreeViewBinder _TreeViewBinder;

        [SetUp]
        public void Init()
        {
            _TreeViewBinder = new TreeViewBinder();
        }

        [Test]
        public void CreateARootTreeNode()
        {
            var node = new Opcion { ParentID = 0, OpcionID = 1, Descripcion = "description" };

            var newNode = _TreeViewBinder.CreateTreeNode(node);

            Assert.That(newNode.Text, Is.EqualTo(string.Format(
                    @"<span class=""Tema"" id=""Tema{0}"">{1}</span>",
                    node.OpcionID,
                    node.Descripcion)));

            TestCommonTreeNodeProperties(newNode, node);
        }

        [Test]
        public void CreateAChildTreeNode()
        {
            var node = new Opcion { ParentID = 1, OpcionID = 1, Descripcion = "description" };

            var newNode = _TreeViewBinder.CreateTreeNode(node);

            Assert.That(newNode.Text, Is.EqualTo(string.Format(
                                @"<span class=""SubTema"">{0}</span>", 
                                node.Descripcion)));

            TestCommonTreeNodeProperties(newNode, node);
        }

        private static void TestCommonTreeNodeProperties(TreeNode newNode, Opcion node)
        {
            Assert.That(newNode.Value, Is.EqualTo(node.OpcionID.ToString()));
            Assert.That(newNode.ToolTip, Is.EqualTo(node.Descripcion));
        }
    }
}

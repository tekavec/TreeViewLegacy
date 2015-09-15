using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TreeViewLegacy.BoPage;

namespace TreeViewLegacy
{
    public class TreeViewBinder
    {
        private PageMode _pagemode;
        private int _idKeyWord;

        public void BindTreeView(IEnumerable<Opcion> optionList, TreeNode parentNode)
        {
            var opcions =
                optionList.Where(x => parentNode == null 
                    ? x.ParentID == 0 
                    : x.ParentID == int.Parse(parentNode.Value));
            if (_pagemode != BoPage.PageMode.View)
            {
                foreach (Opcion opcion in opcions)
                {
                    var newNode = CreateTreeNode(opcion);
                    if (parentNode == null)
                    {
                        TreeViewPalabrasClaveOpciones.Nodes.Add(newNode);
                    }
                    else
                    {
                        if (opcion.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
                        {
                            newNode.Checked = true;
                            parentNode.Expand();
                        }
                        parentNode.ChildNodes.Add(newNode);
                    }
                    BindTreeView(optionList, newNode);
                }
            }
            else
            {
                foreach (Opcion opcion in opcions)
                {
                    if (ExistKeyWord(opcion))
                    {
                        var newNode = CreateTreeNode(opcion);
                        if (parentNode == null)
                        {
                            TreeViewPalabrasClaveOpciones.Nodes.Add(newNode);
                        }
                        else
                        {
                            if (opcion.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
                            {
                                newNode.Checked = true;
                                parentNode.Expand();
                            }
                            if (opcion.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
                            {
                                parentNode.ChildNodes.Add(newNode);
                            }
                        }
                        BindTreeView(optionList, newNode);
                    }
                }
            }
        }

        public TreeNode CreateTreeNode(Opcion node)
        {
            return new TreeNode
            {
                Text = DetermineTextValueForNode(node),
                Value = node.OpcionID.ToString(),
                ToolTip = node.Descripcion
            };
        }

        private string DetermineTextValueForNode(Opcion node)
        {
            return (node.ParentID == 0)
                ? string.Format(
                    @"<span class=""Tema"" id=""Tema{0}"">{1}</span>",
                    node.OpcionID,
                    node.Descripcion)
                : string.Format(
                    @"<span class=""SubTema"">{0}</span>",
                    node.Descripcion);
        }

        public bool ExistKeyWord(Opcion node)
        {
            throw new System.NotImplementedException();
        }
    }
}

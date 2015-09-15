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
            var nodes = optionList.Where(x => parentNode == null ? x.ParentID == 0 : x.ParentID == int.Parse(parentNode.Value));

            if (_pagemode != BoPage.PageMode.View)
            {
                foreach (Opcion node in nodes)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = (node.ParentID == 0) ? string.Format(@"<span class=""Tema"" id=""Tema{0}"">{1}</span>", node.OpcionID.ToString(), node.Descripcion.ToString()) : string.Format(@"<span class=""SubTema"">{1}</span>", node.ParentID.ToString(), node.Descripcion.ToString());
                    newNode.Value = node.OpcionID.ToString();
                    newNode.ToolTip = node.Descripcion.ToString();

                    if (parentNode == null)
                    {
                        TreeViewPalabrasClaveOpciones.Nodes.Add(newNode);
                    }
                    else
                    {
                        if (node.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
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
                foreach (Opcion node in nodes)
                {
                    if (ExistKeyWord(node))
                    {
                        TreeNode newNode = new TreeNode();
                        newNode.Text = (node.ParentID == 0) ? string.Format(@"<span class=""Tema"" id=""Tema{0}"">{1}</span>", node.OpcionID.ToString(), node.Descripcion.ToString()) : string.Format(@"<span class=""SubTema"">{1}</span>", node.ParentID.ToString(), node.Descripcion.ToString());
                        newNode.Value = node.OpcionID.ToString();
                        newNode.ToolTip = node.Descripcion.ToString();

                        if (parentNode == null)
                        {
                            TreeViewPalabrasClaveOpciones.Nodes.Add(newNode);
                        }
                        else
                        {
                            if (node.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
                            {
                                newNode.Checked = true;
                                parentNode.Expand();
                            }

                            if (node.PalabrasClaveOpciones.Where(c => c.KeywordID == _idKeyWord).Count() > 0)
                            {
                                parentNode.ChildNodes.Add(newNode);
                            }

                        }
                        BindTreeView(optionList, newNode);
                    }
                }

            }


        }

        private bool ExistKeyWord(Opcion node)
        {
            throw new System.NotImplementedException();
        }
    }
}

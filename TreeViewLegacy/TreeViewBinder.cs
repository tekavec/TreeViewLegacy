using System.Collections.Generic;
using System.Linq;

namespace TreeViewLegacy
{
    public class TreeViewBinder
    {
        private void BindTreeView(IEnumerable<Option> OptionList, TreeNode parentNode)
        {
            var nodes = OptionList.Where(x => parentNode == null ? x.ParentID == 0 : x.ParentID == int.Parse(parentNode.Value));

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
                    BindTreeView(OptionList, newNode);
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
                        BindTreeView(OptionList, newNode);
                    }
                }

            }


        }
    }
}

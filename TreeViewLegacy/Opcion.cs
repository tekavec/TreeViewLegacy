using System.Collections.Generic;

namespace TreeViewLegacy
{
    public class Opcion
    {
        public int OpcionID;
        public int ParentID { get; set; }
        public string Descripcion { get; set; }
        public IList<PalabrasClaveOpcion> PalabrasClaveOpciones { get; set; }
    }
}
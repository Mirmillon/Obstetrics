using Echographie.Classes;
using System.Collections.Generic;

namespace Echographie.Utilitaires
{
    public class GestionElement
    {
        public void Copier(List<Element> l1, List<Element> l2)
        {
            foreach (Element e in l1)
            {
                Element elt = new Element();
                elt.CleElement = e.CleElement;
                elt.CleLangue = e.CleLangue;
                elt.Langue = e.Langue;
                elt.Label = e.Label;
                elt.Description = e.Description;
                l2.Add(elt);
            }
        }

        public void CopierSans(List<Element> l1, List<Element> l2)
        {
            foreach (Element e in l1)
            {
                Element elt = new Element();
                elt.CleElement = e.CleElement;
                elt.CleLangue = e.CleLangue;
                elt.Langue = e.Langue;
                elt.Label = e.Label;
                elt.Description = e.Description;
                l2.Add(elt);
            }
        }
    }
}

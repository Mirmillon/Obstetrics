using System.Collections.Generic;

namespace Echographie.Utilitaires
{
    public class GestionListe 
    { 
        public void Copier(List<Classes.Element> l1, List<Classes.Element> l2)
        {
            foreach (Classes.Element e in l1)
            {
                Classes.Element elt = new Classes.Element();
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

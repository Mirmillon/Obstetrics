using System.Linq;
using Echographie.Classes.Parametres;
using Echographie.RDMS.Parametres;
using System.Collections.Generic;
using Echographie.Classes;

namespace Echographie.Utilitaires
{
    public class GestionReferenceCheck
    {
        internal void SetDataBaseElementCheck(List<ReferenceCheck> l1, List<ReferenceCheck> l2, int cleElement)
        {
            for (int i = 0; i < l1.Count; ++i)
            {
                if(l1[i].Check == true && l2[i].Check == false)
                {
                    new ElementBase().DeleteElementCheck(l2[i].Cle, cleElement);
                }
                else if (l1[i].Check == false && l2[i].Check == true)
                {
                    new ElementBase().SetElementCheck(l2[i].Cle, cleElement);
                }
            }
        }

        internal List<ReferenceCheck> CheckListReferenceCheck(List<ReferenceCheck> lor, List<ReferenceCheck> lref)
        {
            List<ReferenceCheck> l = new List<ReferenceCheck>();

            for (int i = 0; i < lref.Count; ++i)
            {
                int cle = lref[i].Cle;
                bool absent = true;
                for (int j = 0; j < lor.Count; ++j)
                {
                    if (lor[j].Cle == cle)
                    {
                        absent = false;
                    }
                }
                if (absent)
                {
                    ReferenceCheck r = new ReferenceCheck();
                    r.Cle = cle;
                    r.Label = lref[i].Label;
                    l.Add(r);
                }
            }

            Copier(lor, l);

            var res = from e in l
                    orderby e.Cle
                    select e;

            l = res.ToList();

            return l;
        }

        internal void Copier(List<ReferenceCheck> l1, List<ReferenceCheck> l2)
        {
            foreach (ReferenceCheck e in l1)
            {
                ReferenceCheck elt = new ReferenceCheck();
                elt.Cle = e.Cle;
                elt.Label = e.Label;
                elt.Check = e.Check;
                l2.Add(elt);
            }
        }

        internal void Copier(List<Reference> l1, List<ReferenceCheck> l2)
        {
            foreach (Reference e in l1)
            {
                ReferenceCheck elt = new ReferenceCheck();
                elt.Cle = e.Cle;
                elt.Label = e.Label;
                l2.Add(elt);
            }
        }
    }
}

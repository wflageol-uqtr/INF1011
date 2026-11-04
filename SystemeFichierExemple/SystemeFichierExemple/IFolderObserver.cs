using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public interface IFolderObserver
    {
        void OnAddSubElement(IElement subElement);
        void OnRemoveSubElement(IElement subElement);
    }
}

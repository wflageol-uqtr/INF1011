using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeFichierExemple.Logging;

namespace SystemeFichierExemple
{
    public class LoggingObserver : IFolderObserver
    {
        private ILoggingStrategy strategy;

        public LoggingObserver(ILoggingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void OnAddSubElement(IElement subElement)
        {
            strategy.Log($"Ajout de {subElement.Name}");
        }

        public void OnRemoveSubElement(IElement subElement)
        {
            strategy.Log($"Retrait de {subElement.Name}");
        }
    }
}

using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSDatabase.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AmortizationOS
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IChartOfAccountStorage, ChartOfAccountStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ChartOfAccountBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMOLStorage, MOLStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MOLBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISubdivisionStorage, SubdivisionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SubdivisionBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOSStorage, OSStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OSBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAmortizationStorage, AmortizationStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AmortizationBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITransactionsJournalStorage, TransactionsJournalStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TransactionsJournalBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BackUpAbstractLogic, BackUpLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}

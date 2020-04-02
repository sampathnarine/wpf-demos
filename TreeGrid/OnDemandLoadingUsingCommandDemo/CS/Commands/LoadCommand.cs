using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnDemandLoading.Commands
{
    class LoadCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            TreeNode node = (parameter as TreeNode);
            EmployeeInfo emp = node.Item as EmployeeInfo;
            if (emp != null)
                if (emp.ReportsTo == -1 || emp.ReportsTo == 34 || emp.ReportsTo == 36 || emp.ReportsTo == 65)
                    return true;
            return false;
        }

        public void Execute(object parameter)
        {
            TreeNode node = (parameter as TreeNode);

            EmployeeInfo emp = node.Item as EmployeeInfo;
            if (emp != null)
            {
                node.PopulateChildNodes((App.Current.MainWindow.DataContext as ViewModel).GetReportees(emp.ID));
            }
        }
    }
}

#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using OnDemandLoading;
using System.Windows.Input;
using OnDemandLoading.Commands;

namespace OnDemandLoading
{
    public class ViewModel : NotificationObject
    {
        public ICommand CommandLoad
        { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>

        public ViewModel()
        {
            CommandLoad = new LoadCommand();
            EmployeeDetails = new List<EmployeeInfo>();
            EmployeeDetails.Add(new EmployeeInfo() { FirstName = "Hwakin", ID = 65, LastName = "Grant", Title = "Business Manager", Salary = 200000, ReportsTo = -1 });
            EmployeeDetails.Add(new EmployeeInfo() { FirstName = "Madison", ID = 34, LastName = "Bush", Title = "Vice President", Salary = 200000, ReportsTo = -1 });
            EmployeeDetails.Add(new EmployeeInfo() { FirstName = "Richard", ID = 36, LastName = "Monroe", Title = "HR Coordinator", Salary = 200000, ReportsTo = -1 });
            EmployeeDetails.Add(new EmployeeInfo() { FirstName = "Jack", ID = 43, LastName = "Madison", Title = "Supervisor", Salary = 25000, ReportsTo = 55 });
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public List<EmployeeInfo> EmployeeDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the reportees.
        /// </summary>
        /// <param name="bossID">The boss ID.</param>
        /// <returns></returns>
        public IEnumerable<EmployeeInfo> GetReportees(int bossID)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            if (bossID == 65)
            {
                list.Add(new EmployeeInfo() { FirstName = "John", ID = 5, LastName = "Polk", Title = "Marketing Specialist", Salary = 100000, ReportsTo = 65 });
                list.Add(new EmployeeInfo() { FirstName = "Bill", ID = 26, LastName = "Wilson", Title = "Senior Tool Designer", Salary = 100000, ReportsTo = 65 });
                list.Add(new EmployeeInfo() { FirstName = "Jimmy", ID = 23, LastName = "Harry", Title = "Stocker", Salary = 50000, ReportsTo = 65 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 68, LastName = "Coolidge", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 65 });
            }

            if (bossID == 34)
            {
                list.Add(new EmployeeInfo() { FirstName = "Franklin", ID = 24, LastName = "Madison", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 34 });
                list.Add(new EmployeeInfo() { FirstName = "William", ID = 66, LastName = "Nixon", Title = "Production Technician", Salary = 40000, ReportsTo = 34 });
                list.Add(new EmployeeInfo() { FirstName = "Grover", ID = 35, LastName = "Taft", Title = "Stocker", Salary = 50000, ReportsTo = 34 });
                list.Add(new EmployeeInfo() { FirstName = "Bill", ID = 18, LastName = "Nixon", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 34 });
            }

            if (bossID == 36)
            {
                list.Add(new EmployeeInfo() { FirstName = "Madison", ID = 64, LastName = "Franklin", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 36 });
                list.Add(new EmployeeInfo() { FirstName = "Wilson", ID = 67, LastName = "Harry", Title = "Production Technician", Salary = 40000, ReportsTo = 36 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 59, LastName = "Taft", Title = "Stocker", Salary = 50000, ReportsTo = 36 });
                list.Add(new EmployeeInfo() { FirstName = "Jimmy", ID = 08, LastName = "Grover", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 36 });
            }

            if (bossID == 5)
            {
                list.Add(new EmployeeInfo() { FirstName = "Franklin", ID = 47, LastName = "William", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 5 });
                list.Add(new EmployeeInfo() { FirstName = "Taft", ID = 52, LastName = "Peter", Title = "Production Technician", Salary = 40000, ReportsTo = 5 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 34, LastName = "Wilson", Title = "Stocker", Salary = 50000, ReportsTo = 5 });
                list.Add(new EmployeeInfo() { FirstName = "Grover", ID = 41, LastName = "John", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 5 });
            }

            if (bossID == 26)
            {
                list.Add(new EmployeeInfo() { FirstName = "Andrew", ID = 11, LastName = "Wilson", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 26 });
                list.Add(new EmployeeInfo() { FirstName = "George", ID = 24, LastName = "Madison", Title = "Production Technician", Salary = 40000, ReportsTo = 26 });
                list.Add(new EmployeeInfo() { FirstName = "Peter", ID = 33, LastName = "Taft", Title = "Stocker", Salary = 50000, ReportsTo = 26 });
                list.Add(new EmployeeInfo() { FirstName = "Jimmy", ID = 54, LastName = "Harry", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 26 });
            }

            if (bossID == 23)
            {
                list.Add(new EmployeeInfo() { FirstName = "Bush", ID = 98, LastName = "Bill", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 23 });
                list.Add(new EmployeeInfo() { FirstName = "Hayes", ID =32, LastName = "William", Title = "Production Technician", Salary = 40000, ReportsTo = 23 });
                list.Add(new EmployeeInfo() { FirstName = "Madison", ID = 12, LastName = "Franklin", Title = "Stocker", Salary = 50000, ReportsTo = 23 });
                list.Add(new EmployeeInfo() { FirstName = "Arthur", ID = 96, LastName = "Grover", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 23 });
            }

            if (bossID == 18)
            {
                list.Add(new EmployeeInfo() { FirstName = "Adams", ID = 71, LastName = "Reagan", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 18 });
                list.Add(new EmployeeInfo() { FirstName = "Nixon", ID = 92, LastName = "Tyler", Title = "Production Technician", Salary = 40000, ReportsTo = 18 });
                list.Add(new EmployeeInfo() { FirstName = "Coolidge", ID = 43, LastName = "Polk", Title = "Design Engineer", Salary = 50000, ReportsTo = 18 });
                list.Add(new EmployeeInfo() { FirstName = "George", ID = 84, LastName = "Harrison", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 18 });
            }




            if (bossID == 68)
            {
                list.Add(new EmployeeInfo() { FirstName = "Madison", ID = 125, LastName = "Bill", Title = "Marketing Specialist", Salary = 100000, ReportsTo = 68 });
                list.Add(new EmployeeInfo() { FirstName = "Nixon", ID = 226, LastName = "Wilson", Title = "Senior Tool Designer", Salary = 100000, ReportsTo = 68 });
                list.Add(new EmployeeInfo() { FirstName = "Taft", ID = 253, LastName = "Franklin", Title = "Stocker", Salary = 50000, ReportsTo = 68 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 618, LastName = "Coolidge", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 68 });
            }

            if (bossID == 24)
            {
                list.Add(new EmployeeInfo() { FirstName = "Franklin", ID = 244, LastName = "Madison", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 24 });
                list.Add(new EmployeeInfo() { FirstName = "William", ID = 166, LastName = "Nixon", Title = "Production Technician", Salary = 40000, ReportsTo = 24 });
                list.Add(new EmployeeInfo() { FirstName = "Grover", ID = 355, LastName = "Taft", Title = "Stocker", Salary = 50000, ReportsTo = 24 });
                list.Add(new EmployeeInfo() { FirstName = "Bill", ID = 148, LastName = "Harry", Title = "Production Superviser", Salary = 50000, ReportsTo = 24 });
            }

            if (bossID == 66)
            {
                list.Add(new EmployeeInfo() { FirstName = "Stogner", ID = 64, LastName = "Martin", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 66 });
                list.Add(new EmployeeInfo() { FirstName = "Wilson", ID = 67, LastName = "Harry", Title = "Production Technician", Salary = 40000, ReportsTo = 66 });
                list.Add(new EmployeeInfo() { FirstName = "Harrison", ID = 59, LastName = "Will", Title = "Stocker", Salary = 50000, ReportsTo = 66 });
                list.Add(new EmployeeInfo() { FirstName = "Jimmy", ID = 08, LastName = "Grover", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 66 });
            }

            if (bossID == 35)
            {
                list.Add(new EmployeeInfo() { FirstName = "Franklin", ID = 417, LastName = "William", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 35 });
                list.Add(new EmployeeInfo() { FirstName = "Taft", ID = 522, LastName = "Peter", Title = "Production Technician", Salary = 40000, ReportsTo = 35 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 341, LastName = "Wilson", Title = "Stocker", Salary = 50000, ReportsTo = 35 });
                list.Add(new EmployeeInfo() { FirstName = "Grover", ID = 141, LastName = "John", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 35 });
            }

            if (bossID == 64)
            {
                list.Add(new EmployeeInfo() { FirstName = "Andrew", ID = 141, LastName = "Wilson", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 64 });
                list.Add(new EmployeeInfo() { FirstName = "Will", ID = 244, LastName = "Madison", Title = "Production Technician", Salary = 40000, ReportsTo = 64 });
                list.Add(new EmployeeInfo() { FirstName = "Harrison", ID = 343, LastName = "Taft", Title = "Stocker", Salary = 50000, ReportsTo = 64 });
                list.Add(new EmployeeInfo() { FirstName = "Jimmy", ID = 544, LastName = "Harry", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 64 });
            }

            if (bossID == 67)
            {
                list.Add(new EmployeeInfo() { FirstName = "Bush", ID = 98, LastName = "Bill", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 67 });
                list.Add(new EmployeeInfo() { FirstName = "Hayes", ID = 32, LastName = "William", Title = "Production Technician", Salary = 40000, ReportsTo = 67 });
                list.Add(new EmployeeInfo() { FirstName = "Madison", ID = 12, LastName = "Franklin", Title = "Stocker", Salary = 50000, ReportsTo = 67 });
                list.Add(new EmployeeInfo() { FirstName = "Arthur", ID = 96, LastName = "Grover", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 67 });
            }

            if (bossID == 59)
            {
                list.Add(new EmployeeInfo() { FirstName = "Adams", ID = 711, LastName = "Reagan", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 59 });
                list.Add(new EmployeeInfo() { FirstName = "Nixon", ID = 192, LastName = "Tyler", Title = "Production Technician", Salary = 40000, ReportsTo = 59 });
                list.Add(new EmployeeInfo() { FirstName = "Coolidge", ID = 413, LastName = "Polk", Title = "Design Engineer", Salary = 50000, ReportsTo = 59 });
                list.Add(new EmployeeInfo() { FirstName = "George", ID = 841, LastName = "Harrison", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 59 });
            }

            if (bossID == 8)
            {
                list.Add(new EmployeeInfo() { FirstName = "William", ID = 71, LastName = "Bush", Title = "Quality Assurance Supervisor", Salary = 40000, ReportsTo = 8 });
                list.Add(new EmployeeInfo() { FirstName = "Harry", ID = 92, LastName = "Tyler", Title = "Production Technician", Salary = 40000, ReportsTo = 8 });
                list.Add(new EmployeeInfo() { FirstName = "Arthur", ID = 43, LastName = "Polk", Title = "Design Engineer", Salary = 50000, ReportsTo = 8 });
                list.Add(new EmployeeInfo() { FirstName = "George", ID = 84, LastName = "Harrison", Title = "Maintainence Superviser", Salary = 50000, ReportsTo = 8 });
            }

            return list;
        }
    }
}

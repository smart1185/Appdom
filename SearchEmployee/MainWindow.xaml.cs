using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model1 db = new Model1();
        public static Frame mf { get; set; }     

        public MainWindow()
        {
            InitializeComponent();

            mf = MainFrame;

            AppDomain AppExtended = AppDomain.CreateDomain("AppExtended");

            Assembly aInfo = Assembly.LoadFile(@"C:\Users\safha\Documents\Visual Studio 2015\Projects\SearchEmployee\ExtendedApp\bin\Debug\ExtendedApp.dll");

            Type extendedAppType = aInfo.GetTypes()[1];
            object app = Activator.CreateInstance(extendedAppType);
           

            MethodInfo myMethod = app.GetType().GetMethod("MenuItemCreateMethod");
            myMethod.Invoke(app, new object[] { miMainMenuApp });

            PropertyInfo piF = app.GetType().GetProperty("fm");
            piF.SetValue(app, mf);

           
            PropertyInfo collectionDB = app.GetType().GetProperty("emplListCollection");
            collectionDB.SetValue(app, db.EmployeesListDB);

            MethodInfo myMethod1 = app.GetType().GetMethod("menuItem1_Click");
            myMethod1.Invoke(app, new object[] { miMainMenuApp.Items[1], null });          

            AppDomain.Unload(AppExtended);
        }

        private void miMainMenuApp_Click(object sender, RoutedEventArgs e)
        {
            MainPage mp = new MainPage();
            MainWindow.mf.Source = new Uri("Pages/MainPage.xaml", UriKind.RelativeOrAbsolute);
            mf.NavigationService.Navigate(mp);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace ExtendedApp
{
    public class ExtendedAppPlagin : MarshalByRefObject
    {       
        private string input { get; set; }
        private string input1 { get; set; }
        private TextBox tbxInput { get; set; }
        private TextBox tbxInput2 { get; set; }
        private ListView lvEmployeeList { get; set; }

        //public DbSet<EmpListCollection> emplListCollection;
        public List<EmpListCollection> emplListCollection;

        public Frame fm;
       
        public void MenuItemCreateMethod(Menu mainMenu)
        {
            MenuItem menuItem1 = new MenuItem { Header = "Расширенный поиск" };

            menuItem1.Click += new RoutedEventHandler(menuItem1_Click);
            mainMenu.Items.Add(menuItem1);            
        }

        public void menuItem1_Click(object sender, RoutedEventArgs e)
        {
            FrameClass fc = new FrameClass(fm);   
                        
            Button btn1 = new Button
            {
                Content = "Поиск",
                Width = 150,
                Margin = new Thickness(5)  
            };

            btn1.Click += Btn1_Click;

            tbxInput = new TextBox
            {
                Name = "tbxInput",
                Width = 250,
                Margin = new Thickness(5)
            };

            Label lbl = new Label
            {
                Content = "Введите фамилию или имя сотрудника",
                Margin = new Thickness(3)
            };

            WrapPanel wp1 = new WrapPanel();
            wp1.Children.Add(btn1);
            wp1.Children.Add(tbxInput);
            wp1.Children.Add(lbl);

            Button btnSearch2 = new Button
            {
                Content = "Расширенный поиск",
                Width = 150,
                Margin = new Thickness(5)
            };

            btnSearch2.Click += BtnSearch2_Click;

            tbxInput2 = new TextBox
            {
                Name = "tbxInput2",
                Width = 250,
                Margin = new Thickness(5)
            };

            Label lbl1 = new Label
            {
                Content = "Введите email или номер телефона",
                Margin = new Thickness(3)
            };
             
            WrapPanel wp2 = new WrapPanel();
            wp2.Children.Add(btnSearch2);
            wp2.Children.Add(tbxInput2);
            wp2.Children.Add(lbl1);

            lvEmployeeList = new ListView();
            lvEmployeeList.ItemsSource = emplListCollection;
            GridView myGridView = new GridView();
            myGridView.AllowsColumnReorder = true;

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("EmployeeName");
            gvc1.Header = "Имя";
            gvc1.Width = 120;
            myGridView.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("LastName");
            gvc2.Header = "Фамилия";
            gvc2.Width = 120;
            myGridView.Columns.Add(gvc2);
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("Email");
            gvc3.Header = "Email";
            gvc3.Width = 250;
            myGridView.Columns.Add(gvc3);
            GridViewColumn gvc4 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("DateOfBirth");
            gvc3.Header = "Дата рождения";
            gvc3.Width = 120;
            myGridView.Columns.Add(gvc4);
            GridViewColumn gvc5 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("Phone");
            gvc3.Header = "Телефон";
            gvc3.Width = 180;
            myGridView.Columns.Add(gvc5);

            lvEmployeeList.View = myGridView;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30.0) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30.0) });
            grid.RowDefinitions.Add(new RowDefinition());

            grid.Children.Add(wp1);
            grid.Children.Add(wp2);
            grid.Children.Add(lvEmployeeList);

            Grid.SetRow(wp1, 0);
            Grid.SetRow(wp2, 1);
            Grid.SetRow(lvEmployeeList, 2);

            
            Page ap = new Page { Name = "ExtendedAppPage" };

            Uri u = new Uri(@"C:\Users\safha\Documents\Visual Studio 2015\Projects\SearchEmployee\SearchEmployee\Pages\ExtendedAppPage.xaml", UriKind.Absolute);
            fm.Source = u;
            fm.NavigationService.Navigate(ap);

            ap.Content = grid;
        }

        private void BtnSearch2_Click(object sender, RoutedEventArgs e)
        {
          
            input1 = tbxInput2.Text;

            var empList = emplListCollection.Where(f => f.Email == input1 || f.Phone == input1).ToList();
            lvEmployeeList.ItemsSource = empList;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            input = tbxInput.Text;

            var empList = emplListCollection.Where(f => f.LastName == input || f.EmployeeName == input).ToList();
            lvEmployeeList.ItemsSource = empList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace todolist
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ListBoxItem> ToDoThings;
        public MainWindow()
        {
            InitializeComponent();
            ToDoThings = new ObservableCollection<ListBoxItem>();

            LB.ItemsSource = ToDoThings;

            makeicon();
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            string newtask = TB.Text;
            if (newtask != "")
            {
                ListBoxItem nw = new ListBoxItem();
                nw.Content = newtask;
                
                ToDoThings.Add(nw);
                TB.Text = "";
            }
           
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isEmpty = !ToDoThings.Any();
            if (!isEmpty)
            {
                var buff = sender as ListBox;
                ListBoxItem ba = LB.Items[buff.SelectedIndex] as ListBoxItem;
                ba.IsEnabled = false;
            }
            else
            {
            }

        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            ToDoThings.Clear();
        }

        public void makeicon()
        {
            System.Windows.Forms.NotifyIcon nin = new System.Windows.Forms.NotifyIcon();
            nin.Icon = new System.Drawing.Icon("s.ico");
            nin.Visible = true;

            nin.MouseClick += new System.Windows.Forms.MouseEventHandler(iconclick);

            System.Windows.Forms.ContextMenu ninMenu = new System.Windows.Forms.ContextMenu();
            ninMenu.MenuItems.Add("Close App",new EventHandler(CloseApp));
            nin.ContextMenu = ninMenu;
        }
        
        private void iconclick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Show();
            WindowState = WindowState.Normal;
        }

                   
        private void CloseApp(object sender, EventArgs e)
        {
            MessageBox.Show("👋");
            Application.Current.Shutdown();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DynamicViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int i;
        private int j;
        private DynamicViewModel<Person> _personViewModel;
        private Person _person;
        public MainWindow()
        {
            InitializeComponent();
            _person = new Person() {Name = "Horst"};
            _personViewModel = new DynamicViewModel<Person>(_person);

            this.DataContext = _personViewModel;

            var thread1 = new Thread(() => DoThread1());
            thread1.Start();

            var thread2 = new Thread(() => DoThread2());
            thread2.Start();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            i = i++;            
            var result = _personViewModel;
        }

        private void DoThread1()
        {
            do
            {
                _personViewModel.TriggerUpdate("Name");
                Thread.Sleep(500);
            } while (true);
        }

        private void DoThread2()
        {
            do
            {
                j = j++;
                _person.Name = j.ToString();
                Thread.Sleep(500);
            } while (true);
        }
    }
}

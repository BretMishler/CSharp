using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyLogin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginButton.IsEnabled = false;
        //    var task = Task.Run(() => {

        //        Thread.Sleep(2000);

        //        return "Login Successful!";
        //    });

        //    // loginbutton.content = task.result here would lock the application
        //    // because task.result blocks until their is something to capture

        //    task.ContinueWith((t) => {
        //        if (t.IsFaulted)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                LoginButton.Content = "Login failed!";
        //                LoginButton.IsEnabled = true;
        //            });
        //        }
        //        else
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                LoginButton.Content = t.Result;
        //                LoginButton.IsEnabled = true;
        //            });
        //        }
        //    });
        //}

            // START: BOB AND I TESTING 
        private async Task<String> MyAsyncTask()
        {

            return "string";
        }

        private string aVoid()
        {
            return "np";
        }

        private Task<String> MyNonAsyncTask()
        {
            var myTask = new Task<string>(aVoid);
            var z = myTask;
            z.RunSynchronously();
            return z;
        }
            // END: BOB AND I TESTING

        // tells the compiler that this method has the ability to run asynchronous code
        private async void LoginButton_Click(object send, RoutedEventArgs e)
        {
            //Thread.Sleep(2000);


            //var res3 = MyAsyncTask();
            //var s = await res3;

            //var x = MyNonAsyncTask();
            //x.RunSynchronously();
            //var y = await MyNonAsyncTask();
            //var z = MyNonAsyncTask().Result;

            try
            {
                LoginButton.IsEnabled = false;
                BusyIndicator.Visibility = Visibility.Visible;

                var result = await LoginAsync();

                LoginButton.Content = result;

                LoginButton.IsEnabled = true;
                BusyIndicator.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                LoginButton.Content = "Internal Error!";
            }
        }

        // marking a method as an async task (as opposed to async Task<T>) means run a method as an async operation but do not return a value
        private async Task<string> LoginAsync()
        {
            try
            {
                var loginTask = Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    return "Login Successful";
                });

                var logTask = Task.Delay(2000);

                var purchaseTask = Task.Delay(1000);

                await Task.WhenAll(loginTask, logTask, purchaseTask);

                // Result will block, but we already have the value from Task.WhenAll
                return loginTask.Result;
            }
            catch(Exception)
            {
                return "Login failed!";
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Shapes;

using Tobii.Interaction;

namespace tablero_mateo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Host host;
        public VirtualWindowsAgent virtualWindowsAgent;

        public Stopwatch timer;
        public int currBtn;

        private Tobii.Interaction.Rectangle bounds1;
        private Tobii.Interaction.VirtualWindowBase win1;
        private Tobii.Interaction.VirtualInteractorAgent agent1;

        private Tobii.Interaction.Rectangle bounds2;
        private Tobii.Interaction.VirtualWindowBase win2;
        private Tobii.Interaction.VirtualInteractorAgent agent2;





        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            InitializeComponent();

            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new Stopwatch();
            host = new Host();
            virtualWindowsAgent = host.InitializeVirtualWindowsAgent();

            #region initialize_buttons
            // Button 1
            bounds1 = GetItemBounds(btn1);
            win1 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window1", bounds1).Result;
            agent1 = host.InitializeVirtualInteractorAgent(win1.Id);
            agent1
                .AddInteractorFor(bounds1)
                .WithGazeAware()
                .HasGaze(() => btnEnter(1))
                .LostGaze(() => btnLeave(1));

            // Button 2
            bounds2 = GetItemBounds(btn2);
            win2 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window2", bounds2).Result;
            agent2 = host.InitializeVirtualInteractorAgent(win2.Id);
            agent2
                .AddInteractorFor(bounds2)
                .WithGazeAware()
                .HasGaze(() => btnEnter(2))
                .LostGaze(() => btnLeave(2));

            // Button 3
            Tobii.Interaction.Rectangle bounds3 = GetItemBounds(btn3);
            var win3 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window3", bounds3).Result;
            var agent3 = host.InitializeVirtualInteractorAgent(win3.Id);
            agent3
                .AddInteractorFor(bounds3)
                .WithGazeAware()
                .HasGaze(() => btnEnter(3))
                .LostGaze(() => btnLeave(3));

            // Button 4
            Tobii.Interaction.Rectangle bounds4 = GetItemBounds(btn4);
            var win4 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window4", bounds4).Result;
            var agent4 = host.InitializeVirtualInteractorAgent(win4.Id);
            agent4
                .AddInteractorFor(bounds4)
                .WithGazeAware()
                .HasGaze(() => btnEnter(4))
                .LostGaze(() => btnLeave(4));

            // Button 5
            Tobii.Interaction.Rectangle bounds5 = GetItemBounds(btn5);
            var win5 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window5", bounds5).Result;
            var agent5 = host.InitializeVirtualInteractorAgent(win5.Id);
            agent5
                .AddInteractorFor(bounds5)
                .WithGazeAware()
                .HasGaze(() => btnEnter(5))
                .LostGaze(() => btnLeave(5));

            // Button 6
            Tobii.Interaction.Rectangle bounds6 = GetItemBounds(btn6);
            var win6 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window6", bounds6).Result;
            var agent6 = host.InitializeVirtualInteractorAgent(win6.Id);
            agent6
                .AddInteractorFor(bounds6)
                .WithGazeAware()
                .HasGaze(() => btnEnter(6))
                .LostGaze(() => btnLeave(6));

            // Button 7
            Tobii.Interaction.Rectangle bounds7 = GetItemBounds(btn7);
            var win7 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window7", bounds7).Result;
            var agent7 = host.InitializeVirtualInteractorAgent(win7.Id);
            agent7
                .AddInteractorFor(bounds7)
                .WithGazeAware()
                .HasGaze(() => btnEnter(7))
                .LostGaze(() => btnLeave(7));

            // Button 8
            Tobii.Interaction.Rectangle bounds8 = GetItemBounds(btn8);
            var win8 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window8", bounds8).Result;
            var agent8 = host.InitializeVirtualInteractorAgent(win8.Id);
            agent8
                .AddInteractorFor(bounds8)
                .WithGazeAware()
                .HasGaze(() => btnEnter(8))
                .LostGaze(() => btnLeave(8));

            // Button 9
            Tobii.Interaction.Rectangle bounds9 = GetItemBounds(btn9);
            var win9 = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("window9", bounds9).Result;
            var agent9 = host.InitializeVirtualInteractorAgent(win9.Id);
            agent9
                .AddInteractorFor(bounds9)
                .WithGazeAware()
                .HasGaze(() => btnEnter(9))
                .LostGaze(() => btnLeave(9));
            #endregion

            timer = new Stopwatch();
            timer.Start();
        }

        private void btnEnter(int btn)
        {
            currBtn = btn;
            timer.Restart();
            
           

        }
        private void btnLeave(int btn)
        {
            currBtn = 0;
            timer.Reset();
            

        }
        private void addText(string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                Dialog.Text += text;
            });
        }

        #region Helpers
        private static Tobii.Interaction.Rectangle GetItemBounds(ContentControl item)
        {
            Point pos = item.TransformToAncestor(Application.Current.MainWindow)
                          .Transform(new Point(0, 0));
            double width = item.ActualWidth;
            double height = item.ActualHeight;
            return new Tobii.Interaction.Rectangle((int)pos.X, (int)pos.Y, (int)width, (int)height);
        }

        #endregion
    }
}
using System;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BigVisibleCruise
{

    public partial class HumaneMessageWindow : System.Windows.Window
    {

        delegate void VoidDelegate();

        private HumaneMessageWindow(string message)
        {
            InitializeComponent();
            Message.Text = message;
        }

        private HumaneMessageWindow(string message, TimeSpan maxDuration) : this(message)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = maxDuration;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CloseWithFade();
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            CloseWithFade();
        }

        public void CloseWithFade()
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new VoidDelegate(delegate
            {
                Storyboard story = (Storyboard)this.FindResource("FadeAway");
                story.Completed += new EventHandler(FadeAway_Completed);
                this.BeginStoryboard(story);
            }));
        }

        void FadeAway_Completed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new VoidDelegate(Close));
        }





        public static HumaneMessageWindow Show(String message)
        {
            HumaneMessageWindow humaneWindow = new HumaneMessageWindow(message);
            humaneWindow.Show();
            humaneWindow.Focus();
            return humaneWindow;
        }

        public static HumaneMessageWindow Show(String message, TimeSpan maxDuration)
        {
            HumaneMessageWindow humaneWindow = new HumaneMessageWindow(message, maxDuration);
            humaneWindow.Show();
            humaneWindow.Focus();
            return humaneWindow;
        }


    }
}
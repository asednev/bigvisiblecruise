using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BigVisibleCruise
{
	public partial class HumaneMessageWindow : Window
	{
		private HumaneMessageWindow(string message)
		{
			InitializeComponent();
			Message.Text = message;
		}

		private HumaneMessageWindow(string message, TimeSpan maxDuration) : this(message)
		{
			var timer = new DispatcherTimer();
			timer.Interval = maxDuration;
			timer.Tick += Timer_Tick;
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
			Dispatcher.Invoke(DispatcherPriority.Normal, new VoidDelegate(delegate
			                                                              {
			                                                              	var story =
			                                                              		(Storyboard)
			                                                              		FindResource("FadeAway");
			                                                              	story.Completed +=
			                                                              		FadeAway_Completed;
			                                                              	BeginStoryboard(story);
			                                                              }));
		}

		private void FadeAway_Completed(object sender, EventArgs e)
		{
			Dispatcher.Invoke(DispatcherPriority.Normal, new VoidDelegate(Close));
		}


		public static HumaneMessageWindow Show(String message)
		{
			var humaneWindow = new HumaneMessageWindow(message);
			humaneWindow.Show();
			humaneWindow.Focus();
			return humaneWindow;
		}

		public static HumaneMessageWindow Show(String message, TimeSpan maxDuration)
		{
			var humaneWindow = new HumaneMessageWindow(message, maxDuration);
			humaneWindow.Show();
			humaneWindow.Focus();
			return humaneWindow;
		}

		#region Nested type: VoidDelegate

		private delegate void VoidDelegate();

		#endregion
	}
}

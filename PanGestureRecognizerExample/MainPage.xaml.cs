using System.Diagnostics;

namespace PanGestureRecognizerExample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            this.DisplayAlert("Tapped!", "User has tapped!", "Ok");
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            Debug.WriteLine("PanUpdated with status: " + e.StatusType);
            if (e.StatusType == GestureStatus.Started)
            {
                panStatusLabel.IsVisible = true;
            }

            if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
            {
                panStatusLabel.IsVisible = false;
            }
        }
    }
}
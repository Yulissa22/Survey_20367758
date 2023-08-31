namespace Survey_20367758;

public partial class SurveysView : ContentPage
{
	public SurveysView()
	{
		InitializeComponent();
		MessagingCenter.Subscribe<ContentPage, Surveys>(this, Messages.NewSuveyComplete, (sender, args) =>
		{
			SurveysPanel.Children.Add(new Label() { Text = args.ToString() });
		});
	}

	private async void AddSurvey_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SurveysDetailsViews());
    }
}
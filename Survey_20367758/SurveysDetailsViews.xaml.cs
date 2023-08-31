namespace Survey_20367758;

public partial class SurveysDetailsViews : ContentPage
{
	private readonly string[] teams =
	{
		"Argentina",
		"Bacelona",
		"Brasil",
		"Alianza",
		"Aguila",
		"Jocoro",
		"Fas",
		"Patronato",
		"Inter Miami CF",
		"Manchester city",
		"Juventus",
		"Paris"
	};
	public SurveysDetailsViews()
	{
		InitializeComponent();
	}

	private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
	{
		var FavoriteTeam = await DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, teams);
		if (!string.IsNullOrWhiteSpace(FavoriteTeam))
		{
			FavoriteTeamLabel.Text = FavoriteTeam;
		}
    }

	private async void OkButton_Clicked(object sender, EventArgs e)
	{
		//Evaluamos si los datos están completos
		if(string.IsNullOrWhiteSpace(NameEntry.Text)|| string.IsNullOrWhiteSpace(FavoriteTeamLabel.Text))
		{
			return;
		}
		//Creamos el nuevo objeto de tipo Survey
		var newSurvey = new Surveys()
		{
			Name = NameEntry.Text,
			Birthdate = BirthdatePicker.Date,
			FavoriteTeam = FavoriteTeamLabel.Text
		};

		//Publicamos el mensaje con el objeto de encuesta como argumento 
		MessagingCenter.Send((ContentPage)this,
		Messages.NewSuveyComplete, newSurvey);

		//Removemos la pagina de la pila de navegacion para regresar inmediatamente
		await Navigation.PopAsync();
    }
}
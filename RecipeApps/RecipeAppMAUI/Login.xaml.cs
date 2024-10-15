using RecipeSystem;

namespace RecipeAppMAUI;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        LoginBtn.Clicked += LoginBtn_Clicked;
        CancelBtn.Clicked += CancelBtn_Clicked;
	}

    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            ErrorLbl.Text = "";
            DBManager.SetConnString(App.ConnStringSetting, true, UserNameTxt.Text, PasswordTxt.Text);
            App.LoggedIn = true;
            await Navigation.PopModalAsync();
        } 
        catch (Exception ex)
        {
            ErrorLbl.Text = ex.ToString();
        }
    }

    private void CancelBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

}
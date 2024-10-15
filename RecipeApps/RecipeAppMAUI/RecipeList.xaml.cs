using RecipeSystem;
using System.Data;

namespace RecipeAppMAUI;

public partial class RecipeList : ContentPage
{
	public RecipeList()
	{
		InitializeComponent();
        SearchBtn.Clicked += SearchBtn_Clicked;
	}

    private void SearchRecipes()
    {
        DataTable dt = RecipeProject.GetAnyDataTable("RecipeGet", ("@RecipeName", RecipeNameTxt.Text));
        RecipesLst.ItemsSource = dt.Rows;
    }

    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
        SearchRecipes();
    }
}
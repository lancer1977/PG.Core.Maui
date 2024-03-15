
namespace PolyhydraGames.Core.Maui.Interfaces;

public interface IApp
{
    Page? MainPage { get; }
    Page? DetailPage { get; }
    NavigationPage? NavigationPage { get; }

    INavigation Navigation { get; }
    void SetDetailPage(Page navigationPage);
    Page GetNavigationPage(Page page);
}
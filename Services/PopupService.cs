using CommunityToolkit.Maui.Views;
using HomeAutomationMaui.Interfaces;

namespace HomeAutomationMaui.Services
{
    public class PopupService : IPopupService
    {
        public void ShowPopup(Popup popup)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
            page.ShowPopup(popup);
        }
    }
}

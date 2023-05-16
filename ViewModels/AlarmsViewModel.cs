using CommunityToolkit.Mvvm.Input;
using Plugin.LocalNotification;

namespace HomeAutomationMaui.ViewModels
{
    public partial class AlarmsViewModel : BaseViewModel
    {
        public AlarmsViewModel()
        {
            Title = "Alarmy";

            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }

        private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        {
            if(e.IsDismissed)
            {

            }
            else if(e.IsTapped)
            {

            }
        }

        [RelayCommand]
        public async Task InvokeNotification()
        {
            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "This a test notification",
                Subtitle = "This is test subtitle",
                Description = "This is test description",
                BadgeNumber = 42,
                CategoryType = NotificationCategoryType.Alarm,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                   
                }               
            };

           await LocalNotificationCenter.Current.Show(request);
        }

    }
}

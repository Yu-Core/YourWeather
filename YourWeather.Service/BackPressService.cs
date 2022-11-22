
namespace YourWeather.Service
{
    public class BackPressService
    {
        public BackPressService()
        {
            for (int i = 0; i < 10; i++)
            {
                DialogsState.Add(false);
            }
        }
        public bool HasDialogsOpen => DialogsState.Where(it => it == true).Count() > 0;

        public List<bool> DialogsState { get; set; } = new List<bool>();

        public event Action? OnBackPressChanged;

        public void NotifyBackPressChanged()
        {
            for (int i = 0; i < DialogsState.Count; i++)
            {
                DialogsState[i] = false;
            }
            OnBackPressChanged?.Invoke();
        }
    }
}

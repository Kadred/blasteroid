using System;

namespace GUI
{
    public interface IGUIScreen
    {
        event Action onShown;
        event Action onHidden;

        void Show();

        void Hide();
    }
}
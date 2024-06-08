using System.Windows;

namespace DDD3.UI.Services;
public interface IMessageService
{
    void ShowDialog(string message);
    MessageBoxResult Question(string message);
}

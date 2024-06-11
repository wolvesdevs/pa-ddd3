using System.Windows;

namespace DDDNET8.WPF.Services;
public interface IMessageService
{
    void ShowDialog(string message);
    MessageBoxResult Question(string message);
}

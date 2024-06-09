namespace DDD3.UI.ViewModels;
public sealed class ComboBoxViewModel
{
    public int Value { get; }
    public string DisplayValue { get; }

    public ComboBoxViewModel(int value, string displayValue)
    {
        Value = value;
        DisplayValue = displayValue;
    }
}

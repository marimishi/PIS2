using System.Windows.Forms;

namespace PIS
{
    public interface IForm
    {
        TextBox surnameTextBox { get; }
        TextBox nameTextBox { get; }
        TextBox fathernameTextBox { get; }
        ComboBox birthDayComboBox { get; }
        ComboBox birthMonthComboBox { get; }
        ComboBox birthYearComboBox { get; }
        TextBox phoneTextBox { get; }
        TextBox emailTextBox { get; }
        ComboBox purposeOfVisitComboBox { get; }

        Label surnameWarningLabel { get; }
        Label nameWarningLabel { get; }
        Label fathernameWarningLabel { get; }
        Label phoneWarningLabel { get; }
        Label emailWarningLabel { get; }
    }
}

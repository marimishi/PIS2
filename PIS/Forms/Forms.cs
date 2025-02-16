

using System.Drawing;

namespace PIS
{
    public static class Forms
    {
        public static MainForm mainForm { get; set; }
        public static RegForm regForm { get; set; }
        public static AuthMainForm authMainForm { get; set; }
        public static AccountForm accountForm { get; set; }

        public static void EditSurname(Color textBoxtBackGroundColor, IForm form, string warningLabelText)
        {
            form.surnameTextBox.BackColor = textBoxtBackGroundColor;
            form.surnameWarningLabel.Text = warningLabelText;
        }
        public static void EditName(Color textBoxtBackGroundColor, IForm form, string warningLabelText)
        {
            form.nameTextBox.BackColor = textBoxtBackGroundColor;
            form.nameWarningLabel.Text = warningLabelText;
        }

        public static void EditFathername(Color textBoxtBackGroundColor, IForm form, string warningLabelText)
        {
            form.fathernameTextBox.BackColor = textBoxtBackGroundColor;
            form.fathernameWarningLabel.Text = warningLabelText;
        }

        public static void EditEmail(Color textBoxtBackGroundColor, IForm form, string warningLabelText)
        {
            form.emailTextBox.BackColor = textBoxtBackGroundColor;
            form.emailWarningLabel.Text = warningLabelText;
        }

        public static void EditPassword(Color textBoxtBackGroundColor, string warningLabelText)
        {
            regForm.password1TextBox.BackColor = textBoxtBackGroundColor;
            regForm.password2TextBox.BackColor = textBoxtBackGroundColor;
            regForm.passwordsWarningLabel.Text = warningLabelText;
        }

        public static void EditPhone(Color textBoxtBackGroundColor, IForm form, string warningLabelText)
        {
            form.phoneTextBox.BackColor = textBoxtBackGroundColor;
            form.phoneWarningLabel.Text = warningLabelText;
        }
    }
}

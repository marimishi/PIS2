using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace PIS
{
    public static class SystemController
    {
        public static User user;
        public static Map map;

        public static object[] months = new object[]
        {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Forms.mainForm = new MainForm();
            Application.Run(Forms.mainForm);
        }

        public static void ToRegistrationForm()
        {
            if (Forms.regForm == null)
                Forms.regForm = new RegForm();

            Forms.regForm.Show();
            Forms.mainForm.Hide();
        }

        public static void ToAuthMainForm(Form form)
        {
            ExamineMap();
            Forms.authMainForm = new AuthMainForm();
            Forms.authMainForm.Show();
            form.Hide();
        }

        public static void ToAccountForm()
        {
            if (Forms.accountForm == null)
                Forms.accountForm = new AccountForm();

            Forms.accountForm.Show();
            Forms.authMainForm.Hide();
        }

        public static void ToMainForm()
        {
            if (Forms.mainForm == null)
                Forms.mainForm = new MainForm();

            Forms.mainForm.Show();
            Forms.regForm.Hide();
        }

        public static void ExamineMap()
        {
            IRule[] rules = Rules.GetRules();
            Map map = new Map();

            for (int i = 0; i < rules.Length; i++)
            {
                if (rules[i].Check(user))
                {
                    string[] messages = rules[i].messages;

                    for (int j = 0; j < messages.Length; j++)
                        map.AddPoint(new MapPoint(messages[j], messages.Length, j));
                }
            }

            SystemController.map = map;
        }

        /*data verification*/
        #region
        private static bool EditUserDataVerification(string surname, string name, string fathers_name, string phone, string email)
        {
            bool flag = true;
            flag = CheckSurname(surname, Forms.accountForm);
            flag = CheckName(name, Forms.accountForm);
            flag = CheckFathername(fathers_name, Forms.accountForm);
            flag = CheckPhone(phone, Forms.accountForm);
            flag = CheckEmail(email, Forms.accountForm);
            return flag;
        }

        private static bool CreateUserDataVerification(string surname, string name, string fathers_name, string phone, string email, string visitpurpose, string password1, string password2)
        {
            bool flag = true;
            flag = CheckSurname(surname, Forms.regForm);
            flag = CheckName(name, Forms.regForm);
            flag = CheckFathername(fathers_name, Forms.regForm);
            flag = CheckPhone(phone, Forms.regForm);
            flag = CheckEmail(email, Forms.regForm);
            flag = CheckPassword(password1, password2);

            if (string.IsNullOrEmpty(visitpurpose))
            {
                flag = false;
                Forms.regForm.purposeOfVisitWarningLabel.Text = "Error";
            }
            else
            {
                Forms.regForm.purposeOfVisitWarningLabel.Text = "";
            }

            return flag;
        }

        private static bool CheckName(string name, IForm form)
        {
            if (name == "" || !NamesIsValid(name))
            {
                Forms.EditName(Color.LightPink, form, "Error");
                return false;
            }

            Forms.EditName(Color.White, form, "");
            return true;
        }

        private static bool CheckSurname(string surname, IForm form)
        {
            if (surname == "" || !NamesIsValid(surname))
            {
                Forms.EditSurname(Color.LightPink, form, "Error");
                return false;
            }

            Forms.EditSurname(Color.White, form, "");
            return true;
        }

        private static bool CheckFathername(string fathername, IForm form)
        {
            if (fathername == "" || !NamesIsValid(fathername))
            {
                Forms.EditFathername(Color.LightPink, form, "Error");
                return false;
            }

            Forms.EditFathername(Color.White, form, "");
            return true;
        }

        private static bool NamesIsValid(string name)
        {
            return Regex.IsMatch(name, @"^[А-Яа-яёЁ\s]+$");
        }

        private static bool CheckPhone(string phone, IForm form)
        {
            if (phone == "" || !Regex.IsMatch(phone, @"^(\+79\d{9}|\b89\d{9})$"))
            {
                Forms.EditPhone(Color.LightPink, form, "Error");
                return false;
            }

            Forms.EditPhone(Color.White, form, "");
            return true;
        }

        private static bool CheckEmail(string email, IForm form)
        {
            if (email == "" || !Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                Forms.EditEmail(Color.LightPink, form, "Error");
                return false;
            }

            Forms.EditEmail(Color.White, form, "");
            return true;
        }

        private static bool CheckPassword(string password1, string password2)
        {
            if (password1 == "" || password1 == "" || password1 != password2)
            {
                Forms.EditPassword(Color.LightPink, "Error");
                return false;
            }

            Forms.EditPassword(Color.White, "");
            return true;
        }
        #endregion

        public static void CreateUser(string surname, string name, string fathers_name, DateTime dateofbirth, string phone, string email, string visitpurpose, string password1, string password2)
        {
            if (CreateUserDataVerification(surname, name, fathers_name, phone, email, visitpurpose, password1, password2))
            {
                name = CorrectString(name);
                surname = CorrectString(surname);
                fathers_name = CorrectString(fathers_name);
                email = email.ToLower();

                User user = new User(surname, name, fathers_name, dateofbirth, phone, email, visitpurpose, password1);
                SystemController.user = user;
                ToAuthMainForm(Forms.regForm);
            }
        }

        public static string CorrectString(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static void EditUser(string surname, string name, string fathers_name, DateTime dateofbirth, string phone, string email, string visitpurpose)
        {
            if (EditUserDataVerification(surname, name, fathers_name, phone, email))
            {
                name = CorrectString(name);
                surname = CorrectString(surname);
                fathers_name = CorrectString(fathers_name);
                email = email.ToLower();

                user.surname = surname;
                user.name = name;
                user.fathers_name = fathers_name;
                user.dateofbirth = dateofbirth;
                user.phone = phone;
                user.email = email;
                user.visitpurpose = visitpurpose;
                Forms.accountForm.UpdateTextBoxes();
            }
        }

        public static void CloseApp()
        {
            Application.Exit();
        }

        public static int width => Screen.PrimaryScreen.Bounds.Width;
        public static int height => Screen.PrimaryScreen.Bounds.Height;
    }
}

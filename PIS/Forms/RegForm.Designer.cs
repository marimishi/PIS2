using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PIS
{
    partial class RegForm : IForm
    {
        private IContainer components = null;

        private Panel headerBackGround;
        private Panel regFormBackGround;

        private Button closeButton;
        private Button regButton;
        private Button closeRegButton;

        public TextBox surnameTextBox { get; set; }
        public TextBox nameTextBox { get; set; }
        public TextBox fathernameTextBox { get; set; }
        public ComboBox birthDayComboBox { get; set; }
        public ComboBox birthMonthComboBox { get; set; }
        public ComboBox birthYearComboBox { get; set; }
        public TextBox phoneTextBox { get; set; }
        public TextBox emailTextBox { get; set; }
        public ComboBox purposeOfVisitComboBox { get; set; }
        public TextBox password1TextBox { get; set; }
        public TextBox password2TextBox { get; set; }
        public CheckBox passwordCheckBox { get; set; }

        private Label surnameLabel;
        private Label nameLabel;
        private Label fathernameLabel;
        private Label birthdayLabel;
        private Label phoneLabel;
        private Label emailLabel;
        private Label purposeOfVisitLabel;
        private Label password1Label;
        private Label password2Label;
        private Label passwordCheckBoxLabel;

        public Label surnameWarningLabel { get; set; }
        public Label nameWarningLabel { get; set; }
        public Label fathernameWarningLabel { get; set; }
        public Label phoneWarningLabel { get; set; }
        public Label emailWarningLabel { get; set; }
        public Label purposeOfVisitWarningLabel { get; set; }
        public Label passwordsWarningLabel { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            CreateCloseButton();
            CreateCloseRegButton();
            CreateRegButton();
            CreateRegForm();
            CreateDesign();
        }

        private void ScreenOptions()
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateHeaderBackColor()
        {
            headerBackGround = Samples.CreateHeaderBackGround();
            Controls.Add(headerBackGround);
        }

        private void CreateDesign()
        {
            BackColor = Color.FromArgb(192, 240, 247);
            CreateHeaderBackColor();
            ScreenOptions();
        }

        private void CreateCloseButton()
        {
            closeButton = Samples.CreateCloseButton();
            closeButton.Click += CloseButton_Click;
            Controls.Add(closeButton);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            SystemController.CloseApp();
        }

        private void CreateCloseRegButton()
        {
            closeRegButton = Samples.CreateCloseRegOrAccButton();
            closeRegButton.Click += CloseRegButton_Click;
            Controls.Add(closeRegButton);
        }

        private void CloseRegButton_Click(object sender, EventArgs e)
        {
            SystemController.ToMainForm();
        }

        private void CreateRegButton()
        {
            regButton = new Button
            {
                Text = "Зарегистрировать",
                Size = new Size(width / 12, height / 24),
                Location = new Point(4 * width / 7, 5 * height / 6 - width / 84),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            regButton.Click += RegButton_Click;
            Controls.Add(regButton);
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            string surname = surnameTextBox.Text;
            string name = nameTextBox.Text;
            string fathers_name = fathernameTextBox.Text;
            DateTime birthDate = new DateTime(birthYearComboBox.SelectedIndex + 1924, birthMonthComboBox.SelectedIndex + 1, birthDayComboBox.SelectedIndex + 1);
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;
            string visitpurpose = purposeOfVisitComboBox.Text;
            string password1 = password1TextBox.Text;
            string password2 = password2TextBox.Text;

            SystemController.CreateUser(surname, name, fathers_name, birthDate, phone, email, visitpurpose, password1, password2);
        }

        private void CreateRegForm()
        {
            CreateRegFormTextBoxes();
            CreateRegFormLabels();
            CreateWarningLabels();
            CreateRegFormBackGround();
        }

        private void CreateRegFormBackGround()
        {
            regFormBackGround = Samples.CreateRegAndAccountBackGround();
            Controls.Add(regFormBackGround);
        }

        private void CreateRegFormTextBoxes()
        {
            int xLoc = 3 * width / 8;
            int yLoc = 3 * height / 10;
            int y = height / 18;

            surnameTextBox = Samples.CreateTextBox(0);
            Controls.Add(surnameTextBox);

            nameTextBox = Samples.CreateTextBox(1);
            Controls.Add(nameTextBox);

            fathernameTextBox = Samples.CreateTextBox(2);
            Controls.Add(fathernameTextBox);

            int birthDayLocY = yLoc + 3 * y;
            int h = height / 128;

            birthMonthComboBox = new ComboBox
            {
                Size = new Size(7 * width / 128, h),
                Location = new Point(105 * width / 256, birthDayLocY),
                DropDownWidth = width / 10,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            birthMonthComboBox.Items.AddRange(SystemController.months);
            birthMonthComboBox.SelectedIndex = 0;
            birthMonthComboBox.SelectedIndexChanged += birthMonthAndYearComboBox_SelectedIndexChanged;
            Controls.Add(birthMonthComboBox);

            birthDayComboBox = new ComboBox
            {
                Size = new Size(width / 32, h),
                Location = new Point(xLoc, yLoc + 3 * y),
                DropDownWidth = width / 24,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            for (int day = 1; day <= 31; day++)
                birthDayComboBox.Items.Add(day);
            birthDayComboBox.SelectedIndex = 0;
            Controls.Add(birthDayComboBox);

            birthYearComboBox = new ComboBox
            {
                Size = new Size(11 * width / 224, h),
                Location = new Point(15 * width / 32, birthDayLocY),
                DropDownWidth = width / 12,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            for (int i = 0; i <= 100; i++) 
                birthYearComboBox.Items.Add(i + 1924);
            birthYearComboBox.SelectedIndex = 100;
            birthYearComboBox.SelectedIndexChanged += birthMonthAndYearComboBox_SelectedIndexChanged;
            Controls.Add(birthYearComboBox);

            phoneTextBox = Samples.CreateTextBox(4);
            phoneTextBox.TextChanged += phoneNumberTextBox_TextChanged;
            Controls.Add(phoneTextBox);

            emailTextBox = Samples.CreateTextBox(5);
            Controls.Add(emailTextBox);

            purposeOfVisitComboBox = new ComboBox
            {
                Size = new Size(width / 7, height / 128),
                Location = new Point(xLoc, yLoc + 6 * y),
                DropDownWidth = 3 * width / 8,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            purposeOfVisitComboBox.Items.AddRange(new string[]
            {
                "Участвую в государственной программе",
                "Отметка в качестве участника Государственной программы переселения соотечественников"
            });
            Controls.Add(purposeOfVisitComboBox);

            password1TextBox = Samples.CreateTextBox(7);
            Controls.Add(password1TextBox);

            password2TextBox = Samples.CreateTextBox(8);
            Controls.Add(password2TextBox);

            passwordCheckBox = new CheckBox
            {
                Location = new Point(xLoc, yLoc + 9 * y - height / 36),
                BackColor = Color.DeepSkyBlue
            };
            passwordCheckBox.Size = new Size(passwordCheckBox.Size.Width / 5, passwordCheckBox.Size.Height);
            passwordCheckBox.CheckedChanged += passwordCheckBox_CheckedChanged;
            Controls.Add(passwordCheckBox);
    }

        private void birthMonthAndYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDay = birthDayComboBox.SelectedIndex;
            int selectedMonth = birthMonthComboBox.SelectedIndex + 1;
            int daysInMonth = DateTime.DaysInMonth(birthYearComboBox.SelectedIndex + 1924, selectedMonth);

            birthDayComboBox.Items.Clear();

            for (int day = 1; day <= daysInMonth; day++)
                birthDayComboBox.Items.Add(day);

            if (selectedDay > (daysInMonth - 1))
                birthDayComboBox.SelectedIndex = daysInMonth - 1;
            else
                birthDayComboBox.SelectedIndex = selectedDay;
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheckBox.Checked)
            {
                password1TextBox.PasswordChar = '●';
                password2TextBox.PasswordChar = '●';
            }
            else
            {
                password1TextBox.PasswordChar = '\0';
                password2TextBox.PasswordChar = '\0';
            }
        }

        private void phoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (phoneTextBox.Text.StartsWith("89"))
            {
                phoneTextBox.MaxLength = 11;
            }
            else if (phoneTextBox.Text.StartsWith("+79"))
            {
                phoneTextBox.MaxLength = 12;
            }
        }

        private void CreateRegFormLabels()
        {
            int yLoc = 3 * height / 10;

            surnameLabel = Samples.CreateLabel(0, "Фамилия");
            Controls.Add(surnameLabel);

            nameLabel = Samples.CreateLabel(1, "Имя");
            Controls.Add(nameLabel);

            fathernameLabel = Samples.CreateLabel(2, "Отчество");
            Controls.Add(fathernameLabel);

            birthdayLabel = Samples.CreateLabel(3, "Дата рождения");
            Controls.Add(birthdayLabel);

            phoneLabel = Samples.CreateLabel(4, "Номер телефона");
            Controls.Add(phoneLabel);

            emailLabel = Samples.CreateLabel(5, "Почта");
            Controls.Add(emailLabel);

            purposeOfVisitLabel = Samples.CreateLabel(6, "Цель визита");
            Controls.Add(purposeOfVisitLabel);

            password1Label = Samples.CreateLabel(7, "Пароль");
            Controls.Add(password1Label);

            password2Label = Samples.CreateLabel(8, "Повторите пароль");
            Controls.Add(password2Label);

            passwordCheckBoxLabel = Samples.CreateLabel(0, "");
            passwordCheckBoxLabel.Text = "Скрывать пароль";
            passwordCheckBoxLabel.Location = new Point(3 * width / 8 + passwordCheckBox.Size.Width, 3 * height / 10 + 17 * height / 36);
            Controls.Add(passwordCheckBoxLabel);
        }

        private void CreateWarningLabels()
        {
            surnameWarningLabel = Samples.CreateWarningLabel(0);
            Controls.Add(surnameWarningLabel);

            nameWarningLabel = Samples.CreateWarningLabel(1);
            Controls.Add(nameWarningLabel);

            fathernameWarningLabel = Samples.CreateWarningLabel(2);
            Controls.Add(fathernameWarningLabel);

            phoneWarningLabel = Samples.CreateWarningLabel(4);
            Controls.Add(phoneWarningLabel);

            emailWarningLabel = Samples.CreateWarningLabel(5);
            Controls.Add(emailWarningLabel);

            purposeOfVisitWarningLabel = Samples.CreateWarningLabel(6);
            Controls.Add(purposeOfVisitWarningLabel);

            passwordsWarningLabel = Samples.CreateWarningLabel(8);
            Controls.Add(passwordsWarningLabel);
        }

        private int width => SystemController.width;
        private int height => SystemController.height;
    }
}


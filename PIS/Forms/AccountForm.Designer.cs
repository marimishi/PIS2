using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PIS
{
    partial class AccountForm : IForm
    {
        private IContainer components = null;

        private Panel headerBackGround;
        private Panel accountBackColor;

        private Button closeButton;
        private Button closeAccountButton;
        private Button editAccountButton;
        private Button saveAccountButton;

        public TextBox surnameTextBox { get; set; }
        public TextBox nameTextBox { get; set; }
        public TextBox fathernameTextBox { get; set; }
        public ComboBox birthDayComboBox { get; set; }
        public ComboBox birthMonthComboBox { get; set; }
        public ComboBox birthYearComboBox { get; set; }
        public TextBox phoneTextBox { get; set; }
        public TextBox emailTextBox { get; set; }
        public ComboBox purposeOfVisitComboBox { get; set; }

        private Label surnameLabel;
        private Label nameLabel;
        private Label fathernameLabel;
        private Label birthdayLabel;
        private Label phoneLabel;
        private Label emailLabel;
        private Label purposeOfVisitLabel;

        public Label surnameWarningLabel { get; set; }
        public Label nameWarningLabel { get; set; }
        public Label fathernameWarningLabel { get; set; }
        public Label phoneWarningLabel { get; set; }
        public Label emailWarningLabel { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            CreateButtons();
            CreateAccount();
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

        private void CreateButtons()
        {
            CreateCloseAccountButton();
            CreateEditAccountButton();
            CreateSaveAccountButton();
            CreateCloseButton();
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

        private void CreateAccount()
        {
            CreateAccountTextBoxes();
            CreateAccountLabels();
            CreateWarningLabels();
            CreateAccountBackGround();
        }

        private void CreateCloseAccountButton()
        {
            closeAccountButton = Samples.CreateCloseRegOrAccButton();
            closeAccountButton.Click += CloseAccountButton_Click;
            Controls.Add(closeAccountButton);
        }

        private void CloseAccountButton_Click(object sender, EventArgs e)
        {
            SystemController.ToAuthMainForm(this);
        }

        private void CreateEditAccountButton()
        {
            editAccountButton = new Button
            {
                Text = "Редактировать",
                Size = new Size(width / 12, height / 24),
                Location = new Point(4 * width / 7, 5 * height / 6 - width / 84),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            editAccountButton.Click += EditAccountButton_Click;
            Controls.Add(editAccountButton);
        }

        private void CreateSaveAccountButton()
        {
            saveAccountButton = new Button
            {
                Text = "Сохранить",
                Size = new Size(width / 12, height / 24),
                Location = new Point(10 * width / 21, 5 * height / 6 - width / 84),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            saveAccountButton.Click += SaveEditButton_Click;
            Controls.Add(saveAccountButton);
            saveAccountButton.Hide();
            saveAccountButton.Enabled = false;
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            nameTextBox.ReadOnly = false;
            surnameTextBox.ReadOnly = false;
            fathernameTextBox.ReadOnly = false;

            int daysInMonth = DateTime.DaysInMonth(user.dateofbirth.Year, user.dateofbirth.Month);

            birthMonthComboBox.Items.Clear();
            birthMonthComboBox.Items.AddRange(SystemController.months);
            birthMonthComboBox.SelectedIndex = user.dateofbirth.Month - 1;

            birthDayComboBox.Items.Clear();
            for (int day = 1; day <= daysInMonth; day++)
                birthDayComboBox.Items.Add(day);
            birthDayComboBox.SelectedIndex = user.dateofbirth.Day - 1;

            birthYearComboBox.Items.Clear();
            for (int i = 0; i <= 100; i++)
                birthYearComboBox.Items.Add(i + 1924);
            birthYearComboBox.SelectedIndex = user.dateofbirth.Year - 1924;

            birthMonthComboBox.SelectedIndexChanged += birthMonthYearComboBox_SelectedIndexChanged;
            birthYearComboBox.SelectedIndexChanged += birthMonthYearComboBox_SelectedIndexChanged;

            phoneTextBox.ReadOnly = false;
            emailTextBox.ReadOnly = false; ;
            
            purposeOfVisitComboBox.Items.Clear();
            purposeOfVisitComboBox.Items.AddRange(new string[]
            {
                "Участвую в государственной программе",
                "Отметка в качестве участника Государственной программы переселения соотечественников"
            });
            purposeOfVisitComboBox.SelectedItem = user.visitpurpose;

            saveAccountButton.Enabled = true;
            saveAccountButton.Show();
            editAccountButton.Enabled = false;
        }

        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            string surname = surnameTextBox.Text;
            string name = nameTextBox.Text;
            string fathers_name = fathernameTextBox.Text;
            DateTime birthDate = new DateTime(birthYearComboBox.SelectedIndex + 1924, birthMonthComboBox.SelectedIndex + 1, birthDayComboBox.SelectedIndex + 1);
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;
            string visitpurpose = purposeOfVisitComboBox.Text;

            SystemController.EditUser(surname, name, fathers_name, birthDate, phone, email, visitpurpose);
        }

        public void UpdateTextBoxes()
        {
            birthMonthComboBox.SelectedIndexChanged -= birthMonthYearComboBox_SelectedIndexChanged;
            birthYearComboBox.SelectedIndexChanged -= birthMonthYearComboBox_SelectedIndexChanged;

            saveAccountButton.Enabled = false;
            saveAccountButton.Hide();
            editAccountButton.Enabled = true;

            surnameTextBox.ReadOnly = true;
            surnameTextBox.Text = user.surname;

            nameTextBox.ReadOnly = true;
            nameTextBox.Text = user.name;

            fathernameTextBox.ReadOnly = true;
            fathernameTextBox.Text = user.fathers_name;

            birthDayComboBox.Items.Clear();
            birthDayComboBox.Items.Add(user.dateofbirth.Day);
            birthDayComboBox.SelectedItem = user.dateofbirth.Day;

            birthMonthComboBox.Items.Clear();
            birthMonthComboBox.Items.Add(SystemController.months[user.dateofbirth.Month - 1]);
            birthMonthComboBox.SelectedIndex = 0;

            birthYearComboBox.Items.Clear();
            birthYearComboBox.Items.Add(user.dateofbirth.Year);
            birthYearComboBox.SelectedIndex = 0;

            phoneTextBox.ReadOnly = true;

            emailTextBox.ReadOnly = true;
            emailTextBox.Text = user.email;

            purposeOfVisitComboBox.Items.Clear();
            purposeOfVisitComboBox.Items.Add(user.visitpurpose);
            purposeOfVisitComboBox.SelectedIndex = 0;
        }
        private void CreateAccountBackGround()
        {
            accountBackColor = Samples.CreateRegAndAccountBackGround();
            Controls.Add(accountBackColor);
        }

        private void CreateAccountTextBoxes()
        {
            surnameTextBox = Samples.CreateTextBox(1, user.surname, true);
            Controls.Add(surnameTextBox);

            nameTextBox = Samples.CreateTextBox(2, user.name, true);
            Controls.Add(nameTextBox);

            fathernameTextBox = Samples.CreateTextBox(3, user.fathers_name, true);
            Controls.Add(fathernameTextBox);

            int birthDateLocY = 3 * height / 10 + 4 * height / 18;
            int h = height / 128;

            birthMonthComboBox = new ComboBox
            {
                Size = new Size(7 * width / 128, h),
                Location = new Point(105 * width / 256, birthDateLocY),
                DropDownWidth = width / 10,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            birthMonthComboBox.Items.Add(SystemController.months[user.dateofbirth.Month - 1]);
            birthMonthComboBox.SelectedIndex = 0;
            Controls.Add(birthMonthComboBox);

            birthDayComboBox = new ComboBox
            {
                Size = new Size(width / 32, h),
                Location = new Point(3 * width / 8, birthDateLocY),
                DropDownWidth = width / 10,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            birthDayComboBox.Items.Add(user.dateofbirth.Day);
            birthDayComboBox.SelectedItem = user.dateofbirth.Day;
            Controls.Add(birthDayComboBox);

            birthYearComboBox = new ComboBox
            {
                Size = new Size(11 * width / 224, h),
                Location = new Point(15 * width / 32, birthDateLocY),
                DropDownWidth = width / 10,
                MaxDropDownItems = 10,
                IntegralHeight = false,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            birthYearComboBox.Items.Add(user.dateofbirth.Year);
            birthYearComboBox.SelectedIndex = 0;
            Controls.Add(birthYearComboBox);

            phoneTextBox = Samples.CreateTextBox(5, user.phone, true);
            phoneTextBox.TextChanged += phoneNumberTextBox_TextChanged;
            Controls.Add(phoneTextBox);

            emailTextBox = Samples.CreateTextBox(6, user.email, true);
            Controls.Add(emailTextBox);

            purposeOfVisitComboBox = new ComboBox
            {
                Text = user.visitpurpose,
                Size = new Size(width / 7, h),
                Location = new Point(3 * width / 8, 3 * height / 10 + 7 * height / 18),
                DropDownWidth = 3 * width / 8,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            purposeOfVisitComboBox.Items.Add(user.visitpurpose);
            purposeOfVisitComboBox.SelectedIndex = 0;
            Controls.Add(purposeOfVisitComboBox);
        }

        private void birthMonthYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDay = birthDayComboBox.SelectedIndex + 1;
            int selectedMonth = birthMonthComboBox.SelectedIndex + 1;
            int daysInMonth = DateTime.DaysInMonth(birthYearComboBox.SelectedIndex + 1924, selectedMonth);

            birthDayComboBox.Items.Clear();

            for (int day = 1; day <= daysInMonth; day++)
                birthDayComboBox.Items.Add(day);

            if (selectedDay > (daysInMonth - 1))
            {
                birthDayComboBox.SelectedIndex = daysInMonth - 1;
            }
            else
            {
                birthDayComboBox.SelectedIndex = selectedDay - 1;
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

        private void CreateAccountLabels()
        {
            surnameLabel = Samples.CreateLabel(1, "Фамилия");
            Controls.Add(surnameLabel);

            nameLabel = Samples.CreateLabel(2, "Имя");
            Controls.Add(nameLabel);

            fathernameLabel = Samples.CreateLabel(3, "Отчество");
            Controls.Add(fathernameLabel);

            birthdayLabel = Samples.CreateLabel(4, "Дата рождения");
            Controls.Add(birthdayLabel);

            phoneLabel = Samples.CreateLabel(5, "Номер телефона");
            Controls.Add(phoneLabel);

            emailLabel = Samples.CreateLabel(6, "Почта");
            Controls.Add(emailLabel);

            purposeOfVisitLabel = Samples.CreateLabel(7, "Цель визита");
            Controls.Add(purposeOfVisitLabel);
        }

        private void CreateWarningLabels()
        {
            surnameWarningLabel = Samples.CreateWarningLabel(1);
            Controls.Add(surnameWarningLabel);

            nameWarningLabel = Samples.CreateWarningLabel(2);
            Controls.Add(nameWarningLabel);

            fathernameWarningLabel = Samples.CreateWarningLabel(3);
            Controls.Add(fathernameWarningLabel);

            phoneWarningLabel = Samples.CreateWarningLabel(5);
            Controls.Add(phoneWarningLabel);

            emailWarningLabel = Samples.CreateWarningLabel(6);
            Controls.Add(emailWarningLabel);
        }

        private int width => SystemController.width;
        private int height => SystemController.height;
        private User user => SystemController.user;
    }
}
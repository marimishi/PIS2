using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PIS
{
    partial class MainForm
    {
        private IContainer components = null;

        private Panel headerBackGround;

        private Button closeButton;
        private Button regButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            CreateCloseButton();
            CreateRegButton();
            CreateDesign();
        }

        private void ScreenOptions()
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateHeaderBackGround()
        {
            headerBackGround = Samples.CreateHeaderBackGround();
            Controls.Add(headerBackGround);
        }

        private void CreateDesign()
        {
            BackColor = Color.FromArgb(192, 240, 247);
            CreateHeaderBackGround();
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

        private void CreateRegButton()
        {
            int h = height / 32;
            regButton = new Button
            {
                Text = "Регистрация",
                Size = new Size(width / 16, 2 * h),
                Location = new Point(6 * width / 7 - h, h),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            regButton.Click += RegButton_Click;
            Controls.Add(regButton);
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            SystemController.ToRegistrationForm();
        }

        private int width => Screen.PrimaryScreen.Bounds.Width;
        private int height => Screen.PrimaryScreen.Bounds.Height;
    }
}


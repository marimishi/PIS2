using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PIS
{
    partial class AuthMainForm
    {
        private IContainer components = null;

        private Panel headerBackGround;

        private Button closeButton;
        private Button accountButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ShowMap();
            CreateCloseButton();
            CreateAccountButton();
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

        private void CreateAccountButton()
        {
            int h = height / 16;
            accountButton = new Button
            {
                Text = "Личный кабинет",
                Size = new Size(width / 10, h),
                Location = new Point(67 * width / 80 - h, h / 2),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            accountButton.Click += AccountButton_Click;
            Controls.Add(accountButton);
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            SystemController.ToAccountForm();
        }

        private void ShowMap()
        {
            foreach (MapPoint point in SystemController.map)
            {
                Controls.Add(point.backGroundPanel);
            }
        }

        private int width => SystemController.width;
        private int height => SystemController.height;
    }
}
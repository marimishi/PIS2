using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PIS
{
    public class Samples
    {
        public static Button CreateCloseButton()
        {
            int yLoc = height / 32;
            Button closeButton = new Button
            {
                Text = "Закрыть",
                Size = new Size(width / 16, height / 16),
                Location = new Point(15 * width / 16 - yLoc, yLoc),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            return closeButton;
        }

        public static Panel CreateHeaderBackGround()
        {
            Panel headerBackGround = new Panel
            {
                Size = new Size(width, height / 8),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(140, 240, 255)
            };
            return headerBackGround;
        }

        public static Panel CreateRegAndAccountBackGround()
        {
            int w = width / 3;
            int h = height / 4;
            Panel backGround = new Panel
            {
                Size = new Size(w, 5 * h / 2),
                Location = new Point(w, h),
                BackColor = Color.DeepSkyBlue
            };
            return backGround;
        }

        public static TextBox CreateTextBox(int i, string text="", bool readOnly=false)
        {
            return new TextBox
            {
                Text = text,
                Size = new Size(width / 7, height / 128),
                Location = new Point(3 * width / 8, 3 * height / 10 + i * height / 18),
                ReadOnly = readOnly
            };
        }

        public static Label CreateLabel(int i, string text) 
        {
            return new Label
            {
                Text = text,
                Size = new Size(width / 10, height / 38),
                Location = new Point(29 * width / 56, 3 * height / 10 + i * height / 18),
                BackColor = Color.DeepSkyBlue,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        public static Label CreateWarningLabel(int i)
        {
            return new Label
            {
                Size = new Size(width / 5, height / 50),
                Location = new Point(3 * width / 8, 7 * height / 25 + i * height / 18),
                BackColor = Color.DeepSkyBlue,
                ForeColor = Color.Red
            };
        }

        public static Button CreateCloseRegOrAccButton()
        {
            return new Button
            {
                Text = "Закрыть",
                Size = new Size(width / 15, height / 24),
                Location = new Point(247 * width / 420, height / 4 + width / 84),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
        }

        private static int width => Screen.PrimaryScreen.Bounds.Width;
        private static int height => Screen.PrimaryScreen.Bounds.Height;
    }
}

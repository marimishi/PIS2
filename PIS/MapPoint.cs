using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS
{
    public class MapPoint
    {
        public string message;
        public Label textLabel;
        public Panel backGroundPanel;

        public MapPoint(string message, int length, int i)
        {
            this.message = message;
            CreateUIComponents(length, i);
        }

        private void CreateUIComponents(int length, int i)
        {
            Size size = new Size((width - (length + 1) * height / 16) / length, 3 * height / 4);
            int val = (i + 3) * 3;

            textLabel = new Label
            {
                Text = message,
                Size = new Size((val - 2) * size.Width / val, 5 * height / 8),
                Location = new Point(height / 16 * (i + 1) + size.Width * i + size.Width / val, height / 16),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            textLabel.Font = new Font(textLabel.Font.FontFamily, 28, FontStyle.Regular);

            backGroundPanel = new Panel
            {
                Size = size,
                Location = new Point(height / 16 * (i + 1) + size.Width * i, 3 * height / 16),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
            };

            backGroundPanel.Controls.Add(textLabel);
        }

        private int width => SystemController.width;
        private int height => SystemController.height;
    }
}

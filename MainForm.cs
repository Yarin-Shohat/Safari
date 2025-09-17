using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safari
{
    public partial class MainForm : Form
    {
        private Safari1 main_safari;
        private List<int> lakes_capacity_list;

        private Image lakeImage = Image.FromFile("Lake.png");
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        public MainForm(List<int> lakes_capacity_list)
        {
            this.lakes_capacity_list = lakes_capacity_list;
            this.main_safari = new Safari1(lakes_capacity_list);

            main_safari.Start();

            foreach (var lm in this.main_safari.WaterResources)
            {
                lm.manager.AnimalsUpdated += OnDataUpdated;
            }

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int imageCount = this.lakes_capacity_list.Count;
            int imagesPerRow = 3;
            int spacing = 20;

            int imageWidth = 300;
            int imageHeight = 300;
            int labelHeight = 30;

            int totalWidth = imagesPerRow * (imageWidth + spacing) + spacing;
            int totalRows = (int)Math.Ceiling((double)imageCount / imagesPerRow);
            int totalHeight = totalRows * (imageHeight + labelHeight + spacing) + spacing;

            this.Size = new Size(totalWidth + 20, totalHeight + 40);

            for (int i = 0; i < imageCount; i++)
            {
                int row = i / imagesPerRow;
                int col = i % imagesPerRow;

                int x = spacing + col * (imageWidth + spacing);
                int y = spacing + row * (imageHeight + labelHeight + spacing);

                // Add PictureBox
                PictureBox pb = new PictureBox
                {
                    Image = this.lakeImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(imageWidth, imageHeight),
                    Location = new Point(x, y)
                };
                this.Controls.Add(pb);
                pictureBoxes.Add(pb);

                // Add Label below it
                Label lbl = new Label
                {
                    Text = $"Lake Capacity - {lakes_capacity_list[i]}",  // You can customize this per lake if you want
                    AutoSize = false,
                    Size = new Size(imageWidth, labelHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(x, y + imageHeight)
                };
                this.Controls.Add(lbl);
            }
        }

        private void OnDataUpdated(AnimalsThread[] newData, int index)
        {

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnDataUpdated(newData, index)));
                return;
            }

            if (index < 0 || index >= pictureBoxes.Count) return;

            // Remove old PictureBoxes
            var toRemove = new List<Control>();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox && ctrl.Name.StartsWith($"icon_{index}_"))
                    toRemove.Add(ctrl);
            }
            foreach (var pbx in toRemove)
                this.Controls.Remove(pbx);

            PictureBox centerPb = pictureBoxes[index];

            // Circle center
            int centerX = centerPb.Left + centerPb.Width / 2;
            int centerY = centerPb.Top + centerPb.Height / 2;

            // Radius for circle
            int radius = 70;

            int imgSize = 40;

            for (int i = 0; i < newData.Length; i++)
            {
                if (newData[i] == null)
                    continue;

                double angle = i * 2 * Math.PI / newData.Length;

                int x = centerX + (int)(radius * Math.Cos(angle)) - imgSize / 2;
                int y = centerY + (int)(radius * Math.Sin(angle)) - imgSize / 2;

                string animalImage = null;
                if (newData[i].ToString() == "Flamingo")
                    animalImage = "flamingo.png";
                else if (newData[i].ToString() == "Zebra")
                {
                    animalImage = "zebra.png";
                    i = i + 1;
                }
                else if (newData[i].ToString() == "Hippo")
                {
                    animalImage = "hippo.png";
                    i = i + newData.Length;
                }
                else
                    continue;


                    PictureBox icon = new PictureBox
                    {
                        Name = $"icon_{index}_{i}",
                        Size = new Size(imgSize, imgSize),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(x, y),
                        Image = Image.FromFile(animalImage) // or use different icons per value
                    };

                this.Controls.Add(icon);
                icon.BringToFront();
            }
        }
    }
}

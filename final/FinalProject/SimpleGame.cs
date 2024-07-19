using System;
using System.Drawing;
using System.Windows.Forms;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("System.Windows.Forms")]


// namespace SimpleGame
// {
//     // rest of the code...
// }

// You will need a window nd a root
// There is a command that is something like root.show() that will make it run
// Brother keers does not know how to make that work in c#

namespace SimpleGame
{
    public partial class GameForm : Form
    {
        private PictureBox selectedPictureBox;
        private Image originalImage;
        private Size originalSize;
        private Size enlargedSize;

        public GameForm()
        {
            // InitializeComponent();
            InitializeGame();
            ShowDialog();
        }

        private void InitializeGame()
        {
            // Example: Add two picture boxes to the form
            var pictureBox1 = new PictureBox
            {
                Image = Image.FromFile("image1.png"), // Replace with your image path or resource
                Location = new Point(50, 50),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            var pictureBox2 = new PictureBox
            {
                Image = Image.FromFile("image2.png"), // Replace with your image path or resource
                Location = new Point(200, 50),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            pictureBox1.Click += PictureBox_Click;
            pictureBox2.Click += PictureBox_Click;

            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);

            this.MouseClick += Form_MouseClick;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.Size = originalSize;
            }

            selectedPictureBox = sender as PictureBox;
            originalImage = selectedPictureBox.Image;
            originalSize = selectedPictureBox.Size;
            enlargedSize = new Size(originalSize.Width + 30, originalSize.Height + 30);

            selectedPictureBox.Size = enlargedSize;
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedPictureBox != null && !selectedPictureBox.Bounds.Contains(e.Location))
            {
                selectedPictureBox.Location = new Point(e.X - selectedPictureBox.Width / 2, e.Y - selectedPictureBox.Height / 2);
            }
        }
    }
}
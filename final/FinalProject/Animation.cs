using System;
using System.Drawing;
using System.Windows.Forms;
// using pixilart.com
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("System.Windows.Forms")]

namespace Animation
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
            // InitializeGame();
            // TransparencyKey = Color.Lime;
            // Color.Transparent = Color.Black;
            BackColor = Color.Black;
            WindowState = FormWindowState.Maximized;
            // Make the background color of form display transparently.
            // this.TransparencyKey = BackColor;
            // Update ();
            // ShowDialog();
        }

        public void AddPicture(string imageAddress, int xPosition, int yPosition, int size)
        {
            Image image = Image.FromFile(imageAddress);
            var pictureBox1 = new PictureBox
            {
                Image = image,
                Location = new Point(xPosition, yPosition),
                Size = new Size(size, image.Height*size/image.Width),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(pictureBox1);
        }

        public void AddMovingPicture(string imageAddress, int xPosition, int yPosition, int size)
        {
            Image image = Image.FromFile(imageAddress);
            var pictureBox1 = new PictureBox
            {
                Image = image,
                Location = new Point(xPosition, yPosition),
                Size = new Size(size, image.Height*size/image.Width),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(pictureBox1);

            for (int e=0; e<1000; e++)
            {
                // selectedPictureBox.Location = new Point(e-selectedPictureBox.Width/2, e-selectedPictureBox.Height/2);
                Console.WriteLine($"e = {e}");
                pictureBox1.Location = new Point(e, e);
                Thread.Sleep(100);
                // Update ();
            }
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

        // private void Form_MouseClick(object sender, MouseEventArgs e)
        // {
        //     if (selectedPictureBox != null && !selectedPictureBox.Bounds.Contains(e.Location))
        //     {
        //         selectedPictureBox.Location = new Point(e.X - selectedPictureBox.Width / 2, e.Y - selectedPictureBox.Height / 2);
        //     }
        // }
    }
}
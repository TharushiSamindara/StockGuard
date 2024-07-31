using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemApp
{
    // Declaration of the CustomerButton class, which inherits from PictureBox
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        // Private fields to store the normal and hover images
        private Image NormalImage;
        private Image HoverImage;

        // Property to get or set the normal image
        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        // Property to get or set the hover image
        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        // Event handler for the MouseHover event
        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            // Change the image to the hover image when the mouse hovers over the control
            this.Image = HoverImage;
        }

        // Event handler for the MouseLeave event
        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            // Change the image back to the normal image when the mouse leaves the control
            this.Image = NormalImage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    /// <summary>
    /// The entry point for the pacman application.
    /// </summary>
    public partial class Pacman : Form
    {
        public Pacman()
        {
            InitializeComponent();                      
        }

        /// <summary>
        /// This method executes when the user clicks on the browse button
        /// </summary>
        /// <param name="sender">the origin of the event</param>
        /// <param name="e">event parameters</param>
        private void fileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text Files(*.txt)|*.txt";
            ofd.RestoreDirectory = false;          

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputTextbox.Text = ofd.FileName;
                Game game = new Game(ofd.FileName);
                output.Text = game.Output;
            }
        }
    }
}

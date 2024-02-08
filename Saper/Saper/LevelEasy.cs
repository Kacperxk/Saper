using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class LevelEasy : Form
    {
        PictureBox[] tiles = new PictureBox[64];
        int time = 0;
        public LevelEasy()
        {
            InitializeComponent();
        }

        private void LevelEasy_Load(object sender, EventArgs e)
        {
            time = 0;
            load_tiles();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = time.ToString();
        }

        private void load_tiles()
        {
            int x = 0;
            int y = 0;
            int cnt = 0;

            Random rand = new Random();

            for(int i = 0; i < 64; i++)
            {
                
                tiles[i] = new PictureBox();
                tiles[i].Width = 40;
                tiles[i].Height = 40;
                tiles[i].Left = x;
                tiles[i].Top = y;
                tiles[i].BorderStyle = BorderStyle.FixedSingle;
                tiles[i].Image = imgPic.Images[0];
                tiles[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tiles[i].Tag = "safe";
                tiles[i].Click += new EventHandler(ClickTile);
                panel1.Controls.Add(tiles[i]);
                cnt++;
                x += 40;
                if(cnt == 8)
                {
                    x = 0;
                    cnt = 0;
                    y += 40;
                }
                
            }
            for(int i = 0; i <= 10; i++)
            {
                int random = rand.Next(0, 65);
                if(tiles[random].Image == imgPic.Images[1]){
                    i--;
                } else
                {
                    tiles[random].Tag = "bomb";
                }
            }
        }
        private void ClickTile(object sender, EventArgs e)
        {
            PictureBox tile = (PictureBox)sender;
            if(tile.Tag.ToString() == "bomb")
            {
                for(int i = 0; i < 64; i++)
                {
                    if(tiles[i].Tag.ToString() == "bomb")
                    {
                        tiles[i].Image = imgPic.Images[1];
                    }
                }
                MessageBox.Show("Przegrałeś");

            }
            if(tile.Tag.ToString() == "safe")
            {
                tile.Image = imgPic.Images[2];

            }
        }
    }
}

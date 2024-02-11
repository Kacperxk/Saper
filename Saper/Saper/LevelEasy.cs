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
        int bomby = 10;
        bool czyWygrana = false;
        int flagi = 0;
        bool pierwszyKlik = true;
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
            if (!czyWygrana)
            {
                time++;
                label1.Text = time.ToString();
            }
            
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
                tiles[i].Width = 30;
                tiles[i].Height = 30;
                tiles[i].Left = x;
                tiles[i].Top = y;
                tiles[i].BorderStyle = BorderStyle.FixedSingle;
                tiles[i].Image = imgPic.Images[9];
                tiles[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tiles[i].Tag = "idk";
                tiles[i].MouseClick += new MouseEventHandler(ClickTile);
                panel1.Controls.Add(tiles[i]);
                cnt++;
                x += 30;
                if(cnt == 8)
                {
                    x = 0;
                    cnt = 0;
                    y += 30;
                }
                
            }
            for(int i = 0; i < bomby; i++)
            {
                int random = rand.Next(0, 64);
                if(tiles[random].Tag.ToString() == "bomb"){
                    i--;
                } else
                {
                    tiles[random].Tag = "bomb";
                    //tiles[random].Image = imgPic.Images[11];
                }
            }
        }
        private void ClickTile(object sender, MouseEventArgs e)
        {
            if (czyWygrana) return;
            PictureBox tile = (PictureBox)sender;
            if(e.Button == MouseButtons.Left)
            {
                if (pierwszyKlik)
                {
                    if (tile.Tag.ToString() == "bomb")
                    {
                        tile.Tag = "idk";
                        ChangeFirstBomb(tile);
                    }
                    pierwszyKlik = false;
                }
                if (tile.Tag.ToString() == "bomb")
                {
                    ShowAllBombs();
                    tile.Image = imgPic.Images[12];
                    czyWygrana = true;
                    MessageBox.Show("Przegrałeś");

                }
                if (tile.Tag.ToString() == "idk")
                {
                    revealTile(tile);

                }
                int areAllEmpty = 0;
                foreach (var tileson in tiles)
                {
                    if (tileson.Tag.ToString() == "idk")
                        areAllEmpty++;

                }
                ileempty.Text = areAllEmpty.ToString();
            }
            else if(e.Button == MouseButtons.Right)
            {
                if (flagi >= bomby && (tile.Tag.ToString() == "idk" || tile.Tag.ToString() == "bomb")) return;
                if (tile.Tag.ToString() == "bomb")
                {
                    tile.Image = imgPic.Images[10];
                    tile.Tag = "flaggedBomb";
                    flagi++;
                }
                else if (tile.Tag.ToString() == "idk")
                {
                    tile.Image = imgPic.Images[10];
                    tile.Tag = "flaggedSafe";
                    flagi++;
                }
                else if (tile.Tag.ToString() == "flaggedBomb")
                {
                    tile.Image = imgPic.Images[9];
                    tile.Tag = "bomb";
                    flagi--;
                }
                else if (tile.Tag.ToString() == "flaggedSafe")
                {
                    tile.Image = imgPic.Images[9];
                    tile.Tag = "idk";
                    flagi--;
                }
                howManyFlags.Text = flagi.ToString();
                

            }

            CheckForWin();
            
        }

        private void ShowAllBombs()
        {
            foreach (var tile in tiles)
            {
                if (tile.Tag.ToString() == "bomb")
                    tile.Image = imgPic.Images[11];
            }
        }

        private void revealTile(PictureBox tile)
        {
            tile.Tag = "safe";
            int index = Array.IndexOf(tiles, tile);
            int bombsNearby = checkIfBombsNearby(index);
            if (bombsNearby == 0)
            {
                revealEmptyTiles(index);
            } else
            {
            tile.Image = imgPic.Images[bombsNearby];
            }
            Console.WriteLine("Bombs nearby : " + checkIfBombsNearby(index));
            

        }

        private int checkIfBombsNearby(int index)
        {
            int bombsCount = 0;
            int[] directions = { -9, -8, -7, -1, 1, 7, 8, 9 };
            foreach (int dir in directions)
            {
                if(index % 8 == 7)
                {
                    if(dir == 1 || dir == 9 || dir == -7)
                    {
                        continue;
                    }
                }
                if (index % 8 == 0)
                {
                    if (dir == -1 || dir == -9 || dir == 7)
                    {
                        continue;
                    }
                }
                int neighbourIndex = index + dir;
                if(neighbourIndex >= 0 && neighbourIndex < 64 && bombsAndFlags(neighbourIndex))
                {
                    bombsCount++;
                }
            }
            return bombsCount;
        }

        private bool bombsAndFlags(int index)
        {
            if (tiles[index].Tag.ToString() == "bomb" || tiles[index].Tag.ToString() == "flaggedBomb")
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void revealEmptyTiles(int index)
        {
            PictureBox currentTile = tiles[index];
            if (currentTile.Tag.ToString() == "visited")
                return;

            currentTile.Tag = "visited";
            int bombsNearby = checkIfBombsNearby(index);
            if (bombsNearby == 0)
            {
                currentTile.Image = imgPic.Images[0];
                int[] directions = { -9, -8, -7, -1, 1, 7, 8, 9 };
                foreach (int dir in directions)
                {
                    if (index % 8 == 7 && (dir == 1 || dir == 9 || dir == -7))
                        continue;

                    if (index % 8 == 0 && (dir == -1 || dir == -9 || dir == 7))
                        continue;

                    int neighbourIndex = index + dir;
                    if (neighbourIndex >= 0 && neighbourIndex < 64 && tiles[neighbourIndex].Tag.ToString() == "idk")
                    {
                        revealEmptyTiles(neighbourIndex);
                    }
                }
            }
            else
            {
                currentTile.Image = imgPic.Images[bombsNearby];
            }
        }
        private void CheckForWin()
        {
            int areAllEmpty = 0;
            foreach(var tile in tiles)
            {
                if (tile.Tag.ToString() == "idk")
                    areAllEmpty++;
                if(tile.Tag.ToString() == "bomb")
                    areAllEmpty++;

            }
            if(areAllEmpty - (bomby - flagi) == 0)
            {
                czyWygrana = true;
                ShowAllBombs();
                MessageBox.Show("Wygrałeś!");
            }
        }

        private void ChangeFirstBomb(PictureBox tile)
        {
            Random rand = new Random();
            int index;
            do
            {
                index = rand.Next(0, 64);
            } while (tiles[index].Tag.ToString() == "bomb");

            tiles[index].Tag = "bomb";
            //tiles[index].Image = imgPic.Images[11];
        }
    }
}

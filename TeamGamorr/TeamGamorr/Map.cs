using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Interfaces;
using WindowsGame1.Tiles;

namespace WindowsGame1
{
    class Map : IDrawableObject
    {
        public static int speed;
        public static List<Tile> tiles;
        public static List<ITileCollidable> collidables;
        private int[,] map;
        private List<Tile> listTiles; 
        public Map()
        {
            speed = 0;
            tiles = new List<Tile>();
            listTiles=new List<Tile>();
            collidables = new List<ITileCollidable>();
          
            map = new int[,] {
            { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,0,0,0,0,0  },
            { 3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0  },
            { 3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0  },
            { 3,2,2,0,2,2,2,0,2,2,2,2,2,0,3,0,0,0,0,0  },
            { 3,0,0,0,0,0,0,0,0,0,0,0,3,0,3,0,0,0,0,0  },
            { 3,0,2,2,2,2,2,2,2,2,2,0,3,0,3,0,0,0,0,0  },
            { 3,0,0,0,3,0,0,0,0,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,2,2,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,3,2,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,0,0,0,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,3,0,3,0,3,2,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,3,0,0,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,0,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,2,2,2,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,0,0,3,0,3,0,3,0,3,0,3,0,3,0,0,0,0,0  },
            { 3,0,0,0,0,0,0,0,0,0,3,0,0,0,3,0,0,0,0,0  },
            { 2,0,2,2,2,2,2,2,2,2,2,2,2,2,3,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },};


            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    switch (map[x, y])
                    {
                        case 0:
                            tiles.Add(new Grass(x * Tile.SIZE , y * Tile.SIZE));
                            break;
                        case 1:
                            tiles.Add(new Dirt(x * Tile.SIZE , y * Tile.SIZE));
                            break;
                        case 2:
                            collidables.Add(new Rock(x * Tile.SIZE , y * Tile.SIZE, "SIDE"));
                            tiles.Add(new Rock(x * Tile.SIZE , y * Tile.SIZE, "SIDE"));
                            listTiles.Add(new Rock(x * Tile.SIZE, y * Tile.SIZE, "SIDE"));
                            break;
                        case 3:
                            collidables.Add(new Rock(x * Tile.SIZE, y * Tile.SIZE, "DOWN"));
                            tiles.Add(new Rock(x * Tile.SIZE, y * Tile.SIZE, "DOWN"));
                            listTiles.Add(new Rock(x * Tile.SIZE, y * Tile.SIZE, "DOWN"));
                            break;

                    }
                }
            }
        }

        public IEnumerable<Tile> LisTiles
        {
            get { return this.listTiles; }
        }


        public void draw(SpriteBatch sb)
        {

            foreach (Tile tile in tiles)
            {
                tile.draw(sb);
                
            }
        }

        public void loadContent(GraphicsDevice gd)
        {
            foreach (Tile tile in tiles)
            {
                tile.loadContent(gd);
            }
        }

        public void unloadContent()
        {
            foreach (Tile tile in tiles)
            {
                tile.unloadContent();   
            }
        }

        public void update()
        {
            
        }
    }
}

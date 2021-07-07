using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    public class Map
    {
        private Tile[,] tiles;
        private Tile spawnPoint;
        private Tile[] enemySpawnPoints;
        private Tile exit;
        
        public Map(ContentManager content, int level)
        {
            tiles = new Tile[10, 10];
            List<Tile> temp = new List<Tile>();

            for (int x = 0; x < tiles.GetLength(0); x++)
                for (int y = 0; y < tiles.GetLength(1); y++)
                    if (x == 0 || x == tiles.GetLength(0) - 1 || y == 0 || y == tiles.GetLength(1) - 1)
                        tiles[x, y] = new Tile(content, new Vector2(x, y), Tile.TileType.Wall);
                    else
                    {
                        tiles[x, y] = new Tile(content, new Vector2(x, y), Tile.TileType.Floor);
                        if (!(x == 1 && y == 1) && !(x == tiles.GetLength(0) - 1 && y == tiles.GetLength(1) - 1))
                            temp.Add(tiles[x, y]);
                    }
            Tile t = new Chest(content, Vector2.One);
            tiles[1, 1] = t;
            temp.Remove(t);
            t = new Shop(content, new Vector2(tiles.GetLength(0) - 2, tiles.GetLength(1) - 2), level);
            tiles[tiles.GetLength(0) - 2, tiles.GetLength(1) - 2] = t;
            temp.Remove(t);

            Random ra = new Random();

            t = temp[ra.Next(temp.Count)];
            spawnPoint = t;
            t.Texture = content.Load<Texture2D>("Assets/start");
            temp.Remove(t);

            enemySpawnPoints = new Tile[2];
            for (int i = 0; i < enemySpawnPoints.Length; i++)
            {
                t = temp[ra.Next(temp.Count)];
                enemySpawnPoints[i] = t;
                temp.Remove(t);
            }

            t = temp[ra.Next(temp.Count)];
            exit = t;
            t.Texture = content.Load<Texture2D>("Assets/end");
        }

        public Tile[,] Tiles
        {
            get
            {
                return tiles;
            }
            set
            {
                tiles = value;
            }
        }
        public Tile SpawnPoint
        {
            get
            {
                return spawnPoint;
            }
            set
            {
                spawnPoint = value;
            }
        }
        public Tile[] EnemySpawnPoints
        {
            get
            {
                return enemySpawnPoints;
            }
            set
            {
                enemySpawnPoints = value;
            }
        }
        public Tile Exit
        {
            get
            {
                return exit;
            }
            set
            {
                exit = value;
            }
        }
    }
}

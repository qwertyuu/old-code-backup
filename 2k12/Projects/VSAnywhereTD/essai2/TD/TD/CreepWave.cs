using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD
{
    class CreepWave
    {
        public int level { get; set; }
        public int creepsLeft { get { return toSpawn.Count; } }
        public int speed { get; set; }
        public Stack<Creep> toSpawn { get; set; }
        public static List<Creep> inGameCreeps;
        public DateTime nextWave { get; set; }
        public CreepWave(int numberOfIndividuals)
        {
            speed = 1000;
            toSpawn = new Stack<Creep>();
            inGameCreeps = new List<Creep>();
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                toSpawn.Push(new Creep(Creep.Types.type1));
            }
            nextWave = DateTime.Now.AddMilliseconds(speed);
        }
        public void Update(GameTime gameTime, List<Cell> cellsWithTowers)
        {
            if (toSpawn.Count > 0)
            {
                if (DateTime.Now >= nextWave)
                {
                    inGameCreeps.Add(toSpawn.Pop());
                    nextWave = DateTime.Now.AddMilliseconds(speed);
                }
            }
            else
            {
                if (inGameCreeps.Count == 0)
                {
                    //wave terminée
                }
            }
            for (int i = 0; i < CreepWave.inGameCreeps.Count; i++)
            {
                if (inGameCreeps[i].IsDead)
                {
                    if (Game1.SelectedObject == inGameCreeps[i])
                    {
                        Game1.SelectedObject = null;
                    }
                    inGameCreeps.RemoveAt(i);
                    i--;
                }
                else
                {
                    inGameCreeps[i].Update(gameTime);
                    foreach (var item in cellsWithTowers)
                    {
                        double distance = Tower.DetectCreep(inGameCreeps[i], item.contains);
                        if (distance <= item.contains.Range)
                        {
                            item.contains.AvailableCreeps.Add(inGameCreeps[i]);
                            inGameCreeps[i].distances.Add(item.contains, distance);
                        }
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in inGameCreeps)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}

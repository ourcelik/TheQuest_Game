using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    abstract class Skills : Mover
    {
        protected int Damage = 1;
        protected Game game;
        private bool Pickedup;
       
       
        public Skills(Game game, Point location):base(game,location)
        {
            this.game = game;
        }
        public void Pickedupskills () // skillin alındığını gösterir
        {
            Pickedup = true;
        }
        public abstract string Name { get; } // her skill kendi ismine sahip olur

        public abstract void Attack(Point LocationofPlayer, Point LocationofEnemy,Keys code);
        public void StartAttack(Point LocationofPlayer, Point LocationofEnemy , int Damage , Keys code)//atak sistemi
        {
            if (LocationofPlayer.X - LocationofEnemy.X > 0 && LocationofPlayer.X - LocationofEnemy.X < 53 && code == Keys.A)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (game.player.Near(enemy.Location,53))
                    {
                        enemy.Hit(Damage);
                    }
                    
                }
            }
            else if (LocationofEnemy.X - LocationofPlayer.X > 0 && LocationofEnemy.X - LocationofPlayer.X < 53 && code == Keys.D)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (game.player.Near(enemy.Location, 53))
                    {
                        enemy.Hit(Damage);
                    }

                }
            }
            if (LocationofPlayer.Y - LocationofEnemy.Y > 0 && LocationofPlayer.Y - LocationofEnemy.Y < 53 && code == Keys.W)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (game.player.Near(enemy.Location, 53))
                    {
                        enemy.Hit(Damage);
                    }

                }
            }
            else if (LocationofEnemy.Y - LocationofPlayer.Y > 0 && LocationofEnemy.Y - LocationofPlayer.Y < 53 && code == Keys.S)
            {
               foreach (Enemy enemy in game.Enemies)
                {
                    if (game.player.Near(enemy.Location,53))
                    {
                        enemy.Hit(Damage);
                    }
                    
                }
            }
           


        }

    }
}

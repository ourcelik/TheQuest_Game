using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    abstract class Enemy : Mover
    {
        protected int Damage = 1;
        protected int HealthPoint = 20;
        public int healthpoint { get { return HealthPoint; }
            set { HealthPoint = value; }
        }
        public Enemy(Game game, Point Location) : base(game, Location)
        {

        }
        public  void Move()
        {
            Keys keepkey = FindPlayer();


            base.location = base.Move(keepkey, base._game._rectangle);
        }
        public abstract void StartAttack();
        public Keys FindPlayer()// oyuncunun yerine göre ona yaklaşır.
        {

            if (_game.PlayerNewLocation.X > location.X)
            {
                if (_game.PlayerNewLocation.Y > location.Y)
                {
                    if ((location.X - _game.PlayerNewLocation.X) > (_game.PlayerNewLocation.Y - location.Y))
                    {
                        return Keys.Left;
                    }
                    else
                    {
                        return Keys.Down;
                    }
                }
                else if (_game.PlayerNewLocation.Y < location.Y)
                {
                    if ((_game.PlayerNewLocation.X - location.X) > (_game.PlayerNewLocation.Y - location.Y))
                    {
                        return Keys.Right;
                    }
                    else
                    {
                        return Keys.Up;
                    }
                }
                else
                {
                    return Keys.Right;
                }
            }
            else if (_game.PlayerNewLocation.X < location.X)
            {
                if (_game.PlayerNewLocation.Y < location.Y)
                {
                    if ((location.X - _game.PlayerNewLocation.X) > (location.Y - _game.PlayerNewLocation.Y))
                    {
                        return Keys.Left;
                    }
                    else
                    {
                        return Keys.Up;
                    }
                }
                else if (_game.PlayerNewLocation.Y > location.Y)
                {
                    if ((_game.PlayerNewLocation.Y - location.Y) > (location.X - _game.PlayerNewLocation.X))
                    {
                        return Keys.Down;
                    }
                    else
                    {
                        return Keys.Left;
                    }
                }
                else
                {
                    return Keys.Left;
                }

            }
            else if (_game.PlayerNewLocation.X == location.X)
            {
                if (_game.PlayerNewLocation.Y < location.Y)
                {
                    return Keys.Up;
                }
                else if (_game.PlayerNewLocation.Y > location.Y)
                {
                    return Keys.Down;
                }
                else
                {
                    return Keys.None;
                }
            }
            else
            {
                return Keys.Right;
            }



        }
        public void Attack(int Damage)// oyuncu yeterince yakınsa saldırır.
        {
            if (_game.player.Location.X - location.X > 0 && _game.player.Location.X - location.X < 20 && Math.Abs(_game.player.Location.Y - location.Y ) <= 45)
            {
                if (Near(_game.player.Location,45))
                {
                    _game.player.Hit(Damage);
                }
                
            }
            else if (location.X - _game.player.Location.X > 0 && location.X - _game.player.Location.X < 20 && Math.Abs(location.Y - _game.player.Location.Y ) <= 45)
            {
                if (Near(_game.player.Location, 45))
                {
                    _game.player.Hit(Damage);
                }
            }
            else if (_game.player.Location.Y - location.Y > 0 && _game.player.Location.Y - location.Y < 20 && Math.Abs(_game.player.Location.X - location.X) <= 45)
            {
                if (Near(_game.player.Location, 45))
                {
                    _game.player.Hit(Damage);
                }
            }
            else if (location.Y - _game.player.Location.Y > 0 && location.Y - _game.player.Location.Y < 20 && Math.Abs(location.X - _game.player.Location.X )<= 45)
            {
                if (Near(_game.player.Location, 45))
                {
                    _game.player.Hit(Damage);
                }
            }
            else
            {

            }
        }
        public void Hit(int Damage)// player vurduğunda canı azaltır.
        {
            healthpoint -= Damage;
        }
        public bool İsLive()// oyunu sürdürmek için canlı olup olmadığını kontrol eder.
        {
            if (healthpoint <=0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    abstract class Mover
    {

        
       
        public int moveinterval = 5;
        protected Point location;
        public Point Location { get { return location;} }
        Game game;
        public Game _game
        {
            get { return game; }
        }
        
        public Mover(Game game,Point location)
        {
            this.location = location;
            this.game = game;
            
        }
        public bool Near(Point CheckLocation,int Distance)// yakınlık ölçer
        {
            if (Math.Abs(game.PlayerNewLocation.X-CheckLocation.X)<Distance && Math.Abs(game.PlayerNewLocation.Y-CheckLocation.Y)<Distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Point Move(Keys code, Rectangle Area) // alandan çıkmadığı taktirde girdiden aldığı sonuç ile hareket sağlar.
        {
            Point axis=location;
            switch (code)
            {
                case Keys.Up:
                    if (Area.Top < axis.Y)
                    {
                        axis.Y -= moveinterval;
                    }
                    
                    break;
                case Keys.Down:
                    if (Area.Bottom > axis.Y)
                    {
                        axis.Y += moveinterval;
                    }
                    break;
                case Keys.Left:
                    if (Area.Left < axis.X)
                    {
                        axis.X -= moveinterval;
                    }
                    
                    break;
                case Keys.Right:
                    if (Area.Right > axis.X)
                    {
                        axis.X += moveinterval;
                    }
                    
                    break;
                
            }
            return axis;
        }
     
        }
    
}

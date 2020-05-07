using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    class Potion : Skills
    {
        
        public Potion(Game game, Point Location) : base(game, Location)
        { Damage = 35; }
        public override string Name { get { return "purplehole"; } }
        public override void Attack(Point LocationofPlayer, Point LocationofEnemy, Keys code)
        {
        }
        public void İncreaseHealth()
        {
            if (game.player.healthpoint <40)
            {
                game.player.healthpoint += Damage;
            }
            
            
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApp24
{
    class SmallDragon:Enemy
    {
        public SmallDragon(Game game, Point Location) : base(game, Location)
        {
            healthpoint = 25;
            Damage = 2;
        }
        public override void StartAttack()
        {
            Attack(Damage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    class BossDragon : Enemy
    {
        public BossDragon(Game game, Point Location) : base(game, Location)
        {
            healthpoint = 50;
            Damage = 3;
        }
        public override void StartAttack()
        {
            Attack(Damage);
        }
    }
}

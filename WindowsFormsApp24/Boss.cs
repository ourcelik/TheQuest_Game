using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp24
{
    class Boss : Enemy
    {
        
        public Boss(Game game, Point Location) : base(game, Location)
        {
            healthpoint = 40;
            Damage = 3;
        }
        
        public override void StartAttack()
        {
            Attack(Damage);
        }
    }
}

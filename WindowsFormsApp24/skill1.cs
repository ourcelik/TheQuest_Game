using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    class skill1:Skills
    {
        
        public skill1(Game game, Point Location) : base(game, Location)
        { Damage = 3; }
        public override string Name { get { return "light"; } }

        public override void Attack(Point LocationofPlayer , Point LocationofEnemy,Keys code)
        {
            StartAttack(LocationofPlayer,LocationofEnemy,Damage,code);
        }
    }
}

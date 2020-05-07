using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp24
{
    class skill4:Skills
    {
        public skill4(Game game, Point Location) : base(game, Location)
        { Damage = 7; }
        public override string Name { get { return "fire"; } }
        public override void Attack(Point LocationofPlayer, Point LocationofEnemy, Keys code)
        {
            StartAttack(LocationofPlayer, LocationofEnemy, Damage,code);
        }
    }
}

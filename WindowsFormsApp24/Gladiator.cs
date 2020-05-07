using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp24
{
    class Gladiator:Enemy
    {
        
        public Gladiator(Game game,Point Location): base(game,Location)
        {
            healthpoint = 20;
            Damage = 1;
        }
      
        public override void StartAttack()
        {
            Attack(Damage);
        }
    }
}

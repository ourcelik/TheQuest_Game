using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp24
{
    class Player:Mover
    {
        private bool Potion;
        public bool potion {
            get { return Potion; }
            set { Potion = value; } }   
        protected int HealthPoint = 40;
        public int healthpoint
        {
            get { return HealthPoint; }
            set { HealthPoint = value; }
        }
        private Skills EquippedSkill;// şuan kullandığın skill
        List<Skills> İnventory = new List<Skills>(); // oyunda kazandığın tüm silahları tutar
        public List<string> inventory { // envanterin sadece isimlerinden bir liste çıkarır.
            get 
            {
                List<string> skillsİnİnventory = new List<string>();
                foreach (var skills in İnventory)
                {
                    skillsİnİnventory.Add(skills.Name);
                }
                return skillsİnİnventory;
                } 
            
        }
       

        public Player(Game game,Point location): base(game,location)
        {
               
            
        }
     public void Move (Keys code)// kalıttığımız mover classına gönderim yaparak hareketi sağlar ve ekrandaki skilleri almak burdan sağlanır.
        {

             base.location = base.Move(code,base._game._rectangle);
            if (_game.SkillİnRoom != null)
            {
           
                if (Near(_game.SkillİnRoom.Location,53))
                {
                    İnventory.Add(_game.SkillİnRoom);
                    _game.SkillİnRoom.Pickedupskills();
                }
               

            
            }
            if (_game.PotionİnRoom != null)
            {
            if (Near(_game.PotionİnRoom.Location, 53))
            {
                Potion = true;
            }
            }
            

        }
        public void Equip(string SkillName)// envanterdaki picturlara tıklayınca fonksiyon çalıştırılır eğer envanterda varsa kuşanılır.
        {
            foreach (Skills skill in İnventory)
            {
                if (skill.Name == SkillName)
                {
                    EquippedSkill = skill;
                    
                }
            }
        }
        public void Attack(Point LocationofPlayer, Point LocationofEnemy,Keys code)// elinde silah var ise saldırı yapmanı sağlar.
        {
            if (ControlSkill())
            {
                EquippedSkill.Attack(LocationofPlayer, LocationofEnemy, code);
             
            }
        }
        public void DrinkPotion()
        {
            if (healthpoint < 40)
            {
                healthpoint += 5;
                
            }
            else
            {
                MessageBox.Show("Your Health Point's full,You can't use potion");
            }
            
        }
        public void Hit(int Damage) // enemylerden aldığı damage parametresi ile canını azaltır.
        {
            healthpoint -= Damage;
        }
        public bool ControlSkill()
        {
            if (EquippedSkill != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
           
    }
    
}

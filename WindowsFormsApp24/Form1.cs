using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Runtime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Data.SqlTypes;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        Game newgame;
        int CountOfEnemy = 1;
        int CountOfLiveEnemy = 0;
        bool Potion = false;
        public Form1()
        {
            InitializeComponent();
            newgame = new Game(new Rectangle(118, 99, 762, 317));
            newgame.NewLevel();
            HealthOfEnemy2.Width = 0;
            HealthOfEnemy3.Width = 0;
            HealthOfEnemy4.Width = 0;
            updateAllthings();
        }
        
     
            
          
            
        
        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // bastığın tuşa göre hareket yada atak yapmaya yönelten event
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                newgame.Move(e.KeyCode);
            }
            
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D || e.KeyCode == Keys.W )
            {
                newgame.Attack(e.KeyCode);      
            }
            if (e.KeyCode == Keys.D1|| e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 )
            {
                foreach (string item in newgame.player.inventory)
                {
                    if (item == "light" && e.KeyCode == Keys.D1)
                    {
                        newgame.equip("light");
                        light2.Image = WindowsFormsApp24.Properties.Resources.equippedskill1;
                        water2.Image = water.Image;
                        fire2.Image = fire.Image;
                        tornado2.Image = tornado.Image;
                        purplehole2.Image = purplehole.Image;
                    }
                    else if (item == "water" && e.KeyCode == Keys.D2)
                    {
                        newgame.equip("water");
                        light2.Image = light.Image;
                        water2.Image = WindowsFormsApp24.Properties.Resources.equippedskill5;
                        fire2.Image = fire.Image;
                        tornado2.Image = tornado.Image;
                        purplehole2.Image = purplehole.Image;
                    }
                    else if (item == "purplehole" && e.KeyCode == Keys.D3)
                    {
                        newgame.equip("purplehole");
                        light2.Image = light.Image;
                        water2.Image = water.Image;
                        fire2.Image = fire.Image;
                        tornado2.Image = tornado.Image;
                        purplehole2.Image = WindowsFormsApp24.Properties.Resources.equippedskill4;
                    }
                    else if (item == "fire" && e.KeyCode == Keys.D4)
                    {
                        newgame.equip("fire");
                        light2.Image = light.Image;
                        water2.Image = water.Image;
                        fire2.Image = WindowsFormsApp24.Properties.Resources.equippedskill3;
                        tornado2.Image = tornado.Image;
                        purplehole2.Image = purplehole.Image;
                    }
                    else if (item == "tornado" && e.KeyCode == Keys.D5)
                    {
                        newgame.equip("tornado");
                        light2.Image = light.Image;
                        water2.Image = water.Image;
                        fire2.Image = fire.Image;
                        tornado2.Image = WindowsFormsApp24.Properties.Resources.equippedskill2;
                        purplehole2.Image = purplehole.Image;
                    }
                }
                if (!newgame.PİR && e.KeyCode == Keys.D6 && newgame.player.potion)
                {
                    newgame.PotionİnRoom.İncreaseHealth();
                    newgame.PotionİnRoom = null;
                    if (newgame.player.healthpoint > 40)
                    {
                        newgame.player.healthpoint = 40;
                    }
                    newgame.player.potion = false;
                    potion2.Visible = false;

                    HealthofHero.Width = newgame.player.healthpoint * 5;
                }
            }
            updateAllthings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void updateAllthings()// Herşeyi Günceller
        {
            Hero.Location = newgame.PlayerNewLocation;
            foreach (Enemy enemies in newgame.Enemies)
            {
                WhoİsEnemy(enemies);
            }
            if (newgame.SkillİnRoom != null)
                InventoryControl();
                HealthBars();
            
            
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        void WhoİsEnemy(Enemy enemy)// Güncel düşmanları belirleyerek onları ekranda gösterir.
        {
            if (enemy is Gladiator)
            {
                Gladiator.Visible = true;
                Gladiator.Location = enemy.Location;
            }
            else if (enemy is Boss)
            {
                Boss.Visible = true;
                Boss.Location = enemy.Location;
            }
            else if (enemy is BossDragon)
            {
                BossDragon.Visible = true;
                BossDragon.Location = enemy.Location;
            }
            else if (enemy is SmallDragon)
            {
                SmallDragon.Visible = true;
                SmallDragon.Location = enemy.Location;
            }
        }

        private void light2_Click(object sender, EventArgs e)// eğer light yeteneğini aldıysan envanterda görebilirsin tıklaman durumunda o silah kuşanılır.
        {
            newgame.equip("light");
            light2.Image = WindowsFormsApp24.Properties.Resources.equippedskill1;
            water2.Image = water.Image;
            fire2.Image = fire.Image;
            tornado2.Image = tornado.Image;
            purplehole2.Image = purplehole.Image;
            
        }

        private void water2_Click(object sender, EventArgs e)// eğer water yeteneğini aldıysan envanterda görebilirsin tıklaman durumunda o silah kuşanılır.
        {
            newgame.equip("water");
            light2.Image = light.Image;
            water2.Image = WindowsFormsApp24.Properties.Resources.equippedskill5;
            fire2.Image = fire.Image; 
            tornado2.Image = tornado.Image;
            purplehole2.Image = purplehole.Image;
        }

        private void purplehole2_Click(object sender, EventArgs e)// eğer purphole yeteneğini aldıysan envanterda görebilirsin tıklaman durumunda o silah kuşanılır.
        {
            newgame.equip("purplehole");
            light2.Image = light.Image;
            water2.Image = water.Image;
            fire2.Image = fire.Image;
            tornado2.Image = tornado.Image;
            purplehole2.Image = WindowsFormsApp24.Properties.Resources.equippedskill4;
        }

        private void fire2_Click(object sender, EventArgs e)// eğer fire yeteneğini aldıysan envanterda görebilirsin tıklaman durumunda o silah kuşanılır.
        {
            newgame.equip("fire");
            light2.Image = light.Image;
            water2.Image = water.Image;
            fire2.Image = WindowsFormsApp24.Properties.Resources.equippedskill3;
            tornado2.Image = tornado.Image;
            purplehole2.Image = purplehole.Image;
        }

        private void tornado2_Click(object sender, EventArgs e)
        {
            newgame.equip("tornado");
            light2.Image = light.Image;
            water2.Image = water.Image;
            fire2.Image = fire.Image;
            tornado2.Image = WindowsFormsApp24.Properties.Resources.equippedskill2;
            purplehole2.Image = purplehole.Image;
        }// eğer tornado yeteneğini aldıysan envanterda görebilirsin tıklaman durumunda o silah kuşanılır.

        private void potion2_Click(object sender, EventArgs e)
        {
            newgame.PotionİnRoom.İncreaseHealth();
            newgame.PotionİnRoom = null;
            if (newgame.player.healthpoint>40)
            {
                newgame.player.healthpoint = 40;
            }  
            newgame.player.potion = false;
            potion2.Visible = false;
           
            HealthofHero.Width = newgame.player.healthpoint * 5;
        }// potion iksirdir canı çoğaltır.
        private void HealthBars()// Oyuncu ve düşmanların can seviyelerini belirleyerek,animasyona döker.
        {
            Reset();
            HealthofHero.Width = newgame.player.healthpoint * 5;
            foreach (Enemy item in newgame.Enemies)
            {
                if (item is Gladiator)
                {
                    if (CountOfEnemy == 1)
                    {
                        e1.Visible = true;
                        Bar1.Visible = true;
                        HealthOfEnemy.Visible = true;
                        HealthOfEnemy.Width = item.healthpoint * 10;
                       
                    }
                    else if (CountOfEnemy == 2)
                    {
                        e2.Visible = true;
                        Bar2.Visible = true;
                        HealthOfEnemy2.Visible = true;
                        HealthOfEnemy2.Width = item.healthpoint * 10;
                        
                    }
                    else if (CountOfEnemy == 3)
                    {
                        e3.Visible = true;
                        Bar3.Visible = true;
                        HealthOfEnemy3.Visible = true;
                        HealthOfEnemy3.Width = item.healthpoint * 10;
                        
                    }
                    else if (CountOfEnemy == 4)
                    {
                        e4.Visible = true;
                        Bar4.Visible = true;
                        HealthOfEnemy4.Visible = true;
                        HealthOfEnemy4.Width = item.healthpoint * 10;
                       
                    }
                    CountOfEnemy++;
                    if (item.İsLive())
                    {
                        CountOfLiveEnemy += 1;
                    }


                }
                else if (item is SmallDragon)
                {
                    if (CountOfEnemy == 1)
                    {
                        e1.Visible = true;
                        Bar1.Visible = true;
                        HealthOfEnemy.Visible = true;
                        HealthOfEnemy.Width = item.healthpoint * 8;


                    }
                    else if (CountOfEnemy == 2)
                    {
                        e2.Visible = true;
                        Bar2.Visible = true;
                        HealthOfEnemy2.Visible = true;
                        HealthOfEnemy2.Width = item.healthpoint * 8;
                    }
                    else if (CountOfEnemy == 3)
                    {
                        e3.Visible = true;
                        Bar3.Visible = true;
                        HealthOfEnemy3.Visible = true;
                        HealthOfEnemy3.Width = item.healthpoint * 8;
                    }
                    else if (CountOfEnemy == 4)
                    {
                        e4.Visible = true;
                        Bar4.Visible = true;
                        HealthOfEnemy4.Visible = true;
                        HealthOfEnemy4.Width = item.healthpoint * 8;
                    }
                    CountOfEnemy++;
                    if (item.İsLive())
                    {
                        CountOfLiveEnemy += 1;
                    }
                }
                else if (item is Boss)
                {
                    if (CountOfEnemy == 1)
                    {
                        e1.Visible = true;
                        Bar1.Visible = true;
                        HealthOfEnemy.Visible = true;
                        HealthOfEnemy.Width = item.healthpoint * 5;

                    }
                    else if (CountOfEnemy == 2)
                    {
                        e2.Visible = true;
                        Bar2.Visible = true;
                        HealthOfEnemy2.Visible = true;
                        HealthOfEnemy2.Width = item.healthpoint * 5;
                    }
                    else if (CountOfEnemy == 3)
                    {
                        e3.Visible = true;
                        Bar3.Visible = true;
                        HealthOfEnemy3.Visible = true;
                        HealthOfEnemy3.Width = item.healthpoint * 5;
                    }
                    else if (CountOfEnemy == 4)
                    {
                        e4.Visible = true;
                        Bar4.Visible = true;
                        HealthOfEnemy4.Visible = true;
                        HealthOfEnemy4.Width = item.healthpoint * 5;
                    }
                    CountOfEnemy++;
                    if (item.İsLive())
                    {
                        CountOfLiveEnemy += 1;
                    }
                }
                else if (item is BossDragon)
                {
                    if (CountOfEnemy == 1)
                    {
                        e1.Visible = true;
                        Bar1.Visible = true;
                        HealthOfEnemy.Visible = true;
                        HealthOfEnemy.Width = item.healthpoint * 4;


                    }
                    else if (CountOfEnemy == 2)
                    {
                        e2.Visible = true;
                        Bar2.Visible = true;
                        HealthOfEnemy2.Visible = true;
                        HealthOfEnemy2.Width = item.healthpoint * 4;
                    }
                    else if (CountOfEnemy == 3)
                    {
                        e3.Visible = true;
                        Bar3.Visible = true;
                        HealthOfEnemy3.Visible = true;
                        HealthOfEnemy3.Width = item.healthpoint * 4;
                    }
                    else if (CountOfEnemy == 4)
                    {
                        e4.Visible = true;
                        Bar4.Visible = true;
                        HealthOfEnemy4.Visible = true;
                        HealthOfEnemy4.Width = item.healthpoint * 4;
                    }
                    CountOfEnemy++;
                    if (item.İsLive())
                    {
                        CountOfLiveEnemy += 1;
                    }
                }
            }
            if (CountOfLiveEnemy == 0 )
            {
                ResetBars();
                
                newgame.NewLevel();

                
            }
            CountOfLiveEnemy = 0;
            CountOfEnemy = 1;

        }
        private void InventoryControl() // ekrandaki yetenek ve senin sahip olduklarını belirler.
        {
            switch (newgame.SkillİnRoom.Name)// ekranda hangi yeteneğin belirmesi gerektğini belirler.
            {
                case "light":
                    fire.Visible = false;
                    purplehole.Visible = false;
                    tornado.Visible = false;
                    water.Visible = false;   
                    light.Visible = true;
                    light.Location = newgame.SkillİnRoom.Location;
                    break;
                case "water":
                    fire.Visible = false;
                    purplehole.Visible = false;
                    tornado.Visible = false; 
                    light.Visible = false;
                    water.Visible = true;
                    water.Location = newgame.SkillİnRoom.Location;
                    break;
                case "purplehole":
                    fire.Visible = false;
                    tornado.Visible = false;
                    water.Visible = false;
                    light.Visible = false;
                    purplehole.Visible = true;
                    purplehole.Location = newgame.SkillİnRoom.Location;
                    break;
                case "fire":     
                    purplehole.Visible = false;
                    tornado.Visible = false;
                    water.Visible = false;
                    light.Visible = false;
                    fire.Visible = true;
                    fire.Location = newgame.SkillİnRoom.Location;
                    break;
                case "tornado":
                    fire.Visible = false;
                    purplehole.Visible = false;
                    water.Visible = false;
                    light.Visible = false;
                    tornado.Visible = true;
                    tornado.Location = newgame.SkillİnRoom.Location;
                    break;
                default:
                    break;

            }
            if (newgame.CheckSkills("light"))// envanteri kontrol eder eğer bu yetenek bulunuyorsa envantere ekler.
            {

                light.Visible = false;
                light2.Visible = true;
            }
            if (newgame.CheckSkills("water"))
            {
                water.Visible = false;
                water2.Visible = true;
            }
            if (newgame.CheckSkills("tornado"))
            {
                tornado.Visible = false;
                tornado2.Visible = true;
            }
            if (newgame.CheckSkills("purplehole"))
            {
                purplehole.Visible = false;
                purplehole2.Visible = true;
            }
            if (newgame.CheckSkills("fire"))
            {
                fire.Visible = false;
                fire2.Visible = true;
            }
            if (newgame.PİR)//bölümde iksir var ise aktif hale getirir.
            {
                newgame.PİR = false;
                potion.Visible = true;
                potion.Location = newgame.PotionİnRoom.Location;
            }
            if (newgame.player.potion)
            {
                potion.Visible = false;
                potion2.Visible = true;
            }

        }
       public void Reset()// ölen düşmanları oyundan çıkarır yada oyuncu ölürse oyunu bitirir.
        {
            foreach (Enemy enemy in newgame.Enemies)
            {
                if (enemy.healthpoint <= 0)
                {
                    if (enemy is Gladiator)
                        Gladiator.Visible = false;
                    else if (enemy is BossDragon)
                        BossDragon.Visible = false;
                    else if (enemy is Boss)
                        Boss.Visible = false;
                    else if (enemy is SmallDragon)
                        SmallDragon.Visible = false;
                    
                }
            }

            if (newgame.player.healthpoint <= 0)
            {
                HealthofHero.Width = 0;
                MessageBox.Show("Game Over");
                Application.Exit();
            }
        }
        public void ResetBars()// can barlarını bölüm değiştikçe resetler
        {
            Bar1.Visible = false;
            Bar2.Visible = false;
            Bar3.Visible = false;
            Bar4.Visible = false;
            HealthOfEnemy.Visible = false;
            HealthOfEnemy2.Visible = false;
            HealthOfEnemy3.Visible = false;
            HealthOfEnemy4.Visible = false;
            e1.Visible = false;
            e2.Visible = false;
            e3.Visible = false;
            e4.Visible = false;
            HealthOfEnemy.Width = 200;
            HealthOfEnemy2.Width = 200;
            HealthOfEnemy3.Width = 200; 
            HealthOfEnemy4.Width = 200;
        }

        
    }
   
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    class Game
    {

        public Skills SkillİnRoom;// odadaki silahı tutar

        public bool PİR = true;// potionın içildiğini gösterir.

        public Potion PotionİnRoom;// odada potion varsa onu tutar.

        int _level = 0; // oyun seviyelerini tutar.

         Player _Player; // oyuncumuzu yaratıp game classına bağlamamızı sağlar.

        public Player player { get { return _Player; } } // oyuncuya ait bilgileri alabilmenizi sağlar.

        Random Random = new Random();

        public List<Enemy> Enemies; // oyundaki düşmanları tutar.

       

        public Point PlayerNewLocation { get { return _Player.Location; } }// oyuncunun konumu

        
        private Rectangle rectangle;// oyundaki hareket edebileceğimiz alanı tutar.
        public Rectangle _rectangle
        {
            get { return rectangle; }
        }
        
        public bool CheckSkills(string SkillName)// envanterında olup olmadığını kontrol eder
        {
            return _Player.inventory.Contains(SkillName);
        }

        public Game(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            _Player = new Player(this, new Point(rectangle.Left + 20, rectangle.Top + 133));
            
        }

        public void Move(Keys code)// move methodu buradan sınıflara gönderilir.
        {        
                _Player.Move(code);
   
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move();
                if (enemy.healthpoint >0)
                {
                    enemy.StartAttack();
                }
                
            }


        }
        public void NewLevel()// bu kısım levellar arası geçişi ve odadaki skill,düşman ve iksiri ekler.
        {
            _level++;
            switch (_level)
            {
                case 1:
                    Enemies = new List<Enemy>()
                    {
                        new Gladiator(this,GetRandomLocation(Random)),
                         

                    };
                    PotionİnRoom = new Potion(this, GetRandomLocationforskills(Random));
                    SkillİnRoom = new skill1(this, GetRandomLocationforskills(Random));

                    break;
                case 2:
                    SkillİnRoom = null;
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new SmallDragon(this,GetRandomLocation2(Random)),
                    };
                    
                    SkillİnRoom = new skill2(this, GetRandomLocationforskills(Random));
                    break;
                case 3:
                    SkillİnRoom = null;
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new Boss(this,GetRandomLocation(Random))
                    };
                    
                    SkillİnRoom = new skill3(this, GetRandomLocationforskills(Random));
                    break;
                case 4:
                    SkillİnRoom = null;
                    Enemies.Clear();
                    
                    Enemies = new List<Enemy>()
                    {
                        new BossDragon(this,GetRandomLocation(Random))
                    };
                    SkillİnRoom = new skill4(this, GetRandomLocationforskills(Random));
                    if (PotionİnRoom == null)
                    {
                        PİR = true;
                        player.potion = false;
                    PotionİnRoom = new Potion(this, GetRandomLocationforskills(Random));
                    }
                   
                    break;
                case 5:
                    SkillİnRoom = null;
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new Gladiator(this,GetRandomLocation(Random)),
                        new SmallDragon(this,GetRandomLocation2(Random)),
                    };
                    
                    SkillİnRoom = new skill5(this, GetRandomLocationforskills(Random));
                    break;
                case 6:
                    
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new SmallDragon(this,GetRandomLocation2(Random)),
                        new Boss(this,GetRandomLocation2(Random)),
                    };

                   
                    break;
                case 7:
                    
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new BossDragon(this,GetRandomLocation(Random)),
                        new SmallDragon(this,GetRandomLocation2(Random)),
                    };

                   
                    break;
                case 8:
                    
                    Enemies.Clear();
                    Enemies = new List<Enemy>()
                    {
                        new Boss(this,GetRandomLocation(Random)),
                        new BossDragon(this,GetRandomLocation2(Random)),
                    };
                    break;
                case 9:
                    
                    
                    Enemies.Clear();
                        Enemies = new List<Enemy>()
                        {
                            new Boss(this, GetRandomLocation(Random)),
                            new BossDragon(this, GetRandomLocation2(Random)),
                            new Gladiator(this, GetRandomLocation(Random)),
                            new SmallDragon(this, GetRandomLocation2(Random)),
                        };
                    if (PotionİnRoom == null)
                    {
                        PİR = true;
                        player.potion = false;
                        PotionİnRoom = new Potion(this, GetRandomLocationforskills(Random));
                    }
                    break;
                default:
                    MessageBox.Show("You Win!");
                    Application.Exit();
                    break;
            }

            
        }
        public Point GetRandomLocation(Random rndm)// üç ayrı random konum atama kullanılıyor(üst üste binmeyi azaltmak için.).
        {
            Point axis = new Point(rndm.Next(rectangle.X+450,rectangle.X+644),rndm.Next(rectangle.Y+50,rectangle.Y+100));
            return axis;
        }
        public Point GetRandomLocation2(Random rndm)
        {
            Point axis = new Point(rndm.Next(rectangle.X + 450, rectangle.X + 644), rndm.Next(rectangle.Y + 100, rectangle.Y + 250));
            return axis;
        }

        public Point GetRandomLocationforskills(Random rndm)
        {
            Point axis = new Point(rndm.Next(rectangle.X + 50, rectangle.X + 400), rndm.Next(rectangle.Y + 30, rectangle.Y + 218));
            return axis;
        }

        public void equip(string SkillName)//envanterdeki herhangi skille tıklandığında çalışır ve player sınıfına yönlendirir.
        {
            _Player.Equip(SkillName);
        }
        public void Attack(Keys code)// saldırı sistemini oluşturur.
        {

            
            foreach (Enemy enemy in Enemies)
            {
                _Player.Attack(PlayerNewLocation,enemy.Location,code);
                if (player.ControlSkill())
                {
                    if (enemy.healthpoint > 0)
                    {
                        enemy.StartAttack();
                    }
                    
                }
                
            }
        }
       

        
            
        
       
    }
}

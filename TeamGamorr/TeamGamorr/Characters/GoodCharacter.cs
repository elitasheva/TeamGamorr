using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Interfaces;
using System.Collections.Generic;
using TeamGamorr.Items;


namespace TeamGamorr.Characters
{
    
    public abstract class GoodCharacter : Character,IMovable,IGoodCharacter
    {
        private string gender;
        private int money;
        private int expirience;
        private int shield;
       
        private KeyboardState ks;
        private List<IItem> inventory;
        private readonly Random rnd = new Random();
        private float speed;
        private const int ParamRandomDamage = 50;
        private const int MaxValueExpirience = 300;
        private const int MaxValueShield = 350;


        protected GoodCharacter(string name, int health,string gender,int money,int expirience, int shield, 
            ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping) 
            : base(name,health,Content,rightWalk,leftWalk,upWalk,downWalk,frameSpeed,numOfFrames,looping)
        {
            this.Gender = gender;
            this.Money = money;
            this.Expirience = expirience;
            this.Shield = shield;
            this.inventory = new List<IItem>();
            this.Inventory = inventory;
            this.speed = 3f;
  
        }
           
        public string Gender { get;  }

        public int Money
        {
            get { return this.money; }
            set {
                if (value < 0)
                {
                  throw  new ArgumentOutOfRangeException("Money connot be negative.");
                }
            }
        }

        public int Expirience
        {
            get { return this.expirience; }
            set
            {
                if (value > MaxValueExpirience)
                {
                    this.expirience = MaxValueExpirience;
                }
                else
                {
                    if (value < 0)
                    {
                        this.expirience = 0;
                    }
                    this.expirience = value;
                }
            }
        }

        public int Shield
        {
            get { return this.shield; }
            set
            {
                if (value > MaxValueShield)
                {
                    this.shield = MaxValueShield;
                }
                else
                {
                    if (value < 0)
                    {
                        this.shield = 0;
                    }
                    this.shield = value;
                }
            }
        }
        public bool IsActive { get; set; }
        public List<IItem> Inventory { get; }
        public float Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }


        public virtual void Move(GameTime gameTime)
        {

            collision.Location = new Point((int)this.position.X, (int)this.position.Y);
            collBoxLR.Width = (int)(collision.Width + speed * 2);
            collBoxLR.Height = collision.Height*2;
            collBoxLR.Location = new Point((int)(this.collision.X - speed), (int)this.collision.Y);
            collBoxUD.Height = (int)(collision.Height + speed * 2);
            collBoxUD.Location = new Point((int)this.collision.X, (int)(this.collision.Y - speed));
            
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                WindowsGame1.Collision.collisionRight(this);
                position.X += speed;
                this.currentAnim = this.rightWalk;
                PlayAnimation(gameTime);
                speed = 2;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {   
                WindowsGame1.Collision.collisionLeft(this);
                position.X -= speed;
                this.currentAnim = this.leftWalk;
                PlayAnimation(gameTime);
                speed = 2;
            }
            else if (ks.IsKeyDown(Keys.Up))
            {
                WindowsGame1.Collision.collisionUp(this);

                position.Y -= speed;
                this.currentAnim = this.upWalk;
                PlayAnimation(gameTime);
                speed = 2;

            }
            else if (ks.IsKeyDown(Keys.Down))
            {
                WindowsGame1.Collision.collisionDown(this);

                position.Y += speed;
                this.currentAnim = this.downWalk;
                PlayAnimation(gameTime);
                speed = 2;
            }
            else
            {
                this.SourceRect = new Rectangle(0, 0, this.frameWidth, this.frameHeight);           
            }

            
        }

        public override void RespondToCollision(Character evil)
        {

            int damage = rnd.Next(ParamRandomDamage, 2*ParamRandomDamage);
            ChangeState(damage);
            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsDead = true;
            }
           
        }   

        public virtual void AddToInventory(IItem item)
        {
            this.ApplyItemEffects(item);
            this.Inventory.Add(item);
        }

        public virtual void RemoveFromInventory(IItem item)
        {
            this.RemoveItemEffects(item);
            this.Inventory.Remove(item);
        }

        protected virtual void ApplyItemEffects(IItem item)
        {
            this.Health += item.HealthEffect;
            this.Shield += item.DefenseEffect;
            this.Expirience += item.ExpirienceEffect;
        }

        protected virtual void RemoveItemEffects(IItem item)
        {
            this.Health -= item.HealthEffect;
            this.Shield -= item.DefenseEffect;
            this.Expirience -= item.ExpirienceEffect;
        }

        public void ChangeExpirience(int expirience)
        {
            this.Expirience += expirience;
            
        }


        private void ChangeState(int damage)
        {

            if ((this.Shield - damage) > 0)
            {
                this.Shield -= damage;
            }
            else
            {
                damage -= this.Shield;
                this.Shield = 0;
                if ((this.Health - damage) <= 0)
                {
                    this.IsDead = true;
                    this.Health = 0;
                }
                else
                {
                    this.Health -= damage;
                }

            }
        }

    }
}

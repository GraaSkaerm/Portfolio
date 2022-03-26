using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonCMD
{
    class Pokemon
    {
        private int health;

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health 
        { 
            get => health;
            set
            {
                health = value;

                if (health < 0)
                    health = 0;
                else if (health > MaxHealth)
                    health = MaxHealth;
            } 
        }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }

        public Pokemon(int userID, string name, int level, int health, int maxHealth, int damage, int speed)
        {
            this.UserID = userID;
            this.Name = name;
            this.Level = level;
            this.MaxHealth = maxHealth;
            this.Health = health;
            this.Damage = damage;
            this.Speed = speed;
        }

        public Pokemon(int userID, int level, string type)
        {
            this.UserID = userID;
            this.Level = level;
        }

        public Pokemon(object[] values)
        {
            this.ID = int.Parse(values[0].ToString());
            this.UserID = int.Parse(values[1].ToString());
            this.Name = values[2].ToString();
            this.Level = int.Parse(values[3].ToString());
            this.MaxHealth = int.Parse(values[5].ToString());
            this.Health = int.Parse(values[4].ToString());
            this.Damage = int.Parse(values[6].ToString());
            this.Speed = int.Parse(values[7].ToString());
        }

        public Pokemon(int userID, string name, int level)
        {
            this.UserID = userID;
            this.Name = name;
            this.Level = level;

            Random random = new Random(DateTime.Now.Millisecond);

            this.Damage = random.Next(1, 3);
            this.MaxHealth = random.Next(14, 18);
            this.Health = this.MaxHealth;
            this.Speed = random.Next(3, 7);

            if (level != 1)
            {
                for (int i = 0; i < level - 1; i++)
                {
                    LevelUp();
                }
            }
        }

        public Pokemon(int userID = default, int level = 1)
        {
            this.UserID = userID;
            this.Level = level;
            Random random = new Random(DateTime.Now.Millisecond);
            List<PokedexPokemon> pokenames = GameManager.PokedexTable.GetAll().ToList();
            this.Name = pokenames[random.Next(0, pokenames.Count)].Name;

            this.Damage = random.Next(1, 3);
            this.MaxHealth = random.Next(14, 18);
            this.Health = this.MaxHealth;
            this.Speed = random.Next(3, 7);

            if (level != 1)
            {
                for (int i = 0; i < level - 1; i++)
                {
                    LevelUp();
                }
            }
        }

        public void LevelUp()
        {
            this.Level++;

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 5; i++)
            {
                int r = random.Next(0, 3);

                switch (r)
                {
                    case 0: this.MaxHealth += 1; break;
                    case 1: this.Damage += 1; break;
                    case 2: this.Speed += 1; break;
                    default: break;
                }
            }

            this.Health = this.MaxHealth;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    enum PotionType {smallHealth, mediumHealth, LargeHealth, PlusOneSpeed, PlusOneDamage, PlusOneLevel, PlusTwoMaxhealth}

    class Potion
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public PotionType Type { get; set; }
        public int Amount { get; set; }

        public Potion(object[] values)
        {
            this.ID = int.Parse(values[0].ToString());
            this.UserID = int.Parse(values[1].ToString());
            this.Type = (PotionType)Enum.Parse(typeof(PotionType), values[2].ToString());
            this.Amount = int.Parse(values[3].ToString());
        }

        public Potion(int userID, PotionType type, int amount)
        {
            this.UserID = userID;
            this.Type = type;
            this.Amount = amount;
        }

        public Potion(int id, int userID, PotionType type, int amount)
        {
            this.ID = id;
            this.UserID = userID;
            this.Type = type;
            this.Amount = amount;
        }

        public void UseOn(Pokemon pokemonToUseOn)
        {
            switch (Type)
            {
                case PotionType.smallHealth:
                    pokemonToUseOn.Health += 15;
                    break;
                case PotionType.mediumHealth:
                    pokemonToUseOn.Health += 30;
                    break;
                case PotionType.LargeHealth:
                    pokemonToUseOn.Health += 60;
                    break;
                case PotionType.PlusOneSpeed:
                    pokemonToUseOn.Speed += 1;
                    break;
                case PotionType.PlusOneDamage:
                    pokemonToUseOn.Damage += 1;
                    break;
                case PotionType.PlusOneLevel:
                    pokemonToUseOn.LevelUp();
                    break;
                case PotionType.PlusTwoMaxhealth:
                    pokemonToUseOn.MaxHealth += 2;
                    break;
                default:
                    break;
            }
        }
    }
}

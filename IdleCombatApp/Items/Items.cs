using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdleCombatApp.Items
{
    public interface IItems
    {
        int Level { get; set; }
        int Hitpoints { get; set; }
        int Power { get; set; }
        int Armor { get; set; }
        int Regen { get; set; }
    }
    
    public class ItemBase: IItems
    {
        public int Level { get; set; }
        public int Hitpoints { get; set; }
        public int Power { get; set; }
        public int Armor { get; set; }
        public int Regen { get; set; }

        public ItemBase(int Level, int Hitpoints, int Power, int Armor, int Regen)
        {
            this.Level = Level;
            this.Hitpoints = Hitpoints;
            this.Power = Power;
            this.Armor = Armor;
            this.Regen = Regen;
        }
    }

    //TODO use this to fix the Character class
    public class Helmet : ItemBase
    {
        public int test { get; set; }
        public Helmet(int Level, int Hitpoints, int Power, int Armor, int Regen):base(Level,Hitpoints,Power, Armor, Regen)
        {
            
        }
    }
    public class Body : ItemBase
    {
        public Body(int Level, int Hitpoints, int Power, int Armor, int Regen) : base(Level, Hitpoints, Power, Armor, Regen)
        {

        }
    }
    public class Weapon : ItemBase
    {
        public Weapon(int Level, int Hitpoints, int Power, int Armor, int Regen) : base(Level, Hitpoints, Power, Armor, Regen)
        {

        }
    }
}

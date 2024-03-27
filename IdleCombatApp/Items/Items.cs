using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IdleCombatApp.Items
{
    public class Items:ItemModels
    {
        public ItemBase CreateItem(int MonsterLevel)
        {
            ItemBase item = new ItemBase(MonsterLevel, MonsterLevel, MonsterLevel, MonsterLevel);
            return item;
        }
    }


    public class ItemModels
    {
        public int Hitpoints { get; set; }
        public int Power { get; set; }
        public int Armor {  get; set; }
        public int Regen {  get; set; }
    }

    public class ItemBase:ItemModels
    {
        public ItemBase(int Hitpoints, int Power, int Armor, int Regen)
        {
            this.Hitpoints = Hitpoints;
            this.Power = Power;
            this.Armor = Armor;
            this.Regen = Regen;
            
        }
    }
}

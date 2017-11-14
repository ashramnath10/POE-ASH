using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;


public class FactoryBuilding:Building
    {
        //prvate member declarations
        private string unitType;
        private int rate;
        private int unitX;
        private int unitY;

        public string UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }

        public int Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public int UnitX
        {
            get
            {
                return unitX;
            }

            set
            {
                unitX = value;
            }
        }

        public int UnitY
        {
            get
            {
                return unitY;
            }

            set
            {
                unitY = value;
            }
        }
        //Constructor
        public FactoryBuilding(int xB1, int yB1, int hpB1, bool facB1, char symB, string unityP, int rt, int bUnitX, int bUnitY) : base(xB1, yB1, hpB1, facB1, symB)
        {
            UnitType = unityP;
            Rate = rt;
            UnitX = bUnitX;
            UnitY = bUnitY;
        }
        public Unit GenerateUnit()
        {
            if (UnitType == "Melee")
            {
                if (Faction == false)
                {
                    MeleeUnit u = new MeleeUnit("Axeman",100, UnitX, UnitY, false, 'm');

                    return u;
                }
                else
                {

                    MeleeUnit u = new MeleeUnit("Axeman", 100,UnitX, UnitY, true, 'M');
                    return u;
                }
            }
            else if (UnitType == "Ranged")
            {
                if (Faction == false)//DETERMINING UNIT TYPES
                {
                    RangedUnit u = new RangedUnit("Archer",100, UnitX, UnitY, false, 'r');
                    return u;
                }

                else
                {
                    RangedUnit u = new RangedUnit("Archer",100, UnitX, UnitY, true, 'R');
                    return u;
                }
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            return ("I can generate units which are of the " + Faction + "at a rate of " + Rate + " per second \n My current hp is " + Health);
        }
    public override bool IsDead()
    {
        if (this.Health < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}


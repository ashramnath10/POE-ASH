using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class Building
    {
        //Declarations
        private int xP;
        private int yP;
        private int health;
        private int maxHp;
        private bool faction;
        private char symbol;
    //properties
        public int XP
        {
            get
            {
                return xP;
            }

            set
            {
                xP = value;
            }
        }

        public int YP
        {
            get
            {
                return yP;
            }

            set
            {
                yP = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public bool Faction
        {
            get
            {
                return faction;
            }

            set
            {
                faction = value;
            }
        }

        public char Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }

    //Constructor
    public Building(int x, int y, int hp, bool faction, char symbol)
        {
            this.xP = x;
            this.yP = y;
            this.health = hp;
            this.maxHp = hp;
            this.faction = faction;
            this.symbol = symbol;

        }
        //Deconstructor
        ~Building() { }
        // abstract methods to be overriden
        public abstract override string ToString();
        public abstract bool IsDead();
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Unit
    {
        //member declarations
        private string name;
        private int xP;
        private int yP;
        private int health;
        private int maxHp;
        private int speed;
        private int attack;
        private int atkRange;
        private bool faction;
        private char symbol;
        private bool combatF;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

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

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public int Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        public int AtkRange
        {
            get
            {
                return atkRange;
            }

            set
            {
                atkRange = value;
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

        public bool CombatF
        {
            get
            {
                return combatF;
            }

            set
            {
                combatF = value;
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
    public Unit(string name, int health, int x, int y, bool faction, char symbol, int maxHp, int attack, int attackRange, int speed)
        {
            this.name = name;
            this.health = health;
            this.maxHp = health;
            this.xP = y;
            this.yP = y; ;
            this.faction = faction;
            this.symbol = symbol;
            this.attack = attack;
            this.atkRange = attackRange;
            this.speed = speed;
        }
        //destructor
        ~Unit()
        {

        }
       
        public abstract int Move(int enX,int enY);
        public abstract void Combat(Unit enemy);
        public abstract bool CheckRange(int enX,int enY);
        public abstract Unit ClosestUnit(Unit[] enemies);
        public abstract int Run();
        public abstract bool IsDead();
        public abstract override string ToString();
        public abstract Building ClosestBuilding(Building[] structures);
       
    }


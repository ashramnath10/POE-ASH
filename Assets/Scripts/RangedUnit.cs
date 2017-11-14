using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

public class RangedUnit:Unit
    {
        public RangedUnit(string name, int health, int xP, int yP, bool faction, char symbol) : base(name, health, xP, yP, faction, symbol, 100, 10, 2, 2)
        {

        }
        //methods being overriden
        public override int Move(int enX,int enY)
        {
            int direction = 0;
            int xDistance = this.XP - enX;
            int xAbs = Math.Abs(xDistance);
            int yDistance = this.YP - enY;
            int yAbs = Math.Abs(yDistance);
            if (yDistance == 0)
            {
                if (xDistance < 0 && (XP + 1) > 0)
                {
                    
                    direction = 4;
                }
                else if (xDistance > 0 && (XP - 1) < 19)
                {
                    
                    direction = 2;
                }
            }
            else if (xDistance == 0)
            {
                if (yDistance < 0 && (YP + 1) < 19)
                {
                    
                    direction = 1;
                }
                else if (yDistance > 0 && (YP - 1) > 0)
                {
                    
                    direction = 3;
                }
            }
            if (xAbs < yAbs || xAbs == yAbs)
            {
                if (xDistance < 0 && (XP + 1) > 0)
                {
                    
                    direction = 4;
                }
                else if (xDistance > 0 && (XP - 1) < 19)
                {
                    
                    direction = 2;
                }
            }
            if (yAbs < xAbs)
            {
                if (yDistance < 0 && (YP + 1) < 19)
                {
                    
                    direction = 1;
                }
                else if (yDistance > 0 && (YP - 1) > 0)
                {
                    
                    direction = 3;
                }
            }
            return direction;
        }
        public override void Combat(Unit enemy)
        {
            enemy.Health -= this.Attack;
        }
        public override bool CheckRange(int enX,int enY)
        {
            int xDistance = Math.Abs(this.XP - enX);
            int yDistance = Math.Abs(this.YP - enY);
            if (this.AtkRange >= xDistance && this.AtkRange >= yDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override Unit ClosestUnit(Unit[] enemies)
        {
            int tempDistance = 100;
            Unit tempUnit = null;
            foreach (Unit enemy in enemies)
            {
                if (enemy != null && enemy != this && enemy.Faction != this.Faction && !enemy.IsDead())
                {
                    int xDistance = Math.Abs(this.XP - enemy.XP);
                    int yDistance = Math.Abs(this.YP - enemy.YP);
                    int totalDistance = xDistance + yDistance;
                    if (totalDistance < tempDistance)
                    {
                        tempUnit = enemy;
                        tempDistance = totalDistance;
                    }
                }
            }
            return tempUnit;
        }
        public override int Run()
        {
            int returnValue = 0;
            bool validDirection = false;
            while (validDirection == false)
            {

                System.Random r = new System.Random();
                returnValue = r.Next(1, 5);
 
                switch (returnValue)
                {
                    case 1:
                        {
                            if (XP + 1 < 19)
                            {
                                validDirection = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (YP - 1 > 0)
                            {
                                validDirection = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (XP - 1 > 0)
                            {
                                validDirection = true;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (YP + 1 < 19)
                            {
                                validDirection = true;
                            }
                            break;
                        }
                }
            }
            return returnValue;
        }
    public override Building ClosestBuilding(Building[] structures)
    {
        int tempDist = 100;
        Building tempB = null;
        foreach (Building bl in structures)
        {
            if (bl != null && bl.Faction != this.Faction && !bl.IsDead())
            {
                int xDist = Math.Abs(this.XP - bl.XP);
                int yDist = Math.Abs(this.YP - bl.YP);
                int totalDist = xDist + yDist;
                if (totalDist < tempDist)
                {
                    tempB = bl;
                    tempDist = totalDist;
                }
            }
        }
        return tempB;
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
        public override string ToString()
        {
            return ("i Am  Melee unit and my name is:\n " + Name + " I have " + Health + " hp and my co-ordinates are x: " + XP + "\n y: " + YP);
        }
    

}

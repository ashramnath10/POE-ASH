using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

public class MeleeUnit:Unit
    {
        public MeleeUnit(string name, int health, int xP, int yP, bool faction, char symbol) : base(name, health, xP, yP, faction, symbol, 100, 10, 1, 1)
        {

        }
        //methods being overriden
        public override int Move(int enX, int enY)
        {
            int direct = 0;
            int xDist = this.XP - enX;
            int xAbs = Math.Abs(xDist);
            int yDist = this.YP - enY;
            int yAbs = Math.Abs(yDist);
            if (yDist == 0)
            {
                if (xDist < 0 && (XP + 1) > 0)
                {
                
                    direct = 4;
                }
                else if (xDist > 0 && (XP - 1) < 19)
                {
                 
                    direct = 2;
                }
            }
            else if (xDist == 0)
            {
                if (yDist < 0 && (YP + 1) < 19)
                {
                 
                    direct = 1;
                }
                else if (yDist > 0 && (YP - 1) > 0)
                {
                   
                    direct = 3;
                }
            }
            if (xAbs < yAbs || xAbs == yAbs)
            {
                if (xDist < 0 && (XP + 1) > 0)
                {
                   
                    direct = 4;
                }
                else if (xDist > 0 && (XP - 1) < 19)
                {
                  
                    direct = 2;
                }
            }
            if (yAbs < xAbs)
            {
                if (yDist < 0 && (YP + 1) < 19)
                {
                    
                    direct = 1;
                }
                else if (yDist > 0 && (YP - 1) > 0)
                {
                   
                    direct = 3;
                }
            }
            return direct;
        }
        public override void Combat(Unit enemy)
        {
            enemy.Health -= this.Attack;
        }
        public override bool CheckRange(int enX,int enY)
        {
            int xDist = Math.Abs(this.XP - enX);
            int yDist = Math.Abs(this.YP - enY);
            if (this.AtkRange >= xDist && this.AtkRange >= yDist)
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
            int tempDist = 100;
            Unit tempU = null;
            foreach (Unit enemy in enemies)
            {
                if (enemy != null && enemy != this && enemy.Faction != this.Faction && !enemy.IsDead())
                {
                    int xDist = Math.Abs(this.XP - enemy.XP);
                    int yDist = Math.Abs(this.YP - enemy.YP);
                    int totalDist = xDist + yDist;
                    if (totalDist < tempDist)
                    {
                        tempU = enemy;
                        tempDist = totalDist;
                    }
                }
            }
            return tempU;
        }
        public override int Run()
        {
            int returnVal = 0;
            bool validDir = false;
            while (validDir == false)
            {

                System.Random r = new System.Random();
                returnVal = r.Next(1, 5);
                switch (returnVal)
                {
                    case 1:
                        {
                            if (XP + 1 < 19)
                            {
                                validDir = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (YP - 1 > 0)
                            {
                                validDir = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (XP - 1 > 0)
                            {
                                validDir = true;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (YP + 1 < 19)
                            {
                                validDir = true;
                            }
                            break;
                        }
                }
            }
            return returnVal;
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

    //Melee information tobe outputted
    public override string ToString()
        {
            return ("i Am  Melee unit and my name is:\n " + Name + " I have " + Health + " hp and my co-ordinates are x: " + XP + "\n y: " + YP);
        }


    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

public class ResourceBuilding:Building
    {//member variables
        private string resType;
        private int maxRes;
        private int remRes;
        private int resTick;
    //properties
        public string ResType
        {
            get
            {
                return resType;
            }

            set
            {
                resType = value;
            }
        }

        public int MaxRes
        {
            get
            {
                return maxRes;
            }

            set
            {
                maxRes = value;
            }
        }

        public int RemRes
        {
            get
            {
                return remRes;
            }

            set
            {
                remRes = value;
            }
        }

        public int ResTick
        {
            get
            {
                return resTick;
            }

            set
            {
                resTick = value;
            }
        }
        public ResourceBuilding(int xB1, int yB1, int hpB1, bool facB1, char symB1, int maxr, string resTp, int remT, int res) : base(xB1, yB1, hpB1, facB1, symB1)//constructor assigning values to members
        {
            this.ResType = resTp;
            this.MaxRes = maxr;
            this.ResTick = remT;
            this.RemRes = maxr;


        }
        public void GenerateResources()//updating remaining resources
        {
            RemRes -= ResTick;

        }
        public override string ToString()//outputting resource building info
        {
            return "I am a Resource building and can generate " + MaxRes + " " + ResType + "I have " + RemRes + " resources remaining, so have generated" + (MaxRes - RemRes) + "of " + ResType;
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


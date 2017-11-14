using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;


public class Map
    {
        System.Random r = new System.Random();
        private Unit[] uArray;
        private Building[] bArray;
        private const int fix = 10;

        public Unit[] UArray
        {
            get
            {
                return uArray;
            }

            set
            {
                uArray = value;
            }
        }


        public Building[] BArray
        {
            get
            {
                return bArray;
            }

            set
            {
                bArray = value;
            }
        }
        //Constructor
        public Map(int numU, int numB)
        {
            uArray = new Unit[numU];
            bArray = new Building[numB];

         //   CreateEmptyMap();
            PopulateMap();
        }
       
        public void PopulateMap()
        {
            CreateUnits();
            CreateBuildings();
            FillMap();

        }
        public void CreateUnits()
        {
            for (int i = 0; i < uArray.Length; i++)
            {

                int unittpes = r.Next(1, 5);
                int tempX = r.Next(0, 20);
                int tempY = r.Next(0, 20);
                if (unittpes == 1)//DETERMINING UNIT TYPES and generating 
                {
                    uArray[i] = new MeleeUnit("Axeman",100, tempX, tempY, false, 'm');
                }
                else if (unittpes == 2)
                {
                    uArray[i] = new RangedUnit("Archer",100, tempX, tempY, false, 'r');
                }
                else if (unittpes == 3)
                {
                    uArray[i] = new MeleeUnit("Axeman",100, tempX, tempY, true, 'M');
                }
                else if(unittpes==4)
                {
                    uArray[i] = new RangedUnit("Archer",100, tempX, tempY, true, 'R');

                }

            }
        }
        public void CreateBuildings()
        {
            for (int i = 0; i < bArray.Length; i++)
            {

                int buildType= r.Next(0, 2);//building type to be spawned
                int buildFact = r.Next(0, 2);
                int btemX = r.Next(0, 20);
                int btemY = r.Next(0, 20);
                int spawnX = r.Next(0, 20);
                int spawnY = r.Next(0, 20);
                bool bFac;

                if (buildFact == 0)
                {
                if (buildType == 1)
                {

                    bArray[i] = new FactoryBuilding(btemX, btemY, 150, false, 'F', "Melee", 1, spawnX, spawnY);
                }
                else
                {
                    bArray[i] = new ResourceBuilding(btemX, btemY, 150, false, 'G', 50, "Wood", 20, 50);
                }
             

                }
                else if(buildFact==1)
                {
                if (buildType == 1)
                {

                    bArray[i] = new FactoryBuilding(btemX, btemY, 150, true, 'F', "Melee", 1, spawnX, spawnY);
                }
                else
                {
                    bArray[i] = new ResourceBuilding(btemX, btemY, 150, true, 'G', 50, "Wood", 20, 50);
                }
                
                }
            

            }
        }
        public void FillMap()
        {
            foreach(Unit unt in uArray)
            {
         
            if (unt.GetType().ToString() == "MeleeUnit")
            {
                if (unt.Faction)
                {
                    GameObject mUnit=(GameObject)MonoBehaviour.Instantiate(Resources.Load("fist_good"),new Vector3(unt.XP-fix,unt.YP-fix,-1), Quaternion.identity);
                    mUnit.transform.localScale = new Vector3(0.8f, 0.8f, -1);
                    mUnit.name = (unt.Name + ": " + unt.Faction);
                 
                }
                else
                {
                    GameObject mUnit = (GameObject)MonoBehaviour.Instantiate(Resources.Load("fist_bad"), new Vector3(unt.XP - fix, unt.YP - fix, -1), Quaternion.identity);
                    mUnit.transform.localScale = new Vector3(0.8f, 0.8f, -1);
                    mUnit.name = (unt.Name + ": " + unt.Faction);
            
                }
            }
            else
            {
                if (unt.Faction)
                {
                    GameObject rUnit = (GameObject)MonoBehaviour.Instantiate(Resources.Load("ranged_good"), new Vector3(unt.XP - fix, unt.YP - fix, -1), Quaternion.identity);
                    rUnit.transform.localScale = new Vector3(0.4f, 0.4f, -1);
                    rUnit.name = (unt.Name + ": " + unt.Faction);
                
                }
                else
                {
                    GameObject rUnit = (GameObject)MonoBehaviour.Instantiate(Resources.Load("ranged_bad"), new Vector3(unt.XP - fix, unt.YP - fix, -1), Quaternion.identity);
                    rUnit.transform.localScale = new Vector3(0.4f, 0.4f, -1);
                    rUnit.name = (unt.Name + ": " + unt.Faction);
            
                }
            }
            }
            foreach(Building bdg in bArray)
            {
          
            if (bdg.GetType().ToString() == "FactoryBuilding")//maybe add if lik in units
            {
                GameObject blding = (GameObject)MonoBehaviour.Instantiate(Resources.Load("fact_bad"), new Vector3(bdg.XP - fix, bdg.YP - fix, -1), Quaternion.identity);
                blding.transform.localScale = new Vector3(0.8f, 0.8f, 0);
            }
            else if (bdg.GetType().ToString() == "ResourceBuilding")
            {
                GameObject blding = (GameObject)MonoBehaviour.Instantiate(Resources.Load("mine_bad"), new Vector3(bdg.XP - fix, bdg.YP - fix, -1), Quaternion.identity);
                blding.transform.localScale = new Vector3(0.8f, 0.8f, 0);
            }
            }
      
        }
        public void MoveUnit(Unit unitL,int locX,int locY)
        {
          
            UnitUpdate(unitL, locX, locY);
        }
        public void UnitUpdate(Unit unitL,int locX,int locY)
        {
            unitL.XP = locX;
            unitL.YP = locY;

        }
        public override string ToString()
        {
            string tempS = "";
            for(int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                   
                }
                tempS += Environment.NewLine;
            }
            return tempS;
        }
    
    }


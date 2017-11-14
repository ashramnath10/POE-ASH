using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
    //Declarations
    GameEngine gPlay;
    private Map mapObj;
    public int ticks = 0;//to be updated 
    private int gTime = 0;
    public const int refresh = 60;
    public const int fix = 10;
    public GameEngine(int numU, int numB)
    {
        mapObj = new Map(numU, numB);
    }
    //Map property
    public Map MapObj
    {
        get
        {
            return mapObj;
        }

        set
        {
            mapObj = value;
        }
    }

    //Main playgame method
    public void playGame()
    {
        ++ticks;
        for (int i = 0; i < mapObj.BArray.Length; ++i)
        {
            if (mapObj.BArray[i] != null && mapObj.BArray[i].GetType().ToString() == "ResourceBuilding")
            {
                if (mapObj.BArray[i] != null && !mapObj.BArray[i].IsDead())
                {
                    (mapObj.BArray[i] as ResourceBuilding).GenerateResources();
                    mapObj.BArray[i].ToString();
                }
                else if (mapObj.BArray[i] != null && mapObj.BArray[i].IsDead())
                {
                    mapObj.BArray[i] = null;
                }

            }
            else if (mapObj.BArray[i] != null && mapObj.BArray[i].GetType().ToString() == "FactoryBuilding")
            {
                if (mapObj.BArray[i] != null && ticks % (mapObj.BArray[i] as FactoryBuilding).Rate == 0)
                {
           
                    Unit[] tempUArray = new Unit[mapObj.UArray.Length + 1];
                    for (int j = 0; j < mapObj.UArray.Length; ++j)
                    {
                        tempUArray[j] = mapObj.UArray[j];
                    }
                    tempUArray[tempUArray.Length - 1] = (mapObj.BArray[i] as FactoryBuilding).GenerateUnit();
                   mapObj.UArray = tempUArray;
                }
                else if (mapObj.BArray[i] != null && mapObj.BArray[i].IsDead())
                {
                    mapObj.BArray[i] = null;
                }
                else if (mapObj.BArray[i] == null)
                {
                    Debug.Log("people are dead");
                }

            }
        }

       
        Actions();
        Redraw();
    }
 
    public void Actions()
    {
        ticks++;
        for (int i = 0; i < mapObj.UArray.Length; ++i)
        {
            if (mapObj.UArray[i] != null && !mapObj.UArray[i].IsDead())
            {
               
                Unit tenemy = mapObj.UArray[i].ClosestUnit(mapObj.UArray);
                Building buildtemp = mapObj.UArray[i].ClosestBuilding(mapObj.BArray);
                if (buildtemp != null)
                {
                    AttackBuilding(mapObj.UArray[i], buildtemp);
                }
                else
                {
                    AttackUnit(mapObj.UArray[i], tenemy);
                }
            }
            else if (mapObj.UArray[i] != null && mapObj.UArray[i].IsDead())
            {
               
                mapObj.UArray[i].Symbol = 'T';
                mapObj.UArray[i] = null;
            }
        }
    }

    //allowing units to attack buildings
    public void AttackBuilding(Unit u, Building targB)
    {
        if (targB != null)
        {

            if (u.Health < 25)
            {
                int direct = u.Run();
                switch (direct)
                {
                    
                    case 1:
                        {
                            MapObj.MoveUnit(u, u.XP + 1, u.YP);
                            break;
                        }
                    case 2:
                        {

                            MapObj.MoveUnit(u, u.XP, u.YP - 1);
                            break;
                        }
                    case 3:
                        {
                            MapObj.MoveUnit(u, u.XP - 1, u.YP);
                            break;
                        }
                    case 4:
                        {
                            MapObj.MoveUnit(u, u.XP, u.YP + 1);
                            break;
                        }
                }
            }
            if (u.CombatF == true && !targB.IsDead() && u.CheckRange(targB.XP, targB.YP))
            {
       
                targB.Health -= u.Attack;
                u.CombatF = true;
            }
            else if (u.CombatF == false && u.CheckRange(targB.XP, targB.YP))
            {
              
                targB.Health -= u.Attack;
                u.CombatF = true;
            }
            else
            {
                u.CombatF = false;
                if (ticks % u.Speed == 0 && !targB.IsDead())
                {
                    int direction = u.Move(targB.XP, targB.YP);
                    switch (direction)
                    {
                 
                        case 1:
                            {
                                MapObj.MoveUnit(u, u.XP, u.YP + 1);
                                break;
                            }
                  
                        case 2:
                            {
                                MapObj.MoveUnit(u, u.XP - 1, u.YP);
                                break;
                            }
                       case 3:
                            {
                                MapObj.MoveUnit(u, u.XP, u.YP - 1);
                                break;
                            }

                        case 4:
                            {
                                MapObj.MoveUnit(u, u.XP + 1, u.YP);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
    //moving and engaging in combat
    public void AttackUnit(Unit u, Unit enemy)
    {
        if (enemy != null)
        {

            if (u.Health < 25)
            {
                int direct = u.Run();
                switch (direct)
                {
                  
                    case 1:
                        {

                            MapObj.MoveUnit(u, u.XP + 1, u.YP);
                            break;
                        }
                    case 2:
                        {
                            MapObj.MoveUnit(u, u.XP, u.YP - 1);
                            break;
                        }
                  
                    case 3:
                        {
                            MapObj.MoveUnit(u, u.XP - 1, u.YP);
                            break;
                        }
                    case 4:
                        {
                            MapObj.MoveUnit(u, u.XP, u.YP + 1);
                            break;
                        }
                }
            }
            if (u.CombatF == true && !enemy.IsDead() && u.CheckRange(enemy.XP, enemy.YP))
            {
 
                u.Combat(enemy);
                u.CombatF = true;
            }
            else if (u.CombatF == false && u.CheckRange(enemy.XP, enemy.YP))
            {
                u.Combat(enemy);
                u.CombatF = true;
            }
            else
            {
                u.CombatF = false;
                if (ticks % u.Speed == 0 && !enemy.IsDead())
                {
                    int direct = u.Move(enemy.XP, enemy.YP);
                    Debug.Log(direct + "moved");
                    switch (direct)
                    {
          
                        case 1:
                            {
                                MapObj.MoveUnit(u, u.XP, u.YP + 1);
                                break;
                            }
        
                        case 2:
                            {
                                MapObj.MoveUnit(u, u.XP - 1, u.YP);
                                break;
                            }
              
                        case 3:
                            {
                                MapObj.MoveUnit(u, u.XP, u.YP - 1);
                                break;
                            }
            
                        case 4:
                            {
                                MapObj.MoveUnit(u, u.XP + 1, u.YP);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
    public void Redraw()
    {
        GameObject[] displaying = GameObject.FindGameObjectsWithTag("display");
        foreach (GameObject tempChar in displaying)
        {
            Destroy(tempChar.gameObject);
        }
        foreach (Unit fighter in mapObj.UArray)
        {
            if (fighter != null)
            {
                if (fighter.GetType().ToString() == "MeleeUnit")
                {
                    if (fighter.Faction)
                    {
                        GameObject mUnit = (GameObject)Instantiate(Resources.Load("fist_good"), new Vector3(fighter.XP - fix, fighter.YP - fix, -1), Quaternion.identity);
                        mUnit.transform.localScale = new Vector3(0.6f, 0.6f, -1);
                      
              
                    }
                    else
                    {
                        GameObject mUnit = (GameObject)Instantiate(Resources.Load("fist_bad"), new Vector3(fighter.XP - fix, fighter.YP - fix, -1), Quaternion.identity);
                        mUnit.transform.localScale = new Vector3(0.6f, 0.6f, -1);
                     
                      
                    }
                }
                else
                {
                    if (fighter.Faction)
                    {
                        GameObject rUnit = (GameObject)Instantiate(Resources.Load("ranged_good"), new Vector3(fighter.XP - fix, fighter.YP - fix, -1), Quaternion.identity);
                        rUnit.transform.localScale = new Vector3(0.3f, 0.3f, -1);
                        rUnit.name = (fighter.Name + "," + fighter.Faction);
                       
                    }
                    else
                    {
                        GameObject rUnit = (GameObject)Instantiate(Resources.Load("ranged_bad"), new Vector3(fighter.XP - fix, fighter.YP - fix, -1), Quaternion.identity);
                        rUnit.transform.localScale = new Vector3(0.3f, 0.3f, -1);
                        rUnit.name = (fighter.Name + ": " + fighter.Faction);
                     
                    }
                }
                if (!fighter.IsDead())
                {
                    GameObject hp = (GameObject)Instantiate(Resources.Load(checkHealth(fighter.Health, fighter.MaxHp)), new Vector3(fighter.XP - fix, fighter.YP - fix + 0.7f, -1), Quaternion.identity);
                    hp.transform.localScale = new Vector3(0.5f, 1, 0);
                    hp.name = (fighter.Name + " Hp");
                }
            }
          
        }

        foreach (Building bas in mapObj.BArray)//instantiating buildings and display hp bars
        {
            if (bas != null)
            {
                if (bas.GetType().ToString() == "FactoryBuilding")
                {
                    if (bas.Faction)
                    {
                        GameObject factory = (GameObject)Instantiate(Resources.Load("Factory"), new Vector3(bas.XP - fix, bas.YP - fix, -1), Quaternion.identity);
                        factory.transform.localScale = new Vector3(0.3f, 0.3f, -1);
                        factory.name = (bas.GetType().ToString() + " , " + bas.Faction + " , " + bas.Health);
                    }
                    else
                    {
                        GameObject factory = (GameObject)Instantiate(Resources.Load("FactoryEvil"), new Vector3(bas.XP - fix, bas.YP - fix, -1), Quaternion.identity);
                        factory.transform.localScale = new Vector3(0.3f, 0.3f, -1);
                        factory.name = (bas.GetType().ToString() + " , " + bas.Faction + " , " + bas.Health);
                    }
                }
                else if (bas.GetType().ToString() == "ResourceBuilding")
                {
                    if (bas.Faction)
                    {
                        GameObject resource = (GameObject)Instantiate(Resources.Load("Resource"), new Vector3(bas.XP - fix, bas.YP - fix, -1), Quaternion.identity);
                        resource.transform.localScale = new Vector3(0.4f, 0.4f, -1);
                        resource.name = (bas.GetType().ToString() + " , " + bas.Faction + " , " + bas.Health);
                    }
                    else
                    {
                        GameObject resource = (GameObject)Instantiate(Resources.Load("ResourceEvil"), new Vector3(bas.XP - fix, bas.YP - fix, -1), Quaternion.identity);
                        resource.transform.localScale = new Vector3(0.4f, 0.4f, -1);
                        resource.name = (bas.GetType().ToString() + " , " + bas.Faction + " , " + bas.Health);
                    }
                }
                if (!bas.IsDead())
                {
                    GameObject hp = (GameObject)Instantiate(Resources.Load(checkHealth(bas.Health, bas.MaxHp)), new Vector3(bas.XP - fix, bas.YP - fix + 1.4f, -1), Quaternion.identity);
                    hp.transform.localScale = new Vector3(0.5f, 1, 0);
                    hp.name = (bas.GetType().ToString() + " Hp");
                }
            }
            else
            {
                Debug.Log("Redraw works");
            }
        }
    }
    string checkHealth(int hp, int maxHp)
    {
        string temp = "Hp";
        double hpPercent = ((double)hp / (double)maxHp) * 20;
        hpPercent = System.Math.Ceiling(hpPercent);
        int roundHp = System.Convert.ToInt32(hpPercent);
        temp += 21 - roundHp ;
        return temp;
    }
    // Use this for initialization

    void Start()
    {

        gPlay = new GameEngine(6, 3);
        GameObject map = (GameObject)Instantiate(Resources.Load("grass"), new Vector3(0.03f, 0.1f, 0), Quaternion.identity);
        map.transform.localScale = new Vector3(4.5f,4.8f,0);
    }
    // Update is called once per frame
    void Update()
    {

        //update game time and display every 60 f
        gTime++;
        if (gTime % refresh == 0)
        {
            gPlay.playGame();
        }
    }

}

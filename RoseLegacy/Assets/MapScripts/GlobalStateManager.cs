using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    public static GlobalStateManager Instance;
    //PLAYER STATS
    public int health;
    public int attack;
    public int defense;
    public int magic;
    public int speed;
    public List<Skill> GlobalPlayerSkills = new List<Skill>();
    //PLAYER CAMPAIGN
    public int CurrentNode;

    //MASTER LISTS
    public List<Skill> SkillMList = new List<Skill>();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //TEST
        //SkillMList.Add(new Skill("mtest1", "attack", 2));
        //SkillMList.Add(new Skill("mtest2", "attack", 2));
        //SkillMList.Add(new Skill("mtest3", "attack", 2));
        //SkillMList.Add(new Skill("mtest4", "attack", 2));

        //GlobalPlayerSkills.Add(new Skill("ptest1", "attack", 2));
        //GlobalPlayerSkills.Add(new Skill("ptest2", "attack", 2));
        //GlobalPlayerSkills.Add(new Skill("ptest3", "attack", 2));
        //GlobalPlayerSkills.Add(new Skill("ptest4", "attack", 2));

        health = 10;
        attack = 10;
        magic = 10;
        speed = 10;
        defense = 10;

    }

    void Start()
    {
        
    }

    //void saveState()
    //{
    //}
}

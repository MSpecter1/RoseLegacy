using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleManager : MonoBehaviour
{
    public GlobalStateManager globalstate;
    private int health;
    private int attack;
    private int speed;
    private int magic;
    public List<Skill> eskills = new List<Skill>();
    public Unit EnemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSkills();
        health = Mathf.FloorToInt(Random.value * 30) + 10;
        attack = Mathf.FloorToInt(Random.value * 10) + 10;
        magic = Mathf.FloorToInt(Random.value * 10) + 10;
        speed = Mathf.FloorToInt(Random.value * 5) + 10;
        EnemyUnit.loadStats("Monster", health, attack, speed, magic, eskills);
    }

    public void GenerateSkills()
    {
        //TWEAK LATER
        eskills.Add(globalstate.SkillMList[Random.Range(0, 3)]);
        eskills.Add(globalstate.SkillMList[Random.Range(0, 3)]);
        eskills.Add(globalstate.SkillMList[Random.Range(0, 3)]);
        eskills.Add(globalstate.SkillMList[Random.Range(0, 3)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

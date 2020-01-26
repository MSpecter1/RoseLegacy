using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string UnitName = "NONAME";
    public int health;
    public int attack;
    public int speed;
    public int magic;
    public List<Skill> skills = new List<Skill>();

    public GameObject actionPanel;

    public int NextTurnDmg;
    public string NextTurnSkill;
    public string NextTurnNonSkill;

    // Start is called before the first frame update
    void Start()
    {
        actionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadStats(string UName, int hp, int ad, int spd, int ap, List<Skill> Uskill)
    {
        UnitName = UName;
        health = hp;
        attack = ad;
        speed = spd;
        magic = ap;
        skills = Uskill;
    }

    public void CalculateNextTurn()
    {
        if (this.tag=="Player")
        {
            Debug.Log("Player Decides next move");
            int skillnum = Mathf.RoundToInt(Random.Range(0,3));
            Debug.Log(skillnum);
            NextTurnDmg = skills[skillnum].SkillDamage(attack, magic);
            NextTurnSkill = skills[skillnum].SkillName;
        }
        else
        {
            Debug.Log("Enemy makes random move");
            int skillnum = Mathf.RoundToInt(Random.Range(0, 3));
            NextTurnDmg = skills[skillnum].SkillDamage(attack, magic);
            NextTurnSkill = skills[skillnum].SkillName;
        }
    }

    public void AttackOtherUnit(Unit other, int damage)
    {
        other.health -= damage;
    }
}

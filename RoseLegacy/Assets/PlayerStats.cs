using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 *  1) HP = health
 *  2) AP = magic
 *  3) ATK = attack
 *  4) SPD = speed
 */
public class PlayerStats : MonoBehaviour
{

    public int health;
    public int magic;
    public int attack;
    public int speed;

    public PlayerStats(int hp, int ap, int atk, int spd)
    {
        this.health = hp;
        this.magic = ap;
        this.attack = atk;
        this.speed = spd;
    }

    public void setHP(int hp)
    {
        this.health = hp;
    }

    public void setAP (int ap)
    {
        this.magic = ap;
    }

    public void setATK (int atk)
    {
        this.attack = atk;
    }

    public void setSPD (int spd)
    {
        this.speed = spd;
    }

    public int getHP()
    {
        return this.health;
    }

    public int getAP()
    {
        return this.health;
    }

    public int getATK()
    {
        return this.attack;
    }

    public int getSPD()
    {
        return this.speed;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatistic : MonoBehaviour
{
    protected int level;
    protected float experience;
    protected float hitPoints;
    protected float defense;
    protected float strenght;
    protected float _speed;

    protected float defenseBuff;
    protected float strenghtBuff;
    protected float speedBuff;

    public float Speed
    {
        get
        {
            return _speed;
        }
    }
}

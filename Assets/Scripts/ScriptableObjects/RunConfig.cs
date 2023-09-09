using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using System;

[Serializable]
public class RunConfig
{
    public int id;
    public int userId;
    public int score;
    public DateTime startDate;
    public DateTime endDate;
    public int wave;
    public List<Artifact> artifacts;
    public List<Weapon> weapons;
    public List<Enemy> enemies;
}
[Serializable]
public class Weapon
{
    public int weaponId;
    public int picked;
}

[Serializable]
public class Enemy
{
    public int enemyId;
    public int deaths;
    public int seen;
    public int damage;
}
[Serializable]
public class Artifact
{
    public int artifactId;
    public int picked;
}

//conf

[Serializable]
public class EnemyConf
{
    /*"id": 1,
            "name": "Baby Bat",
            "health": 20,
            "damage": 20,
            "speed": 0.7*/
    public int id;
    public string name;
    public int health;
    public int damage;
    public float speed;
}
[Serializable]
public class WeaponConf
{
    public int id;
    public string name;
    public int damage;
    public float speed;
}
[Serializable]
public class ArtifactConf
{
    public int id;
    public string name;
    public int power;
}
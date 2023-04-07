using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Player
{
    //User's playing data everytime user enter chamber
    [SerializeField] private int health { get; set; }
    [SerializeField] private int shield { get; set; }
    [SerializeField] private int blank { get; set; }
    [SerializeField] private int silverKey { get; set; }
    [SerializeField] private int goldkey { get; set; }
    [SerializeField] private int shell {get;set;}
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private List<Item> activeItems;
    [SerializeField] private List<Item> passiveItems;
    [SerializeField] private List<Item> passives;
    [SerializeField] private List<Synergy> synergies;

    //User's store data
    [SerializeField] private List<Weapon> weaponCollection;
    [SerializeField] private List<Item> itemCollection;
    [SerializeField] private List<Enemy> enemyCollection;
    [SerializeField] private List<Boss> bossCollection;

    public Player(List<Weapon> _weapons, List<Item> _items)
    {
        health = 6;
        shield = 0;
        blank = 0;
        silverKey = 0;
        goldkey = 0;
        shell = 0;

        weapons = _weapons;
        foreach (Item _i in _items)
        {
            //Check item type [Active or Passive]
            activeItems.Add(_i);
            passiveItems.Add(_i);
        }
    }
    public void addInList(object obj)
    {
        switch (obj.GetType().Name)
        {
            case "Item":
                var tmp = (Item)obj;
                if (!itemCollection.Contains(tmp))
                {
                    itemCollection.Add(tmp);
                }
                break;

            case "Weapon":
                var tmp1 = (Weapon)obj;
                if (!weapons.Contains(tmp1))
                {
                    weapons.Add(tmp1);
                }
                if (!weaponCollection.Contains(tmp1))
                {
                    weaponCollection.Add(tmp1);
                }
                break;

            case "Synergy":
                var tmp2 = (Synergy)obj;
                if (!synergies.Contains(tmp2))
                {
                    synergies.Add(tmp2);
                }
                break;

            case "Enemy":
                var tmp3 = (Enemy)obj;
                if (!enemyCollection.Contains(tmp3))
                {
                    enemyCollection.Add(tmp3);
                }
                break;

            case "Boss":
                var tmp4 = (Boss)obj;
                if (!bossCollection.Contains(tmp4))
                {
                    bossCollection.Add(tmp4);
                }
                break;
        }
    }
}

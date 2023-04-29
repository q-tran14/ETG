using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

[System.Serializable]
public class Player
{
    //User's playing data everytime user enter chamber
    public string name;
    public int health;
    public int shield;
    public int blank;
    public int silverKey;
    public int goldkey;
    public int shell;
    public List<Weapon> weapons;
    public List<Item> activeItems;
    public List<Item> passiveItems;
    public List<Synergy> synergies;

    public Player(CharacterData characterData)
    {
       name = characterData.name;
       health = characterData.HP;
       shield = characterData.Shield;
       blank = characterData.Blank;
       silverKey = characterData.SilverKey;
        goldkey = characterData.GoldKey;
        shell = characterData.Coin;
    }

    public void addInList(object obj)
    {
        switch (obj.GetType().Name)
        {
            case "Item":
                var tmp = (Item)obj;
                if (!activeItems.Contains(tmp))
                {
                    activeItems.Add(tmp);
                }
                if (!passiveItems.Contains(tmp))
                {
                    passiveItems.Add(tmp);
                }
                break;

            case "Weapon":
                var tmp1 = (Weapon)obj;
                if (!weapons.Contains(tmp1))
                {
                    weapons.Add(tmp1);
                }
                break;

            case "Synergy":
                var tmp2 = (Synergy)obj;
                if (!synergies.Contains(tmp2))
                {
                    synergies.Add(tmp2);
                }
                break;
        }
    }
}

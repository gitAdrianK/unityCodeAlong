using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity player.
/// </summary>
/// <seealso cref="Entity" />
public class EntityPlayer : Entity
{
    private int gold;
    private Dictionary<Item, int> items;

    public int Gold { get => gold; }
    public Dictionary<Item, int> Items { get => items; }

    /// <summary>
    /// Initializes the object with given values.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="life">The life.</param>
    /// <param name="attack">The attack.</param>
    /// <param name="defense">The defense.</param>
    /// <param name="gold">The gold.</param>
    /// <param name="items">The items.</param>
    public void Initialize(string name, int life, int attack, int defense, int gold, Dictionary<Item, int> items)
    {
        base.Initialize(name, life, attack, defense);
        this.gold = gold;
        if (null == items)
        {
            items = new Dictionary<Item, int>();
        }
        this.items = items;
    }

    /// <summary>
    /// Changes the players gold.
    /// </summary>
    /// <param name="value">Value the gold is changed by.</param>
    public void ChangeGoldBy(int value)
    {
        gold += value;
        if (gold < 0)
        {
            gold = 0;
        }
    }

    /// <summary>
    /// Adds an item to the players items and modifies the player based on its gain effect.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(Item item, int count)
    {
        if (!item)
        {
            return;
        }
        if (!items.ContainsKey(item))
        {
            items.Add(item, 0);
        }
        for (int i = 0; i < count; i++)
        {
            items[item] = ++items[item];
            item.OnItemGained(this);
        }
    }

    public void AddItem(Item item)
    {
        AddItem(item, 1);
    }

    public void AddItems(Dictionary<Item, int> items)
    {
        if (items == null)
        {
            return;
        }
        foreach (KeyValuePair<Item, int> item in items)
        {
            AddItem(item.Key, item.Value);
        }
    }

    /// <summary>
    /// Removes an item from the players items and modifies the player based on its loss effect.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    public void RemoveItem(Item item)
    {
        if (!item)
        {
            return;
        }
        if (!items.ContainsKey(item))
        {
            return;
        }
        items[item] = --items[item];
        if (items[item] <= 0)
        {
            items.Remove(item);
        }
        item.OnItemLost(this);
    }

    // override object.ToString
    public override string ToString()
    {
        string str = "";
        str += base.ToString() + "\nPlayer - Gold: " + Gold + ", Items:\n";
        foreach (KeyValuePair<Item, int> kvp in items)
        {
            str += kvp.Key.Name + ": " + kvp.Value + "\n";
        }
        return str;
    }
}

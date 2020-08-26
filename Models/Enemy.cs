using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
  public class Enemy : IEnemy
  {
    public List<IItem> Loot => new List<IItem>();

    public string Name { get; set; }

    public int Health { get; set; }

    public bool Dead { get => Health <= 0; }

    public IWeapon Weapon { get; private set; }


    public void DealDamage(IPlayer player)
    {
      player.TakeDamage(Weapon.Damage);
    }

    public void EquipWeapon(IWeapon weapon)
    {
      Weapon = weapon;
      Loot.Add(Weapon);
    }

    public void TakeDamage(int amount)
    {
      Health -= amount;
      System.Console.WriteLine($"You delt {amount} damage to {Name}");
      // if(Health <= 0)
      // {
      //   Dead = true
      // }
    }
    public Enemy(string name, int health)
    {
      Name = name;
      Health = health;
    }
  }

}
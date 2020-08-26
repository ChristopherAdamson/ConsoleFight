using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
  class Player : IPlayer
  {
    public List<IItem> Inventory { get; set; } = new List<IItem>();

    public string Name { get; set; }

    public int Health { get; set; }

    public bool Dead { get => Health <= 0; }

    public IWeapon Weapon { get; set; }

    public void DealDamage(IEnemy player)
    {
      if (Weapon != null)
      {
        player.TakeDamage(Weapon.Damage);
        System.Console.WriteLine($"You delt {Weapon.Damage} damage to {player.Name}");
      }
      else
      {
        System.Console.WriteLine("Your fists dont seem to have much effect");
      }

    }

    public void EquipWeapon(IWeapon weapon)
    {
      Weapon = weapon;
      System.Console.WriteLine($"You Equipped {Weapon.Name}");
    }

    public void TakeDamage(int amount)
    {
      Health -= amount;
      System.Console.WriteLine($"You took {amount} damage!");
    }

    public Player()
    {
      Console.WriteLine("Hey Listen..... What is your name?");
      Name = Console.ReadLine();
      Health = 150;
    }

  }
}
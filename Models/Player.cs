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
      player.TakeDamage(Weapon.Damage);
    }

    public void EquipWeapon(IWeapon weapon)
    {
      Weapon = weapon;
    }

    public void TakeDamage(int amount)
    {
      Health -= amount;
    }

    public Player()
    {
      Console.WriteLine("Hey Listen..... What is your name?");
      Name = Console.ReadLine();
      Health = 150;
    }

  }
}
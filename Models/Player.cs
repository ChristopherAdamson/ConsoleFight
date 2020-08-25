using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
  class Player : IPlayer
  {
    public List<IItem> Inventory { get; set; }

    public string Name { get; set; }

    public int Health { get; set; }

    public bool Dead { get => Health <= 0; }

    public IWeapon Weapon { get; set; }

    public void DealDamage(IEnemy player)
    {
      throw new NotImplementedException();
    }

    public void EquipWeapon(IWeapon weapon)
    {
      throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
      Health -= amount;
    }

    public Player()
    {
      Console.WriteLine("Hey Listen..... What is your name?");
      Name = Console.ReadLine();
      Health = 100;
    }

  }

}
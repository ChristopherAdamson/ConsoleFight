using System;
using Demo.Interfaces;

namespace Demo.Models
{
  public class Weapon : IWeapon
  {
    public int Damage { get; set; }
    public string Name { get; set; }
    public int Durability { get; set; }
    public Weapon(string name, int damage)
    {
      Name = name;
      Damage = damage;
    }
  }
}
using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
  class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Fighting { get => Enemy.Health <= 0; }
    public List<IItem> Content { get; set; } = new List<IItem>();
    public IEnemy Enemy { get; set; }
    public Dictionary<string, IRoom> Exits { get; } = new Dictionary<string, IRoom>();

    public virtual void OnPlayerEnter(IPlayer player)
    {
      Console.WriteLine($"You enter {Name}");
      System.Console.WriteLine(Name);
      System.Console.WriteLine(Description);

    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
    }

  }

}
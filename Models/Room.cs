using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
  class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnemy Enemy { get; set; }
    public Dictionary<string, IRoom> Exits { get; } = new Dictionary<string, IRoom>();

    public virtual void OnPlayerEnter(IPlayer player)
    {
      System.Console.WriteLine(Name);
      System.Console.WriteLine(Description);
    }

  }

  class TrapRoom : Room
  {
    public override void OnPlayerEnter(IPlayer player)
    {
      base.OnPlayerEnter(player);
      player.TakeDamage(500);

    }
  }

}
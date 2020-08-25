using System.Collections.Generic;

namespace Demo.Interfaces
{
  public interface IRoom
  {
    IEnemy Enemy { get; }
    string Name { get; set; }
    string Description { get; set; }

    Dictionary<string, IRoom> Exits { get; }

    void OnPlayerEnter(IPlayer player);

  }

}
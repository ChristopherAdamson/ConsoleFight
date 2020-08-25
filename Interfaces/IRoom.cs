using System.Collections.Generic;

namespace Demo.Interfaces
{
  public interface IRoom
  {
    IEnemy Enemy { get; }

    Dictionary<string, IRoom> Exits { get; }

  }

}
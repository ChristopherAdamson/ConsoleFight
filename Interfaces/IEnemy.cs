using System.Collections.Generic;

namespace Demo.Interfaces
{
  public interface IEnemy : ICharacter
  {
    List<IItem> Loot { get; }
    void DealDamage(IPlayer player);
  }

}
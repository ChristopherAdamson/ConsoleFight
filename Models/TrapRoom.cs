using Demo.Interfaces;

namespace Demo.Models
{
  class TrapRoom : Room
  {

    public int TrapDamage { get; }

    public override void OnPlayerEnter(IPlayer player)
    {
      base.OnPlayerEnter(player);
      player.TakeDamage(TrapDamage);
    }

    public TrapRoom(string name, string description, int trapDamage) : base(name, description)
    {
        TrapDamage = trapDamage;
    }

  }

}

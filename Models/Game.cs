using System;
using Demo.Interfaces;

namespace Demo.Models
{
  public class Game
  {
    private bool Playing { get; set; } = true;
    private Room CurrentRoom { get; set; }
    private Player CurrentPlayer { get; set; }
    public bool Fighting { get; set; }

    void Setup()
    {
      // Do the things like create enemies and rooms and assign items to enemies
      Weapon Dagger = new Weapon("Dull dagger", 15);
      Weapon EnchantedDagger = new Weapon("Enchanted Dagger", 50);
      Weapon Sword = new Weapon("Old Sword", 25);
      Weapon Battleaxe = new Weapon("Rusted Battleaxe", 30);
      Enemy Goblin = new Enemy("Gleb", 50);
      Enemy Kobold = new Enemy("Gromp", 75);
      Goblin.EquipWeapon(Dagger);
      Kobold.EquipWeapon(Dagger);
      Enemy Orc = new Enemy("Grawl", 75);
      Orc.EquipWeapon(Battleaxe);


      var room1 = new Room("The Starting Room", "You awake to the sound of violence coming from the north, west to the south it is suspiciously quiet, An acrid smell permeates from the south.");
      room1.Content.Add(Sword);
      var room2 = new Room("North Room", "its bland but there is a grotesque goblin staring at you");
      room2.Enemy = Goblin;
      var poisonTrapRoom = new TrapRoom("Poison Room", "smells bad", 300);
      var room3 = new Room("West of starting room", "It is a dimly lit room with a fire in the corner, sitting by the fire is kobold with its back to you there appears to be dried blood on the ground and a torn tapestry to the south");
      var secretRoom = new Room("secret Room", "It appears to be an old storeroom poorly hidden. inside is a stool, utop that stool is a unlabled flask. and beside is a dagger engraved with uninteligable script");
      secretRoom.Content.Add(EnchantedDagger);
      // secretRoom.Content.Add(Potion)
      var bossRoom = new Room("Boss Room", "As you approach the door you get chills down your spine, maybe you should have thought more about this decision. Once inside you see a large Orc with a battleaxe waiting for you.");
      room1.Exits.Add("north", room2);
      room1.Exits.Add("south", poisonTrapRoom);
      room1.Exits.Add("west", room3);
      room1.Exits.Add("east", bossRoom);
      room3.Exits.Add("south", secretRoom);
      room3.Exits.Add("east", room1);
      secretRoom.Exits.Add("north", room3);
      room2.Exits.Add("south", room1);

      CurrentRoom = room1;
      Start();
    }

    void Start()
    {
      // Get Player Info
      CurrentPlayer = new Player();
      Help();
      Play();
    }

    void Play()
    {
      CurrentRoom.OnPlayerEnter(CurrentPlayer);
      while (Playing)
      {
        if (CurrentRoom.Enemy != null)
        {
          System.Console.WriteLine($"{CurrentRoom.Enemy.Name} attacks you!");
          Fighting = true;
          Combat(CurrentPlayer, CurrentRoom.Enemy);
        }

        Console.WriteLine("What would you like to do?");
        HandlePlayerInput();
        // Console.Clear();
      }
    }

    void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
        CurrentRoom.OnPlayerEnter(CurrentPlayer);
      }
      else
      {
        System.Console.WriteLine("Invalid Direction!");
      }

    }
    void Look(Room CurrentRoom)
    {
      System.Console.WriteLine("You find...");
      // TODO need to add items into rooms to be added to player inventory, loot for battles too?
      if (CurrentRoom.Content.Count > 0)
      {
        for (int i = 0; i < CurrentRoom.Content.Count; i++)
        {
          System.Console.WriteLine(CurrentRoom.Content[i].Name);
        }
      }
      else
      {
        System.Console.WriteLine("nothing.");

      }
    }
    void Take(string itemName)
    {

      // TODO need to add items into rooms to be added to player inventory, loot for battles too?
      IItem foundItem = CurrentRoom.Content.Find(item => item.Name.ToLower() == itemName);
      if (foundItem != null)
      {
        CurrentRoom.Content.Remove(foundItem);
        CurrentPlayer.Inventory.Add(foundItem);
        System.Console.WriteLine($"You Put the {foundItem.Name} in your inventory");
      }
      else
      {
        System.Console.WriteLine("You couldnt find that item to take");
      }

    }
    void Use(string itemName)
    {
      // TODO need to implement an inventory and once having items inside procede to use them :P
      IItem foundItem = CurrentPlayer.Inventory.Find(item => item.Name.ToLower() == itemName);
      if (foundItem is Weapon)
      {
        CurrentPlayer.EquipWeapon((Weapon)foundItem);
      }
      CurrentPlayer.Inventory.Remove(foundItem);
    }
    private void HandlePlayerInput()
    {
      var playerInput = Console.ReadLine().ToLower();

      if (playerInput == null)
      {
        HandlePlayerInput();
        return;
      }

      var command = playerInput.Split(" ")[0];
      var option = playerInput.Substring(playerInput.IndexOf(" ") + 1);

      switch (command)
      {
        case "go":
          Go(option);
          break;
        case "look":
          Look(CurrentRoom);
          break;
        case "take":
          Take(option);
          break;
        case "use":
          Use(option);
          break;
        case "restart":
          Setup();
          break;
        case "help":
          Help();

          break;
        case "q":
        case "quit":
          Playing = false;
          break;
      }
    }
    private void Combat(IPlayer player, IEnemy enemy)
    {

      while (Fighting)
      {

        System.Console.WriteLine(enemy.Health);
        System.Console.WriteLine(enemy.Dead);
        System.Console.WriteLine("Options: 1. Attack 2. Use Items. 3. Check Inventory");
        handleCombatInput(player, enemy);
        enemy.DealDamage(player);
        if (enemy.Health <= 0)
        {
          Fighting = false;
        }

      }
      System.Console.WriteLine($"You killed {enemy.Name}!");
      if (enemy.Loot != null)
      {
        enemy.Loot.ForEach(item => CurrentRoom.Content.Add(item));
      }
    }

    private void handleCombatInput(IPlayer player, IEnemy enemy)
    {
      var playerInput = Console.ReadLine().ToLower();

      if (playerInput == null)
      {
        handleCombatInput(player, enemy);
        return;
      }

      var command = playerInput.Split(" ")[0];
      var option = playerInput.Substring(playerInput.IndexOf(" ") + 1);

      switch (command)
      {
        case "1":
        case "attack":
          if (player.Weapon != null)
          {
            enemy.TakeDamage(player.Weapon.Damage);
            break;
          }
          else
          {
            System.Console.WriteLine("Your fists dont seem to have much effect");
            break;
          }

      }
    }


    public Game()
    {
      System.Console.WriteLine(@"
 ________ ___  ________  ___  ___  _________        ________  ___       ___  ___  ________     
|\  _____\\  \|\   ____\|\  \|\  \|\___   ___\     |\   ____\|\  \     |\  \|\  \|\   __  \    
\ \  \__/\ \  \ \  \___|\ \  \\\  \|___ \  \_|     \ \  \___|\ \  \    \ \  \\\  \ \  \|\ /_   
 \ \   __\\ \  \ \  \  __\ \   __  \   \ \  \       \ \  \    \ \  \    \ \  \\\  \ \   __  \  
  \ \  \_| \ \  \ \  \|\  \ \  \ \  \   \ \  \       \ \  \____\ \  \____\ \  \\\  \ \  \|\  \ 
   \ \__\   \ \__\ \_______\ \__\ \__\   \ \__\       \ \_______\ \_______\ \_______\ \_______\
    \|__|    \|__|\|_______|\|__|\|__|    \|__|        \|_______|\|_______|\|_______|\|_______|
      ");
      Setup();
    }
    private void Help()
    {
      System.Console.WriteLine(@"
'look'- Looks to see if there is anything of worth in the room.
'go'- paired with a direction will try to leave the room through that door if possible.
'use'- paired with an item in your inventory to use, if a weapon use will equipt it.
'take'- paired with takeable items that are in the room to add them to your inventory.
'inventory'- displays items in your inventory.
'quit'- exits the application, WARNING: PROGRESS DOES NOT SAVE.
'restart'- resets the game.
      ");
    }
  }

}
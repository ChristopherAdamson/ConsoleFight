using System;
using Demo.Interfaces;

namespace Demo.Models
{
  public class Game
  {
    private bool Playing { get; set; } = true;
    private IRoom DeathRoom { get; set; }
    private IRoom CurrentRoom { get; set; }
    private Player CurrentPlayer { get; set; }

    void Setup()
    {
      // Do the things like create enemies and rooms and assign items to enemies

      var room1 = new Room("The Starting Room", "You awake to the sound of violence coming from the north, west to the south it is suspiciously quiet, An acrid smell permeates from the south.");

      var room2 = new Room("North Room", "its bland but there is a grotesque goblin staring at you");
      var poisonTrapRoom = new TrapRoom("Poison Room", "smells bad", 300);
      var room3 = new Room("West of starting room", "It is a dimly lit room with a fire in the corner, sitting by the fire is kobold with its back to you there appears to be dried blood on the ground and a torn tapestry to the south");
      var secretRoom = new Room("secret Room", "It appears to be an old storeroom poorly hidden. inside is a stool, utop that stool is a unlabled flask. and beside is a dagger engraved with uninteligable script");
      DeathRoom = poisonTrapRoom;
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
      while (Playing)
      {
        System.Console.WriteLine(CurrentRoom.Name);
        System.Console.WriteLine(CurrentRoom.Description);

        Console.WriteLine("What would you like to do?");
        HandlePlayerInput();
        // Console.Clear();
      }
    }

    void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        CurrentRoom.OnPlayerEnter(CurrentPlayer);
      }
      else
      {
        System.Console.WriteLine("Invalid Direction!");
      }

    }

    void Take(string item)
    {
      // TODO need to add items into rooms to be added to player inventory, loot for battles too?
    }
    void Use(string item)
    {
      // TODO need to implement an inventory and once having items inside procede to use them :P
    }
    private void HandlePlayerInput()
    {
      var playerInput = Console.ReadLine();

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
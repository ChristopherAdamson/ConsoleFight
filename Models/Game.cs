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
      DeathRoom = poisonTrapRoom;
      room1.Exits.Add("north", room2);
      room2.Exits.Add("south", room1);

      CurrentRoom = room1;
      Start();
    }

    void Start()
    {
      // Get Player Info
      CurrentPlayer = new Player();

      Play();
    }

    void Play()
    {
      while (!CurrentPlayer.Dead)
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
      }
      else
      {
        CurrentRoom = DeathRoom;
      }
      CurrentRoom.OnPlayerEnter(CurrentPlayer);
    }

    private void HandlePlayerInput()
    {
      var playerInput = Console.ReadLine();

      if (playerInput == null)
      {
        HandlePlayerInput();
        return;
      }

      var command = playerInput.Split(" ") [0];
      var option = playerInput.Substring(playerInput.IndexOf(" ") + 1);

      switch (command)
      {
        case "go":
          Go(option);
          break;
        case "restart":
          Setup();
          break;
        case "help":
          // Help(); print all the comands
          Console.WriteLine("Bah no help here");
          break;
        case "q":
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
  }

}
using System;
using System.Collections.Generic;
using System.Linq;
using static AutoBattle.Types;

namespace AutoBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 10);

            Character playerCharacter;
            Character enemyCharacter;

            List<Character> allPlayers = new List<Character>();
            int currentTurn = 0;

            GetPlayerChoice();

            void GetPlayerChoice()
            {
                //asks for the player to choose between for possible classes via console.
                Console.WriteLine("Choose Between One of this Classes:\n");
                Console.WriteLine("[1] Paladin, [2] Warrior, [3] Cleric, [4] Archer");
                //store the player choice in a variable
                string choice = Console.ReadLine();

                //Checking if player choice is valid and creating a Player Character
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    CreatePlayerCharacter(Int32.Parse(choice));
                }
                else
                {
                    Console.WriteLine("\n\nInvalid value!\n\n");
                    GetPlayerChoice();
                }
            }

            //Create player and proceed to create an enemy
            void CreatePlayerCharacter(int classIndex)
            {

                CharacterClass characterClass = (CharacterClass)classIndex;
                Console.WriteLine($"Player Class Choice: {characterClass}");
                playerCharacter = new Character(characterClass);
                //Populate character variables
                ClassData.SetCharacterStats(playerCharacter);
                playerCharacter.playerIndex = 0;
                allPlayers.Add(playerCharacter);

                CreateEnemyCharacter();
            }

            //Creates enemy and start the game
            void CreateEnemyCharacter()
            {
                //randomly choose the enemy class and set up vital variables
                int randomInteger = GetRandomInt(1, 5);
                CharacterClass enemyClass = (CharacterClass)randomInteger;
                Console.WriteLine($"Enemy Class Choice: {enemyClass}");
                enemyCharacter = new Character(enemyClass);
                //Populate character variables
                ClassData.SetCharacterStats(enemyCharacter);
                enemyCharacter.playerIndex = 1;
                allPlayers.Add(enemyCharacter);

                StartGame();
            }

            void StartGame()
            {
                //Set the character targets
                enemyCharacter.target = playerCharacter;
                playerCharacter.target = enemyCharacter;
                //Place the characters
                AlocateCharacters();
                StartTurn();

            }

            //Sets characters speed and then performs character actions
            void StartTurn()
            {

                RollTurnSpeed();
                foreach (Character character in allPlayers)
                {
                    character.StartTurn(grid);
                }

                currentTurn++;
                HandleTurn();
            }

            void HandleTurn()
            {
                //Checks if enemyCharacter won
                if (playerCharacter.health <= 0f && enemyCharacter.health > 0f)
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    Console.WriteLine($"Player {playerCharacter.name}{playerCharacter.playerIndex} Morreu");
                    Console.WriteLine($"Player {enemyCharacter.name}{enemyCharacter.playerIndex} Venceu");

                    Console.Write(Environment.NewLine + Environment.NewLine);
                    return;
                }
                //Checks if playerCharacter won
                else if (enemyCharacter.health <= 0f && playerCharacter.health > 0f)
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    Console.WriteLine($"Player {enemyCharacter.name}{enemyCharacter.playerIndex} Morreu");
                    Console.WriteLine($"Player {playerCharacter.name}{playerCharacter.playerIndex} Venceu");

                    Console.Write(Environment.NewLine + Environment.NewLine);

                    return;
                }
                //Check if it was a draw
                else if (enemyCharacter.health <= 0f && playerCharacter.health <= 0f)
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    Console.WriteLine($"Player {playerCharacter.name}{playerCharacter.playerIndex} Morreu");
                    Console.WriteLine($"Player {enemyCharacter.name}{enemyCharacter.playerIndex} Morreu");
                    Console.WriteLine($"DRAW!!!");

                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
                //The game continues
                else
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);
                    Console.WriteLine("Click on any key to start the next turn...\n");
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    ConsoleKeyInfo key = Console.ReadKey();
                    StartTurn();
                }
            }

            //Return a random integer in a specified range
            int GetRandomInt(int min, int max)
            {
                var rand = new Random();
                int index = rand.Next(min, max);
                return index;
            }

            void AlocateCharacters()
            {
                AlocateCharacter(playerCharacter);
                AlocateCharacter(enemyCharacter);
            }

            //Sets a Character cell to a random cell
            void AlocateCharacter(Character character)
            {
                int randomValue = GetRandomInt(0, grid.grids.Count);

                GridBox randomLocation = (grid.grids.ElementAt(randomValue));
                if (!randomLocation.ocupied)
                {
                    randomLocation.ocupied = true;
                    randomLocation.character = character;
                    grid.grids[randomValue] = randomLocation;
                    character.currentBox = grid.grids[randomValue];
                }
                else
                {
                    AlocateCharacter(character);
                }
            }

            //Sets Character's speed, influences who attacks first
            void RollTurnSpeed()
            {
                playerCharacter.speed = GetRandomInt(0, 11);
                enemyCharacter.speed = GetRandomInt(0, 11);

                Console.WriteLine($"Player {playerCharacter.name}{playerCharacter.playerIndex} rolled {playerCharacter.speed}\n\n");
                Console.WriteLine($"Player {enemyCharacter.name}{enemyCharacter.playerIndex} rolled {enemyCharacter.speed}\n\n");

                allPlayers.Clear();
                if (playerCharacter.speed > enemyCharacter.speed)
                {
                    allPlayers.Add(playerCharacter);
                    allPlayers.Add(enemyCharacter);
                }
                else
                {
                    allPlayers.Add(enemyCharacter);
                    allPlayers.Add(playerCharacter);
                }
            }
        }
    }
}

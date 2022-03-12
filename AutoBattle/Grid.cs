using System;
using System.Collections.Generic;
using static AutoBattle.Types;

namespace AutoBattle
{
    /// <summary>Represents battlefield where units will fight each other</summary>
    public class Grid
    {
        public List<GridBox> grids = new List<GridBox>();
        public IntVector2 size;
        public Grid(int _x, int _y)
        {
            size = new IntVector2(_x, _y);
            Console.WriteLine("The battle field has been created\n");
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    GridBox newBox = new GridBox(j, i, false, (_y * i + j));
                    grids.Add(newBox);
                }
            }
        }

        /// <summary>Prints the matrix that indicates the tiles of the battlefield</summary>
        public void DrawBattlefield(int lines, int columns)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    GridBox currentgrid = grids[size.y * i + j];
                    if (currentgrid.ocupied)
                    {

                        Console.Write($"[{CharacterBattlefieldName(currentgrid)}]\t");
                    }
                    else
                    {
                        Console.Write($"[ ]\t");
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }

        /// <summary>Returns the correct name of each battlefield cell, based on its Character</summary>
        private string CharacterBattlefieldName(GridBox gridBox)
        {
            string showValue = "";

            //Defining the character owner
            if (gridBox.character.playerIndex == 0)
            {
                showValue += "P";
            }
            else if (gridBox.character.playerIndex == 1)
            {
                showValue += "E";
            }
            else
            {
                showValue += "?";
            }

            showValue += ".";

            //Defining the character Class
            if (gridBox.character.characterClass == CharacterClass.Archer)
            {
                showValue += "A";
            }
            else if (gridBox.character.characterClass == CharacterClass.Cleric)
            {
                showValue += "C";
            }
            else if (gridBox.character.characterClass == CharacterClass.Paladin)
            {
                showValue += "P";
            }
            else if (gridBox.character.characterClass == CharacterClass.Warrior)
            {
                showValue += "W";
            }
            else
            {
                showValue += "?";
            }

            return showValue;
        }

    }
}

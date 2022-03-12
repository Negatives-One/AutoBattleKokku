using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle
{
    public class Types
    {

        public struct CharacterClassSpecific
        {
            CharacterClass CharacterClass;
            float hpModifier;
            float ClassDamage;
            CharacterSkills[] skills;

        }

        /// <summary>
        /// Cell that constitutes the battlefield
        /// </summary>
        public struct GridBox
        {
            public IntVector2 position;
            public bool ocupied;
            public int index;
            public Character character;

            public GridBox(int _xIndex, int _yIndex, bool _ocupied, int _index, Character _character = null)
            {
                position = new IntVector2(_xIndex, _yIndex);
                ocupied = _ocupied;
                index = _index;
                character = _character;
            }

        }

        public struct CharacterSkills
        {
            string Name;
            float damage;
            float damageMultiplier;
        }

        public enum CharacterClass : uint
        {
            Paladin = 1,
            Warrior = 2,
            Cleric = 3,
            Archer = 4
        }

        /// <summary>
        /// Simple representation of a two-dimensional vector of integers
        /// </summary>
        public struct IntVector2
        {
            public int x { get; set; }
            public int y { get; set; }

            public IntVector2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public void GetDirection(IntVector2 from, IntVector2 to)
            {
                if (from.x > to.x)
                    this.x = -1;
                else if (from.x < to.x)
                    this.x = 1;
                else
                    this.x = 0;

                if (from.y > to.y)
                    this.y = -1;
                else if (from.y < to.y)
                    this.y = 1;
                else
                    this.y = 0;
            }
        }

    }
}

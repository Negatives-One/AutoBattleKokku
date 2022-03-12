﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;

namespace AutoBattle
{
    public class Character
    {
        public string name { get; set; }
        public float health { get; set; }
        public float baseDamage { get; set; }
        public int attackRange { get; set; }
        public int speed { get; set; }
        public bool paralized { get; set; }
        public bool dead { get; set; }
        public float damageMultiplier { get; set; }
        public GridBox currentBox;
        public Character target { get; set; }
        public int playerIndex { get; set; }
        public CharacterClass characterClass;

        public Character(CharacterClass _characterClass)
        {
            characterClass = _characterClass;
            paralized = false;
            dead = false;
        }

        /// <summary>Causes the Character to take damage to reduce its health, if the health reaches zero or less then the Character dies</summary>
        private void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                dead = true;
            }
        }

        public void StartTurn(Grid battlefield)
        {
            if (paralized) //If the character is paralyzed, skip the turn
            {
                Console.WriteLine($"Player {name}{playerIndex} is paralized and can't attack or move.");
                paralized = false;
                return;
            }
            else if (CheckCloseTargets(battlefield)) //If there are targets nearby then attack
            {
                Attack(target);
                return;
            }

        }

        /// <summary>Checks if there is a valid target in neighboring cells.</summary>
        public bool CheckCloseTargets(Grid battlefield)
        {
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            //checking various cells based on Character's attackRange
            for (int i = 1; i <= attackRange; i++)
            {
                if (left == false)
                    left = battlefield.grids.Find(x => x.position.x == currentBox.position.x - i && x.position.y == currentBox.position.y).ocupied;
                if (right == false)
                    right = battlefield.grids.Find(x => x.position.x == currentBox.position.x + i && x.position.y == currentBox.position.y).ocupied;
                if (up == false)
                    up = battlefield.grids.Find(x => x.position.y == currentBox.position.y - i && x.position.x == currentBox.position.x).ocupied;
                if (down == false)
                    down = battlefield.grids.Find(x => x.position.y == currentBox.position.y + i && x.position.x == currentBox.position.x).ocupied;
            }

            if (left || right || up || down)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Makes the Character attack its target.</summary>
        public void Attack(Character target)
        {
            var rand = new Random();
            target.TakeDamage(rand.Next(0, (int)baseDamage));
            Console.WriteLine($"Player {playerIndex} is attacking the player {target.playerIndex} and did {baseDamage} damage\n");
        }
    }
}

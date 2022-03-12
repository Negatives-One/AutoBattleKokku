using System;
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

        //    if (CheckCloseTargets(battlefield)) 
        //    {
        //        Attack(target);
                

        //        return;
        //    }
        //    else
        //    {   // if there is no target close enough, calculates in wich direction this character should move to be closer to a possible target
        //        /*if(this.currentBox.position.x > target.currentBox.position.x)
        //        {
        //            if ((battlefield.grids.Exists(x => x.Index == currentBox.Index - 1)))
        //            {
        //                currentBox.ocupied = false;
        //                battlefield.grids[currentBox.Index] = currentBox;
        //                currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index - 1));
        //                currentBox.ocupied = true;
        //                battlefield.grids[currentBox.Index] = currentBox;
        //                Console.WriteLine($"Player {playerIndex} walked left\n");
        //                battlefield.drawBattlefield(5, 5);

        //                return;
        //            }
        //        } else if(currentBox.xIndex < target.currentBox.xIndex)
        //        {
        //            currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index + 1));
        //            currentBox.ocupied = true;
        //            return;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {playerIndex} walked right\n");
        //            battlefield.drawBattlefield(5, 5);
        //        }

        //        if (this.currentBox.yIndex > target.currentBox.yIndex)
        //        {
        //            battlefield.drawBattlefield(5, 5);
        //            this.currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            this.currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index - battlefield.xLenght));
        //            this.currentBox.ocupied = true;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {playerIndex} walked up\n");
        //            return;
        //        }
        //        else if(this.currentBox.yIndex < target.currentBox.yIndex)
        //        {
        //            this.currentBox.ocupied = true;
        //            battlefield.grids[currentBox.Index] = this.currentBox;
        //            this.currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index + battlefield.xLenght));
        //            this.currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {playerIndex} walked down\n");
        //            battlefield.drawBattlefield(5, 5);

        //            return;
        //        }*/
        //    }
        }

        // Check in x and y directions if there is any character close enough to be a target.
        //bool CheckCloseTargets(Grid battlefield)
        //{
        //    bool left = (battlefield.grids.Find(x => x.Index == currentBox.Index - 1).ocupied);
        //    bool right = (battlefield.grids.Find(x => x.Index == currentBox.Index + 1).ocupied);
        //    bool up = (battlefield.grids.Find(x => x.Index == currentBox.Index + battlefield.xLenght).ocupied);
        //    bool down = (battlefield.grids.Find(x => x.Index == currentBox.Index - battlefield.xLenght).ocupied);

        //    if (left & right & up & down) 
        //    {
        //        return true;
        //    }
        //    return false; 
        //}

        public void Attack (Character target)
        {
            var rand = new Random();
            target.TakeDamage(rand.Next(0, (int)baseDamage));
            Console.WriteLine($"Player {playerIndex} is attacking the player {target.playerIndex} and did {baseDamage} damage\n");
        }
    }
}

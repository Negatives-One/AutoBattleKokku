namespace AutoBattle
{
    /// <summary>Contains data that must be used when creating a Character</summary>
    public static class ClassData
    {
        /// <summary>Identifies the Character's class and then assigns its status</summary>
        public static void SetCharacterStats(Character character)
        {
            if(character.characterClass == Types.CharacterClass.Archer)
            {
                SetArcherStats(character);
            }
            else if (character.characterClass == Types.CharacterClass.Cleric)
            {
                SetClericStats(character);
            }
            else if (character.characterClass == Types.CharacterClass.Paladin)
            {
                SetPaladinStats(character);
            }
            else if (character.characterClass == Types.CharacterClass.Warrior)
            {
                SetWarriorStats(character);
            }
        }
        private static void SetArcherStats(Character character)
        {
            character.health = 100f;
            character.baseDamage = 25f;
            character.attackRange = 3;
            character.damageMultiplier = 1.1f;
            character.name = "Legolas";
        }
        private static void SetPaladinStats(Character character)
        {
            character.health = 150f;
            character.baseDamage = 13f;
            character.attackRange = 1;
            character.damageMultiplier = 1.2f;
            character.name = "Daniel_Paladino";
        }
        private static void SetWarriorStats(Character character)
        {
            character.health = 120f;
            character.baseDamage = 30f;
            character.attackRange = 1;
            character.damageMultiplier = 1.15f;
            character.name = "Demeeenciaaa";
        }
        private static void SetClericStats(Character character)
        {
            character.health = 130f;
            character.baseDamage = 22f;
            character.attackRange = 1;
            character.damageMultiplier = 1.05f;
            character.name = "Clerigao";
        }
    }
}

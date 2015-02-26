namespace Minotaur
{
    using System;
    using System.Text;

    using Minotaur.GameSprites;

    public static class BattleEngine
    {
        public static string StartBattle(GameSprite player, GameSprite enemy)
        {
            StringBuilder battleLog = new StringBuilder();
            int roundCounter = 1;
            bool playerTurn = true;

            while (player.IsAlive() && enemy.IsAlive())
            {
                battleLog.AppendLine(string.Format("Round {0}: Player health {1}{2} | Enemy health {1}{3}", roundCounter, (char)3, player.HealthPoints, enemy.HealthPoints));

                int playerAttack = player.Attack();
                int playerDefence = player.Defend();

                int enemyAttack = enemy.Attack();
                int enemyDefence = enemy.Defend();

                if (playerTurn)
                {
                    if (playerAttack > enemyDefence)
                    {
                        enemy.HealthPoints -= playerAttack;
                    }
                }
                else
                {
                    if (enemyAttack > playerDefence)
                    {
                        player.HealthPoints -= enemyAttack;
                    }
                }

                playerTurn = !playerTurn;
                roundCounter++;
            }

            return battleLog.ToString();
        }
    }
}

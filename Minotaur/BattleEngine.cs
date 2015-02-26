namespace Minotaur
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Minotaur.GameSprites;
    using Minotaur.DrawEngines;

    public static class BattleEngine
    {
        public static void StartBattle(GameSprite player, GameSprite enemy, ICollection<GameSprite> enemies)
        {
            StringBuilder battleLog = new StringBuilder();
            int roundCounter = 1;
            bool playerTurn = true;

            battleLog.AppendLine(string.Format("Started battle with: {0}", enemy.GetType().Name));
            battleLog.AppendLine(new string('-', 20));
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

            battleLog.AppendLine(string.Format("Round {0}: Player health {1}{2} | Enemy health {1}{3}", roundCounter, (char)3, player.HealthPoints, enemy.HealthPoints));

            if (!enemy.IsAlive())
            {
                RemoveEnemy(enemy, enemies);
                battleLog.AppendLine("Player wins.");
            }
            else
            {
                battleLog.AppendLine("Player is dead.");
            }
            
            ConsoleDrawEngine.DisplayBattleLog(battleLog.ToString());
            GameEngine.RedrawLabyrinth = true;
        }

        private static void RemoveEnemy(GameSprite enemy, ICollection<GameSprite> enemies)
        {
            enemies.Remove(enemy);
        }
    }
}

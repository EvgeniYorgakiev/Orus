using Orus.GameObjects;
using Orus.GameObjects.Enemies.NormalEnemies;
using Microsoft.Xna.Framework;
namespace Orus.Levels
{
    public class Level1 : Level
    {
        public Level1() : base(1, Orus.Instance.Content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!this.SpawnedEnemies && this.RequiredXForEnemySpawn < Orus.Instance.Character.Position.X && this.RequiredXForEnemySpawn > 0)
            {
                this.Enemies.Add(new Zombie(new Point2D(300, 300), Orus.Instance.Content));
                this.SpawnedEnemies = true;
            }
        }
    }
}

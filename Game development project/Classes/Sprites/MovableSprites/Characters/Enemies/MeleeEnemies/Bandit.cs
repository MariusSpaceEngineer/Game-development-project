﻿using Game_development_project.Classes.Animations;
using Game_development_project.Classes.Characters.Character_States;
using Game_development_project.Classes.Characters.CharacterDirections;
using Game_development_project.Classes.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development_project.Classes.Sprites.MovableSprites.Characters.Enemies.MeleeEnemies
{
    internal class Bandit : MeleeEnemy 
    {
        #region Private variables

        private Animation attackAnimation;
        private Animation damageAnimation;
        private Animation deathAnimation;
        private Animation idleAnimation;
        private Animation moveAnimation;

        #endregion
        public Bandit(Texture2D attackSprite, Texture2D damageSprite, Texture2D deathSprite, Texture2D idleSprite, Texture2D moveSprite, Vector2 position, float speed, float distance, Texture2D boundingBoxTexture) : base(attackSprite, damageSprite, deathSprite, idleSprite, moveSprite, position, speed, distance, boundingBoxTexture)
        {
            attackAnimation = CreateAnimation(attackSprite, 8, 8, 1);
            damageAnimation = CreateAnimation(damageSprite, 3, 3, 1);
            deathAnimation = CreateAnimation(deathSprite, 5, 5, 1);
            idleAnimation = CreateAnimation(idleSprite, 4, 4, 1);
            moveAnimation = CreateAnimation(moveSprite, 8, 8, 1);

            PatrolDistance = distance;

            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 30, 40);

        }

        #region Override methods

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (CharacterState is IdleState)
            {
                CharacterState.Draw(spriteBatch, IdleSprite, idleAnimation, Direction, Position, this);
            }
            else if (CharacterState is MoveState)
            {
                CharacterState.Draw(spriteBatch, MoveSprite, moveAnimation, Direction, Position, this);
            }
            else if (CharacterState is AttackState)
            {
                CharacterState.Draw(spriteBatch, AttackSprite, attackAnimation, Direction, Position, this);

            }
            else if (CharacterState is DamagedState)
            {
                CharacterState.Draw(spriteBatch, DamageSprite, damageAnimation, Direction, Position, this);
                IsHit = false;
            }
            else if (CharacterState is DeathState)
            {
                CharacterState.Draw(spriteBatch, DeathSprite, deathAnimation, Direction, Position, this);
            }

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            AttackBox = new Rectangle();
            Patrol();

            if (CharacterState is MoveState)
            {
                moveAnimation.Update(gameTime);

            }
            else if (CharacterState is DamagedState)
            {
                damageAnimation.Update(gameTime);

            }
            else if (CharacterState is AttackState)
            {
                attackAnimation.Update(gameTime);
                MoveAttackBox();

            }
            MoveBoundingBox(Position);
        }

        public override void MoveAttackBox()
        {
            if (Direction is LeftDirection)
            {
                attackBox = new Rectangle(BoundingBox.Left - 5, BoundingBox.Y, 15, 40);
            }
            else
            {
                attackBox = new Rectangle(BoundingBox.Right - 10, BoundingBox.Y, 15, 40);
            }
        }

        public override void MoveBoundingBox(Vector2 position)
        {
            boundingBox.X = (int)position.X + 10;
            boundingBox.Y = (int)position.Y + 5;
        }

        #endregion
    }
}

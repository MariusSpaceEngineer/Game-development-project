﻿using Game_development_project.Classes.Animations;
using Game_development_project.Classes.Characters.Character_States;
using Game_development_project.Classes.Characters.CharacterDirections;
using Game_development_project.Classes.Characters.Enemies;
using Game_development_project.Classes.GameObjects.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development_project.Classes.Characters
{
    internal class Huntress : ProjectileEnemy //IGameObject
    {
        private Animation attackAnimation;
        private Animation damageAnimation;
        private Animation deathAnimation;
        private Animation idleAnimation;
        private Animation moveAnimation;

        public Huntress(Texture2D attackSprite, Texture2D damageSprite, Texture2D deathSprite, Texture2D idleSprite, Texture2D moveSprite, Vector2 position, float speed, float distance, Texture2D boundingBoxTexture) : base(attackSprite, damageSprite, deathSprite, idleSprite, moveSprite, position, speed, distance, boundingBoxTexture)
        {

            this.attackAnimation = CreateAnimation(attackSprite, 6, 6, 1);
            this.damageAnimation = CreateAnimation(damageSprite, 3, 3, 1);
            this.deathAnimation = CreateAnimation(deathSprite, 10, 10, 1);
            this.idleAnimation = CreateAnimation(idleSprite, 10, 10, 1);
            this.moveAnimation = CreateAnimation(moveSprite, 8, 8, 1);

            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 28, 40);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.characterState is MoveState)
            {
                if (this.direction is RightDirection)
                {
                    spriteBatch.Draw(moveSprite, Position, moveAnimation.CurrentFrame.SourceRectangle, Color.White);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);

                }
                else
                {
                    spriteBatch.Draw(moveSprite, Position, moveAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);
                }

               


            }
            else if (this.characterState is AttackState)
            {
                if (this.direction is LeftDirection)
                {
                    spriteBatch.Draw(attackSprite, Position, attackAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);

                }
                else
                {
                    spriteBatch.Draw(attackSprite, Position, attackAnimation.CurrentFrame.SourceRectangle, Color.White);



                }
            }
            else if(this.characterState is DamagedState)
            {
                if (this.direction is LeftDirection)
                {
                    spriteBatch.Draw(damageSprite, Position, damageAnimation.CurrentFrame.SourceRectangle, Color.White);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);
                    spriteBatch.Draw(this.boundingBoxTexture, AttackBox, Color.Green);
                    //this.characterState = new MoveState();
                }
                else
                {
                    spriteBatch.Draw(damageSprite, Position, damageAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);
                    spriteBatch.Draw(this.boundingBoxTexture, AttackBox, Color.Green);
                    //this.characterState = new MoveState();



                }

            }

            else if (this.characterState is DeathState)
            {
                if (this.direction is LeftDirection)
                {
                    spriteBatch.Draw(deathSprite, Position, deathAnimation.CurrentFrame.SourceRectangle, Color.White);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);
                    spriteBatch.Draw(this.boundingBoxTexture, AttackBox, Color.Green);
                    //this.characterState = new MoveState();
                }
                else
                {
                    spriteBatch.Draw(deathSprite, Position, deathAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
                    //spriteBatch.Draw(this.blokTexture, BoundingBox, Color.Blue);
                    spriteBatch.Draw(this.boundingBoxTexture, AttackBox, Color.Green);
                    //this.characterState = new MoveState();



                }
            }
        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Patrol();
            if (this.characterState is AttackState)
            {
                attackAnimation.Update(gameTime);
                AddBullet(sprites);
            }
            else if (this.characterState is MoveState)
            {
                moveAnimation.Update(gameTime);

            }
            else if (this.characterState is DamagedState)
            {
                damageAnimation.Update(gameTime);

            }

            //moveAnimation.Update(gameTime);
            MoveBoundingBox(Position);

        }

        private void MoveBoundingBox(Vector2 position)
        {
            boundingBox.X = (int)position.X + 32;
            boundingBox.Y = (int)position.Y + 30;
        }

        //    public Arrow projectile;


        //    private void AddBullet(List<Sprite> sprites)
        //    {
        //        var arrowProjectile = projectile.Clone() as Arrow;
        //        //if (direction is LeftDirection)
        //        //{
        //        //    arrowProjectile.Direction.X = -1;
        //        //    Debug.WriteLine("Shooting Left");
        //        //}
        //        //else
        //        //{
        //        //    arrowProjectile.Direction.X = 1;
        //        //}
        //        arrowProjectile.Direction = this.Direction;
        //        arrowProjectile.Position = this.Position;
        //        arrowProjectile.LinearVelocity = this.LinearVelocity * 2;
        //        arrowProjectile.LifeSpan = 2f;
        //        //arrowProjectile.Parent = this;

        //        sprites.Add(arrowProjectile);
        //    }
        //}
    }
}


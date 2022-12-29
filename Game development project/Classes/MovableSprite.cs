﻿using Game_development_project.Classes.Animations;
using Game_development_project.Classes.Characters.CharacterDirections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development_project.Classes
{
    internal abstract class MovableSprite : Sprite
    {
        public Vector2 Direction;

        public float HorizontalVelocity;

        public Animation CreateAnimation(Texture2D sprite, int fps, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            Animation animation = new Animation(fps);
            animation.GetFramesFromTextureProperties(sprite.Width, sprite.Height, numberOfWidthSprites, numberOfHeightSprites);
            return animation;
        }

        public virtual void MoveBoundingBox(Vector2 position) 
        { 
        
        }
    }
}
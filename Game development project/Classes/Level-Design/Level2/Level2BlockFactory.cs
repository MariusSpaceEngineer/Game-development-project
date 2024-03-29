﻿using Default_Block;
using Game_development_project.Classes.Level_Design.Level;
using Game_development_project.Classes.Level_Design.TypeBlocks;
using Microsoft.Xna.Framework;

namespace Game_development_project.Classes.Level_Design.Level2
{
    public class Level2BlockFactory : IBlockFactory
    {
        public Block CreateBlock(int number, Rectangle rectangle)
        {
            Block block = null;

            if (number == 1)
            {
                block = new CastleGroundBlock(rectangle);
            }
            else if (number == 2)
            {
                block = new TriggerBlock(rectangle);
            }
            return block;
        }
    }
}

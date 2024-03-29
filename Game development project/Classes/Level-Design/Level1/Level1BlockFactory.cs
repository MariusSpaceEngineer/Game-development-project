﻿using Default_Block;
using Game_development_project.Classes.Level_Design.Level;
using Game_development_project.Classes.Level_Design.TypeBlocks;
using Microsoft.Xna.Framework;

namespace Game_development_project.Classes.Level_Design.Level1
{
    internal class Level1BlockFactory : IBlockFactory
    {

        public Block CreateBlock(int number, Rectangle rectangle)
        {
            Block block = null;

            if (number == 1)
            {
                block = new GrassBlock(rectangle);
            }
            else if (number == 2)
            {
                block = new TriggerBlock(rectangle);
            }
            return block;
        }
    }
}

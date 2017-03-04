using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Llatext.Rooms
{
    public interface IRoom
    {
        /// <summary>
        /// When the user Looks around the room
        /// </summary>
        /// <returns></returns>
        Instructions.Instruction Look();
        /// <summary>
        /// Introduction to be stated when entering the room
        /// </summary>
        /// <returns></returns>
        Instructions.Instruction Introduction();
        /// <summary>
        /// When the user attempts to examine 'parameter' 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Instructions.Instruction Examine(string parameter);
        /// <summary>
        /// When the user attempts to take 'parameter'
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Instructions.Instruction Take(string parameter);
        /// <summary>
        /// When the user attempts to open 'parameter'
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Instructions.Instruction Open(string parameter);
        /// <summary>
        /// When a user attempts to go North, South, East or West
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Instructions.Instruction Go(string parameter);
        /// <summary>
        /// When a user uses an item
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        Instructions.Instruction Use(string parameter);
        /// <summary>
        /// When a user attempts to use two items together
        /// </summary>
        /// <param name="items">A two element array containing the items</param>
        /// <returns></returns>
        Instructions.Instruction Use(string[] items);
    }
}

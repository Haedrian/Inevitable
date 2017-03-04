using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;
using Llatext.Instructions;
using Llatext;

namespace Inevitable.Rooms
{
    class TownCenterBeforeWork: IRoom
    {
        bool hasComeBackFromWork = false;

        public Llatext.Instructions.Instruction Look()
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You are in the middle of the town center. There is nothing of interest here. To the North there is the Latex Factory. To the South is your home.");
                InevitableGUI.Output("The rest of the town is to the West, and the El Cheapo Motel is to the East");
            }
            else
            {
            //TODO: 
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You walk to a plaza in the middle of the town center");
            }
            else
            {

            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You can't see any of that from here");
            }
            else
            {
                //TODO:
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You can't take that");
            }
            else
            {
                //TODO:
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You can't open that");
            }
            else
            {
                //TODO:
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (!hasComeBackFromWork)
            {
                if (parameter.Equals("NORTH"))
                {
                    hasComeBackFromWork = true; //in preperation
                    InevitableGUI.Output("You walk towards the Latex Factory. Your place of work");
                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryentrance");
                }
                else if (parameter.Equals("SOUTH"))
                {
                    InevitableGUI.Output("Don't you have work to go to? Focus");
                }
                else if (parameter.Equals("WEST"))
                {
                    InevitableGUI.Output("You don't have time to explore the rest of the town. You have a job to do");
                }
                else if (parameter.Equals("EAST"))
                {
                    InevitableGUI.Output("You don't need a hotel room. You need to get to your job");
                }
                else
                {
                    InevitableGUI.Output("You can't move in that direction");
                }
            }
            else if (hasComeBackFromWork)
            {
                //TODO:

                
            }
            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (!hasComeBackFromWork)
            {
                InevitableGUI.Output("That won't work");
            }
            return new Llatext.Instructions.Instruction();
        }
    }
}

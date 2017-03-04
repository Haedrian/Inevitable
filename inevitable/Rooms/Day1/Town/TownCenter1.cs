using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;
using Llatext.Instructions;

namespace Inevitable.Rooms.Day1.Town
{
    class TownCenter1: IRoom
    {
        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in the town center. There is nothing of interest here");
            InevitableGUI.Output("To the north is the latex factory, which is currently closed. To the south are the ruins of your house. The El Cheapo motel is to the East, the rest of the town - including the supermarket - is to the West");

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You are in the town center. There is nothing much of interest here");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Contains("FACTORY"))
            {
                InevitableGUI.Output("The latex factory is closed since its the weekend");
            }
            else if (parameter.Contains("HOUSE") || parameter.Contains("RUIN"))
            {
                InevitableGUI.Output("You see the ruins of your house. Maybe after breakfast you can deal with the situation");
            }
            else if (parameter.Contains("MOTEL"))
            {
                InevitableGUI.Output("Current Home Sweet Home");
            }
            else if (parameter.Contains("TOWN"))
            {
                InevitableGUI.Output("You glance at the rest of the town. The supermarket is that way");
            }
            else
            {
                InevitableGUI.Output("You can't see that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            InevitableGUI.Output("You can't take that");

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            InevitableGUI.Output("You can't open that");

            parameter.Count();

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.EqualsCaseless("north"))
            {
                InevitableGUI.Output("The factory is closed today");
            }
            else if(parameter.EqualsCaseless("South"))
            {
                InevitableGUI.Output("You don't feel like dealing with this mess on an empty stomach. Lets get some breakfast first");
            }
            else if (parameter.EqualsCaseless("West"))
            {
                InevitableGUI.Output("You walk towards town and into the supermarket.");
                return new Instruction(InstructionType.LOAD, "d1supermarketcash1");
            }
            else if (parameter.EqualsCaseless("East"))
            {
                InevitableGUI.Output("You walk back to the motel room");
                return new Instruction(InstructionType.LOAD, "d1motellobby1");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            InevitableGUI.Output("You can't use that");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            InevitableGUI.Output("You can't use those");
            return new Instruction();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Inevitable.Rooms.Day0.House
{
    public class HouseRuin:IRoom
    {
        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You can see a pile of rubble. At the top of that you see Thunderbeak looking angry");
            InevitableGUI.Output("I guess you should go to a motel for now");
            InevitableGUI.Output("North leads to the town center");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You arrive at your house. Unfortunatly you left the gas on and the house has burnt down");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals("RUBBLE"))
            {
                InevitableGUI.Output("You see that which once was a proud house.");

            }
            else if (parameter.Equals("THUNDERBEAK") || parameter.Equals("CHICKEN"))
            {
                InevitableGUI.Output("Thunderbeak looks angry at having had his house burnt down. She squaks angrily at you");
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
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                InevitableGUI.Output("You walk back to the town center");
                return new Instruction(InstructionType.LOAD, "towncenterafterwork");
            }
            else
            {
                InevitableGUI.Output("You can only go North");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            InevitableGUI.Output("You can't use that");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("HAMMERDRIVER"))
            {
                if (!InventoryHandling.HasItem("hammerdriver"))
                {
                    InevitableGUI.Output("You don't have that item");
                    return new Instruction();

                }

                if (items.Contains("THUNDERBEAK") || items.Contains("CHICKEN"))
                {
                    InevitableGUI.Output("The poor chicken! Leave her alone");
                    return new Instruction();
                }

            }

            InevitableGUI.Output("You can't use those two together");
            return new Instruction();
        }
    }
}

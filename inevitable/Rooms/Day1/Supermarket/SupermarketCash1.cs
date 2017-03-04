using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Inevitable.Rooms.Day1.Supermarket
{
    class SupermarketCash1:
        IRoom
    {
        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You're in a very small Supermarket. There is only one cash point");
            InevitableGUI.Output("There is a register and a cashier, and some sweets in a jar on top of the counter");
            InevitableGUI.Output("To the EAST is the breakfast isle, and the door out is to the WEST");

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You walk into a very small supermarket. Its void of all human life except for the cashier");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.EqualsCaseless("register"))
            {
                InevitableGUI.Output("You see a rather generic cash register. Its locked unless the cashier presses the magic open button");
            }
            else if (parameter.EqualsCaseless("cashier"))
            {
                InevitableGUI.Output("The cashier is a ginger haired kid with freckles. He's waiting for your purchase");
            }
            else if (parameter.EqualsCaseless("sweets") || parameter.EqualsCaseless("jar"))
            {
                InevitableGUI.Output("A jar of sweets. If only you brought with you a bit more money...");
            }
            else if (parameter.EqualsCaseless("west"))
            {
                InevitableGUI.Output("The door out. But you can't consider leaving until you've eaten");
            }
            else if (parameter.EqualsCaseless("east"))
            {
                InevitableGUI.Output("The section of the supermarket which contains breakfast stuff");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.EqualsCaseless("register"))
            {
                InevitableGUI.Output("That's illegal! As a law-abiding citizen you shouldn't harbour such thoughts");
            }
            else if (parameter.EqualsCaseless("cashier"))
            {
                InevitableGUI.Output("You're not touching him. He's ginger!");
            }
            else if (parameter.EqualsCaseless("sweets") || parameter.EqualsCaseless("jar"))
            {
                InevitableGUI.Output("You wait till the guy isn't looking and then nick a few. You add sweets to your inventory");
                InventoryHandling.AddItem(new InventoryItem("sweets", "Some mint flavoured sweets"));
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.EqualsCaseless("register"))
            {
                return Take(parameter);
            }
            else
            {
                InevitableGUI.Output("You can't open that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.EqualsCaseless("EAST"))
            {
                InevitableGUI.Output("You walk to the breakfast isle. What a conviniantly designed supermarket...");
                return new Instruction(InstructionType.LOAD,"d1breakfast1");
            }
            else if (parameter.EqualsCaseless("WEST"))
            {
                InevitableGUI.Output("You can't leave now. Not without breakfast!");
            }
            else 
            {
                InevitableGUI.Output("You can't go there");
            }
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.EqualsCaseless("register"))
            {
                return Open(parameter);
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            throw new NotImplementedException();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("pspray"))
            {
                if (!InventoryHandling.HasItem("pspray"))
                {
                    InevitableGUI.Output("You don't have that in your inventory");
                    return new Instruction();
                }
            }

            throw new NotImplementedException();
        }
    }
}

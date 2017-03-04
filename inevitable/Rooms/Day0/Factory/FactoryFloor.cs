using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms.Factory
{
    class FactoryFloor: IRoom
    {

        //items
        string drones = "DRONES";
        string machine = "MACHINE";



        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in a factory floor. Near you there is a machine being run by 3 drones. The floor extends for a bit but this part is all you care about currently");
            InevitableGUI.Output("The door to the East leads to the entrance");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("The noisy factory floor is where the magic all happens. That is if by magic we mean latex.");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals(drones))
            {
                InevitableGUI.Output("You see a number of very bored workers working the large machine");
            }
            else if (parameter.Equals(machine))
            {
                InevitableGUI.Output("You see a complicated looking machine which plays some part in the production of latex");
            }
            else
            {
                InevitableGUI.Output("You can't see any of that there");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.Equals(drones))
            {
                InevitableGUI.Output("\"Don't you touch me!\"");
            }
            else if (parameter.Equals(machine))
            {
                InevitableGUI.Output("You're not going to be able to carry it, even if you could pull it off the floor");
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            InevitableGUI.Output("You can't open that");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("EAST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryentrance");
            }
            else
            {
                InevitableGUI.Output("You can't go there, you can only go east");
                return new Llatext.Instructions.Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals(drones))
            {
                InevitableGUI.Output("\"Don't you touch me!\"");
            }
            else if (parameter.Equals(machine))
            {
                InevitableGUI.Output("Its not your job to work the machines. Anyway the latex-making process is too complicated for you to understand");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("HAMMERDRIVER") && items.Contains("DRONES"))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("hammerdriver"))
                {
                    InevitableGUI.Output("You club one of the drones over the head with the hammerdriver and bash his skull in");
                    InevitableGUI.Output("Another of the drones, fearing for his safety stabs you through the chest with a piece of latex");

                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.DEATH, "It wasn't just a fleshwound. Survived till day 0.3333");

                    //he's dead jim
                }
                else
                {
                    InevitableGUI.Output("You don't have that item in your inventory");
                }
            }
            else if (items.Contains("HAMMERDRIVER") && items.Contains(machine))
            {
                InevitableGUI.Output("You club the machine with the hammer part of the tool. The machine creaks a bit and the drones look at you suspiciously");

            }
            else if (items.Contains("MONEY") && items.Contains(drones))
            {
                InevitableGUI.Output("\" You can pay me all you like, I'm still not sleeping with you \"");

            }
            else if (items.Contains("MONEY") && items.Contains(machine))
            {
                InevitableGUI.Output("This isn't a slot machine you know");
            }
            else
            {
                InevitableGUI.Output("That'll never work");
            }

            return new Llatext.Instructions.Instruction();
        }
    }
}

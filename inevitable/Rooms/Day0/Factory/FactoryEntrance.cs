using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Rooms;

namespace Inevitable.Rooms.Factory
{
    class FactoryEntrance : IRoom
    {

        //Ladder
        //->hammerdriver
        //Desk
        //Noticeboard
        //Plant

        //parameters
        string ladder = "LADDER";
        string hammerdriver = "HAMMERDRIVER";
        string desk = "DESK";
        string noticeboard = "NOTICEBOARD";
        string plant = "PLANT";

        bool hastakenHammerDriver = false;
        bool hasreadboard = false;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in a factory entrance. You can see a ladder, a desk, a noticeboard and a plant in the corner");
            InevitableGUI.Output("The stairs to the north lead to the offices, the door to the east leads to the janitor's room, west leads to the factory floor, and south leads outside.");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            if (hasreadboard)
            {
                InevitableGUI.Output("You are standing in the entrance hall of the factory");
            }
            else
            {
                InevitableGUI.Output("You are standing in the entrance of the factory. Maybe you should check the noticeboard for your next mission");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals(ladder))
            {
                if (hastakenHammerDriver)
                {
                    InevitableGUI.Output("You see a wooden ladder propped up against the wall");
                }
                else
                {
                    InevitableGUI.Output("You see a wooden ladder propped up against the wall, upon one of the rungs you see a hammerdriver");
                }
            }
            else if (parameter.Equals(hammerdriver))
            {
                InevitableGUI.Output("You see the bastard child of a hammer and a screwdriver. A brilliant all-in-one tool for the discriminating janitor");
            }
            else if (parameter.Equals(desk))
            {
                InevitableGUI.Output("The front desk. Usually Gracie would be here, but she's not in today");
            }
            else if (parameter.Equals(noticeboard))
            {
                InevitableGUI.Output("You find your name. Your task today is to produce a boring report. And collect your paycheck");
                InevitableGUI.Output("You don't feel like producing a report. Maybe one of your co-workers won't mind doing your job for you");
                hasreadboard = true;
            }
            else if (parameter.Equals(plant))
            {
                InevitableGUI.Output("A cactus. Everyone calls him George. He doesn't speak much");
            }
            else
            {
                InevitableGUI.Output("You can't see any of those there");
            }

            return new Llatext.Instructions.Instruction();

        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.Equals(ladder))
            {
                InevitableGUI.Output("You don't want to stay hauling a heavy ladder around do you? No you don't");
            }
            else if (parameter.Equals(hammerdriver))
            {
                if (hastakenHammerDriver)
                {
                    InevitableGUI.Output("You took that already");
                }
                else
                {
                    InevitableGUI.Output("You take the hammerdriver");
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("hammerdriver","A cross between a hammer and a screwdriver"));
                    hastakenHammerDriver = true;
                }
            }
            else if (parameter.Equals(desk))
            {
                InevitableGUI.Output("Its too heavy to stay moving around, what did you want it for anyway");
            }
            else if (parameter.Equals(noticeboard))
            {
                InevitableGUI.Output("Its bolted firmly to the wall");
            }
            else if (parameter.Equals(plant))
            {
                InevitableGUI.Output("Leave George alone");
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            InevitableGUI.Output("That doesn't open");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryoffice");
            }
            else if (parameter.Equals("WEST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryfloor");
            }
            else if (parameter.Equals("EAST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "janitorcloset");
            }
            else if (parameter.Equals("SOUTH"))
            {
                //check if he has his paycheck
                if (Llatext.Inventory.InventoryHandling.HasItem("paycheck"))
                {
                    //he can leave
                    return new Instruction(InstructionType.LOAD, "towncenterafterwork");
                }
                else
                {
                    //Not done yet
                    InevitableGUI.Output("Oi slacker, get back to work");
                }
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals(ladder))
            {
                InevitableGUI.Output("You climb up the ladder. Don't you feel tall now? You climb down again");
            }
            else if (parameter.Equals(hammerdriver))
            {
                InevitableGUI.Output("The hammerdriver is a means to the end, never an end in itself");
            }
            else if (parameter.Equals(desk))
            {
                InevitableGUI.Output("You can't use that");
            }
            else if (parameter.Equals(noticeboard))
            {
                Examine(noticeboard);
            }
            else if (parameter.Equals(plant))
            {
                InevitableGUI.Output("You can't use that");
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains(hammerdriver) && items.Contains(desk))
            {
                InevitableGUI.Output("You club the desk with the hammer part. You vandal");
            }
            else
            {
                InevitableGUI.Output("Those two will never work");
            }
            return new Llatext.Instructions.Instruction();
        }
    }
}

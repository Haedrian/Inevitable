using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms.Factory
{
    class FactoryOffice: IRoom
    {
        //items
        string table = "TABLE";
        string desk = "DESK";
        string slot = "SLOT";
        string drawer = "DRAWER";
        string report = "REPORT";
        string copier = "COPIER";
        string socket = "SOCKET";
        string window = "WINDOW";
        string door = "DOOR";

        bool hasOpenedWindow = false;
        bool hasFixedCopier = false;
        bool hasOpenedDrawer = false;
        bool hasMadeCopy = false;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("The office is quite luxurious. You can see a desk, and your own smaller table. There is the boss' door with a slot in it to the east. A copier is in the corner");
            InevitableGUI.Output("The North of the room is a giant window which gives a view of the streets, there is a door to the east. The stairs to the South lead back to the factory entrance");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You are in the offices, they are nicely decorated and there is a large glass window which makes up the Northern wall, giving a beautiful view of the street below");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals(table))
            {
                InevitableGUI.Output("An ugly scratched table, where you usually work at");
            }
            else if (parameter.Equals(desk))
            {
                InevitableGUI.Output("A beautiful desk, with a small drawer underneath the work area");
            }
            else if (parameter.Equals(window))
            {
                InevitableGUI.Output("A large window which you'd be able to fit through if it were open");
            }
            else if (parameter.Equals(slot))
            {
                InevitableGUI.Output("A slot in the door for posting reports and other documents");
            }
            else if (parameter.Equals(drawer))
            {
                if (hasOpenedDrawer)
                {
                    InevitableGUI.Output("A report is lying down in the desk. That might be useful");
                }
                else
                {
                    InevitableGUI.Output("Its closed");
                }
            }
            else if (parameter.Equals(report))
            {
                InevitableGUI.Output("Rather boring report on the price increase of latex on the international market");
            }
            else if (parameter.Equals(copier))
            {
                if (hasFixedCopier)
                {
                    InevitableGUI.Output("The Copier is signalling with a green light, meaning its ready to copy. It is connected to an electrical socket");
                }
                else
                {
                    InevitableGUI.Output("The Copier is signalling that its out of toner. It is connected to an electrical socket");
                }
            }
            else if (parameter.Equals(socket))
            {
                InevitableGUI.Output("An electrical socket. Passes 230 V of AC current at a frequency of 50 Hertz");
            }
            else if (parameter.Equals(door))
            {
                InevitableGUI.Output("The boss's door. It is locked, but has a slit for passing papers through it");
            }
            else
            {
                InevitableGUI.Output("You can't examine that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.Equals(report))
            {
                if (hasMadeCopy)
                {
                    InevitableGUI.Output("You don't need the original now that you have a copy");
                }
                else
                {
                    InevitableGUI.Output("You'd better not take it from its place until you are going to use it with a functioning copier");
                }
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.Equals(drawer))
            {
                if (hasOpenedDrawer)
                {
                    InevitableGUI.Output("You close the drawer");
                    hasOpenedDrawer = false;
                }
                else
                {
                    InevitableGUI.Output("You open the drawer");
                    hasOpenedDrawer = true;
                }
            }
            else if (parameter.Equals(window))
            {
                if (!hasOpenedWindow)
                {
                    InevitableGUI.Output("You open the window. Be careful!");
                    hasOpenedWindow = true;
                }
                else
                {
                    InevitableGUI.Output("You tug the window closed.");
                    hasOpenedWindow = false;
                }
            }
            else if (parameter.Equals(door))
            {
                InevitableGUI.Output("The door is locked. Use the slot");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                if (hasOpenedWindow)
                {
                    //death
                    InevitableGUI.Output("You walk through the open window and are dashed to pieces on the ground below");
                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.DEATH, "Tried to fly. Survived till Day 0.333");
                }
                else
                {
                    InevitableGUI.Output("You bump your face into the glass window");
                }
            }
            else if (parameter.Equals("SOUTH"))
            {
                InevitableGUI.Output("You walk back down to the entrance");
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryentrance");
            }
            else if (parameter.Equals("EAST"))
            {
                InevitableGUI.Output("The boss' door is closed");
            }
            else
            {
                InevitableGUI.Output("You can't go there");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals("COPIER"))
            {
                InevitableGUI.Output("You're too mature to want to photocopy parts of yourself aren't you?");
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains(copier) && items.Contains("TONER"))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("toner"))
                {
                    InevitableGUI.Output("As you open the copier to put the toner in, you find a banknote that someone was illegally photocopying. Score!");
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("banknote", "The root of all evil"));
                    InevitableGUI.Output("Otherwise, you fix the machine. Congrats");
                    hasFixedCopier = true;
                    Llatext.Inventory.InventoryHandling.RemoveItem("toner");
                }
                else
                {
                    InevitableGUI.Output("You don't have that in your inventory");
                }
            }
            else if (items.Contains(copier) && items.Contains("REPORT"))
            {
                if (!hasFixedCopier)
                {
                    InevitableGUI.Output("The copier is out of toner. Maybe you should fix that first");
                }
                else if (!hasOpenedDrawer)
                {
                    InevitableGUI.Output("What report?");
                }
                else if (hasMadeCopy)
                {
                    InevitableGUI.Output("One copy is more than enough, you don't have to fill it out in triplicate");
                }
                else
                {
                    InevitableGUI.Output("You quickly take the report from the drawer and make a copy for your own. You then replace it back in its place");
                    hasMadeCopy = true;
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("report","A photocopy of someone else's report. Plagerist"));
                }

            }
            else if (items.Contains("HAMMERDRIVER") && items.Contains("SOCKET"))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("hammerdriver"))
                {
                    //death
                    InevitableGUI.Output("You put the screwdriver side of the tool into the socket. You are zapped by electricity");

                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.DEATH, "Lit up like a Christmas tree. Survived till day 0.333");
                }
                else
                {
                    InevitableGUI.Output("You don't have that item");
                }
            }
            else if (items.Contains("REPORT") && (items.Contains("SLOT") || items.Contains("DOOR")))
            {
                if (hasMadeCopy)
                {
                    InevitableGUI.Output("You slide the copy out of the door. You receive your paycheck from underneath the door. Congrats, you can go home now.");
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("paycheck","Look at all the 0s behind the dot"));
                    Llatext.Inventory.InventoryHandling.RemoveItem("report");
                }
            }
            else if (items.Contains("HAMMERDRIVER") && (items.Contains("WINDOW")))
            {

                if (Llatext.Inventory.InventoryHandling.HasItem("HAMMERDRIVER"))
                {
                    InevitableGUI.Output("You whack the window with the hammer but it doesn't break. Reinforced glass ftw");
                    return new Llatext.Instructions.Instruction();
                }
                else
                {
                    InevitableGUI.Output("You don't have the hammerdriver");
                }


            }
            else
            {
                InevitableGUI.Output("That'll never work");
            }

            return new Llatext.Instructions.Instruction();
        }
    }
}

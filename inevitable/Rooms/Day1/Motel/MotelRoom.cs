using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Inevitable.Rooms.Day1.Motel
{
    public class MotelRoom: IRoom
    {
        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You're in your motel room. You can see a pile of your items in the corner where you left them. There is a door to the south which leads to the lobby");

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {

            InevitableGUI.Output("You wake up the next morning. You grab some of your previous inventory items and take them with you");
            InevitableGUI.Output("Your next mission is to obtain some breakfast from the Supermarket: cerial and milk.");


            //Bit dirty - but this means it doesn't come from a savegame
            if (InventoryHandling.InventoryCount() != 0)
            {
                //clear the inventory
                InventoryHandling.RemoveAll();

                InventoryHandling.AddItem(new InventoryItem("money", "Enough cash to buy yourself some cerial and milk"));
                InventoryHandling.AddItem(new InventoryItem("hammerdriver", "Your faithful multi-tool companion"));

                return new Instruction(InstructionType.SAVE, "1"); //save day 1
            }
            else
            {
                //comes from a savegame
                InventoryHandling.AddItem(new InventoryItem("money", "Enough cash to buy yourself some cerial and milk"));
                InventoryHandling.AddItem(new InventoryItem("hammerdriver", "Your faithful multi-tool companion"));

                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Contains("BED"))
            {
                InevitableGUI.Output("A smelly bed with no bedsheets, not the most luxurious of places to rest one's head");
            }
            else if (parameter.Contains("PILE") || (parameter.Contains("STUFF")))
            {
                InevitableGUI.Output("A pile of your assorted stuff. Leave it here for today");
            }
            else if (parameter.Contains("DOOR"))
            {
                InevitableGUI.Output("The door to the outside world");
            }
            else
            {
                InevitableGUI.Output("You can't see any of those here");
            }

            return new Instruction();

        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.Contains("PILE") || parameter.Contains("STUFF"))
            {
                InevitableGUI.Output("You should have enough items with you for today's adventures. You can leave the rest");
            }
            else if (parameter.Contains("BED"))
            {
                InevitableGUI.Output("Even if you could carry the bed, you wouldn't want it");
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.Contains("DOOR"))
            {
                InevitableGUI.Output("You open the door and walk to the lobby");

                return new Instruction(InstructionType.LOAD, "d1motellobby1");
            }
            else
            {
                InevitableGUI.Output("You can't open that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Contains("SOUTH"))
            {
                InevitableGUI.Output("You open the door and walk to the lobby");

                return new Instruction(InstructionType.LOAD, "d1motellobby1");
            }
            else
            {
                InevitableGUI.Output("You can't go in that direction. The door out is to the South");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Contains("DOOR"))
            {
                //open it
                return Open(parameter);
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            InevitableGUI.Output("You can't use those two together");

            return new Instruction();
        }
    }
}

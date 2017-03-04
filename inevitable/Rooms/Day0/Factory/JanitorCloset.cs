using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms.Factory
{
    class JanitorCloset: IRoom
    {
        //items
        string locker = "LOCKER";
        string broom = "BROOM";
        string shelves = "SHELVES";
        string toner = "TONER";

        bool hasOpenedLocker = false;
        bool hasTakentoner = false;


        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in a very small room. There is a locker in the corner, a broom propped up against it, and a number of shelves of assorted products");
            InevitableGUI.Output("The door to the West leads back to the factory entrance");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You are in a small and dark room which the Janitor uses to keep his supplies in");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals(locker))
            {
                if (hasOpenedLocker)
                {
                    InevitableGUI.Output("Aside from items which you might not care about, the now opened locker contains some toner");
                }
                else
                {
                    InevitableGUI.Output("The Janitor's Locker. It is securely locked by a combination lock and you don't know the combination");
                }
            }
            else if (parameter.Equals(broom))
            {
                InevitableGUI.Output("A generic broom used to sweep generic floors");
            }
            else if (parameter.Equals(shelves))
            {
                InevitableGUI.Output("The shelves are filled to the brim with assorted cleaning products you have no use for and no knowledge of");

            }
            else if (parameter.Equals(toner))
            {
                if (hasOpenedLocker && !hasTakentoner)
                {
                    InevitableGUI.Output("The kind of stuff that you use with laser printers to be able to print things");
                }
            }
            else
            {
                InevitableGUI.Output("You can't examine that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.Equals(locker))
            {
                InevitableGUI.Output("You can't move the locker, so why even bother");
            }
            else if (parameter.Equals(broom))
            {
                InevitableGUI.Output("You have no need for a broom");
            }
            else if (parameter.Equals(toner))
            {
                InevitableGUI.Output("You take the toner");
                hasTakentoner = true;
                Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("toner", "A cartridge of magic stuff which makes laser printers work"));
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.Equals(locker))
            {
                if (hasOpenedLocker)
                {
                    InevitableGUI.Output("The locker is already open, and its not likely to be able to close after that");
                }
                else
                {
                    InevitableGUI.Output("You twiddle with the combination lock, but you don't know the correct code to put in to open it");
                }
            }
            else
            {
                InevitableGUI.Output("You can't open that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("WEST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "factoryentrance");
            }
            else
            {
                InevitableGUI.Output("The only exit from this room is to the west");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals(locker))
            {
                Open(locker);
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }
            return new Llatext.Instructions.Instruction();   
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("HAMMERDRIVER") && items.Contains(locker))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("hammerdriver"))
                {
                    InevitableGUI.Output("You smack the lock with the hammer part of the tool, the lock breaks and the door swings open");
                    hasOpenedLocker = true;
                }
                else
                {
                    InevitableGUI.Output("You don't have that in your inventory");
                }

            }
            else
            {
                InevitableGUI.Output("That will never work");
            }

            return new Llatext.Instructions.Instruction();
        }
    }
}

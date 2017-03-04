using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Inevitable.Rooms.Day0.Motel
{

    public class Motel:IRoom
    {
        bool hasKey = false;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You're in a sleasy looking motel. There is an ATM in the corner, and a receptionist sitting on a desk.");
            InevitableGUI.Output("The door north leads to the rooms");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You walk into the sleasy looking motel. It won't win any awards for cleanliness, safety or lack-of-rodents - but at least its a roof on one's head");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals("ATM"))
            {
                InevitableGUI.Output("You see an Automated Bank Teller Machine. The interface says 'paycheck auto casher'");
                return new Instruction();

            }
            else if (parameter.Equals("RECEPTIONIST"))
            {
                InevitableGUI.Output("You see an unshaved guy behind a desk. He mutters 'pay in advance'");
                return new Instruction();
            }
            else
            {
                InevitableGUI.Output("You can't see that");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            InevitableGUI.Output("You can't take that");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.Equals("ATM"))
            {
                InevitableGUI.Output("You try to open the ATM but its screwed very tightly together");
                return new Instruction();
            }
            else
            {
                InevitableGUI.Output("You can't open that");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                if (hasKey)
                {
                    //load day 1
                    InevitableGUI.Output("You walk north and find your room. You dump your inventory into a pile next to the bed and go to sleep");
                    return new Instruction(InstructionType.LOAD, "day1");
                }
                else
                {
                    InevitableGUI.Output("Maybe you should get your room first");
                    return new Instruction();
                }
            }
            else
            {
                InevitableGUI.Output("I know you want to leave, but its the best you can do");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals("ATM"))
            {
                if (InventoryHandling.HasItem("paycheck"))
                {
                    InevitableGUI.Output("You insert the paycheck into the ATM. You get some cash in return. Hooray");

                    InventoryHandling.RemoveItem("banknote");
                    InventoryHandling.RemoveItem("paycheck");
                    InventoryHandling.AddItem(new InventoryItem("cash", "Money Money Money"));

                    return new Instruction();

                }
                else
                {
                    InevitableGUI.Output("You don't have your paycheck");
                    return new Instruction();
                }

            }
            else
            {
                InevitableGUI.Output("You can't use that");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("ATM"))
            {
                if (items.Contains("HAMMERDRIVER") && InventoryHandling.HasItem("hammerdriver"))
                {
                    InevitableGUI.Output("You raise your hammerdriver, but then think better of it");

                }
                else if (items.Contains("PAYCHECK") && InventoryHandling.HasItem("paycheck"))
                {
                    InevitableGUI.Output("You insert the paycheck into the ATM. You get some cash in return. Hooray");
                    InventoryHandling.RemoveItem("banknote");
                    InventoryHandling.RemoveItem("paycheck");
                    InventoryHandling.AddItem(new InventoryItem("cash", "Money Money Money"));
                }
                else
                {
                    InevitableGUI.Output("That won't work");
                }
            }
            else if (items.Contains("RECEPTIONIST"))
            {
                if (items.Contains("BANKNOTE") && InventoryHandling.HasItem("banknote"))
                {
                    InevitableGUI.Output("He sneers at you 'That's not nearly enough'");
                }
                else if (items.Contains("CASH") && InventoryHandling.HasItem("cash"))
                {
                    if (hasKey)
                    {
                        InevitableGUI.Output("You've already paid him");
                    }
                    else
                    {
                        InevitableGUI.Output("He takes some of your money, handing you the rest and opens a room for you.");
                        InevitableGUI.Output("You can go North now");
                        hasKey = true;
                    }
                }
                else if (items.Contains("HAMMERDRIVER") && InventoryHandling.HasItem("hammerdriver"))
                {
                    InevitableGUI.Output("You raise the hammerdriver threatiningly. The receptionist fears for his life and pulls out a shotgun from his desk");
                    InevitableGUI.Output("You are shot. You die");
                    return new Instruction(InstructionType.DEATH, "Had too much lead in his diet. Survived till day 0.6");

                }
                else
                {
                    InevitableGUI.Output("That won't work");
                }
            }
            else
            {
                InevitableGUI.Output("That won't work");
            }

            return new Instruction();
        }
    }
}

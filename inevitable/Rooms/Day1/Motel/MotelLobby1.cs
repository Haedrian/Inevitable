using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;
using Llatext.Instructions;
using Llatext.Inventory;

namespace Inevitable.Rooms.Day1.Motel
{
    class MotelLobby1: IRoom
    {
        public Instruction Look()
        {
            InevitableGUI.Output("You're in the motel lobby. The owner isn't here. There is an ATM in the corner and a desk across it.");
            InevitableGUI.Output("North leads back to your room. South leads to outside");

            return new Instruction();
        }

        public Instruction Introduction()
        {
            InevitableGUI.Output("You're in the motel lobby. The owner doesn't seem to be here and the room is void of other people. Onwards to the supermarket");

            return new Instruction();
        }

        public Instruction Examine(string parameter)
        {
            if (parameter.Contains("DESK"))
            {
                InevitableGUI.Output("The desk has a metal grid around it with a flap for money and keys to pass through. The flap may be big enough for an arm to pass through");
            }
            else if (parameter.Contains("FLAP"))
            {
                InevitableGUI.Output("The flap is very small but you might be able to pass your arm through with some difficulty");
            }
            else if (parameter.Contains("ATM"))
            {
                InevitableGUI.Output("The ATM is powered off");
            }
            else
            {
                InevitableGUI.Output("You can't see that");
            }

            return new Instruction();
        }

        public Instruction Take(string parameter)
        {
            if (parameter.Contains("FLAP"))
            {
                return Use(parameter);
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Instruction();
        }

        public Instruction Open(string parameter)
        {
            if (parameter.Contains("FLAP"))
            {
                return Use(parameter);
            }
            else
            {
                InevitableGUI.Output("You can't open that");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Contains("NORTH"))
            {
                InevitableGUI.Output("You have a mission to perform. You can go back to sleep later");
                return new Instruction();
            }
            else if (parameter.Contains("SOUTH"))
            {
                InevitableGUI.Output("You walk outdoors to the town");
                return new Instruction(InstructionType.LOAD, "d1towncenter1");
            }
            else
            {
                InevitableGUI.Output("You can't go in that direction. You can go South");
                return new Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Contains("ATM"))
            {
                InevitableGUI.Output("The ATM isn't working, its powered off");
                return new Instruction();
            }
            else if (parameter.Contains("FLAP"))
            {
                InevitableGUI.Output("You push your hand through the flap and grab around. You pick up a mysterious tube and put it in your pocket");
                InevitableGUI.Output("You examine the tube and discover it to be a tube of PSpray - a commerical Pepper Spray solution");

                InventoryHandling.AddItem(new InventoryItem("pspray", "A bottle of pepper spray"));
            }
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("HAMMERDRIVER") && InventoryHandling.HasItem("hammerdriver"))
            {
                if (items.Contains("ATM"))
                {
                    InevitableGUI.Output("You smash the ATM with the hammerdriver. The ATM's security system kicks in and delivers a high voltage shock through the hammer");
                    return new Instruction(InstructionType.DEATH, "ATM Security Victim. Survived till day 1");
                }
                else if (items.Contains("DESK"))
                {
                    InevitableGUI.Output("The proprietor won't be too happy with you smashing his desk");
                    return new Instruction();
                }

                return new Instruction();
            }
            else
            {
                InevitableGUI.Output("That won't work");
                return new Instruction();
            }
            
        }
    }
}

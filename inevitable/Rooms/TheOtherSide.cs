using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms
{
    class TheOtherSide: IEndRoom
    {
        //LIGHT - NORTH
        //Book
        //Gravestone

        private string causeOfDeath;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in a white place full of clouds. You are a sphere of light. You can see a gravestone, an open book floating in the air");
            InevitableGUI.Output("There is an overwhelmingly bright white light to the North");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            //lose all the inventory
            Llatext.Inventory.InventoryHandling.RemoveAll();

            InevitableGUI.Output("You open your eyes. You're not sure where you are exactly");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Remove(string parameter)
        {
            InevitableGUI.Output("You have nothing to remove");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.Equals("LIGHT"))
            {
                InevitableGUI.Output("You see a blindingly powerful light in the distance. It almost becons you to come forward");
            }
            else if (parameter.Equals("BOOK"))
            {
                InevitableGUI.Output("The Book Reads - Congratulations Traveller. You have lived a worthy life. Come forth for your reward");
            }
            else if (parameter.Equals("GRAVESTONE"))
            {
                InevitableGUI.Output("You see a gravestone. It reads Mr/s Player. " + causeOfDeath);
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            InevitableGUI.Output("You can't bring anything with you");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.Equals("BOOK"))
            {
                InevitableGUI.Output("The book is already open");
            }
            else
            {
                InevitableGUI.Output("You can't open that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                InevitableGUI.Output("You walk towards the light...");
                InevitableGUI.Output("Your open your eyes again. You are a cria in a field. This is the best reward any human can expect. Good going!");
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.WIN, "Reincarnated");
            }
            else
            {
                InevitableGUI.Output("Your way is blocked by clouds. The only gap is to the North");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals("BOOK"))
            {
                return Examine("BOOK");
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            InevitableGUI.Output("You can't Use those");
            return new Llatext.Instructions.Instruction();
        }

        public void SetCauseOfDeath(string cause)
        {
            this.causeOfDeath = cause;
        }
    }
}

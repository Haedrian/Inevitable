using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms
{
    class Garden: IRoom
    {
        //Nest
        //-> Egg
        //Chicken

        //West <- Kitchen

        bool hasFedChicken = false;
        bool eggThere = true;

        public Llatext.Instructions.Instruction Look()
        {
            if (!hasFedChicken)
            {
                InevitableGUI.Output("You're in a garden. You can see your pet chicken running around looking hungry. There is also her nest. The door to the kitchen is to the West");
            }
            else
            {
                InevitableGUI.Output("You're in a garden. You can see a content looking chicken. There is also her nest. The door to the kitchen is to the West");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("The garden is pretty serene. Thunderbeak pecks around");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Remove(string parameter)
        {
            if (parameter.ToUpper().Equals("CHICKEN") || parameter.ToUpper().Equals("THUNDERBEAK"))
            {
                InevitableGUI.Output("Remove what from the chicken?");
            }
            else
            {
                InevitableGUI.Output("You can't remove that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.ToUpper().Equals("CHICKEN") || parameter.ToUpper().Equals("THUNDERBEAK"))
            {
                if (hasFedChicken)
                {
                    InevitableGUI.Output("You see Thunderbeak looking rather content and well fed");
                }
                else
                {
                    InevitableGUI.Output("Thunderbeak looks hungry. He squawks angrily at you");
                }
            }
            else if (parameter.ToUpper().Equals("EGG"))
            {
                if (eggThere)
                {
                    InevitableGUI.Output("A nice smooth egg, perhaps Thunderbeak's future child");
                }
            }
            else if (parameter.ToUpper().Equals("NEST"))
            {
                if (eggThere)
                {
                    InevitableGUI.Output("Thunderbeak's home. There is an egg in there");
                }
                else
                {
                    InevitableGUI.Output("Thunderbeak's home");
                }
            }
            else
            {
                InevitableGUI.Output("You can't see any of that there");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.ToUpper().Equals("CHICKEN") || parameter.ToUpper().Equals("THUNDERBEAK"))
            {
                InevitableGUI.Output("Unfortunatly Thunderbeak is a heavy chook and isn't very portable");
            }
            else if (parameter.ToUpper().Equals("NEST"))
            {
                InevitableGUI.Output("Why rob such a nice chicken of its home?");
            }
            else if (parameter.ToUpper().Equals("EGG"))
            {
                if (hasFedChicken && eggThere)
                {
                    InevitableGUI.Output("You take the egg. Now all you need to do is cook it");
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("egg","What will one day become a chicken. Unless you cook it"));
                    eggThere = false;
                }
                else if (!eggThere)
                {
                    InevitableGUI.Output("Egg is not there anymore");
                }
                else
                {
                    InevitableGUI.Output("Thunderbeak pecks angrily at you, he won't let you near the egg");
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
            if (parameter.ToUpper().Equals("CHICKEN")|| parameter.ToUpper().Equals("THUNDERBEAK"))
            {
                InevitableGUI.Output("Open a chicken? Really? You're disgusting");
            }
            else
            {
                InevitableGUI.Output("That doesn't open");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.ToUpper().Equals("WEST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "kitchen");
            }
            else
            {
                InevitableGUI.Output("You can't go there. The kitchen door is West of here");
                return new Llatext.Instructions.Instruction();
            }
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.ToUpper().Equals("CHICKEN") || parameter.ToUpper().Equals("THUNDERBEAK"))
            {
                InevitableGUI.Output("You have a very disturbing like of chickens...");
            }
            else
            {
                InevitableGUI.Output("That won't work");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {

            if (items.Contains("SEEDS") && (items.Contains("CHICKEN") || items.Contains("THUNDERBEAK")))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("seeds"))
                {
                    InevitableGUI.Output("You feed Thunderbeak. He looks much happier");
                    hasFedChicken = true;
                    Llatext.Inventory.InventoryHandling.RemoveItem("seeds");
                }
                else
                {
                    InevitableGUI.Output("You don't have the seeds. Cheater!");
                }
            }
            else if (items.Contains("BLINDFOLD") && (items.Contains("CHICKEN") || items.Contains("THUNDERBEAK")))
            {
                InevitableGUI.Output("You attempt to blindfold the chicken. Seriously what is wrong with you?");
            }
            else
            {
                InevitableGUI.Output("Those two won't work");
            }
            return new Llatext.Instructions.Instruction();
        }
    }
}

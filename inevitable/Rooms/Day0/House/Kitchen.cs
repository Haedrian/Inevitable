using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Llatext.Rooms;

namespace Inevitable.Rooms
{
    class Kitchen: IRoom
    {

        //ROOM CONTAINS:
        //Cupboard 
        //-> Seeds
        //Stove
        //-> Pan
        //--> Omlette
        //-> Knob
        //-> Fire


        private bool hastakenSeeds = false;
        private bool cupboardOpen = false;
        private bool hasFire = false;
        private bool hasOmlette = false;
        private bool hasHadBreakfast = false;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are in a very small kitchen. There is a stove with a frying pan on top of it. There is also a cupboard.");
            InevitableGUI.Output("The door South Leads to the Bedroom. The door North is the front door, the door East leads to the garden, the door west leads to uninteresting parts of the house");
            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You walk into the kitchen. Your stomach grumbles. Your new mission - breakfast. You feel like an omlette.");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Remove(string parameter)
        {
            InevitableGUI.Output("There is nothing to remove");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.ToUpper().Equals("STOVE"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("The stove is lit with a pan on top of it, and a cheerful flame burns. There is a knob to turn it off");
                }
                else
                {
                    InevitableGUI.Output("The stove is unlit, and has a pan on top of it. There is a knob to turn it on");
                }
            }
            else if (parameter.ToUpper().Equals("FIRE"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("You see a small flame, perfect for cooking food");
                }
                else
                {
                    InevitableGUI.Output("You don't see any fire anywhere");
                }
            }
            else if (parameter.ToUpper().Equals("KNOB"))
            {
                InevitableGUI.Output("Turning this in one direction or the other turns the stove on or off");
            }
            else if (parameter.ToUpper().Equals("CUPBOARD"))
            {
                if (cupboardOpen)
                {
                    InevitableGUI.Output("You see a packet of seeds in the cupboard, and nothing else");
                }
                else
                {
                    InevitableGUI.Output("The cupboard is closed");
                }

            }
            else if (parameter.ToUpper().Equals("SEEDS"))
            {
                if (cupboardOpen && !hastakenSeeds)
                {
                    InevitableGUI.Output("A packet of seeds, something you'd feed a bird of some sort");
                }
                else
                {
                    InevitableGUI.Output("What seeds?");
                }

            }
            else if (parameter.ToUpper().Equals("PAN"))
            {
                if (hasOmlette)
                {
                    InevitableGUI.Output("A pan with a lovely cooked omlette in it");
                }
                else
                {
                    InevitableGUI.Output("A pan for shallow frying omlettes or other things of that sort");
                }
            }
            else if (parameter.ToUpper().Equals("OMLETTE") || (parameter.Contains("OMELETTE")))
            {
                if (hasOmlette)
                {
                    InevitableGUI.Output("A delicious cooked omlette. Also known as your breakfast");
                }
                else if (hasHadBreakfast)
                {
                    InevitableGUI.Output("Its not there anymore, you just ate it");
                }
                else
                {
                    InevitableGUI.Output("You're so hungry you're imagining omlettes now?");
                }
            }
            else
            {
                InevitableGUI.Output("You can't see that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            if (parameter.ToUpper().Equals("STOVE"))
            {
                InevitableGUI.Output("It won't fit into your pocket");
            }
            else if (parameter.ToUpper().Equals("KNOB"))
            {
                InevitableGUI.Output("You could pull it out I guess, but do you really want to?");
            }
            else if (parameter.ToUpper().Equals("FIRE"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("You burn your finger slightly");
                }
                else 
                {
                    InevitableGUI.Output("What fire?");
                }
                
            }
            else if (parameter.ToUpper().Equals("PAN"))
            {
                InevitableGUI.Output("It's already in the right place, no need to move it");
            }
            else if (parameter.ToUpper().Equals("CUPBOARD"))
            {
                InevitableGUI.Output("You try to pull the cupboard out of the counter but fail horribly");
            }
            else if (parameter.ToUpper().Equals("SEEDS"))
            {
                if (hastakenSeeds)
                {
                    InevitableGUI.Output("You've already taken that");
                }

                if (!cupboardOpen)
                {
                    InevitableGUI.Output("You can't see any seeds");
                }

                InevitableGUI.Output("You take the seeds and place them into your pocket");

                Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("seeds", "Small seeds, something you'd feed to a bird of some sort"));
                hastakenSeeds = true;
            }
            else if (parameter.ToUpper().Equals("OMLETTE") || (parameter.Contains("OMELETTE")))
            {
                if (hasOmlette)
                {
                    InevitableGUI.Output("You take the omlette and eat it. Nom Nom. Now you can go to work!");
                    hasHadBreakfast = true;
                    hasOmlette = false;
                }
                else
                {
                    InevitableGUI.Output("You can't take what you don't have");
                }
            }
            else
            {
                InevitableGUI.Output("You can't take that...");
            }

            return new Llatext.Instructions.Instruction();

        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (parameter.ToUpper().Equals("CUPBOARD"))
            {
                if (cupboardOpen)
                {
                    InevitableGUI.Output("Its already open...");
                }
                else
                {
                    InevitableGUI.Output("You open the cupboard");
                    cupboardOpen = true;
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
            if (parameter.ToUpper().Equals("NORTH"))
            {
                if (hasHadBreakfast)
                {
                    if (hasFire)
                    {
                        InevitableGUI.Output("You leave for work");
                    }
                    else
                    {
                        InevitableGUI.Output("You leave for work");
                    }
                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "towncenterbeforework");
                }
                else
                {
                    InevitableGUI.Output("You can't leave yet, you haven't had breakfast.");
                }
            }
            else if (parameter.ToUpper().Equals("SOUTH"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "bedroom");
            }
            else if (parameter.ToUpper().Equals("WEST"))
            {
                InevitableGUI.Output("The rest of the house is totally uninteresting for the purpose of this quest");
            }
            else if (parameter.ToUpper().Equals("EAST"))
            {
                return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.LOAD, "garden");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.ToUpper().Equals("CUPBOARD"))
            {
                Open("Cupboard");
            }
            else if (parameter.ToUpper().Equals("SEEDS"))
            {
                if (!hastakenSeeds)
                {
                    InevitableGUI.Output("They're too small for breakfast. What you need is a nice big omlette");
                }
            }
            else if (parameter.ToUpper().Equals("STOVE"))
            {
                InevitableGUI.Output("How do you want to use that exactly?");
            }
            else if (parameter.ToUpper().Equals("PAN"))
            {
                InevitableGUI.Output("The pan is already prepped for cooking. All you need is fire and the egg");
            }
            else if (parameter.ToUpper().Equals("OMLETTE"))
            {
                if (hasOmlette)
                {
                    InevitableGUI.Output("You eat your delicious breakfast. Nom Nom. You can finally leave for work");
                    hasHadBreakfast = true;
                    hasOmlette = false;
                }
                else
                {
                    InevitableGUI.Output("What omlette?");
                }
            }
            else if (parameter.ToUpper().Equals("KNOB"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("You try to turn the knob but its stuck. Cheap rubbish");
                }
                else
                {
                    InevitableGUI.Output("You turn the fire on. You made fire!");
                    hasFire = true;
                }
            }
            else if (parameter.ToUpper().Equals("FIRE"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("You sit around the fire and sing campsongs. Time to keep going...");
                }
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Llatext.Instructions.Instruction();

        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("EGG") && items.Contains("PAN"))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("EGG"))
                {
                    if (hasFire)
                    {
                        //Cook it
                        InevitableGUI.Output("You cook a delicious omlette from Thunderbeak's would-have-been child. Yummy.");
                        hasOmlette = true;
                        Llatext.Inventory.InventoryHandling.RemoveItem("egg");
                    }
                    else
                    {
                        InevitableGUI.Output("The tradition is to actually get a fire going before you try to cook");
                    }

                }
                else
                {
                    InevitableGUI.Output("You don't have the egg in your inventory. Cheater!");
                }
            }
            else if (items.Contains("SEEDS") && items.Contains("PAN"))
            {
                if (Llatext.Inventory.InventoryHandling.HasItem("seeds"))
                {
                    InevitableGUI.Output("You want an omlette, not popcorn");
                }
                else
                {
                    InevitableGUI.Output("You might want to have them in your inventory first");
                }
            }
            else if (items.Contains("FIRE") && items.Contains("EGG"))
            {
                if (hasFire)
                {
                    InevitableGUI.Output("Why not use a pan instead?");
                }
                else
                {
                    InevitableGUI.Output("There's no fire unfortunatly");
                }
            }
            else if (items.Contains("FIRE") && items.Contains("BLINDFOLD"))
            {
                if (!Llatext.Inventory.InventoryHandling.HasItem("blindfold"))
                {
                    InevitableGUI.Output("You don't have that in your inventory");
                }
                else if (!hasFire)
                {
                    InevitableGUI.Output("You don't have a fire going");
                }
                else
                {
                    InevitableGUI.Output("You set the silk on fire. It burns very quickly. You also catch fire and burn to death. You are now a charred corpse. Good going");
                    return new Llatext.Instructions.Instruction(Llatext.Instructions.InstructionType.DEATH, "Felt too cold, and tried to warm up. Died Day 0");
                }
            }
            else if (items.Contains("BLINDFOLD") && items.Contains("PAN"))
            {
                InevitableGUI.Output("Cooking a blindfold? Really?");
            }
            else
            {
                InevitableGUI.Output("Those two won't work...");
            }

            return new Llatext.Instructions.Instruction();

        }
    }
}

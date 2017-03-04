using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Inevitable.Rooms.TownCenter
{
    public class TownCenterAfterWork:IRoom
    {
        bool beggerThere = true;

        public Llatext.Instructions.Instruction Look()
        {
            InevitableGUI.Output("You are standing in the middle of the town center. There is a beggar sitting in the corner.");
            InevitableGUI.Output("To the North is the Latex Factory. To the South is your House. To the East is El Cheapo Motel. To the West is the rest of the town");

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You walk to the middle of the town center after work. You are very tired. Next Mission: Sleep");

            return new Llatext.Instructions.Instruction();
        }

        public Instruction Examine(string parameter)
        {
            if (parameter.Equals("BEGGAR"))
            {
                if (beggerThere)
                {
                    InevitableGUI.Output("You see a person wearing a shabby coat. He looks up at you 'Spare some Change?'");
                }
                else
                {
                    InevitableGUI.Output("You can't see him there anymore");
                }
            }
            else
            {
                InevitableGUI.Output("You can't see that there");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Take(string parameter)
        {
            InevitableGUI.Output("You can't take that");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            InevitableGUI.Output("You can't open that");
            return new Instruction();
        }

        public Llatext.Instructions.Instruction Go(string parameter)
        {
            if (parameter.Equals("NORTH"))
            {
                InevitableGUI.Output("You've just come back from work. You want to sleep now");
            }
            else if (parameter.Equals("SOUTH"))
            {
                InevitableGUI.Output("You walk south towards your house");
                return new Instruction(InstructionType.LOAD,"d0houseruin");
            }
            else if (parameter.Equals("WEST"))
            {
                InevitableGUI.Output("You don't want to explore town right now. You're tired");
            }
            else if (parameter.Equals("EAST"))
            {
                InevitableGUI.Output("You walk towards the Motel");
                return new Instruction(InstructionType.LOAD,"d0motel");
            }
            else 
            {
                InevitableGUI.Output("You can only go North, South, West or East");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (parameter.Equals("BEGGAR"))
            {
                InevitableGUI.Output("You try to touch the beggar. He mutters 'As long as I get paid after this'");
            }
            else
            {
                InevitableGUI.Output("You can't use that");
            }

            return new Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            if (items.Contains("BEGGAR") && beggerThere)
            {
                if (items.Contains("BANKNOTE"))
                {
                    if (InventoryHandling.HasItem("banknote"))
                    {
                        InevitableGUI.Output("You hand the beggar the cash. He smiles at you and hands you a Get Out Of Death Free card. He then disappears in a puff of smoke");
                        InventoryHandling.AddGODFC();
                        InventoryHandling.RemoveItem("banknote");
                        beggerThere = false;
                    }
                    else
                    {
                        InevitableGUI.Output("You don't have that item");
                    }

                }
                else if (items.Contains("HAMMERDRIVER"))
                {
                    if (InventoryHandling.HasItem("hammerdriver"))
                    {
                        InevitableGUI.Output("You whack the beggar with your hammer driver. He runs away screaming");
                        InevitableGUI.Output("You chase him but eventually give up.");
                        beggerThere = false;
                    }
                    else
                    {
                        InevitableGUI.Output("You don't have that item");
                    }

                }
                else
                {
                    InevitableGUI.Output("You don't have that item");
                }

            }
            else
            {
                InevitableGUI.Output("You can't use those two together");
                
            }
            return new Instruction();
   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Llatext.Rooms;

namespace Inevitable.Rooms
{
    public class Bedroom: IRoom
    {
        bool hasBlindfold = true; 
        bool cabinetClosed = true;
        bool doorClosed = true;

        public Llatext.Instructions.Instruction Look()
        {
            if (hasBlindfold)
            {
                InevitableGUI.Output("The room seems pretty dark. Maybe you should remove the blindfold...");

            }
            else
            {
                if (doorClosed)
                {
                    InevitableGUI.Output("You are lying down on a bed in a bedroom. Next to the bed is a Cabinet. You are wearing a suit made of latex. The room is otherwise empty except for a closed door to the north");
                }
                else
                {
                    InevitableGUI.Output("The bedroom has a bed in it, with a cabinet nearbye");
                }
            }

            return new Llatext.Instructions.Instruction();
        
        }

        public Llatext.Instructions.Instruction Introduction()
        {
            InevitableGUI.Output("You enter the bedroom");
            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Examine(string parameter)
        {
            if (parameter.ToUpper() == "BLINDFOLD")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("The side you can see is really really black");

                }
            }
            else if (parameter.ToUpper() == "BED")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("What Bed?");
                }
                else
                {
                    InevitableGUI.Output("The bed lacks bedsheets but it has some very interesting stains on the mattress");
                }

            }
            else if (parameter.ToUpper() == "CLOTHES")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("What Clothes?");
                }
                else
                {
                    InevitableGUI.Output("You're wearing a suit made of latex. It squeeks when you walk");
                }
            }
            else if (parameter.ToUpper() == "CABINET")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("What Cabinet?");
                }
                else if (cabinetClosed)
                {
                    InevitableGUI.Output("The Cabinet is currently closed");
                }
                else if (!cabinetClosed)
                {
                    InevitableGUI.Output("There is a thick book in the drawer and nothing else");
                }

            
            }
            else if (parameter.ToUpper() == "BOOK")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("What book?");
                }
                else if (cabinetClosed)
                {
                    InevitableGUI.Output("You can't see any books");
                }
                else
                {
                    InevitableGUI.Output("The book's cover suggests its some sort of Romance Novel between \"vampires\" and humans. Yeah you're not reading it");
                }

            }
            else if (parameter.ToUpper() == "DOOR")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("What door?");
                }
                else
                {
                    InevitableGUI.Output("The door is closed but does not appear to be locked. It is a normal wooden door");
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
            if (hasBlindfold && parameter.ToUpper() != "BLINDFOLD")
            {
                //you can't take anything
                InevitableGUI.Output("You can't see it to take it");
                return new Llatext.Instructions.Instruction();
            }
            
            if (parameter.ToUpper() == "BOOK")
            {
                if (cabinetClosed)
                {
                    InevitableGUI.Output("What book?");
                }
                else
                {
                    InevitableGUI.Output("Seriously why would you want this drivel? Leave it there");
                }
            }
            else if (parameter.ToUpper() == "BED")
            {
                InevitableGUI.Output("You can't carry a bed. Don't be silly");
            }
            else if (parameter.ToUpper() == "CABINET")
            {
                InevitableGUI.Output("Its too heavy to stay hauling around");
            }
            else if (parameter.ToUpper() == "BLINDFOLD")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("You take the blindfold off your eyes and you can see again. You add it to your inventory");
                    Llatext.Inventory.InventoryHandling.AddItem(new Llatext.Inventory.InventoryItem("blindfold", "A piece of flameable cloth used to cover someone else's eyes"));
                    hasBlindfold = false;
                }
                else
                {
                    InevitableGUI.Output("Its already in your inventory");
                }
            }
            else if (parameter.ToUpper() == "DOOR")
            {
                InevitableGUI.Output("Iva Gahan...");
            }
            else
            {
                InevitableGUI.Output("You can't take that");
            }

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Open(string parameter)
        {
            if (hasBlindfold)
            {
                InevitableGUI.Output("You feel around for whatever it is you're trying to open, but fail. Seriously take off your blindfold");
                return new Llatext.Instructions.Instruction();
            }

            if (parameter.ToUpper() == "CABINET")
            {
                if (cabinetClosed)
                {
                    InevitableGUI.Output("You slide the cabinet open");
                    cabinetClosed = false;
                }
                else
                {
                    InevitableGUI.Output("The cabinet is already open");
                }
            }
            else if (parameter.ToUpper() == "DOOR")
            {
                if (doorClosed)
                {
                    InevitableGUI.Output("You open the door. You can now go North");
                    doorClosed = false;
                }
                else
                {
                    InevitableGUI.Output("The door is already open");
                }

            }
            else if (parameter.ToUpper() == "BOOK")
            {
                if (cabinetClosed)
                {
                    InevitableGUI.Output("What Book?");
                }
                else
                {
                    InevitableGUI.Output("You open the book and start reading. You feel your intelligence dropping, so you stop");
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
            if (parameter.ToUpper() == "SOUTH" || parameter.ToUpper() == "WEST" || parameter.ToUpper() == "EAST")
            {
                InevitableGUI.Output("You walk into a wall. Ouch");
            }
            else if (parameter.ToUpper() == "NORTH")
            {
                if (doorClosed)
                {
                    InevitableGUI.Output("You try to walk north but there's a door in the way");
                }
                else
                {
                    Llatext.Instructions.Instruction inst = new Llatext.Instructions.Instruction();
                    //load the kitchen
                    inst.inst = Llatext.Instructions.InstructionType.LOAD;
                    inst.detail = "kitchen";

                    return inst;
                }
            }
            else
            {
                InevitableGUI.Output("You can only walk North, South, West or East");
            }


            return new Llatext.Instructions.Instruction();
        }



        public Llatext.Instructions.Instruction Use(string parameter)
        {
            if (hasBlindfold)
            {
                InevitableGUI.Output("You can't see it to use it");
            }

            //lets see if its in the room
            if (parameter.ToUpper() == "BED")
            {
                InevitableGUI.Output("You got your 8 hours of sleep already. Get on with it");
            }
            else if (parameter.ToUpper() == "CABINET")
            {
                 //open it
                 this.Open(parameter);
            }
            else if (parameter.ToUpper() == "BOOK")
            {
                if (!cabinetClosed)
                {
                    InevitableGUI.Output("The only possible use for this book is lining the trash. You can't see a trashcan nearby");
                }
                else
                {
                    InevitableGUI.Output("What book?");
                }
            }
            else if (parameter.ToUpper() == "DOOR")
            {
                //open it
                Open("door");
            }
            else if (parameter.ToUpper() == "BLINDFOLD")
            {
                if (hasBlindfold)
                {
                    InevitableGUI.Output("You've already taken it off once..");
                }
                else
                {
                    InevitableGUI.Output("What blindfold?");
                }
            }

            //see if the inventory has something 

            return new Llatext.Instructions.Instruction();
        }

        public Llatext.Instructions.Instruction Use(string[] items)
        {
            //We don't have anything in this room which can be used together
            
            //maybe the inventory does

            InevitableGUI.Output("That combination won't work I'm afraid");

            //Form1.Output(Inventory.InventoryHandling.UseItem(item1,item2));

            return new Llatext.Instructions.Instruction();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Llatext.Inventory
{
    public static class InventoryHandling
    {
        private static List<InventoryItem> inventoryContents = new List<InventoryItem>();
        /// <summary>
        /// Determines the amount of "Get Out of Death Free cards held"
        /// </summary>
        private static int goodfc = 0;

        /// <summary>
        /// Attempts to use up a Get out of Death Free Card in return for life.
        /// If there are none avaliable, returns false
        /// </summary>
        /// <returns></returns>
        public static bool ConsumeGOODFC()
        {
            if (goodfc != 0)
            {
                goodfc--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Goodfc
        {
            get {return goodfc;}
            set { goodfc = value; }
        }

        /// <summary>
        /// Adds a GODFC to the list
        /// </summary>
        /// <returns></returns>
        public static void AddGODFC()
        {
            goodfc++;
        }

        /// <summary>
        /// Returns true if the user has a particular item in the Inventory
        /// </summary>
        /// <returns></returns>
        public static bool HasItem(string item)
        {

            return inventoryContents.Any(i => i.Equals(item));
/*
            foreach (InventoryItem inventoryItem in inventoryContents)
            {
                if (item.ToUpper().Equals(inventoryItem.ToUpper()))
                {
                    return true;
                }

                
            }
            return false; */
        }
        /// <summary>
        /// Returns true if the user has a particular item in the Invetory
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool HasItem(InventoryItem item)
        {
            return inventoryContents.Any(i => i.Equals(item));
        }
        /// <summary>
        /// Returns the amount of items in inventory
        /// </summary>
        /// <returns></returns>
        public static int InventoryCount()
        {
            return inventoryContents.Count();
        }
        /// <summary>
        /// Removes an item from the inventory
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public static void RemoveItem(string item)
        {
            inventoryContents.RemoveAll(i => i.Equals(item));


            /*
            for (int i = 0; i < inventoryContents.Count; i++)
            {
                string invItem = inventoryContents[i];

                if (invItem.ToUpper().Equals(item.ToUpper()))
                {
                    inventoryContents.RemoveAt(i);
                    return;
                }

            }*/

        }
        /// <summary>
        /// Deletes the entire contents of the inventory
        /// </summary>
        public static void RemoveAll()
        {
            inventoryContents.Clear();
        }

        /// <summary>
        /// Returns a string which represents the contents of the inventory
        /// </summary>
        /// <returns></returns>
        public static string ListInventory()
        {
            string returnString = "";

            foreach (InventoryItem inv in inventoryContents)
            {
                returnString += inv.itemName + ", ";
            }

            if (inventoryContents.Count == 0)
            {
                returnString = " Nothing ";
            }

            return returnString.Trim().Trim(',') + "\nYou have " + goodfc + " Get Out Of Death Free cards"; //remove trailing comma
        }
        /// <summary>
        /// Adds an item to the inventory if its not there already
        /// </summary>
        /// <param name="s"></param>
        public static void AddItem(InventoryItem item)
        {
            if (HasItem(item))
            {
                return;
            }
            else
            {
                inventoryContents.Add(item);
            }

        }

        /// <summary>
        /// Describes the item in question, or returns an empty string if the user does not have the item
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DescribeItem(string s)
        {
            if (!HasItem(s))
            {
                return "";
            }
            else
            {
                InventoryItem returnItem = inventoryContents.Single(i => i.Equals(s));

                return returnItem.itemDescription;
            }
        }


        //Might have to redo this in the future using delegates or something

   /*     /// <summary>
        /// Triggered first when a user wants to use an item which belongs in his inventory
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string UseItem(string item)
        {
            if (!HasItem(item))
            {
                return "";
            }
            else if (item.ToUpper().Equals("BLINDFOLD"))
            {
                return "You're not going to put it on again. You've had enough of the dark anyway";
            }
            else if (item.ToUpper().Equals("SEEDS"))
            {
                return "They're too small to eat. You want an omlette";
            }

            return "" ;
        } */

/*
        /// <summary>
        /// Triggered LAST when a user wants to use two items which BOTH belong in his inventory
        /// If you want to handle an item in inventory with an item which isn't - then check !HasItem and then write the code in the Room
        /// This is intended to be triggered when the Room Check has failed
        /// </summary>
        /// <param name="item"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        public static string UseItem(string item, string item2)
        {
            //todo - put in stuff which works

            return "This'll never work";

        }
 * */

    }
}

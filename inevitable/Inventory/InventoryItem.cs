using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Llatext.Inventory
{
    public class InventoryItem
    {
        /// <summary>
        /// The name of the item, and the key that will be used to identify it
        /// </summary>
        public string itemName;
        /// <summary>
        /// What the user should see when you examine the item
        /// </summary>
        public string itemDescription;

        public override string ToString()
        {
            return itemName + " - " + itemDescription;
        }

        public InventoryItem(string itemName)
        {
            this.itemName = itemName;
            this.itemDescription = "Unknown Description";
        }

        public InventoryItem(string itemName, string itemDescription)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
        }
        /// <summary>
        /// Compares an inventory item with a string, or with another inventoryItem
        /// </summary>
        /// <param name="obj">A string or an inventory item. Otherwise will return false</param>
        /// <returns>True if the string or the inventoryItem have the same name, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                string objectString = (string)obj;

                if (objectString.ToUpper().Equals(this.itemName.ToUpper()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (obj.GetType() == typeof(InventoryItem))
            {
                InventoryItem objItem = (InventoryItem)obj;

                if (objItem.itemName.ToUpper().Equals(this.itemName.ToUpper()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

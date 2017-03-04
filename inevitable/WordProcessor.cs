using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Inevitable;
using Inevitable.Rooms;
using Inevitable.Rooms.Day0.House;
using Inevitable.Rooms.Day0.Motel;
using Inevitable.Rooms.Day1.Motel;
using Inevitable.Rooms.Day1.Supermarket;
using Inevitable.Rooms.Day1.Town;
using Inevitable.Rooms.TownCenter;
using Llatext.Instructions;
using Llatext.Inventory;
using Llatext.Rooms;

namespace Llatext
{

    public static class WordProcessor
    {
        private static Dictionary<string,IRoom> rooms = new Dictionary<string,IRoom>();
        private static IRoom currentRoom;
        private static bool hasStarted = false;
        private static bool hasWon = false;
        private static string fileName;
        private static DateTime startTime;

        /// <summary>
        /// Put in the rooms we're interested in and pick out the first room
        /// </summary>
        public static void Init()
        {
            rooms.Add("bedroom", new Bedroom());
            rooms.Add("kitchen", new Kitchen());
            rooms.Add("garden", new Garden());
            rooms.Add("otherside",new TheOtherSide());
            rooms.Add("towncenterbeforework", new TownCenterBeforeWork());
            rooms.Add("factoryentrance", new Inevitable.Rooms.Factory.FactoryEntrance());
            rooms.Add("factoryfloor", new Inevitable.Rooms.Factory.FactoryFloor());
            rooms.Add("janitorcloset", new Inevitable.Rooms.Factory.JanitorCloset());
            rooms.Add("factoryoffice",new Inevitable.Rooms.Factory.FactoryOffice());
            rooms.Add("towncenterafterwork", new TownCenterAfterWork());
            rooms.Add("d0houseruin", new HouseRuin());
            rooms.Add("d0motel", new Motel());
            
            rooms.Add("day1", new MotelRoom());
            rooms.Add("d1motellobby1", new MotelLobby1());
            rooms.Add("d1towncenter1",new TownCenter1());
            rooms.Add("d1supermarketcash1", new SupermarketCash1()); 

            currentRoom = rooms["bedroom"];

            fileName = "Adventure of " + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            WriteToFile("Adventure Started!");

        }
        /// <summary>
        /// Writes to a file
        /// </summary>
        /// <param name="s"></param>
        public static void WriteToFile(string s)
        {
            try
            {
                TextWriter writer = new StreamWriter(fileName, true);
                writer.WriteLine(s);
                writer.Flush();
                writer.Close();
            }
            catch
            {
                //if it fails nothing we can do
            }
        }

        public static void ProcessTerm(string term)
        {
            Instruction returnInstruction = new Instruction(InstructionType.UNKNOWN, "");

            term = term.ToUpper();

            if (term.Contains("QUIT") || (term.Contains("EXIT")))
            {
                InevitableGUI.Output("Bye");
                System.Environment.Exit(0);
            }

            if (hasWon)
            {
                List<string> replies = new List<string>();

                replies.Add("You won already");
                replies.Add("You've already won.. what else do you want?");
                replies.Add("We've got a winner here");
                replies.Add("Yeah you won. You can stop now");
                replies.Add("A winnar is you!");
                replies.Add("Why are you still playing? You're a winner. Do something else");

                InevitableGUI.Output(PickReplyFromList(replies));
                return;
            }

            if (!(term.Contains("START")) && (!hasStarted))
            {
                InevitableGUI.Output("\"Start Easy\" or \"Start Hard\" to start");
                return;
            }
            #region 0 parameters

            if (term.Contains("ABOUT"))
            {
                InevitableGUI.Output("Inevitable, and the LLatext Engine was written by Llama");
                InevitableGUI.Output("Dedicated to the Missus - who hates these sorts of games");
                InevitableGUI.Output("Feel free to redistribute, break, rewrite and not sell");
                InevitableGUI.Output("Please credit accordingly if you do");

                return;
            }

            if (term.Contains("LOOK"))
            {
               returnInstruction = currentRoom.Look();

            }
            else if (term.Contains("INVENTORY"))
            {
                string inventoryOutput = InventoryHandling.ListInventory();

                //split its linebreaks

                var inventorySplit = inventoryOutput.Split('\n');

                InevitableGUI.Output("Your inventory contains : " + inventorySplit[0]);

                for (int i=1; i < inventorySplit.Count(); i++)
                {
                    InevitableGUI.Output(inventorySplit[i]);
                }
            }
            else if (term.Contains("HELP"))
            {
                InevitableGUI.Output("Help:");
                InevitableGUI.Output("Start - Starts the Game");
                InevitableGUI.Output("Quit - Quits the game");
                InevitableGUI.Output("Look - Looks around the room");
                InevitableGUI.Output("Inventory - Shows your inventory");
                InevitableGUI.Output("Help - Helps you.");
                InevitableGUI.Output("Remove X - Removes X");
                InevitableGUI.Output("Examine X - Examines a particular X in the room or your inventory");
                InevitableGUI.Output("Take X - Adds X to your inventory");
                InevitableGUI.Output("Open X - Opens X");
                InevitableGUI.Output("Go X - Go to a cardinal direction North/South/East/West");
                InevitableGUI.Output("Use X - Uses an item belonging in the room or in the inventory");
                InevitableGUI.Output("Use X with Y - Uses two items together");
                InevitableGUI.Output("About - Displays some about information");
                InevitableGUI.Output("Load X - Loads a savegame with filename x.isg");
                InevitableGUI.Output("End Help");

            }

            #endregion

            #region 1 parameters
                else
                    if (term.Contains("EXAMINE"))
                    {
                        //we want the next word after it

                        string nextWord = GetNextWord("EXAMINE",term);

                        if (nextWord == null)
                        {
                            InevitableGUI.Output("Error in Command - Examine what?");
                        }
                        else
                        {
                            //check if its in the inventory
                            string invDesc = Inventory.InventoryHandling.DescribeItem(nextWord);

                            if (invDesc != "")
                            {
                                InevitableGUI.Output(invDesc);
                            }
                            else
                            {
                                //Check if its in the room
                                returnInstruction = currentRoom.Examine(nextWord);
                            }
                        }
                        
                    }
            else if (term.Contains("START"))
            {
                string nextWord ;

                if ((nextWord = GetNextWord("START", term)) == null || !((nextWord.Contains("EASY") || (nextWord.Contains("HARD")))))
                {
                    InevitableGUI.Output("Start Easy or Hard?");
                }
                else
                {
                    if (nextWord.Contains("EASY"))
                    {
                        InventoryHandling.AddGODFC();

                    }
                    else if (nextWord.Contains("HARD"))
                    {
                        //no GODFC
                    }
                    else
                    {

                    }


                    if (!hasStarted)
                    {
                        hasStarted = true;
                        InevitableGUI.Output("This is a game about death.");
                        InevitableGUI.Output("Regardless of what you do, it is Inevitable");
                        InevitableGUI.Output("How long can you survive?");
                        InevitableGUI.Output("---Starting Game---");

                        InevitableGUI.Output("You open your eyes and see only darkness. You are wearing a blindfold");
                        startTime = DateTime.Now;
                    }
                    else
                    {
                        InevitableGUI.Output("((The Game has started already. Focus!))");
                    }
                }
            }
                    else if (term.Contains("TAKE"))
                    {
                        //we want the next word after it

                        if (GetNextWord("TAKE", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Take what?");
                        }
                        else
                        {
                            returnInstruction = currentRoom.Take(GetNextWord("TAKE", term));
                        }
                    }
                    else if (term.Contains("OPEN"))
                    {
                        if (GetNextWord("OPEN", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Open what?");
                        }
                        else
                        {
                            returnInstruction = currentRoom.Open(GetNextWord("OPEN", term));
                        }

                    }
                    else if (term.Contains("GO"))
                    {
                        if (GetNextWord("GO", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Go where?");
                        }
                        else
                        {
                            returnInstruction = currentRoom.Go(GetNextWord("GO", term));
                        }

                    }
                    else if (term.Contains("USE") && !term.Contains("WITH"))
                    {
                        if (GetNextWord("USE", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Use what?");
                        }
                        else
                        {
                            returnInstruction = currentRoom.Use(GetNextWord("USE", term));    
                        }
                    }
                    else if (term.Contains("LOAD") && !(term.Contains("CHEATLOAD")))
                    {
                        if (GetNextWord("LOAD", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Which file do you want to load?");
                        }
                        else
                        {
                            returnInstruction = LoadSavedGame(GetNextWord("LOAD", term));
                        }

                    }

                    #region cheats
                    else if (term.Contains("CHEATLOAD")) //loads the map
                    {
                        returnInstruction = new Instruction(InstructionType.LOAD, GetNextWord("CHEATLOAD", term.ToLower()));
                    }
                    else if (term.Contains("CHEATADD")) //adds something to the inventory
                    {
                        Inventory.InventoryHandling.AddItem(new InventoryItem(GetNextWord("CHEATADD", term)));
                    }
                    else if (term.Contains("IDONTWANTTODIE")) //adds a GOODFC
                    {
                        InventoryHandling.AddGODFC();
                      }


                    #endregion

            #endregion

                    #region 2

                    else if (term.Contains("USE") && term.Contains("WITH"))
                    {
                        if (GetNextWord("USE", term) == null)
                        {
                            InevitableGUI.Output("Error in command. Use what?");

                        }
                        else
                        {
                            if (GetNextWord("WITH", term) == null)
                            {
                                InevitableGUI.Output("Error in command. What do you want to use it with?");
                            }
                            else
                            {
                                string[] items = new string[] { GetNextWord("USE", term), GetNextWord("WITH", term) };

                                returnInstruction = currentRoom.Use(items);

                            }
                        }

                    }


                    #endregion

                    else
                    {
                        List<string> bogusReplies = new List<string>();
                        bogusReplies.Add("Unknown Command");
                        bogusReplies.Add("Pardon?");
                        bogusReplies.Add("Come again?");
                        bogusReplies.Add("I don't know how to do that");
                        bogusReplies.Add("Command not understood");
                        bogusReplies.Add("Uh what?");
                        bogusReplies.Add("No idea what you want");
                        bogusReplies.Add("What do you want?");

                        InevitableGUI.Output(PickReplyFromList(bogusReplies));

                    }

            #region Instruction Handling

            if (returnInstruction == null)
            {
                return;
            }

            if (returnInstruction.inst == InstructionType.LOAD)
            {
                try
                {
                    currentRoom = rooms[returnInstruction.detail];
                   returnInstruction = currentRoom.Introduction(); //change return instruction
                }
                catch (Exception ex)
                {
                    InevitableGUI.Output("Something went wrong when loading the next room : " + ex.Message);
                }
            }
            if (returnInstruction.inst == InstructionType.WIN)
            {
                InevitableGUI.Output("------END OF ADVENTURE------");
                TimeSpan span = DateTime.Now - startTime;

                InevitableGUI.Output("It has taken you : " + span.TotalSeconds + " to finish this adventure!");

                hasWon = true;
            
            }
            if (returnInstruction.inst == InstructionType.DEATH)
            {
                try
                {
                    //Can he be saved?
                    if (InventoryHandling.ConsumeGOODFC())
                    {
                        InevitableGUI.Output("One of your Get Out Of Death Free cards disappears in a powerful light. You don't feel so dead anymore. Weird.");
                    }
                    else
                    {
                        //take it to the other place
                        currentRoom = rooms["otherside"];
                        currentRoom.Introduction();

                        //Rather dirty - but assign the cause of death
                        IEndRoom endRoom = (IEndRoom)currentRoom;
                        endRoom.SetCauseOfDeath(returnInstruction.detail);
                    }
                }
                catch (Exception ex)
                {
                    InevitableGUI.Output("Something went wrong when loading your death :( Sorry. Exception was : " + ex.Message + " Please tell me");
                }
            }
            if (returnInstruction.inst == InstructionType.SAVE)
            {
                //save the game
                InevitableGUI.Output("Your game has been saved. To be able to continue, use LOAD " + Save(Convert.ToInt32(returnInstruction.detail)));

            }

            #endregion
        }

        /// <summary>
        /// Will pick a reply from the list pseudo-randomly
        /// </summary>
        /// <param name="list">List of strings from which to pick</param>
        /// <returns></returns>
        public static string PickReplyFromList(List<string> list)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            int randomInt = random.Next(list.Count);

            return list[randomInt];
        }
        /// <summary>
        /// Returns the next word in the string after marker if it is possible to do so, or null if it isn't
        /// </summary>
        /// <param name="marker"></param>
        /// <returns></returns>
        private static string GetNextWord(String marker, String phrase)
        {
            var splitTerm = phrase.Split(' ');

            for (int i = 0; i < splitTerm.Length; i++)
            {
                string s = splitTerm[i].ToUpper();

                if (s == marker.ToUpper() && i < splitTerm.Length - 1)
                {
                    return splitTerm[i + 1];
                }
            }

            return null;

        }
        /// <summary>
        /// Loads a game from a saved file
        /// </summary>
        /// <param name="name">The name of the file to load</param>
        private static Instruction LoadSavedGame(string name)
        {
            //Is the file really there
            try
            {
                FileStream stream = new FileStream(name + ".isg", FileMode.Open);

                BinaryReader reader = new BinaryReader(stream);

                //first one is the day, second is the gotdfc and third is the time

                int day = reader.ReadInt32();
                InventoryHandling.Goodfc = reader.ReadInt32();

                //Change the start time

                TimeSpan span = new TimeSpan(0, 0, reader.ReadInt32());

                startTime = DateTime.Now - span;
                InventoryHandling.RemoveAll(); //clear the inventory

                return new Instruction(InstructionType.LOAD, "day" + day);

            }
            catch
            {
                //File not there
                InevitableGUI.Output("The save game does not exist :( Sorry.");
                return new Instruction(InstructionType.UNKNOWN, "");
            }
            //We have to read 3 values



        }
        /// <summary>
        /// Saves the game in a file. THe filename will be a numerical value ending with .isg
        /// </summary>
        /// <param name="day">The day the player is at</param>
        /// <returns>The savegame filename</returns>
        private static string Save(int day)
        {
            //We have to save the game
            //We need to save the day we're in, the amount of GOTDFC and the time in seconds

            //Three integers

            //Lets see what we need to call the file

            int count = Directory.GetFiles(".", "*.isg").Length;

            using (FileStream stream = new FileStream(count.ToString() + ".isg", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(day);
                    writer.Write(InventoryHandling.Goodfc);

                    TimeSpan span = DateTime.Now - startTime;

                    writer.Write(span.TotalSeconds);

                    writer.Flush();
                    writer.Close();
                }
            }

            return count.ToString();


        }

    }
}

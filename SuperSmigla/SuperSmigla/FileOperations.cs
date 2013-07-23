using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSmigla;

namespace SuperSmigla
{
//----------------------------------------------------------------------------------------------------------------------------------------//
    public class Barbers
    {
        // Holds information for barber positions //

        public int x = -1;              // x position
        public int y = -1;              // y position
        public int step = -1;           // time when barber is at x,y
        public Barbers next = null;     // list pointing to another barber

    }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
    public class FileOperations
    {
        // Map Layout - Default 10x8 //
        public char[,] Map = new char[10, 8] { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                                               { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, };//{ ' ', ' ' } };


        // MapBuilder - Builds map from a file //
        public void MapBuilder(String Layout)
        {
            System.IO.StreamReader Reader = new System.IO.StreamReader(Layout); // File reader
            string buffer;                      // Input buffer                                 //
            string[] bufferSplit;               // Parsed input buffer, array without spaces    //
            const int INFORMATION_FIELD = 3;    // given each line has 3 pieces of information  //
            const int MAP_SIZE_FIELD = 3;       // Given map label & size has two number fields //
            const char START = 'S';             // Starting cell                                //
            const char GOAL = 'G';              // Ending cell                                  //
            const char WALL = 'W';              // Wall cell                                    //
            const char FLOOR = 'F';             // Floor cell                                   //
            int xDim = 0;                       // Size of the x-axis cells                     //
            int yDim = 0;                       // Size of the y-axis cells                     //
            int xPos = 0;                       // Grid position on x-axis                      //
            int yPos = 0;                       // Grid position on y-axis                      //
            char fieldType;                     // Identifies what kind of cell to place        //
            int index = 0;                      // indexing integer                             //

            // Read in the map size information //
            buffer = Reader.ReadLine();
            bufferSplit = buffer.Split(new Char[] { ' ' });
            index = bufferSplit.GetLength(0);
            if (index == MAP_SIZE_FIELD)
            {

                // Convert the x and y values, create a new map //
                xDim = Convert.ToInt32(bufferSplit[1]);
                yDim = Convert.ToInt32(bufferSplit[2]);
                Map = new char [xDim, yDim];
            }

            // Loop until the end of file, getting map layout //
            while (Reader.Peek() != -1)
            {
             //   Reader.ReadBlock(buf,0,1000);
                // Read line by line, parce the line when there's a space and put it in an array //
                buffer = Reader.ReadLine();
                bufferSplit = buffer.Split(new Char[] { ' ' });

                // Get the size of the array, place the field information in the map array //
                index = bufferSplit.GetLength(0);
                if (index == INFORMATION_FIELD)
                {
                    fieldType = Convert.ToChar(bufferSplit[0]);
                    xPos = Convert.ToInt32(bufferSplit[1]);
                    yPos = Convert.ToInt32(bufferSplit[2]);

                    if (xPos < Map.GetLength(0) && yPos < Map.GetLength(1))
                    {
                        // look at start, goal, and wall positions //
                        if (fieldType == START)
                        {
                            Map[xPos, yPos] = START;
                        }
                        else if (fieldType == GOAL)
                        {
                            Map[xPos, yPos] = GOAL;
                        }
                        else if (fieldType == WALL)
                        {
                            Map[xPos, yPos] = WALL;
                        }
                        else
                        {
                            Map[xPos, yPos] = FLOOR;
                        }
                    }
                }
            
            }
            // Close the file //
            Reader.Close();
        }




        public Barbers barberList; // Globally accessable list of barber information //

        // barberLoader - Loads barber information into a list from a file //
        public void barberLoader(string Layout)
        {
            System.IO.StreamReader Reader = new System.IO.StreamReader(Layout); // File reader
            Barbers current;                // Pointer to current barber //
            string buffer;                  // Input buffer              //
            string[] bufferSplit;           // Parsed array of strings   //
            barberList = new Barbers();     // Create a new barber list  //
            current = barberList;           // Set pointer to the head   //
            int index = 0;                  // Indexing integer          //

            // While the file is not empty, loop through it //
            while (Reader.Peek() != -1)
            {
                // Read line by line, parce the line when there's a space and put it in an array //
                buffer = Reader.ReadLine();
                bufferSplit = buffer.Split(new Char[] { ' ' });

                // Get the size of the array, place the information in a list //
                index = bufferSplit.GetLength(0);
                if (index > 1)
                {
                    current.y = Convert.ToInt32(bufferSplit[index - 1]);
                    index--;
                    current.x = Convert.ToInt32(bufferSplit[index - 1]);
                    index--;
                    current.step = Convert.ToInt32(bufferSplit[index - 1]);

                    current.next = new Barbers();
                    current = current.next;
                }
            }
            // Close the file //
            Reader.Close();
        }
    }
//----------------------------------------------------------------------------------------------------------------------------------------//
}

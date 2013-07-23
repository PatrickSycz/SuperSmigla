/***************************************************
 * Name:    Patrick Sycz    ************************
 * Date:    09/26/2012      ************************
 * Project: Astar           ************************
 * Description: Takes a map and barber file and ****
 * step by step guide super smigla to the goal  ****
 **************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace SuperSmigla
{
    public partial class superSmiglaForm : Form
    {
        FileOperations file = new FileOperations();             
        Int32 stepCounter = 0;                                  // time step counter        //
        char[,] map = new char[10,10];                          // Map grid, default 10x8   //
        const int OFFSET = 50;                                  // pixel offset             //
        int goalX = 0;                                          // goal x position          //
        int goalY = 0;                                          // goal y position          //
        int SmiglaX = 0;                                        // smigla x position        //
        int SmiglaY = 0;                                        // smigla y position        //
        int fromX = 0;
        int fromY = 0;
        bool startFlag = false;                                     // start flag               //
        Bitmap smigla = new Bitmap("..\\..\\..\\Smigla.jpg");   // Super Smigla image       //
        Bitmap wall = new Bitmap("..\\..\\..\\Wall.jpg");       // Wall image               //
        Bitmap floor = new Bitmap("..\\..\\..\\Floor.jpg");     // Floor tile image         //
        Bitmap path = new Bitmap("..\\..\\..\\Path.jpg");       // Path tile image          //
        Bitmap barber = new Bitmap("..\\..\\..\\Barber.jpg");   // Barber image             //
        Bitmap kiss = new Bitmap("..\\..\\..\\Kiss.jpg");       // Kiss concert image       //
        Barbers current;                                        // barberList index         //
        AstarHelpers.list OpenList = new AstarHelpers.list();
        AstarHelpers.list ClosedList = new AstarHelpers.list();
        AstarHelpers.node Start = new AstarHelpers.node();
        
       
        
//----------------------------------------------------------------------------------------------------------------------------------------//
        public superSmiglaForm()
        {
            InitializeComponent();
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        private void Form1_Load(object sender, EventArgs e)
        {

        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        // When step button is clicked //
        private void stepsButton_Click(object sender, EventArgs e)
        {
            // Increase the step timer, display it, refresh the map //
            stepCounter++;
            stepsCounterText.Text = Convert.ToString(stepCounter);
            pictureBox1.Refresh();
            // display message if goal is reached, reset all values //
            if (SmiglaX == goalX && SmiglaY == goalY)
            {
                MessageBox.Show("GOAL REACHED IN " + Convert.ToString(stepCounter) + " STEPS!");
                startFlag = false;
                stepCounter = 0;
                stepsCounterText.Text = Convert.ToString(stepCounter);
                pictureBox1.Refresh();
            }
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        //when the start button is clicked
        private void StartButton_Click(object sender, EventArgs e)
        {
            // set the start flag //
            startFlag = true;

            // find the starting positions for super smigla and the goal //
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'S')
                    {
                        SmiglaX = i;
                        SmiglaY = j;
                    }
                    else if (map[i, j] == 'G')
                    {
                        goalX = i;
                        goalY = j;
                    }
                }
            }

            // set the path finding x and y, reset the step counter //
            fromX = SmiglaX;
            fromY = SmiglaY;
            stepCounter = 0;
            stepsCounterText.Text = Convert.ToString(stepCounter);
            pictureBox1.Refresh();
        }
//----------------------------------------------------------------------------------------------------------------------------------------//



//----------------------------------------------------------------------------------------------------------------------------------------//
        // When barber's load button is clicked
        private void loadBarbersMenu_Click(object sender, EventArgs e)
        {
            // Open a file dialog, with restrictions //
            OpenFileDialog barberFile = new OpenFileDialog();
            barberFile.InitialDirectory = ".\\";
            barberFile.Filter = "Text Files (*.txt)|*.txt";

            // Prompt user for a file, load file or display error //
            if (barberFile.ShowDialog() == DialogResult.OK)
            {
                file.barberLoader(barberFile.FileName);
            }
            else
            {
                MessageBox.Show("No barber file was selected");
            }

            // reset the step counter, display it, refresh the map
            stepCounter = 0;
            stepsCounterText.Text = Convert.ToString(stepCounter);
            //pictureBox1.Refresh();

        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        // when load map is clicked
        private void loadMapMenu_Click(object sender, EventArgs e)
        {
            // open a file dialog with restrictions //
            OpenFileDialog mapFile = new OpenFileDialog();
            mapFile.InitialDirectory = ".\\";
            mapFile.Filter = "Text Files (*.txt)|*.txt";

            // prompt user to select a file, load file or display error //
            if (mapFile.ShowDialog() == DialogResult.OK)
            {
                file.MapBuilder(mapFile.FileName);
            }
            else
            {
                MessageBox.Show("No map file was selected");
            }
            map = file.Map;
            // reset step counter, display it, refresh the map //
            stepCounter = 0;
            stepsCounterText.Text = Convert.ToString(stepCounter);
            //pictureBox1.Refresh();
        }
//----------------------------------------------------------------------------------------------------------------------------------------//



//----------------------------------------------------------------------------------------------------------------------------------------//
        // When the mouse is pressed on the button //
        private void stepsButton_MouseDown(object sender, MouseEventArgs e)
        {
            // Change the color of the button to indicate a press has been made //
            stepsButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            stepsButton.ForeColor = System.Drawing.Color.Black;
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        // When the mouse is removed from the button //
        private void stepsButton_MouseUp(object sender, MouseEventArgs e)
        {
            // change the color of the button to indicate the button is no longer pressed //
            stepsButton.BackColor = System.Drawing.SystemColors.Control;
            stepsButton.ForeColor = System.Drawing.Color.Black;
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        AstarHelpers.node bestPath; // Stores the best path to the goal //

        // Search finds the best path //
        void search()
        {

            AstarHelpers.node current;      // node for current position //
            AstarHelpers.node temp;         // node to temporarily store //
            OpenList.clearList();           // open list                 //
            ClosedList.clearList();         // closed list               //


            Start.x = fromX;                // Starting x position       //
            Start.y = fromY;                // Starting y position       //
            Start.calculateH(goalX, goalY); // calculate the start h     //
            Start.calculateG(null);         // calculate the start g     //
            Start.calculateF();             // calculate the start f     //
            OpenList.addItem(Start);        // add it to the open list   //

            // loop until the open list is empty //
            while (OpenList.isEmpty() == 0)
            {
                // get the best node, add to the closed list, delete it from the open list //
                current = OpenList.findBest();
                ClosedList.addItem(current);
                OpenList.deleteItem(current);

                // check to see if the goal was reached //
                if (current.x == goalX && current.y == goalY)
                {
                    //MessageBox.Show("GOAL");
                    bestPath = current;
                    return;
                }
                else
                {
                    // find the successors //
                    for (int i = 3; i >= 0; i--)
                    {
                        temp = current.findSuccessor(current, map, i);
                        if (temp != null)
                        {
                            temp.calculateH(goalX, goalY);
                            temp.calculateG(temp.parent);
                            temp.calculateF();
                            
                            if (!ClosedList.isIn(temp))
                            {
                                OpenList.addItem(temp);
                            }
                        }

                    }

                }
                
            }

            // display there's no path to be found //
            MessageBox.Show("NO PATH FOUND");
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        // moves smigla //
        public void moveSmigla()
        {
            AstarHelpers.node current = bestPath;
            if (current != null)
            {
                if (current.parent != null)
                {
                    while (current.parent.parent != null)
                    {
                        current = current.parent;
                    }
                    fromX = current.x;
                    fromY = current.y;
                    SmiglaX = current.parent.x;
                    SmiglaY = current.parent.y;
                    current.parent = null;
                    //SmiglaX = current.x;
                    //SmiglaY = current.y;
                }
                else
                {
                    SmiglaX = current.x;
                    SmiglaY = current.y;
                }
            }
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


//----------------------------------------------------------------------------------------------------------------------------------------//
        AstarHelpers.node currentNode; // node designated for traversal //
        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // only start if the start flag has been thrown //
            if (startFlag)
            {
                // Traverse through the barber setting their map positions //
                current = file.barberList;
                while (current != null)
                {
                    if (current.step == stepCounter)
                    {
                        file.Map[current.x, current.y] = 'B';
                        current = current.next;
                    }
                    else
                    {
                        current = current.next;
                    }
                }

                // run the astar search //
                search();


                // run through the map displaying the types //
                for (int i = 0; i < file.Map.GetLength(0); i++)
                {
                    for (int j = 0; j < file.Map.GetLength(1); j++)
                    {
                        // display wall//
                        if (file.Map[i, j] == 'W')
                        {
                            g.DrawImage(wall, i * OFFSET, j * OFFSET);
                        }
                        //display barber//
                        else if (file.Map[i, j] == 'B')
                        {
                            g.DrawImage(barber, i * OFFSET, j * OFFSET);
                            file.Map[i, j] = ' ';
                        }
                        //display floor//
                        else
                        {
                            g.DrawImage(floor, i * 50, j * 50);
                        }

                    }

                }
                //move smigla's position//
                moveSmigla();

                //draw the best path//
                currentNode = bestPath;
                while (currentNode != null)
                {
                    g.DrawImage(path, currentNode.x * OFFSET, currentNode.y * OFFSET);
                    currentNode = currentNode.parent;
                }

                //draw smigla and the goal//
                g.DrawImage(smigla, SmiglaX * OFFSET, SmiglaY * OFFSET);
                g.DrawImage(kiss, goalX * OFFSET, goalY * OFFSET);


            }            
        }
//----------------------------------------------------------------------------------------------------------------------------------------//


    }
}

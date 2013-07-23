using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSmigla
{
    public class AstarHelpers
    {
        const int MAX_LIST = 100;       // max size for the list     //
        const int MAX_Y = 20;           // max size for y coordinate //
        const int MAX_X = 20;           // max size for x coordinate //
        const double MIN_COST = 1.0;    // minimum cost constant     //
        const double ALPHA = 0.5;       // alpha value               //
        static int [,] successorList = new int [4,2] {{0,1}, {1,0}, {0,-1}, {-1,0}};    // list of successor values //
        // list for diagonals //static int[,] successorList = new int[8, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

        // node class //
        public class node
        {            
            public double g = 0.0;      // holds g value //
            public double h = 0.0;      // holds h value //
            public double f = 0.0;      // holds f value //
            public int x = 0;           // holds x position //
            public int y = 0;           // holds y position //
            public node parent = null;  // points to parent //


            // calculate the h value //
            public void calculateH(int goalX, int goalY)
            {
                this.h = MIN_COST * (double)(System.Math.Abs(this.x - goalX) + System.Math.Abs(this.y - goalY));
            }

            // calculate the g value //
            public void calculateG(node parent)
            {
                if (parent != null)
                {
                    this.g = MIN_COST + (parent.g);//(ALPHA * (parent.g - MIN_COST));
                }
            }

            // calculate the f value //
            public void calculateF()
            {
                this.f = this.h + this.g;
            }

            // finds successor node //
            public node findSuccessor(node current, char [,] map, int i)
            {

                node child = null;
                int newX = (current.x + successorList[i, 0]);
                int newY = (current.y + successorList[i, 1]);

                if (newX >= 0 && newY >= 0 && newX < 10 && newY < 8)
                {

                    if (map[newX, newY] != 'W' && map[newX, newY] != 'B')
                    {
                        child = new node();
                        child.parent = current;
                        child.x = current.x + successorList[i, 0];
                        child.y = current.y + successorList[i, 1];
                    }
                    else
                    {
                        return child;
                    }
                }
                return child;
            }
        }



        // list class //
        public class list
        {
            public int size = 0;                            // list size    //
            public node [] elements = new node[MAX_LIST];   // list of nodes //
            
            
            // test to see if the list is empty //
            public int isEmpty()
            {
                if (this.size == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            // finds the best node //
            public node findBest()
            {
                node current;
                int index = 0;
                int pos = 0;
                if (this.isEmpty() == 0)
                {
                    current = this.elements[index];
                    while (index < this.size)
                    {
                        if (current.f > this.elements[index].f)
                        {
                            current = this.elements[index];
                            pos = index;
                        }
                        index++;
                    }
                }
                else
                {
                    current = null;
                }
                return current;
            }

            // add item to list //
            public void addItem(node item)
            {
                if (item != null)
                {
                    bool inList = false;
                    for (int i = 0; i < this.size; i++)
                    {
                        if (item.x == this.elements[i].x && item.y == this.elements[i].y)
                        {
                            //System.Windows.Forms.MessageBox.Show("FOUND IN LIST");
                            inList = true;
                        }
                    }
                    if (!inList)
                    {
                        this.elements[size] = item;
                        this.size++;
                    }
                }
            }

            // delete item from list //
            public void deleteItem(node item)
            {
                int i = 0;
                bool found = false;
                while (!found && (i < this.size))
                {
                    if (item == this.elements[i])
                    {
                        found = true;
                    }
                    i++;
                }
                i--;
                if (found)
                {
                    while (i < this.size)
                    {
                        this.elements[i] = null;
                        this.elements[i] = this.elements[i + 1];
                        i++;
                    }
                    //System.Windows.Forms.MessageBox.Show("deleted in the list");
                    this.elements[i] = null;
                    this.size--;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Nothing to be deleted");
                }
            }

            // clears the list //
            public void clearList()
            {
                for (int i = 0; i < this.size; i++)
                {
                    this.elements[i] = null;
                }
                this.size = 0;
            }

            // tests if item is in the list //
            public bool isIn(node item)
            {
                bool found = false;
                for (int i = 0; i < this.size; i++ )
                {
                    if (item.x == this.elements[i].x && item.y == this.elements[i].y)
                    {
                        found = true;
                    }
                }
                return found;
            }
           
        }

        
    }
}

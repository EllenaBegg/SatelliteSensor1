using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Galileo;

/*
 * Student:     Ellena Begg, 30040389
 * Date:        July, August 2022
 * Version:     1.0 Initial before testing
 * Description: Use Galileo dll to create data set of two Sensors. 
 *              Display, search and sort the data in a Windows Form application.
 */

namespace SatelliteSensor1
{
    public partial class SatelliteSensorForm : Form
    {
        public SatelliteSensorForm()
        {
            InitializeComponent();
        }

        // 4.1 declare two global variables which represent the LinkedLists for Sensor A and Sensor B
        private LinkedList<double> sensorALinkedList = new LinkedList<double>();
        private LinkedList<double> sensorBLinkedList = new LinkedList<double>();

        #region Global Methods

        //4.2 Create a method called “LoadData” which will populate both LinkedLists.
        private void LoadData()
        {
            ReadData readData = new ReadData(); // Declare an instance of the Galileo library 
            int maxDataSize = 400;     // The LinkedList size will be hardcoded inside the method and must be equal to 400.
            sensorALinkedList.Clear();
            sensorBLinkedList.Clear();

            for (int x = 0; x < maxDataSize; x++)
            {
                sensorALinkedList.AddLast(readData.SensorA(((double)numericUpDownMu.Value), (double)numericUpDownSigma.Value));
                sensorBLinkedList.AddLast(readData.SensorB(((double)numericUpDownMu.Value), (double)numericUpDownSigma.Value));
            }
        }

        //4.3 Create a custom method called “ShowAllSensorData” which will display both LinkedLists in a ListView
        private void ShowAllSensorData()
        {
            listViewSensorData.Items.Clear();

            for (int i = 0; i < sensorALinkedList.Count; i++)
            {
                string[] lvRow = { sensorALinkedList.ElementAt(i).ToString(), sensorBLinkedList.ElementAt(i).ToString() };
                listViewSensorData.Items.Add(new ListViewItem(lvRow));
            }
        }


        #endregion

        #region Utility Methods
        // 4.5 Create a method called "NumberOfNodes" to return integer of number of nodes in a LinkedList
        private int NumberOfNodes(LinkedList<double> linkedList)
        {
            return linkedList.Count;
        }

        // 4.6 Create a method called "DisplayListboxData" to display content of a LinkedList in appropriate ListBox
        private void DisplayListboxData(LinkedList<double> linkedList, ListBox listBoxName)
        {
            listBoxName.Items.Clear(); 
            foreach (double sensorData in linkedList)
            {
                listBoxName.Items.Add(sensorData.ToString());
            }
        }

        private void HighlightItemInListBox(ListBox listBox, int index)
        {
            listBox.ClearSelected();

            if (index <= 2) // Check if at beginning of list
            {
                for (int x = 0; x <= 2; x++)
                {
                    listBox.SetSelected(x, true); // highlight first 3 items, if at beginning of list
                }

            }
            else if (index >= listBox.Items.Count - 3) // Check if at end of list
            {
                for (int x = listBox.Items.Count - 3; x <= listBox.Items.Count - 1; x++)
                {
                    listBox.SetSelected(x, true); // highlight last 3 items, if at end of list
                }
            }
            else
            {
                for (int x = index - 2; x <= index + 2; x++)
                {
                    listBox.SetSelected(x, true); // highlight item, and the 2 before and after it
                }
            }
        } // end HighlightItemInListBox()

        private bool IsValidSearchValue(LinkedList<double> linkedList, double searchValue)
        {
            // Check search value is between actual values of LinkedList data
            double minimumValue = linkedList.First.Value;
            double maximumValue = linkedList.Last.Value;

            if ((searchValue >= minimumValue) && (searchValue <= maximumValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Sort and Search Methods
        // 4.7 Create a method called “SelectionSort” 
        private bool SelectionSort(LinkedList<double> linkedList)
        {
            int minimum = 0;
            int maximum = NumberOfNodes(linkedList);
            for (int i = 0; i < maximum; i++)
            {
                minimum = i;
                for (int j = i + 1; j < maximum; j++)
                {
                    // Is element value at 'j' smaller than the element value at 'current minimum'?
                    if(linkedList.ElementAt(j) < linkedList.ElementAt(minimum))
                    {
                        minimum = j; 
                    }
                }

                // Create Nodes to perform a swap of values
                LinkedListNode<double> currentMinimum = linkedList.Find(linkedList.ElementAt(minimum));
                LinkedListNode<double> currentI = linkedList.Find(linkedList.ElementAt(i));

                var temp = currentMinimum.Value;
                currentMinimum.Value = currentI.Value;
                currentI.Value = temp;
            }
            return true;
        }

        // 4.8 Create a method called “InsertionSort” 
        private bool InsertionSort(LinkedList<double> linkedList)
        {
            int maximum = NumberOfNodes(linkedList);
            for (int i = 0; i < (maximum - 1); i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (linkedList.ElementAt(j - 1) > linkedList.ElementAt(j))
                    {
                        // create Nodes to perform a swap of values
                        LinkedListNode<double> current = linkedList.Find(linkedList.ElementAt(j));
                        LinkedListNode<double> previous = linkedList.Find(linkedList.ElementAt(j - 1));

                        var temp = previous.Value;
                        previous.Value = current.Value;
                        current.Value = temp;
                    }
                }
            }
            return true;//TODO 
        }

        // 4.9 Create a method called “BinarySearchIterative” 
        // 'minimum' param = minimum list size
        // 'maximum' param = number of nodes in List
        // return value = found index
        private int BinarySearchIterative(LinkedList<double> linkedList, double searchValue, int minimum, int maximum)
        {
            while (minimum <= (maximum - 1))
            {
                int middle = (minimum + maximum) / 2;
                if (searchValue == linkedList.ElementAt(middle))
                {
                    return ++middle;
                }
                else if (searchValue < linkedList.ElementAt(middle))
                {
                    maximum = middle - 1;
                }
                else
                {
                    minimum = middle + 1;
                }
            }
            return minimum; 


            /*
             * 4.9	Create a method called “BinarySearchIterative” which has the following four parameters: 
             * LinkedList, SearchValue, Minimum and Maximum. 
             * This method will return an integer of the linkedlist element from a successful search 
             * or the nearest neighbour value. 
             * The calling code argument is the linkedlist name, search value, minimum list size 
             * and the number of nodes in the list. 
             * The method code must follow the pseudo code supplied below in the Appendix.
             * */
        }

        // 4.10 Create a method called “BinarySearchRecursive” 
        // 'minimum' param = minimum list size
        // 'maximum' param = number of nodes in List
        // return value = found index
        private int BinarySearchRecursive(LinkedList<double> linkedList, double searchValue, int minimum, int maximum)
        {
            if (minimum <= maximum -1)
            {
                int middle = (minimum + maximum) / 2;
                if (searchValue == linkedList.ElementAt(middle))
                {
                    return middle;
                }
                else if (searchValue < linkedList.ElementAt(middle))
                {
                    return BinarySearchRecursive(linkedList, searchValue, minimum, middle - 1);    
                }
                else
                {
                    return BinarySearchRecursive(linkedList, searchValue, middle + 1, maximum);
                }
            }
            return minimum;

            /*
             * 4.10	Create a method called “BinarySearchRecursive” which has the following four parameters: 
             * LinkedList, SearchValue, Minimum and Maximum. 
             * This method will return an integer of the linkedlist element from a successful search 
             * or the nearest neighbour value. 
             * The calling code argument is the linkedlist name, search value, minimum list size 
             * and the number of nodes in the list. 
             * The method code must follow the pseudo code supplied below in the Appendix.
             */
        }
        #endregion

        #region UI Button Methods
        // 4.4 Button method to call LoadData and ShowAllSensorData
        private void buttonLoadSensorData_Click(object sender, EventArgs e)
        {
            LoadData();
            ShowAllSensorData();
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using SelectionSort method
        private void buttonSelectionSortA_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SelectionSort(sensorALinkedList);
            stopWatch.Stop();
            textBoxSelectionSortTimeA.Text = stopWatch.ElapsedMilliseconds.ToString(); // display milliseconds it took to run the Sort
            ShowAllSensorData();
            DisplayListboxData(sensorALinkedList, listBoxSensorA);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using SelectionSort method
        private void buttonSelectionSortB_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SelectionSort(sensorBLinkedList);
            stopWatch.Stop();
            textBoxSelectionSortTimeB.Text = stopWatch.ElapsedMilliseconds.ToString(); // display milliseconds it took to run the Sort
            ShowAllSensorData();
            DisplayListboxData(sensorBLinkedList, listBoxSensorB);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using InsertionSort method
        private void buttonInsertionSortA_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            InsertionSort(sensorALinkedList);
            stopWatch.Stop();
            textBoxInsertionSortTimeA.Text = stopWatch.ElapsedMilliseconds.ToString(); // display milliseconds it took to run the Sort
            ShowAllSensorData();
            DisplayListboxData(sensorALinkedList, listBoxSensorA);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using InsertionSort method
        private void buttonInsertionSortB_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            InsertionSort(sensorBLinkedList);
            stopWatch.Stop();
            textBoxInsertionSortTimeB.Text = stopWatch.ElapsedMilliseconds.ToString(); // display milliseconds it took to run the Sort
            ShowAllSensorData();
            DisplayListboxData(sensorBLinkedList, listBoxSensorB);
        }

        // 4.11 Create Button click methods to search LinkedList<T> using Binary Search Iterative method
        private void buttonIterativeSearchA_Click(object sender, EventArgs e)
        {
            // Make sure we have data
            if (sensorALinkedList.Count > 0 && listBoxSensorA.Items.Count > 0)
            {
                // Make sure there is text in search box
                if (!string.IsNullOrEmpty(textBoxSearchTargetA.Text))
                {
                    // Ensure LinkedList is SORTED
                    if (SelectionSort(sensorALinkedList))
                    {
                        double searchValue = (Convert.ToDouble(textBoxSearchTargetA.Text));

                        // Check search value is between actual values of LinkedList data
                        if (IsValidSearchValue(sensorALinkedList, searchValue))
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            int foundValue = BinarySearchIterative(sensorALinkedList, searchValue, 0, sensorALinkedList.Count);
                            stopWatch.Stop();

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorA, foundValue);

                            // Display number of ticks to run this Search algorithm
                            textBoxIterativeSearchTimeA.Text = stopWatch.ElapsedTicks.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Number entered to search for is not in the Sensor A Data collected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sort the List from Sensor A first.");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value to search for.");
                }
            }
            else
            {
                MessageBox.Show("Load Sensor data, and choose a Sort option first.");
            }
        } // end buttonIterativeSearchA_Click()

        // 4.11 Create Button click methods to search LinkedList<T> using Binary Search Iterative method
        private void buttonIterativeSearchB_Click(object sender, EventArgs e)
        {
            // Make sure we have data
            if (sensorBLinkedList.Count > 0 && listBoxSensorB.Items.Count > 0)
            {
                // Make sure there is text in search box
                if (!string.IsNullOrEmpty(textBoxSearchTargetB.Text))
                {
                    // Ensure LinkedList is SORTED
                    if (SelectionSort(sensorBLinkedList))
                    {
                        double searchValue = (Convert.ToDouble(textBoxSearchTargetB.Text));

                        // Check search value is between actual values of LinkedList data
                        if (IsValidSearchValue(sensorBLinkedList, searchValue))
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            int foundValue = BinarySearchIterative(sensorBLinkedList, searchValue, 0, sensorBLinkedList.Count);
                            stopWatch.Stop();

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorB, foundValue);

                            // Display number of ticks to run this Search algorithm
                            textBoxIterativeSearchTimeB.Text = stopWatch.ElapsedTicks.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Number entered to search for is not in the Sensor B Data collected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sort the List from Sensor B first.");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value to search for.");
                }
            }
            else
            {
                MessageBox.Show("Load Sensor data, and choose a Sort option first.");
            }
        } // end buttonIterativeSearchB_Click()

        // 4.11 Create Button click methods to search LinkedList<T> using Binary Search Recursive method
        private void buttonRecursiveSearchA_Click(object sender, EventArgs e)
        {
            // Make sure we have data
            if (sensorALinkedList.Count > 0 && listBoxSensorA.Items.Count > 0)
            {
                // Make sure there is text in search box
                if (!string.IsNullOrEmpty(textBoxSearchTargetA.Text))
                {
                    // Ensure LinkedList is SORTED
                    if (SelectionSort(sensorALinkedList))
                    {
                        double searchValue = (Convert.ToDouble(textBoxSearchTargetA.Text));

                        // Check search value is between actual values of LinkedList data
                        if (IsValidSearchValue(sensorALinkedList, searchValue))
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            int foundValue = BinarySearchRecursive(sensorALinkedList, searchValue, 0, sensorALinkedList.Count);
                            stopWatch.Stop();

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorA, foundValue);

                            // Display number of ticks to run this Search algorithm
                            textBoxRecursiveSearchTimeA.Text = stopWatch.ElapsedTicks.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Number entered to search for is not in the Sensor A Data collected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sort the List from Sensor A first.");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value to search for.");
                }
            }
            else
            {
                MessageBox.Show("Load Sensor data, and choose a Sort option first.");
            }
        } // end buttonRecursiveSearchA_Click()

        // 4.11 Create Button click methods to search LinkedList<T> using Binary Search Recursive method
        private void buttonRecursiveSearchB_Click(object sender, EventArgs e)
        {
            // Make sure we have data
            if (sensorBLinkedList.Count > 0 && listBoxSensorB.Items.Count > 0)
            {
                // Make sure there is text in search box
                if (!string.IsNullOrEmpty(textBoxSearchTargetB.Text))
                {
                    // Ensure LinkedList is SORTED
                    if (SelectionSort(sensorBLinkedList))
                    {
                        double searchValue = (Convert.ToDouble(textBoxSearchTargetB.Text));

                        // Check search value is between actual values of LinkedList data
                        if (IsValidSearchValue(sensorBLinkedList, searchValue))
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            int foundValue = BinarySearchRecursive(sensorBLinkedList, searchValue, 0, sensorBLinkedList.Count);
                            stopWatch.Stop();

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorB, foundValue);

                            // Display number of ticks to run this Search algorithm
                            textBoxRecursiveSearchTimeB.Text = stopWatch.ElapsedTicks.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Number entered to search for is not in the Sensor B Data collected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sort the List from Sensor B first.");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value to search for.");
                }
            }
            else
            {
                MessageBox.Show("Load Sensor data, and choose a Sort option first.");
            }
        } // end buttonRecursiveSearchB_Click()

        // 4.14 Only numeric integer values can be entered
        private void textBoxSearchTargetA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)) return;
            if (char.IsControl(e.KeyChar)) return; //allowing backspace
            e.Handled = true;
        }

        // 4.14 Only numeric integer values can be entered
        private void textBoxSearchTargetB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)) return;
            if (char.IsControl(e.KeyChar)) return; //allowing backspace
            e.Handled = true;
        }
        #endregion


    } // end class 
} // end namespace

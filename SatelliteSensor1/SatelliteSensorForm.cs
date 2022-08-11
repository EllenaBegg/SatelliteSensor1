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

        // 4.2 Create a method called “LoadData” which will populate both LinkedLists.
        /// <summary>
        /// Read data from the Galileo Library into two LinkedLists with max size of 400.
        /// </summary>
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

        // 4.3 Create a custom method called “ShowAllSensorData” which will display both LinkedLists in a ListView
        /// <summary>
        /// Display both LinkedLists in a ListView
        /// </summary>
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
        /// <summary>
        /// Simply count and return the number of nodes in a LinkedList
        /// </summary>
        /// <param name="linkedList"></param>
        /// <returns></returns>
        private int NumberOfNodes(LinkedList<double> linkedList)
        {
            return linkedList.Count;
        }

        // 4.6 Create a method called "DisplayListboxData" to display content of a LinkedList in appropriate ListBox
        /// <summary>
        /// Display content of a LinkedList in the appropriate ListBox
        /// </summary>
        /// <param name="linkedList">The LinkedList<double> containing data</param>
        /// <param name="listBoxName">The ListBox to display the data in</param>
        private void DisplayListboxData(LinkedList<double> linkedList, ListBox listBoxName)
        {
            listBoxName.Items.Clear(); 
            foreach (double sensorData in linkedList)
            {
                listBoxName.Items.Add(sensorData.ToString());
            }
        }

        /// <summary>
        /// When a Search is invoked, the found item (closest value to given search value) will be highlighted 
        /// in the ListBox, along with 2 before and after it.
        /// If the found item is at the beginning of the data list, then the first 3 items will be highlighted.
        /// If the found item is at the end of the data list, then the last 3 items will be highlighted.
        /// </summary>
        /// <param name="listBox">The ListBox to highlight the rows in</param>
        /// <param name="index">The index of the ListBox where the found item is</param>
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

        /// <summary>
        /// Confirm the input given to invoke a Search is between the actual values of the LinkedList data
        /// </summary>
        /// <param name="linkedList">The LinkedList<double> to check</param>
        /// <param name="searchValue">The input value to confirm is present in the LinkedList</param>
        /// <returns></returns>
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
        /// <summary>
        /// Run a Selection Sort algorithm on a given LinkedList<double>
        /// </summary>
        /// <param name="linkedList"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Run a Insertion Sort algorithm on a given LinkedList<double>
        /// </summary>
        /// <param name="linkedList"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Run a Iterative Binary Search algorithm on a given LinkedList<double>
        /// </summary>
        /// <param name="linkedList">The LinkedList<double> to search</param>
        /// <param name="searchValue">The value to search for</param>
        /// <param name="minimum">The Minimum size of the LinkedList</param>
        /// <param name="maximum">The number of nodes of the LinkedList</param>
        /// <returns>The index of the LinkedList where the item has been found</returns>
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
        /// <summary>
        /// Run a Recursive Binary Search algorithm on a given LinkedList<double>
        /// </summary>
        /// <param name="linkedList">The LinkedList<double> to search</param>
        /// <param name="searchValue">The value to search for</param>
        /// <param name="minimum">The Minimum size of the LinkedList</param>
        /// <param name="maximum">The number of nodes of the LinkedList</param>
        /// <returns></returns>
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
        /// <summary>
        /// Load data into both of the LinkedLists, then display the data in the ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadSensorData_Click(object sender, EventArgs e)
        {
            LoadData();
            ShowAllSensorData();
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using SelectionSort method
        /// <summary>
        /// Invoke the Selection Sort algorithm on Sensor A data, display the milliseconds it takes to run the Sort algorithm,
        /// and redisplay the sorted data into the ListView and ListBox under Sensor A.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectionSortA_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SelectionSort(sensorALinkedList);
            stopWatch.Stop();
            // display milliseconds it took to run the Sort. Milliseconds are recorded as integers, so do not have decimal places.
            textBoxSelectionSortTimeA.Text = stopWatch.ElapsedMilliseconds.ToString("N0") + " milliseconds"; 
            ShowAllSensorData();
            DisplayListboxData(sensorALinkedList, listBoxSensorA);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using SelectionSort method
        /// <summary>
        /// Invoke the Selection Sort algorithm on Sensor B data, display the milliseconds it takes to run the Sort algorithm,
        /// and redisplay the sorted data into the ListView and ListBox under Sensor B.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectionSortB_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SelectionSort(sensorBLinkedList);
            stopWatch.Stop();
            // display milliseconds it took to run the Sort. Milliseconds are recorded as integers, so do not have decimal places.
            textBoxSelectionSortTimeB.Text = stopWatch.ElapsedMilliseconds.ToString("N0") + " milliseconds"; 
            ShowAllSensorData();
            DisplayListboxData(sensorBLinkedList, listBoxSensorB);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using InsertionSort method
        /// <summary>
        /// Invoke the Insertion Sort algorithm on Sensor A data, display the milliseconds it takes to run the Sort algorithm,
        /// and redisplay the sorted data into the ListView and ListBox under Sensor A.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsertionSortA_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            InsertionSort(sensorALinkedList);
            stopWatch.Stop();
            // display milliseconds it took to run the Sort. Milliseconds are recorded as integers, so do not have decimal places.
            textBoxInsertionSortTimeA.Text = stopWatch.ElapsedMilliseconds.ToString("N0") + " milliseconds"; 
            ShowAllSensorData();
            DisplayListboxData(sensorALinkedList, listBoxSensorA);
        }

        // 4.12 Create Button click methods to sort LinkedList<T> using InsertionSort method
        /// <summary>
        /// Invoke the Insertion Sort algorithm on Sensor B data, display the milliseconds it takes to run the Sort algorithm,
        /// and redisplay the sorted data into the ListView and ListBox under Sensor B.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsertionSortB_Click(object sender, EventArgs e)
        {
            // Must start with a StopWatch before calling the method.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            InsertionSort(sensorBLinkedList);
            stopWatch.Stop();
            // display milliseconds it took to run the Sort. Milliseconds are recorded as integers, so do not have decimal places.
            textBoxInsertionSortTimeB.Text = stopWatch.ElapsedMilliseconds.ToString("N0") + " milliseconds";  
            ShowAllSensorData();
            DisplayListboxData(sensorBLinkedList, listBoxSensorB);
        }

        // 4.11 Create Button click methods to search LinkedList<T> using Binary Search Iterative method
        /// <summary>
        /// Invoke the Iterative Search algorithm on Sensor A data, display the ticks it takes to run the Search algorithm,
        /// and highlist the found item in the ListBox under Sensor A, along with 2 before and after it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                            DisplayListboxData(sensorALinkedList, listBoxSensorA);

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorA, foundValue);

                            // Display number of ticks to run this Search algorithm. Not showing any decimals
                            textBoxIterativeSearchTimeA.Text = stopWatch.ElapsedTicks.ToString("N0") + " ticks";
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
        /// <summary>
        /// Invoke the Iterative Search algorithm on Sensor B data, display the ticks it takes to run the Search algorithm,
        /// and highlist the found item in the ListBox under Sensor B, along with 2 before and after it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                            DisplayListboxData(sensorBLinkedList, listBoxSensorB);

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorB, foundValue);

                            // Display number of ticks to run this Search algorithm. Not showing any decimals
                            textBoxIterativeSearchTimeB.Text = stopWatch.ElapsedTicks.ToString("N0") + " ticks";
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
        /// <summary>
        /// Invoke the Recursive Search algorithm on Sensor A data, display the ticks it takes to run the Search algorithm,
        /// and highlist the found item in the ListBox under Sensor A, along with 2 before and after it. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                            DisplayListboxData(sensorALinkedList, listBoxSensorA);

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorA, foundValue);

                            // Display number of ticks to run this Search algorithm. Not showing any decimals
                            textBoxRecursiveSearchTimeA.Text = stopWatch.ElapsedTicks.ToString("N0") + " ticks"; 
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
        /// <summary>
        /// Invoke the Recursive Search algorithm on Sensor B data, display the ticks it takes to run the Search algorithm,
        /// and highlist the found item in the ListBox under Sensor B, along with 2 before and after it. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                            DisplayListboxData(sensorBLinkedList, listBoxSensorB);

                            // Highlight value in ListBox, plus two either side
                            HighlightItemInListBox(listBoxSensorB, foundValue);

                            // Display number of ticks to run this Search algorithm. Not showing any decimals
                            textBoxRecursiveSearchTimeB.Text = stopWatch.ElapsedTicks.ToString("N0") + " ticks";
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

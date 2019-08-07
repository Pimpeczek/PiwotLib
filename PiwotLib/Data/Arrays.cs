using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Data
{
    public class Arrays
    {
        #region Counting
        /// <summary>Counts how many elements of a given bool array are true.</summary>
        /// <param name="boolArr">The array to be analized.</param>
        public static int CountTrues(bool[] boolArr)
        {
            int counter = 0;
            for (int i = 0; i < boolArr.Length; i++)
                if (boolArr[i])
                    counter++;
            return counter;
        }

        /// <summary>Counts how many elements of a given bool array are false.</summary>
        /// <param name="boolArr">The array to be analized.</param>
        public static int CountFalses(bool[] boolArr)
        {
            return boolArr.Length - CountTrues(boolArr);
        }

        /// <summary>Counts how many elements of a given array satisfy a given condition.</summary>
        /// <param name="array">The array to be analized.</param>
        /// <param name="condition">The condition based on an element.</param>
        public static int CountByCondition<T>(T[] array, Func<T, bool> condition)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
                if (condition(array[i]))
                    counter++;
            return counter;
        }

        /// <summary>Counts how many elements of a given array satisfy a given condition.</summary>
        /// <param name="array">The array to be analized.</param>
        /// <param name="condition">The condition based on an element and its position.</param>
        public static int CountByCondition<T>(T[] array, Func<T, int, bool> condition)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
                if (condition(array[i], i))
                    counter++;
            return counter;
        }
        #endregion

        #region Building arrays
        /// <summary>Returns new instance of a type T array with all values set using a given function.</summary>
        /// <param name="length">The length of a new array.</param>
        /// <param name="value">The value assigned values to fields in the new array.</param>
        public static T[] GetCustomArray<T>(int length, T value)
        {
            T[] boolArr = new T[length];
            for (int i = 0; i < boolArr.Length; i++)
                boolArr[i] = value;
            return boolArr;
        }

        /// <summary>Returns new instance of a type T array with all values set using a given function.</summary>
        /// <param name="length">The length of a new array.</param>
        /// <param name="func">The function used to assign values to the new array</param>
        public static T[] GetCustomArray<T>(int length, Func<int, T> func)
        {
            T[] boolArr = new T[length];
            for (int i = 0; i < boolArr.Length; i++)
                boolArr[i] = func(i);
            return boolArr;
        }
        #endregion

        #region Iterating
        /// <summary>Prints each element of a given array in seperate line.</summary>
        /// <typeparam name="T">Type of an array.</typeparam>
        /// <param name="array">The array to be printed.</param>
        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);
        }

        /// <summary>Performs a given action on each element of a given array.</summary>
        /// <typeparam name="T">Type of an array.</typeparam>
        /// <param name="array">The array to be iterated through.</param>
        /// <param name="action">The action to be performed based on an element and its position.</param>
        public static void IterateThrough<T>(T[] array, Action<T, int> action)
        {
            for (int i = 0; i < array.Length; i++)
                action(array[i], i);

        }

        /// <summary>Assigns a value to each field on a given array based of a given function.</summary>
        /// <typeparam name="T">Type of an array.</typeparam>
        /// <param name="array">The array to be iterated through.</param>
        /// <param name="func">The function based on an element and its position.</param>
        public static void IterateThrough<T>(T[] array, Func<T, int, T> func)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = func(array[i], i);
        }

        /// <summary>Negates all elements of a given bool array.</summary>
        /// <param name="boolArr">The array to be negated.</param>
        public static bool[] NegateBoolArray(bool[] boolArr)
        {
            for (int i = 0; i < boolArr.Length; i++)
                boolArr[i] = !boolArr[i];
            return boolArr;
        }
        #endregion

        #region Operations on size
        /// <summary>Returns a new instance expanded to a given length.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">Thelength of the new array.</param>
        public static T[] BuildExpandedArray<T>(T[] array, int length)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }
            return expandedArray;
        }

        /// <summary>Returns a new instance expanded to a given length with empty fields assigned a given value.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">The length of the new array.</param>
        /// <param name="value">The value assigned to the new fields.</param>
        public static T[] BuildExpandedArray<T>(T[] array, int length, T value)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }

            for (int i = array.Length; i < length; i++)
            {
                expandedArray[i] = value;
            }
            return expandedArray;
        }

        /// <summary>Returns a new instance expanded to a given length with empty fields assigned using a fiven function.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">The length of the new array.</param>
        /// <param name="func">Function used to assign new values.</param>
        public static T[] BuildExpandedArray<T>(T[] array, int length, Func<int, T> func)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }

            for (int i = array.Length; i < length; i++)
            {
                expandedArray[i] = func(i);
            }
            return expandedArray;
        }

        /// <summary>Expands a given array to a given length.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">Thelength of the new array.</param>
        public static void ExpandArray<T>(ref T[]  array, int length)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }
            array = expandedArray;
        }

        /// <summary>Expands a given array to a given length with empty fields assigned a given value.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">The length of the new array.</param>
        /// <param name="value">The value assigned to the new fields.</param>
        public static void ExpandArray<T>(ref T[] array, int length, T value)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }

            for (int i = array.Length; i < length; i++)
            {
                expandedArray[i] = value;
            }
            array = expandedArray;
        }

        /// <summary>Expands a given array to a given length with empty fields assigned using a given function.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="length">The length of the new array.</param>
        /// <param name="value">The value assigned to the new fields.</param>
        public static void ExpandArray<T>(ref T[] array, int length, Func<int, T> func)
        {
            if (length < array.Length)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            T[] expandedArray = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }

            for (int i = array.Length; i < length; i++)
            {
                expandedArray[i] = func(i);
            }
            array = expandedArray;
        }

        /// <summary>Removes elements from a given array so it starting at from-th position and has 'lenght' elements.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="from">Position of the first element of th subarray.</param>
        /// <param name="length">Lenght of the subarray.</param>
        public static void SubArray<T>(ref T[] array, int from, int length)
        {
            if (from < 0 || from >= array.Length)
                throw new ArgumentOutOfRangeException("from");
            if (length < 0 || from + length >= array.Length)
                throw new ArgumentOutOfRangeException("length");
            array =  array.Skip(from).Take(length).ToArray();
        }

        /// <summary>Removes elements from a given array that do not satisf a given condition.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="condition">The condition based on an element.</param>
        public static void SubArray<T>(ref T[] array, Func<T, bool> condition)
        {
            array = array.Where(condition).ToArray();
        }

        /// <summary>Removes elements from a given array that do not satisf a given condition.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="condition">The condition based on an element and its position.</param>
        public static void SubArray<T>(ref T[] array, Func<T, int, bool> condition)
        {
            array = array.Where(condition).ToArray();
        }

        /// <summary>Returns a subarray starting at from-th position and having 'lenght' elements.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="from">Position of the first element of th subarray.</param>
        /// <param name="length">Lenght of the subarray.</param>
        public static T[] BuildSubArray<T>(T[] array, int from, int length)
        {
            if (from < 0 || from >= array.Length)
                throw new ArgumentOutOfRangeException("from");
            if (length < 0 || from + length >= array.Length)
                throw new ArgumentOutOfRangeException("length");
            return array.Skip(from).Take(length).ToArray();
        }

        /// <summary>Returns a subarray consisting of elements satisfying the given condition.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="condition">The condition based on an element.</param>
        public static T[] BuildSubArray<T>(T[] array, Func<T, bool> condition)
        {
            return array.Where(condition).ToArray();
        }

        /// <summary>Returns a subarray consisting of elements satisfying the given condition.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="condition">The condition based on an element and its position.</param>
        public static T[] BuildSubArray<T>(T[] array, Func<T, int, bool> condition)
        {
            return array.Where(condition).ToArray();
        }


        /// <summary>Returns a new instance expanded to given dimentions.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="dimentions">The dimentions of the new array.</param>
        public static T[,] BuildExpandedArray<T>(T[,] array, int[] dimentions)
        {
            int[] oldLen = new int[] { array.GetLength(0), array.GetLength(1) };
            if (dimentions[0] < oldLen[0] || dimentions[1] < oldLen[0])
            {
                throw new ArgumentOutOfRangeException("length");
            }

            T[,] expandedArray = new T[dimentions[0], dimentions[1]];
            for (int i = 0; i < oldLen[0]; i++)
            {
                for (int j = 0; j < oldLen[1]; j++)
                {
                    expandedArray[i,j] = array[i,j];
                }
            }
            return expandedArray;
        }

        /// <summary>Returns a new instance expanded to given dimentions with empty fields assigned a given value.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="dimentions">The dimentions of the new array.</param>
        /// <param name="value">The value assigned to the new fields.</param>
        public static T[,] BuildExpandedArray<T>(T[,] array, int[] dimentions, T value)
        {
            int[] oldLen = new int[] { array.GetLength(0), array.GetLength(1) };
            if (dimentions[0] < oldLen[0] || dimentions[1] < oldLen[0])
            {
                throw new ArgumentOutOfRangeException("length");
            }

            T[,] expandedArray = new T[dimentions[0], dimentions[1]];

            for (int i = 0; i < oldLen[0]; i++)
            {
                for (int j = 0; j < oldLen[1]; j++)
                {
                    expandedArray[i, j] = array[i, j];
                }
            }

            for (int i = 0; i < oldLen[0]; i++)
            {
                for (int j = 0; j < oldLen[1]; j++)
                {
                    expandedArray[i, j] = value;
                }
            }
            return expandedArray;
        }

        /// <summary>Returns a new instance expanded to a given length with empty fields assigned using a fiven function.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array to be expanded.</param>
        /// <param name="dimentions">The dimentions of the new array.</param>
        /// <param name="func">Function used to assign new values.</param>
        public static T[,] BuildExpandedArray<T>(T[,] array, int[] dimentions, Func<int, int, T> func)
        {
            int[] oldLen = new int[] { array.GetLength(0), array.GetLength(1) };
            if (dimentions[0] < oldLen[0] || dimentions[1] < oldLen[0])
            {
                throw new ArgumentOutOfRangeException("length");
            }

            T[,] expandedArray = new T[dimentions[0], dimentions[1]];

            for (int i = 0; i < oldLen[0]; i++)
            {
                for (int j = 0; j < oldLen[1]; j++)
                {
                    expandedArray[i, j] = array[i, j];
                }
            }

            for (int i = 0; i < oldLen[0]; i++)
            {
                for (int j = 0; j < oldLen[1]; j++)
                {
                    expandedArray[i, j] = func(i, j);
                }
            }
            return expandedArray;
        }
        #endregion

        #region Random
        /// <summary>Returns a random permutation the given array.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        public static T[] BuildRandomizedArray<T>(T[] array)
        {
            T[] newArray = (T[])array.Clone();
            T temp;
            int randomPos;
            for (int i = 0; i < array.Length; i++)
            {
                randomPos = PMath.Rand.Int(array.Length);
                temp = newArray[i];
                newArray[i] = newArray[randomPos];
                newArray[randomPos] = temp;
            }
            return newArray;
        }

        /// <summary>Rearanges fields of a given array creating a random permutation.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        public static void RandomizrArray<T>(T[] array)
        {
            T temp;
            int randomPos;
            for (int i = 0; i < array.Length; i++)
            {
                randomPos = PMath.Rand.Int(array.Length);
                temp = array[i];
                array[i] = array[randomPos];
                array[randomPos] = temp;
            }
        }
        #endregion

        #region Moving elements
        /// <summary>Swaps places of elements on pos1 and pos2.</summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The base array.</param>
        /// <param name="pos1">Position of an element to be swapped.</param>
        /// <param name="pos2">Position of an element to be swapped.</param>
        public static void Swap<T>(T[] array, int pos1, int pos2)
        {
            T temp;
            temp = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = temp;
        }
        #endregion
    }
}

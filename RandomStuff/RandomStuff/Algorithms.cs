using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuff
{
    public class Algorithms
    {
        public static void Program()
        {
            var list = new List<int>{4, 1, 3, 2, 2, 8, 9};
            Quick(ref list);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


        public static void Quick(ref List<int> numbers)
        {
            Quick(ref numbers, 0, numbers.Count);
        }

        private static int Partition(ref List<int> numbers, int start, int stop)
        {
            var rndm = new Random();
            // return int between (-1, stop)

            // [x, y)
            var pivot = rndm.Next(start, stop);
            var pivotVal = numbers[pivot];
            numbers[pivot] = numbers[start];
            numbers[start] = pivotVal;

            int tempIndex = start;
            int tempVal;
            for (int target = start + 1; target < stop; target++)
            {
                if (numbers[target] <= pivotVal)
                {
                    tempIndex++;
                    tempVal = numbers[target];
                    numbers[target] = numbers[tempIndex];
                    numbers[tempIndex] = tempVal;
                }
            }
            tempVal = numbers[tempIndex];
            numbers[tempIndex] = pivotVal;
            numbers[start] = tempVal;
            return tempIndex;
        }

        private static void Quick(ref List<int> numbers, int start, int stop)
        {
            int pivotIndex;
            if (start < stop)
            {
                pivotIndex = Partition(ref numbers, start, stop);
                Quick(ref numbers, start, pivotIndex - 1);
                Quick(ref numbers, pivotIndex + 1, stop);
            }
        }

        public static async Task<List<int>> Merge(List<int> numbers)
        {
            var numItems = numbers.Count;
            if(numItems == 1)
            {
                return numbers;
            }
            else
            {
                decimal count = (decimal)numItems / 2;
                var leftList = numbers.GetRange(0, (Int32)Math.Floor(count));
                var rightList = numbers.GetRange((Int32)Math.Floor(count), (Int32)Math.Ceiling(count));
                var newList = new List<int>();
                var getLeftList = Merge(leftList);
                var getRightList = Merge(rightList);

                int leftEle;
                int rightEle;
                leftList = await getLeftList;
                rightList = await getRightList;
                do
                {
                    leftEle = leftList.First();
                    rightEle = rightList.First();
                    if (leftEle <= rightEle)
                    {
                        newList.Add(leftEle);
                        leftList.Remove(leftEle);
                    }
                    else
                    {
                        newList.Add(rightEle);
                        rightList.Remove(rightEle);
                    }
                } while (leftList.Count > 0 && rightList.Count > 0);
                newList = newList.Concat(leftList).Concat(rightList).ToList();
                return newList;
            }
        }
    }
}

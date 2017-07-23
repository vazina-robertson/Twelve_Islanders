/* 
 * This program is written in C#. 
 * Authors: Vazina Nugmanova (Robertson) and William Olson
 * Date: 03/07/2017
 * Problem: There is an island with 12 islanders. 
 *          All of the islanders individually weigh exactly the same amount, 
 *          except for one (either weigh more, or less than the other 11). 
 *          How can you find which islander is the one that weighs more/less 
 *          than the others? You must use a see-saw to figure out the weights, 
 *          and you may only use the see-saw 3 times max. There are no scales 
 *          or any other weighing device on the island. 
 *          
 * From Authors: 
 *          The assumption is that all islanders weight in int. 
 *          Please modify the code to float where appropriate.
 * VERSION: 1.0;
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables{

    class Program{
    
         static void Main(string[] args){
            
            /* Test Array */
            int[] array = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4 };

            /* 
             * To make is easy to see where the different islander
             * located while running the program 
             */
            
            Console.Write("Original: ");
            printArr(array);

            /* Three new subarrays derived from original array */
            int[] tmpArr1;
            int[] tmpArr2;
            int[] tmpArr3;          

            /* To be able to use new subarrays from SPlit function */
            Split(array, out tmpArr1, out tmpArr2, out tmpArr3);

            /* This is our unknown islander */
            int islander;
            int sum1=0, sum2=0, sum3=0, sum4=0, sum5=0, sum6=0;

            /* 
             * Following two FOR loops will calculate the sum of 
             * different subarrays 
             */
            for(int i = 0; i < tmpArr1.Length; i++){
                sum1 += tmpArr1[i];
            }          

            for(int j = 0; j < tmpArr2.Length; j++){
                sum2 += tmpArr2[j];
            }
            
            /* Case 1: {1,2,3,4} == {5,6,7,8}. Seesaw #1*/
            if(sum1 == sum2){
                System.Console.WriteLine("sum1 == sum2");
                sum3 = tmpArr1[0] + tmpArr1[1];
                sum4 = tmpArr3[0] + tmpArr3[1];
                /* Case 1.1: {1,2} == {9,10} */
                if(sum3 == sum4){
                    /* Case 1.1.1: {1} == {11}. Seesaw #3 */
                    if(tmpArr1[0] == tmpArr3[2]){
                        islander = tmpArr3[3];
                        Console.Write("Position: 12 \nWeight: " + islander);
                        Console.WriteLine();

                    }
                    /* Case 1.1.2 and 1.1.3: {1} > || < {11}. Seesaw #3 */
                    else if ((tmpArr1[0] > tmpArr3[2]) || (tmpArr1[0] < tmpArr3[2])){
                        islander = tmpArr3[2];
                        Console.Write("Position: 11 \nWeight: " + islander);
                        Console.WriteLine();
                    }           
                }
                /* Case 1.2: {1,2} > {9,10}. Seesaw #2 */
                else if(sum3 > sum4) {
                    System.Console.WriteLine("sum3 > sum4");
                    /* Case 1.2.1: {9} > {10} */
                    if(tmpArr3[0] > tmpArr3[1]){
                        islander = tmpArr3[1];
                        Console.Write("Position: 10 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 1.2.2: {9} < {10}. Seesaw #3 */
                    else{
                        islander = tmpArr3[0];
                        Console.Write("Position: 9 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }
                /* Case 1.3: {1,2} < {9,10}. Seesaw #2 */
                else if(sum3 < sum4){
                    System.Console.WriteLine("sum3<sum4");
                    /* Case 1.3.1: {9} > {10}. Seesaw #3 */
                    if(tmpArr3[0] > tmpArr3[1]){
                        islander = tmpArr3[0];
                        Console.Write("Position: 9 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 1.3.2: {9} < {10}. Seesaw #3 */
                    else{
                        islander = tmpArr3[1];
                        Console.Write("Position: 10 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }
            }
            /* sum5 == {1,2,3,5}, sum6 == {4,9,10,11} */
            for(int i = 0; i < (tmpArr1.Length - 1); i++){
                    sum5 += tmpArr1[i]; 
                }
                sum5 += tmpArr2[0];
               
                for(int j = 0; j < (tmpArr3.Length - 1); j++){
                    sum6 += tmpArr3[j]; 
                }
                sum6 += tmpArr1[3];

            /* Case 2: {1,2,3,4} < {5,6,7,8}. Seesaw #1 */
            if(sum1 < sum2){
                System.Console.WriteLine("sum1 < sum2");
                /* Case 2.1: {1,2,3,5} == {4,9,10,11}. Seesaw #2 */
                if(sum5 == sum6){
                    /* Case 2.1.1: {6} == {7}. Seesaw #3 */
                    if(tmpArr2[1] == tmpArr2[2]){
                        islander = tmpArr2[3];
                        Console.Write("Position: 8 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 2.1.2: {6} > {7}. Seesaw #3 */
                    else if(tmpArr2[1] > tmpArr2[2]){
                        islander = tmpArr2[1];
                        Console.Write("Position: 6 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 2.1.3: {6} < {7}. Seesaw #3 */
                    else if(tmpArr2[1] < tmpArr2[2]){
                        islander = tmpArr2[2];
                        Console.Write("Position: 7 \nWeight: " + islander;
                        Console.WriteLine();
                    }
                }
                /* Case 2.2: {1,2,3,5} < {4,9,10,11} Seesaw #2 */
                else if(sum5 < sum6){
                    /* Case 2.2.1: {1} == {2}. Seesaw #3 */
                    if(tmpArr1[0] == tmpArr1[1]){
                        islander = tmpArr1[2];
                        Console.Write("Position: 3 \nWeight: " + islander);
                        Console.WriteLine();                 
                    }
                    /* Case 2.2.2: {1} < {2}. Seesaw #3 */
                    else if(tmpArr1[0] < tmpArr1[1]){
                        islander = tmpArr1[0];
                        Console.Write("Position: 1 \nWeight: " + islander);
                        Console.WriteLine();                   
                    }
                    /* Case 2.2.3: {2}. Seesaw #3 */
                    else {
                        islander = tmpArr1[1];
                        Console.Write("Position: 2 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }
                /* Case 2.3: {1,2,3,5} > {4,9,10,11}. Seesaw #2 */
                else if(sum5 > sum6){
                    /* Case 2.3.1: {1} == {5}. Seesaw #3 */
                    if(tmpArr1[0] == tmpArr2[0]){
                        islander = tmpArr1[3];
                        Console.Write("Position 4 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 2.3.2: {5}. Seesaw #3 */
                    else{
                        islander = tmpArr2[0];
                        Console.Write("Position: 5 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }             
            }
            /* Case 3: {1,2,3,4} > {5,6,7,8}. Seesaw #1 */
            else if(sum1 > sum2){
                /* Case 3.1: {1,2,3,5} == {4,9,10,11}. Seesaw #2 */
                if(sum5 == sum6){
                    /* Case 3.1.1: {6} == {7}.Seesaw #3 */
                    if(tmpArr2[1] == tmpArr2[2]){
                        islander = tmpArr2[3];
                        Console.Write("Position: 8 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 3.1.2: {6} < {7}. Seesaw #3 */
                    else if(tmpArr2[1] < tmpArr2[2]){
                        islander = tmpArr2[1];
                        Console.Write("Position: 6 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 3.1.3: {6} > {7}. Seesaw #3 */
                    else if(tmpArr2[1] > tmpArr2[2]){
                        islander = tmpArr2[2];
                        Console.Write("Position: 7 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }
                /* Case 3.2: {1,2,3,5} > {4,9,10,11}. Seesaw #2 */
                else if(sum5 > sum6){
                    /* Case 3.2.1: {1} == {2}. Seesaw #3 */
                    if(tmpArr1[0] == tmpArr1[1]){
                        islander = tmpArr1[2];
                        Console.Write("Position: 3 \nWeight: " + islander);
                        Console.WriteLine();                 
                    }
                    /* Case 3.2.2: {1} > {2}. Seesaw #3 */
                    else if(tmpArr1[0] > tmpArr1[1]){
                        islander = tmpArr1[0];
                        Console.Write("Position: 1 \nWeight: " + islander);
                        Console.WriteLine();                   
                    }
                    /* Case 3.2.3: {2}. Seesaw #3 */
                    else {
                        islander = tmpArr1[1];
                        Console.Write("Position: 2 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }
                /* Case 3.3: {1,2,3,5} < {4,9,10,11}. Seesaw #2 */
                else if(sum5 < sum6){
                    /* Case 3.3.1: {1} == {5}. Seesaw #3 */
                    if(tmpArr1[0] == tmpArr2[0]){
                        islander = tmpArr1[3];
                        Console.Write("Position: 4 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                    /* Case 3.3.2: {5}. Seesaw #3 */
                    else{
                        islander = tmpArr2[0];
                        Console.Write("Position: 5 \nWeight: " + islander);
                        Console.WriteLine();
                    }
                }      
            }            
        }

/* This method prints the entire array of islanders */
        public static void printArr(int[] array){

            foreach(int item in array){
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            }

/* This method splits an array of islanders into three subarrays */
        public static void Split(int[] array, out int[] first,
            out int[] second, out int[] third) {

            /* Determine where to split */
            int firstChunkIndex = array.Length / 3;
            int secondChunkIndex = firstChunkIndex * 2;
            
            /* If there are too few items in the array */
            if (array.Length <= 2) {
                firstChunkIndex = 1;
                secondChunkIndex = 2;
            }

            /* Three newly formed arrays from the split */
            first = array.Take(firstChunkIndex).ToArray();
            second = array.Take(secondChunkIndex)
                .ToArray().Skip(firstChunkIndex).ToArray();
            third = array.Skip(secondChunkIndex).ToArray();
        }     
    }
}

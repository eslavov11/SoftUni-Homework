//#include <stdio.h>
//#include <stdlib.h>
//
//int main() 
//{
//    int i,j;
//    for (i = 1; i <= 13; i++) 
//    {
//        for (j = 0; j < 4; j++)
//        {
//            if (i!=10)
//            {
//               printf("%c%c ",face(i), suits(j));
//            }
//            else printf("10%c ", suits(j));
//        }
//        printf("\n");
//    }
//    return 0;
//}
//int face(int i)
//{
//    switch (i) {
//        case 1:
//            return 'A';
//            break;
//        case 2:
//            return '2';
//            break;
//        case 3:
//            return '3';
//            break;
//        case 4:
//            return '4';
//            break;
//        case 5:
//            return '5';
//            break;
//        case 6:
//            return '6';
//            break;
//        case 7:
//            return '7';
//            break;
//        case 8:
//            return '8';
//            break;
//        case 9:
//            return '9';
//            break;
//        case 10:
//            return '1';
//            break;
//        case 11:
//            return 'J';
//            break;
//        case 12:
//            return 'Q';
//            break;
//        case 13:
//            return 'K';
//            break;
//        default:
//            return -1;
//            break;
//    }
//}
//int suits(int j)
//{
//   switch (j) {
//        case 0:
//            return 'C';
//            break;
//        case 1:
//            return 'D';
//            break;
//        case 2:
//            return 'H';
//            break;
//        case 3:
//            return 'S';
//            break;
//        default:
//            return -1;
//            break;
//    } 
//}
//
////Write a program that generates and prints all possible cards from a standard deck of 52 cards 
////(without the jokers).
////The cards should be printed using the classical notation (like 5S (♠), AH (♥), 9C (♣) and KD
////(♦)). The card faces
////should start from 2 to A. Print each card face in its four possible suits: clubs, diamonds,
////        hearts and spades. Use 2
////nested for-loops and a switch-case statement.

# AlgorithmPlayground

Tired of writing a new BT node class or listnode class whenever I want to play with algorithms, thought I'd finally save one of them. 

Example:

// creates an array numbered from 1-63
int[] turnintotree = ArrayLib.CreateArray(63);
//creates a binary tree from the array. Since the array is ordered, the tree will be a BST
BinaryTreeNode treeHead = new BinaryTreeNode(turnintotree);

// Prints an in order traversal of the tree out
treeHead.InOrderPrint();
// OUTPUT:
// 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63


// The real prize, prints the tree prettily for easy debugging and just plain coolness. 
treeHead.PrettyPrintTree();
// OUTPUT:
//                                                               32
//                               16                                                              48
//               8                               24                              40                              56
//       4               12              20              28              36              44              52              60
//   2       6       10      14      18      22      26      30      34      38      42      46      50      54      58      62
// 1   3   5   7   9   11  13  15  17  19  21  23  25  27  29  31  33  35  37  39  41  43  45  47  49  51  53  55  57  59  61  63

// Also works on non full trees:
//               5
//       2               8
//   1       3       6       9
//             4       7       10

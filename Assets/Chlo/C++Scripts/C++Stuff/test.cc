#include "test.h"
#include <iostream>
using namespace std;
/*
int returnIndexInMatrix(matrix currentMatrix){
return currentMatrix[grabMatrixPosition(returnAttatchedNodes(0)];
}*/
/*
class Node {
public:
//init
Node(char id){
for(int i = 0; i < 4; i++){
		adjacentEdges[i] = nullptr;
}
}
Edge* returnAdjacentEdges(int index){
return adjacentEdges[index];
}
private:
Edge* adjacentEdges[4];

};*/
/*class Edge {

public:

int createEdge(Node one, Node two) {
for (int i = 0; i < 2; i++){
children[i] = nullptr;
}
children[0] = one;
children[1] = two; 

return 0;
}
Node[] returnAttatchedNodes(int index){
		return children;
}
private:
Node children[] = new Node[2];
};
*/

// Prototype shape within matrix creation
extern "C" {
std::array<string, 4> DLL_EXPORT createFakeShape(std::array<string, 100> basis){
std::array<string, 4> arr = {"0,0", "1,0", "0,1", "1,1"};
return arr;
}
}


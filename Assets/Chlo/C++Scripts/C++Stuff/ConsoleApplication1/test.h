#ifndef TEST_H
#define TEST_H
#include <comdef.h>
#include <string>
#define DLL_EXPORT __declspec(dllexport)
using namespace std;



extern "C" {
    //std::array<string, 4> DLL_EXPORT passToCPP(std::array<string, 4> shape);
    const BSTR* DLL_EXPORT retrieveData(char* arr[], int len);

}

#endif


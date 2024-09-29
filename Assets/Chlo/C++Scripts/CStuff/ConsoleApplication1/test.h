#ifndef TEST_H
#define TEST_H
#include <comdef.h>
#include <sstream>
#include <vector>
#include <iostream>
#include <oleauto.h>
#include <string>
#define DLL_EXPORT __declspec(dllexport)



extern "C" {
    //std::array<string, 4> DLL_EXPORT passToCPP(std::array<string, 4> shape);
     DLL_EXPORT BSTR retrieveData(char* inputStr);

}

char* createBody(char* input);
#endif


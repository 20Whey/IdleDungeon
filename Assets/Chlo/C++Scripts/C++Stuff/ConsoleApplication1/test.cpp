#include "test.h"
#include <iostream>

using namespace std;
/*
extern "C" {
std::array<string, 4> DLL_EXPORT feedToCPP(std::array<string, 4> basis){
std::array<string, 4> arr = {"0,0", "1,0", "0,1", "1,1"};
return arr;
}*/
/*
    extern "C" {
    const char** DLL_EXPORT feedToCPP()
    {
        // Create static C-style strings
        static const char* arr[4] = {"0,0", "1,0", "0,1", "1,1"};
        // Return the array
        return arr;
    }*/
    extern "C"{
      const BSTR* DLL_EXPORT retrieveData(char* arr[], int len)
        {
          
          char* str[len];
          BSTR returnee[len];
          for(int i = 0; i < len; i++)
          { 
              strcpy_s(str[i], 6, arr[i]);
              MultiByteToWideChar(CP_ACP, 0, str[i], -1, returnee[i], 0);
          }
          delete[] str;
          return returnee;
       // return SysAllocString("data", "data")
        }


    }

    


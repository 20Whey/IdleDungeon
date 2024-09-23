#include "test.h"
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
    }
   extern "C"{
     std::string DLL_EXPORT retrieveData(const char* inputStr)
        {
		 BSTR current = SysAllocString(BSTR(inputStr);
		int len = SysStringLen(inputStr);
       int size_needed =  WideCharToMultiByte(CP_ACP, 0, inputStr, len, NULL, 0, NULL, NULL);
       

		std::string ret(
		WideCharToMultiByte(CP_UTF8, 0, bstr, len, ret.data(), ret.size(), NULL, NULL);
        return );
        }
      }
    

*/
    extern "C"{
     BSTR DLL_EXPORT retrieveData(char* inputr)
        {
      	int len = static_cast<int>(strlen(inputr));
     	BSTR curr = SysAllocString((BSTR)inputr);
     	if(len == 0) return nullptr;
     	int size_needed = WideCharToMultiByte(CP_UTF8, 0, curr, len, NULL, 0, NULL, NULL);
     	std::string ret(size_needed, '\0');
      	WideCharToMultiByte(CP_UTF8, 0, curr, len, (LPSTR)ret.data(), ret.size(), NULL, NULL);
      	return curr;
        }
      }
    

    











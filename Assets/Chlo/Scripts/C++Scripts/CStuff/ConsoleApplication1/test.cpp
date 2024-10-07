#include "test.h"
enum Direction{
	NORTH = 10, 
	SOUTH = -10, 
	EAST = 1, 
	WEST = -1
	};

	


	std::vector<std::string>* discoverCords(char* input)
	{
		int len = static_cast<int>(strlen(input));
		std::string str(input);
		std::stringstream ss(input);
		
		//input is now a string
		char delim = ',';
		std::string token;
		std::vector<std::string> tokens;
		//	return new char*;
		while (getline(ss, token, delim))
		{
			tokens.push_back(token);

		}
		return &tokens;
	}
	

	char* createBody(char* input)
	{
		
		//foreach token do *something*
		
	}


    extern "C"{
     BSTR DLL_EXPORT retrieveData(char* inputr)
        {
     	discoverCords(inputr);

      	int len = static_cast<int>(strlen(inputr));
     	BSTR curr = SysAllocString((BSTR)inputr);
     	if(len == 0) return nullptr;
     	int size_needed = WideCharToMultiByte(CP_UTF8, 0, curr, len, NULL, 0, NULL, NULL);
     	std::string ret(size_needed, '\0');
      	WideCharToMultiByte(CP_UTF8, 0, curr, len, (LPSTR)ret.data(), ret.size(), NULL, NULL);
		
/* body






*/
     	return curr;






     	
        }
      }
    

    











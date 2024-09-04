#include "test.h"

extern "C" {
int DLL_EXPORT returnTenPlusWhatever(int a){
return a + 10;
    }
}
#ifndef TEST_H
#define TEST_H
#include <array>
#define DLL_EXPORT __declspec(dllexport)
using namespace std;

extern "C" {
int DLL_EXPORT returnTenPlusWhatever(int a);
}
extern "C" {
    std::array<string, 4> DLL_EXPORT createFakeShape(std::array<string, 100> shape);
}
#endif


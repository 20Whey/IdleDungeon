#ifndef TEST_H
#define TEST_H
#define DLL_EXPORT __declspec(dllexport)

extern "C" {
int DLL_EXPORT returnTenPlusWhatever(int a);
}
#endif
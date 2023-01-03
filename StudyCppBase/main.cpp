#include <iostream>
using namespace std;

struct Hoge {
    int x;
    int y;
};

int main (){
    std::cout << "Hello World" << std::endl;

    Hoge* pHoge;
    pHoge->x;

    return 0;
}
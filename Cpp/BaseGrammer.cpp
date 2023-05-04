#include <iostream>
#include <string>
#include <vector>
#include <list>
#include <map>
#include <set>

using namespace std;

namespace{
    // template 関数
    template <typename T>
    T Add(T x, T y){
        return x + y; 
    }
}

class CSuper{
private:
    string _name;
public:
    CSuper() {cout << "call constructor" << endl; }
    ~CSuper() { cout << "call destructor" << endl; }
    void SetName(string name){
        _name = name;
    }
    static void ShowCSuper(){
        cout << "CSuper!!" << endl;
    }
    virtual void virtualFunc() = 0; // 完全仮想関数
protected: // protectedにアクセスできるのはサブクラスとスーバクラスの中だけ。
    void ProtectedFunc(){
        cout << "Protect" << endl;
    }
};

class CSub : public CSuper{
public:
    CSub(){}

    // subクラスのデストラクタには必ず、「virtual」をつける。
    virtual ~CSub() {} 
    
    void ProtectedFunc(){
        ProtectedFunc();
    }
    virtual void virtualFunc() override {
        cout << "override!!" << endl;
    }

    // const メンバ関数 (メンバ関数を書き換えない)
    void NormalFunc() const {
        // do nothing
    }
};

// template クラス
template <typename T> class CTemplate{
public:
    T m_value1;
    T m_value2;
    CTemplate(T v1, T v2){
        m_value1 = v1;
        m_value2 = v2;
    }
    T GetAddResult(){
        return m_value1 + m_value2;
    }
};

class Vector2
{
private:
    int _x;
    int _y;
public:
    Vector2(int x, int y){
        _x = x;
        _y = y;
    }
    ~Vector2();

    // 演算子のオーバロード
    Vector2& operator =(const Vector2& v){
        this->_x = v._x;
        this->_y = v._y;
        return *this;
    }
};

int main(){
    cout << Add<int>(1, 2) << endl;
    cout << Add<string>("hoge", "piyo") << endl;

    CTemplate<int> t1(1, 2);
    CTemplate<string> t2("1", "2");

    cout << t1.GetAddResult() << endl;
    cout << t2.GetAddResult() << endl;
}

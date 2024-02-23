
#include <iostream>

using namespace std;

// C++のキャスト

namespace {
	enum class eType {
		None,
		Normal,
		Special,
	};

	class Base {
	public:
		virtual ~Base() {}
	};
	class Sub1 : public Base {};
	class Sub2 : public Base {};
}

int main()
{
	// 1. static_cast
	// 型変換を明示的に行う
	// 必要があれば値も変更する
	const int iType = static_cast<int>(eType::None);
	const int iValue = static_cast<int>(7.5f);

	// 2. dynamic_cast
	// 一般にダウンキャストをする際に、 dynamic_cast を使う。
	// アップキャストに使うときは static_cast と同じ意味を持つ。 
	// static_cast は dynamic_cast とは違い、 実行時の型の情報をチェックしていないので、 
	// 危険なダウンキャストも出来る。
	// static_cast の場合、キャストが成功しても動作は保証されないので注意。
	Base* b = new Base();
	Sub1* s1 = dynamic_cast<Sub1*>(b);//ダウンキャスト
	Base* base = new Sub1();  // Sub1 からのアップキャスト
	Sub1* sub1 = static_cast<Sub1*>(base);  // Sub1 へのダウンキャスト

	// 3. const_cast
	// cosnt を外すためのキャスト。基本使わない。
	const string str1 = "hogehoge";
	auto& tmp = const_cast<string&>(str1);
	tmp = "piyopiyo";// 参照でstr1を書き換え可能。

	// 4. reinterpret_cast
	// 値は保持したまま型情報のみを変換する。
	unsigned int uValue = 23u;
	int& t = reinterpret_cast<int&>(uValue);
}

#include <iostream>
#include <vector>
#include <map>
#include <set>
#include <unordered_map>
#include <array>
#include <list>

using namespace std;

int main()
{
	// 〇：vectorはランダムアクセスが高速
	// △：要素の追加、削除に弱い
	vector<int> vec1(10);
	vec1.assign(10, 5);

	// 〇：途中要素への追加・削除に強い。
	// △：listはランダムアクセスが線形
	// △：メモリ消費大。
	list<int> list1(10);

	// 〇：要素の存在チェックが対数時間。
	// 要素が自動で並び変えられる。
	// △：メモリ消費量が大きい。
	set<int> set1;

	// 連想配列。
	// キーをsetと同様の方式で格納
	// 〇：空きのある番号や文字列を使って要素を取得する際に有効。
	map<string, int> map1;


	// (1) IDでの検索
	map<int, pair<string, int>> mapInfo;
	mapInfo.insert({ 1151, make_pair("abe", 121) });
	mapInfo.insert({ 8430, make_pair("ito", 84) });
	mapInfo.insert({ 742, make_pair("ueda", 91) });

	// (2) score順 →multimap
	multimap<int, string> mMap;
	mMap.insert({121, "abe"});
	mMap.insert({ 91, "ito" });
	mMap.insert({ 91, "sato" });
	auto p = mMap.equal_range(91);
	
	set<tuple<int, string, int>> setInfo;
	setInfo.insert({ 121, "abe", 1151 });
	setInfo.insert({ 84, "ito", 8430 });
}

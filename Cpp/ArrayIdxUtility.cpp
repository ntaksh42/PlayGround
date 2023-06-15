
#include <iostream>
#include <vector>
#include <atlstr.h>

using namespace std;

struct ArrayBoundInfo {
    int startIdx;
    int endIdx;
    ArrayBoundInfo(int s, int e) {
        startIdx = s;
        endIdx = e;
    }
    int getRange() const { return endIdx - startIdx + 1; } 
};

// N次元配列のインデックスを一次元配列のインデックスに変換する関数
int ConvertNdTo1dIdx(const vector<int>& indices, const vector<ArrayBoundInfo>& vecArrayBoundInfo) {
    int index = 0;
    int factor = 1;
    for (int i = indices.size() - 1; i >= 0; i--) {
        index += (indices[i] - vecArrayBoundInfo[i].startIdx) * factor; // オフセットを引く
        factor *= vecArrayBoundInfo[i].getRange();
    }
    return index;
}

// Convert1dToNdIdx関数の定義
vector<int> Convert1dToNdIdx(int index, const vector<ArrayBoundInfo>& vecArrayBound) {
    vector<int> indices;
    for (auto ite = vecArrayBound.rbegin(); ite != vecArrayBound.rend(); ite++) {
        int range = ite->getRange();
        indices.push_back((index % range) + ite->startIdx); // N次元配列のインデックスを計算してベクトルに追加
        index /= range; 
    }
    reverse(indices.begin(), indices.end());
    return indices;
}

CStringW GetNextArrayIdxStr(const vector<int>& indices, const vector<ArrayBoundInfo>& vecArrayBoundInfo) {
    auto idx1d = ConvertNdTo1dIdx(indices, vecArrayBoundInfo);
    auto nextIdx = idx1d + 1;
    auto vecNextIdxNd = Convert1dToNdIdx(nextIdx, vecArrayBoundInfo);

    CStringW strNextIdx = L"[";

    for (auto i = 0; i < vecNextIdxNd.size(); i++) {
        auto idx = vecNextIdxNd[i];
        strNextIdx.AppendFormat(L"%d", idx);
        if (i != vecArrayBoundInfo.size() - 1) {
            strNextIdx.Append(L",");
        }
    }
    strNextIdx += L"]";
    return strNextIdx;
}

bool test1() {
    CStringW strExpected = L"[4,1,2]";
    vector<ArrayBoundInfo> vecArrayBound;
    vector<int> indeces{3, 4, 8};
    vecArrayBound.push_back(ArrayBoundInfo(2, 5));
    vecArrayBound.push_back(ArrayBoundInfo(1, 4));
    vecArrayBound.push_back(ArrayBoundInfo(2, 8));
}

int main()
{
    vector<ArrayBoundInfo> vecArrayBound;
    //vector<int> indeces{3, 0, 3, 4, 4};
    vector<int> indeces{3, 4, 8};
    vecArrayBound.push_back(ArrayBoundInfo(2, 5));
    vecArrayBound.push_back(ArrayBoundInfo(1, 4));
    vecArrayBound.push_back(ArrayBoundInfo(2, 8));
    /*vecArrayBound.push_back(ArrayBoundInfo(0, 4));
    vecArrayBound.push_back(ArrayBoundInfo(0, 4));
    vecArrayBound.push_back(ArrayBoundInfo(0, 4));
    vecArrayBound.push_back(ArrayBoundInfo(0, 4));
    vecArrayBound.push_back(ArrayBoundInfo(0, 4));*/
    auto str = GetNextArrayIdxStr(indeces, vecArrayBound);
}


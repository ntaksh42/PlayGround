﻿
#include <iostream>
#include <atlstr.h>
#include <vector>

int main()
{
    // 区切り文字
    const auto spliter = L"@";

    // 対象の文字列
    CStringW targetStr(L"HogePiyoFuga@type@3");

    std::vector<CStringW> vecElement;
    while (true) {
        const auto index = targetStr.Find(spliter, 0);
        if (index == -1) {
            vecElement.push_back(targetStr);
            break;
        }
        const auto& ele = targetStr.Mid(0, index);
        vecElement.push_back(ele);
        targetStr.Delete(0, index + 1);
    }
}

//--
#include <iostream>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

vector<string> split(const string& s, char delimiter)
{
    vector<string> tokens;
    string token;
    istringstream tokenStream(s);
    while (getline(tokenStream, token, delimiter))
    {
        tokens.push_back(token);
    }
    return tokens;
}

int main()
{
    string str = "Hello.World";
    char delimiter = '.';
    vector<string> tokens = split(str, delimiter);
    for (const auto& token : tokens)
    {
        cout << token << endl;
    }
}

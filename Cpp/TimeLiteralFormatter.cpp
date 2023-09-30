#include "LiteralFomatter.h"
#include <vector>
#include <map>
#include <string>

using namespace std;

CStringW LiteralFormatter::ToTimeString(__int64 value) {
    const vector<pair<wstring, __int64>> timeUnitsInNs = {
        {L"d", (__int64)24 * 60 * 60 * 1000 * 1000 * 1000},
        {L"h", (__int64)60 * 60 * 1000 * 1000 * 1000},
        {L"m", (__int64)60 * 1000 * 1000 * 1000},
        {L"s", (__int64)(1000 * 1000 * 1000)},
        {L"ms", (__int64)(1000 * 1000)},
        {L"us", (__int64)(1000)},
        {L"ns", (__int64)(1)},
    };

    wstring timeStr = L"";
    auto valueTmp = value;
    for (const auto& timePair : timeUnitsInNs) {
        const auto& strUnit = timePair.first;
        const auto timeMax = timePair.second;
        auto unitValue = (valueTmp / timeMax);
        if (unitValue != 0) {
            timeStr += to_wstring(abs(unitValue)) + strUnit;
        }
        // 余剰を次の単位に持ち越す
        valueTmp = (valueTmp % timeMax);
    }
    if (value < 0) timeStr = L"-" + timeStr;
    timeStr = (timeStr != L"") ? timeStr : L"0ns";
    return CStringW((L"T#" + timeStr).c_str());
}
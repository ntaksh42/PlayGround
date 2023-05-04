// [NOTE]
// MEMORY_BASIC_INFORMATION
// BaseAddress: ページ範囲の最初のアドレス。
// AllocationBase: ページ範囲が割り当てられたメモリ領域の最初のアドレス。
// AllocationProtect: メモリ領域が割り当てられたときの保護属性。
// RegionSize: ページ範囲のサイズ (バイト単位)。
// State: ページ範囲の状態 (MEM_COMMIT, MEM_FREE, MEM_RESERVE)。
// Protect: ページ範囲の現在の保護属性。
// Type: ページ範囲のタイプ (MEM_IMAGE, MEM_MAPPED, MEM_PRIVATE)。

//メモリ使用量 VS2022
// https://learn.microsoft.com/ja-jp/visualstudio/profiling/memory-usage?view=vs-2022


#include "windows.h"
#include <iostream>

HANDLE hProcess = GetCurrentProcess(); // 現在実行中のプロセスのハンドルを取得
    LPCVOID lpAddress = NULL; // 走査開始アドレスを0に設定
    MEMORY_BASIC_INFORMATION mbi; // 情報を格納する構造体
    SIZE_T dwLength = sizeof(mbi); // 構造体のサイズ

    while (VirtualQueryEx(hProcess, lpAddress, &mbi, dwLength) != 0) // 関数が0を返すまで繰り返す
    {
        std::cout << "Base address: " << mbi.BaseAddress << std::endl; // 領域の開始アドレスを表示
        std::cout << "Region size: " << mbi.RegionSize << std::endl; // 領域のサイズを表示
        std::cout << "State: " << mbi.State << std::endl; // 領域の状態を表示
        std::cout << "Protect: " << mbi.Protect << std::endl; // 領域の保護属性を表示
        std::cout << "Type: " << mbi.Type << std::endl; // 領域の種類を表示
        std::cout << "--------------------------" << std::endl;

        lpAddress = (LPVOID)((SIZE_T)mbi.BaseAddress + mbi.RegionSize); // 次の領域の開始アドレスに移動
    }

    
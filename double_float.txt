int main()
{
    // FLT_MAXのバイナリ表現
    long long ll = 0x47EFFFFFDFF07036;
    double* pd = (double*)(&ll);
    double value = *pd;

    // -FLT_MAXのバイナリ表現
    long long ll2 = 0xC7EFFFFFDFF07036;
    double* pd2 = (double*)(&ll2);
    double value2 = *pd2;


    // 参考サイト
//https://silight.hatenablog.jp/entry/2016/08/23/212820
}
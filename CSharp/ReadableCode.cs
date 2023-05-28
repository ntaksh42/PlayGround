
using System;

// [NOTE]
// 単数形と複数系は明確に区別する。
// 長い名前になるのはうまくクラス分割できていない可能性がある。
// 原則、関数内の宣言は使う直前で宣言する。スコープは極力短くなるようにする。
// 可能な限り否定形（負論理）はつかわない
// メソッドは基本動詞にする。
// 名前で表現されていないことはメソッドないでやらない。
// アクセス修飾子は明示的につける(sealedも。)4
// class名はソリューションエクスプローラでの並びも意識して命名する。
// わかりづらい処理はメソッド化して、関数名で思いを伝えるようにする。

// コメント
// コメントで悪いコードを読めるようにするようなことはしない。
// 余計なコメントはつけない。

namespace ReadableCode {
    public class Program
    {
        public static void Main(string[] args){
            Console.WriteLine("hello world");
        }

        // クラス名で継承元や、特性を表現する。
        private sealed class ProductFactory{
        }

        // インテリセンスを意識した名前にする。
        // 語尾をずらしておけばインテリセンスで並んで出る。
        private void UpdateProductName(Product p, string newName){
        }
        private void UpdateProductId(Product p, int newId){
        }

        // 解放が必要なオブジェクトはusingを使う。
        private static void ReadSettingFile(){

            using (var sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))){
                sr.Read();
            }
        }

        // 意図が明確な名前をつける
        // BAD: DataCheck check?何を？
        // GOOD : ExistsProductName
        private bool ExistsProductName(Product p){
            return !string.IsNullOrEmpty(p.Name);
        }

        // 必ずしたい処理はfinally
        private void DoSomething(){
            try{
            }finally{
                Console.Write("");
            }
        }

        //　できるだけ早期return するようにする。
        private bool CheckProduct (Product product){
            // bad: チェックを多用する。
            if(product != null){
                if(product.Name.Length > 3){
                    if(product.Name.StartsWith("A")){
                        return true;
                    }
                }
            }
            
            // good : 条件に合わない時は早期return する。
            if(product == null) return false;
            if(product.Name.Length <= 2) return false;
            return product.Name.StartsWith("A");
        }

        // 型チェックはasを使うようにする。
        private static void CheckType(object obj){
            
            // bad:キャストが二回起きて冗長。
            if(obj is Product){
            
                var p = (Product)obj;
                Console.WriteLine(p.ID);
            }

            // Good
            var product = obj as Product;
            if(product != null){
                Console.WriteLine(p.ID);
            }
        }

        private class Product
        {
            public int ID {get;}
            public string Name { get; set; }

            public Product(int id, string name)
            {
                ID = id;
                Name = name;
            }
        } 

        private enum Conditiuon{
            Setting,
            Stop,
            Error,
        }
    }
}

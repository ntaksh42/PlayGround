using System;
using System.ComponentModel;

namespace EffectiveCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var b = new Item16.Derived("コンストラクタから渡す。");
        }
    }

    namespace Item1
    {
        // ローカル変数はvar を使う
        // コンパイラが最適な型を決めてくれるのでそれにしたがっておくのが吉
        // 明示的に型を指定すると、パフォーマンスに影響がでることがある。

        class Contents
        {
            private readonly List<Customer> _customers = new List<Customer>(){
                new Customer("tanka", 5),
                new Customer("satou", 10),
                new Customer("kato", 16),
            };

            public void Sample()
            {
                var q = from c in _customers
                        select c.Name.Contains("a");
            }


            private class Customer
            {
                public string Name { get; set; }
                public int Id { get; set; }

                public Customer(string name, int id)
                {
                    Name = name;
                    Id = id;
                }
            }
        }
    }

    namespace Item2
    {
        // const よりもreadonlyを使うこと
        // const : コンパイル時定数
        // readonly : 実行時定数
        class Program
        {
            // const はコンパイル時に定数が確定するので実行速度で若干有利
            // 将来にわたっても変更がなさそうな値に対して使う。
            private const int CONST_VALUE = 10;

            // readonly は実行時に値が解決される。
            private readonly int _memberInt;

            public Program()
            {
            }
        }
    }

    namespace Item3
    {
        // キャストには is ,asを使用する。
        // is, as でのキャストは意味論的に正しい時にのみ、正しい結果を返す。
        // キャスト演算の場合は思わぬ結果を返すことがある。
    }

    namespace Item4
    {
        // string.Formatではなく、
        // 補間文字列を使う。
        // 補間文字列のほうが可読性がよい。
        class Program
        {
            public static void Do()
            {
                var name = "tanaka";
                System.Console.WriteLine(string.Format("Hello, {0}", name));
                System.Console.WriteLine(string.Format($"Hello, {name}"));
            }
        }
    }

    namespace Item5
    {
        // カルチャ固有の文字列よりも
        // FormatableStringを使用すること。

        public class Program
        {
            public static string ToGerman(FormattableString src)
            {
                return string.Format(null,
                                     System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
                                     src.Format,
                                     src.GetArguments());
            }
        }
    }

    namespace Item6
    {
        public class Program : INotifyPropertyChanged
        {
            // 文字列指定のAPIを使用しない。
            private string _name = string.Empty;
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name == null) return;
                    _name = value;
                    // nameof 使っておけばプロパティの名前が変わっても、イベントの引数名
                    // にも変更が繁栄される。
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
            public event PropertyChangedEventHandler? PropertyChanged;
        }
    }

    namespace Item7
    {
        // デリケードでコールバックを表現する。

        public class Program
        {
            public static void Do()
            {
                Enumerable.Range(1, 100).ToList().ForEach(n => System.Console.WriteLine(n));
                var oddNumbers = Enumerable.Range(1, 100).ToList().RemoveAll(n => (n % 2 == 0));
            }
        }
    }

    namespace Item8
    {
        // イベントの呼び出し時にnull条件演算子を使用する。
        public class EventSource
        {
            private int _counter = 0;
            public EventHandler<int> Updated;
            public void RaiseUpdates()
            {
                _counter++;
                Updated(this, _counter);
            }
        }
    }

    namespace Item9
    {
        // ボックス化およびボックス化解除を最小限に抑える。
        public class Program
        {
            public void Do()
            {
                var i = 10;
                object o = i;// ボックス化が起きる
            }    
        }
    }

    namespace Item13
    {
        // static メンバを適切に初期化すること。
        // 基本的にはstatic メンバも初期化子で初期化すればよいか,
        // 複雑な初期化処理が必要な場合はstaticコンストラクタを使うのが吉。
        // シングルトンパターンはstatic コンストラクタを使うのが一般的。
        public class Singlton
        {
            private static readonly Singlton _singlton;
            // static メンバはstaic コンストラクタで初期化する。
            static Singlton(){
                _singlton = new Singlton();
            }
            
            public static Singlton GetInstance() => _singlton;

            private Singlton()
            {
            }
        }        
    }

    namespace Imte14 {
        // 初期ロジックの重複は最小限にする。
    }

    namespace Item15
    {
        // 不要なオブジェクトの生成を避ける
        class Program
        {
            public static void Do(){
                Enumerable.Range(1, 100).ToList().ForEach(i => {
                    // var pen = new Pen(); loopの外でいいものは外でやる。
                });
            }
        }
    }

    namespace Item16
    {
        // コンストラクタ内で仮想メソッドを呼び出さないこと。
        class B
        {
            protected B() {
                // これNG。実は派生クラスのメンバ変数が派生クラスのコンストラクタで
                // 初期化される前に呼ばれて、「初期化子で設定」が出力される。
                VFunc();
            }    
            protected virtual void VFunc(){
                System.Console.WriteLine("Bの仮想メソッド");
            }
        }

        class Derived : B {
            private readonly string _msg = "初期化子で設定";

            public Derived(string msg)
            {
                _msg = msg;
            }

            protected override void VFunc()
            {
                System.Console.WriteLine(_msg);
            }
        }
    }
}
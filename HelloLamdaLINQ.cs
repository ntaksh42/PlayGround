// [NOTE]
// VSCODEでC#のプログラムを実行する手順
// 1.Cmdで プロジェクトを作成する。
//  dotnet new console -o "sampleConsole"
// 2. code sampleConsole
// 　でプロジェクトをVSCODEで開く。
// 3.開いたときに左下に出るポップアップで、YESを選択する。

using System;
using System.Linq;

namespace HelloLINQ {
    class Program{
        static List<Product> Products = new List<Product>
            {
                new Product(1, "hoge", 100),
                new Product(2, "piyo", 200),
                new Product(3, "fuga", 300),
                new Product(4, "foo", 400),
                new Product(5, "neko", 400),
                new Product(5, "usagi", 300),
            }; 

        static int[] IntArr = new []{
                1, 13, 45, 2, 3, 4, 56, 5, 6, 7, 8, 9, 10, 1, 3, 5
            };
        
        static List<string> Names = new List<string>
            {
                "takashi",
                "taro",
                "hanako",
            };

        static void Main(string[] args){
            QuerySample();
            MethodQuerySample();
        }



        public static void QuerySample() {
            // クエリ構文
            var oddNums = from num in IntArr
                         where num % 2 == 0
                         orderby num descending // 降順
                         select num;

            var nameContainsK = from name in Names
                                where name.Contains("k")
                                select name;

            var productNamesPriceOver200 = from p in Products
                                      where p.Price >= 200
                                      orderby p.Price //昇順
                                      select p.Name;

            // let キーワード
            var sentences = new List<string>
            {
                "My name is Hoge.",
                "Nice to meet you",
                "I like apple.",
            };
            var result = from sentence in sentences
                         let words = sentence.Split(" ")
                         from word in words
                         select word;

            // group by キーワード
            // Priceをキーにグループ分けする。
            var productsGroupByPrice = from p in Products
                                       group p by p.Price;

            foreach (var group in productsGroupByPrice)
            {
                Console.WriteLine(group.Key);
                foreach(var item in group) {
                    Console.WriteLine($"ID:{item.Id} Name:{item.Name} Price:{item.Price}");
                }
            }

            // join　キーワード(innerJoin)
            var sato = new Person("sato","toshiya");
            var yamada = new Person("yamada","taro");
            var kato = new Person("kato","kouji");
            var matui = new Person("matui","hideki");
            
            var people = new List<Person>
            {
                sato,
                yamada,
                kato,
                matui,
            };

            var pets = new List<Pet>
            {
                new Pet("shiro", sato),
                new Pet("tama", yamada),
                new Pet("mugi", kato),
                new Pet("mike", matui),
            };

            var query = from person in people
                        join pet in pets
                        on person equals pet.Owner
                        select new {OwnerName = person.FirstName, PetName = pet.Name};
        }

        public static void MethodQuerySample() {
            
            // 遅延実行(この段階ではクエリの条件が設定されただけ。)
            // 即時実行したいなら ToListする。
            var over5 = IntArr.Where(i => i > 5);

            // OfType で特定の型のみ取り出す。
            object[] objects = {1, 2, 3, 4, "AAA" ,"BBB", IntArr};
            var onlyInt = objects.OfType<int>();// int型だけ取り出す。

            //  orderby
            // price基準で昇順にする。
            var ascendingByPrice = Products.OrderBy(p => p.Price);
            // price基準で降順にする。
            var descendingByPrice = Products.OrderByDescending(p => p.Price);

            // groupby
            var gruopByPrice = Products.GroupBy(p => p.Price);

            // IEnumerableの関数
            var rep = Enumerable.Repeat(1, 10);//1を10個返す。
            var range = Enumerable.Range(15 , 7);// 15から7までの範囲を返す。

            //// SequenceEqual
            var l1 = new List<string> {"AAA", "BBB"};
            var l2 = new List<string> {"AAA", "BBB"};
            l1.SequenceEqual(l2);//中身が全部一緒かチェックする。順番も一致してるときにTRUE

            //// Distinct(重複を削除)
            var distinct = IntArr.Distinct();

            //// Intersect(両方にあるものだけ)
            var intArrTmp = new List<int> {1, 2, 3 };
            var intersect = IntArr.Intersect(intArrTmp);

            //// Union (どちらかにあるものをとる)
            var union = IntArr.Union(intArrTmp);

            //// Except(引数で渡したListに含まれないものだけ取る)
            var ex = IntArr.Except(intArrTmp);

            //// Skip
            var skipFirst = Products.Skip(1);
            var skipWhileLess100 = Products.SkipWhile(p => p.Price > 100);

            //// Take
            var secondProduct = Products.Take(2);
            var takeWhileIdLess3 = Products.TakeWhile(p => p.Id < 3);

            //// ALL Any
            var allOver0 = IntArr.All(i => i > 0);
            var anyOver100 = IntArr.Any(i => i > 100);
        }

        private record Product(int Id, string Name, int Price);       
        private record Person(string FirstName, string LastName);
        private record Pet(string Name, Person Owner);
    }
}


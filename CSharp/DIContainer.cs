using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    internal interface IMyService
    {
        public string GetName(int code);
    }

    internal class MyService : IMyService
    {
        public string GetName(int code)
        {
            switch (code)
            {
                case 0: return "hoge";
                case 1: return "piyo";
                case 2: return "fuga";
                default: return "neko";
            }
        }
    }

    internal class MyClass
    {
        public string GetCurrentTimeString()
        {
            return DateTime.Now.ToString();
        }
    }

    internal class MyClass2 
    {
        public void SayHello() 
            => Console.WriteLine("Hello!!");
    }
    class Program
    {
        static void Main(string[] args)
        {
            // DIコンテナ使える.Netのクラスライブラリ。
            // Nugetからとってくれば使える。
            var serviceCollection = new ServiceCollection();

            // AddTransientで登録すると毎回別インスタンスがとれる
            serviceCollection.AddTransient<MyService>();

            // AddSingletonで登録する毎回同じインスタンス
            serviceCollection.AddSingleton<MyClass>();

            // AddScopedで登録すると同じスコープ内だと同じインスタンス
            serviceCollection.AddScoped<MyClass2>();

            var provider = serviceCollection.BuildServiceProvider();
            var myService = provider.GetService<MyService>();
            Console.WriteLine(myService?.GetName(3));

            var myClass = provider.GetService<MyClass>();
            Console.WriteLine(myClass?.GetCurrentTimeString());
        }
    }
    
}

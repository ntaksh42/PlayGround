namespace NullProglem
{
    // NOTE
    // そのクラスのクラアントがNullチェックしなければならないような作りにしないのが基本。
    // ① nullは返さない、渡さない。
    class Equipment {
        // 「装備なし」といった状態もNullでは表現すべきでない。
        // きちんとそれ相当の状態を用意すべき。
        public int Defence { get;}
        public static readonly Equipment EmptyState = new Equipment("装備なし", 0, 0, 0);
        private readonly string _name;
        private readonly int _price; 
        private readonly int _magicDefence;

        public Equipment(string name, int price, int defence, int magicDefence)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentException();
            _name = name;
            _price = price;
            Defence = defence;
            _magicDefence = magicDefence;            
        }
        public Equipment DeepCopy(){
            return new Equipment(_name, _price, Defence, _magicDefence);
        }
    }

    class Member {
        private Equipment _head;
        private Equipment _body;
        private Equipment _arm;
        private int _defence = 0;

        public Member(Equipment head, Equipment body, Equipment arm, int defence)
        {
            _head = head;
            _body = body;
            _arm = arm;
            _defence = defence;
        }

        public void ChangeEquipment(Equipment head, Equipment body, Equipment arm)
        {
            _head = head.DeepCopy();
            _body = body.DeepCopy();
            _arm = arm.DeepCopy();
        }

        public void TakeOffAllEquipment(){
            // ここでnullを代入するようなコードを書いてしまうと、ほかの処理で
            // nullチェックが必要になるなど、null安全ではないコードになってしまう。
            _head = Equipment.EmptyState;
            _body = Equipment.EmptyState;
            _arm = Equipment.EmptyState;
        }
        
        public int GetTotalDefence(){
            var total = _defence;
            total += _head.Defence;
            total += _body.Defence;
            total += _arm.Defence;
            return total;
        }
    }
}
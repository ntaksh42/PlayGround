// NOTE
// ファーストクラスコレクションとは、配列やコレクションをクラスにラップして
// 管理させる設計パターン

using System.Linq;

internal class Member
{
    public int Id { get;}
    public bool IsAlive() => true;//dummy
    
    public Member(int id)
    {
        Id = id;
    }
}

internal class Patry
{
    static readonly int MAX_MEMBER_COUNT = 4;
    
    //元の _membersが変更されないようにする。 
    private readonly IReadOnlyList<Member> _members;
    public Patry()
    {
        _members = new List<Member>();
    }

    private Patry(List<Member> members)
    {
        _members = members;
    }

    // 追加対象のメンバがすでにParty内にいた場合、
    // Partyが満員の場合は今のPartyをそのまま返す。
    public Patry AddMember(Member member) 
    {
        // 必ず、membersはコピーして返すようにする。
        if(IsExistMember(member)) return new Patry(_members.ToList());
        if(IsFull()) return new Patry(_members.ToList());

        var newMembers = new List<Member>(_members);
        newMembers.Add(member);
        return new Patry(newMembers);
    }

    // 直接参照を返すようなことは絶対しない。コピーして返すか、IEnumrable / IReadOnlyListなどを使って
    // 返すようにする。
    public IReadOnlyList<Member> GetMembers() => _members;

    private bool IsExistMember(Member member) => _members.Any(m => m.Id == member.Id);
    private bool IsFull() => _members.Count == MAX_MEMBER_COUNT;
}  
using System.Drawing;

namespace ReadDataFromExcel
{
    public class MemberDto

    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public MemberDto() { }
        public MemberDto(string id, string name , string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}

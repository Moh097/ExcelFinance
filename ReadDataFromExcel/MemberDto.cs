using System.Drawing;

namespace ReadDataFromExcel
{
    public class MemberDto

    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Membership { get; set; }
        public Image Photo { get; set; }
        public string Address { get; set; }
        public string JoinDate { get; set; }
        public MemberDto() { }
        public MemberDto(string id, string name, Image photo, string membership, string address, string joinDate)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Membership = membership;
            Address = address;
            JoinDate = joinDate;
        }
    }
}
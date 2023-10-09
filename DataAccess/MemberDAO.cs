using BusinessObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataAccess;
internal class MemberDAO
{

    // Get default user from appsettings
    private MemberObject GetDefaultMember()
    {
        var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

        string email = config["account:defaultAccount:email"];
        string password = config["account:defaultAccount:password"];


        return new MemberObject
        {
            MemberID = 1,
            Email = "admin@fstore.com",
            Password = "admin@@",
            City = "",
            Country = "",
            MemberName = "Admin"
        };

    }

    // Initialize MemberList
    private static List<MemberObject> members = new List<MemberObject>
        {
            new MemberObject
            {
                MemberID = 2,
                MemberName = "Nguyễn Dương",
                Email = "duong3214@gmail.com",
                Password = "123456",
                City = "Quy Nhon",
                Country = "Viet Nam"
            },
            new MemberObject
            {
                MemberID = 3,
                MemberName = "Trần Bảo",
                Email = "tranbao@gmail.com",
                Password = "abcxyz",
                City = "Da Nang",
                Country = "Viet Nam"
            },
            new MemberObject
            {
                MemberID = 4,
                MemberName = "Khoi",
                Email = "khoigialai@gmail.com",
                Password = "123456",
                City = "Bangkok",
                Country = "Thailand"
            },
            new MemberObject
            {
                MemberID = 5,
                MemberName = "Hang",
                Email = "Hangpt@gmail.com",
                Password = "123456",
                City = "Ky Anh",
                Country = "Viet Nam"
            },new MemberObject
            {
                MemberID = 6,
                MemberName = "bluemcq",
                Email = "blue@gmail.com",
                Password = "123456",
                City = "Ky Anh",
                Country = "Viet Nam"
            }


        };
    private MemberDAO()
    {
        MemberObject DefaultAdmin = GetDefaultMember();
        if (DefaultAdmin != null)
        {
            members.Add(DefaultAdmin);
        }
    }

    // Using Singleton Pattern
    private static MemberDAO? instance = null;
    private static object instanceLook = new object();

    public static MemberDAO Instance
    {
        get
        {
            lock (instanceLook)
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }
    }

    public List<MemberObject> GetMembersList => members;

    public MemberObject Login(string Email, string Password)
    {
        return members.SingleOrDefault(mb
            => mb.Email!.Equals(Email, StringComparison.Ordinal)
            && mb.Password!.Equals(Password))!;
    }

    public MemberObject GetMember(int MemberId)
    {
        return members.SingleOrDefault(mb => mb.MemberID == MemberId)!;
    }
    public MemberObject GetMember(string MemberEmail)
    {
        return members.SingleOrDefault(mb => mb.Email!.Equals(MemberEmail))!;
    }
    public void AddMember(MemberObject member)
    {
        if (member == null)
        {
            throw new Exception("Member is undefined!!");
        }

        if (GetMember(member.MemberID) == null && GetMember(member.Email!) == null)
        {
            members.Add(member);
        }
        else
        {
            throw new Exception("Member is existed!!");
        }
    }
    public void Update(MemberObject member)
    {
        if (member == null)
        {
            throw new Exception("Member is undefined!!");
        }
        MemberObject mem = GetMember(member.MemberID);
        if (mem != null)
        {
            var index = members.IndexOf(mem);
            members[index] = member;
        }
        else
        {
            throw new Exception("Member does not exist!!");
        }
    }
    public void Delete(int MemberId)
    {
        MemberObject member = GetMember(MemberId);
        if (member != null)
        {
            members.Remove(member);
        }
        else
        {
            throw new Exception("Member does not exist!!");
        }
    }

    public IEnumerable<MemberObject> SearchMember(int id)
    {
        IEnumerable<MemberObject>? searchResult = null;

        var memberSearch = from member in members
                           where member.MemberID == id
                           select member;
        searchResult = memberSearch;

        return searchResult;
    }
    public IEnumerable<MemberObject> SearchMember(string name)
    {
        IEnumerable<MemberObject>? searchResult = null;

        var memberSearch = from member in members
                           where member.MemberName!.ToLower().Contains(name.ToLower())
                           select member;
        searchResult = memberSearch;

        return searchResult;
    }

    public IEnumerable<MemberObject> FilterMemberByCountry(string country, IEnumerable<MemberObject> searchList)
    {
        IEnumerable<MemberObject>? searchResult = null;

        var memberSearch = from member in searchList
                           where member.Country == country
                           select member;
        if (country.Equals("All"))
        {
            memberSearch = from member in searchList
                           select member;
        }
        searchResult = memberSearch;

        return searchResult;
    }

    public IEnumerable<MemberObject> FilterMemberByCity(string country, string city, IEnumerable<MemberObject> searchList)
    {
        IEnumerable<MemberObject>? searchResult = null;

        var memberSearch = from member in searchList
                           where member.City == city
                           select member;
        if (city.Equals("All"))
        {
            memberSearch = from member in searchList
                           where member.Country == country
                           select member;
            if (country.Equals("All"))
            {
                memberSearch = from member in searchList
                               select member;
            }
        }
        searchResult = memberSearch;

        return searchResult;
    }
}

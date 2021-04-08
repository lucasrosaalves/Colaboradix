using System;

namespace Colaboradix.Domain.Enumerations
{
    public class MemberType
    {
        public static MemberType Admin = new MemberType(1, "Admin");
        public static MemberType Regular = new MemberType(2, "Regular");

        public MemberType(byte id, string name)
        {
            Id = id;
            Name = name;
        }

        protected MemberType() { }


        public static MemberType FromId(byte id)
        {
            switch (id)
            {
                case 1:
                    return Admin;
                case 2:
                    return Regular;
            }
            throw new ArgumentException($"Could not create a member type with id {id}");
        }

        public byte Id { get; }
        public string Name { get; }
    }
}

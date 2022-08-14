using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    static class Defs
    {
        public enum Rank
        {
            Kit,
            Apprentice,
            Warrior,
            Elder,
            Deputy,
            Leader,
            Loner
        }

        public enum Gender
        {
            SheCat,
            Tom,
            Other
        }

        public static Dictionary<Rank, string> rankDict = new Dictionary<Rank, string>()
        {
            {Rank.Kit, "Kit" },
            {Rank.Apprentice, "Apprentice"},
            {Rank.Warrior, "Warrior"},
            {Rank.Elder, "Elder"},
            {Rank.Deputy, "Deputy"},
            {Rank.Leader, "Leader"},
            {Rank.Loner, "Loner" }
        };

        public static Dictionary<Gender, string> genderDict = new Dictionary<Gender, string>()
        {
            {Gender.SheCat, "She-Cat"},
            {Gender.Tom, "Tom" },
            {Gender.Other, "Other" }
        };
    }
}

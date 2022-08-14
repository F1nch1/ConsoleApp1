using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    struct Cat
    {
        //Stats
        public string name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(prefix) && !string.IsNullOrWhiteSpace(suffix))
                {
                    return (prefix + suffix);
                }
                if (string.IsNullOrWhiteSpace(suffix))
                {
                    return prefix;
                }
                else
                {
                    return "error";
                }
            }
        }
        public int age;
        public string rank
        {
            get { return Defs.rankDict[rankAccesor]; }
        }
        public string gender
        {
            get { return Defs.genderDict[genderAccesor]; }
        }
        public string prefix;
        public string suffix;

        //Accesors
        public Defs.Rank rankAccesor;
        public Defs.Gender genderAccesor;

        //Initializer
        public Cat(string pre, string suf, Defs.Rank rankAssigner, Defs.Gender genderAssigner, int ageAssigner)
        {
            prefix = pre;
            suffix = suf;
            rankAccesor = rankAssigner;
            genderAccesor = genderAssigner;
            age = ageAssigner;
        }
        
    }
}

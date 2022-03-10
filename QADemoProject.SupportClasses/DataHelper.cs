using Bogus;
using System;

namespace QADemoProject.SupportClasses
{
    //NOTE - Dynamic Data generation happens here
    public static class DataHelper
    {
        public static string RandomPhoneNumber()
        {
            var faker = new Faker();
            //Create Random Phone Number
            var rnd1 = faker.Random.Number(100, 999).ToString();
            var rnd2 = faker.Random.Number(100, 999).ToString();
            var rnd3 = faker.Random.Number(1000, 9999).ToString();
            return rnd1 + rnd2 + rnd3;
        }

        public static string RandomNumberGenerator()
        {
            var faker = new Faker();
            //Create Random Phone Number
            var rnd1 = faker.Random.Number(100, 999).ToString();

            return rnd1;
        }


        public enum StateAbbr
        {
            AL,
            AK,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            DC,
            FL,
            GA,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            OH,
            OK,
            OR,
            PA,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VA,
            WA,
            WV,
            WI,
            WY
        }
    }
}

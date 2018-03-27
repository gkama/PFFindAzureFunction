using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pffind
{
    public static class UnitTest
    {
        //Index fund test case
        public static PFFind.data FIndexFund()
        {
            PFFind.data data = new PFFind.data()
            {
                id = "unit_testid",
                title = "This is a test to find fidelity index funds",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is FUSVX, then there is this FSEVX"
            };
            return data;
        }
        public static PFFind.data FIndexFund_2()
        {
            PFFind.data data = new PFFind.data()
            {
                id = "unit_testid",
                title = "This is a test to not find fidelity index funds",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is FUSV (this is incorrect), then there is this fsevx (this is correct length"
                            + " but not capitalized)" + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };
            return data;
        }



        //401k test case
        public static PFFind.data Four01k()
        {
            PFFind.data data = new PFFind.data()
            {
                id = "unit_testid",
                title = "This is a test to find 401k and maybe 401(k)",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is 401k, then there is this four oh 1 k"
            };
            return data;
        }
        public static PFFind.data Four01k_2()
        {
            PFFind.data data = new PFFind.data()
            {
                id = "unit_testid",
                title = "This is a test to not find four01k",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is four01k, then there is this four oh 1 k"
            };
            return data;
        }
    }
}
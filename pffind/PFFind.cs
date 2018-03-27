using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;

using Newtonsoft.Json;

namespace pffind
{
    public class PFFind
    {
        private List<result> Data { get; set; }

        //Constructor
        public PFFind()
        {
            this.Data = new List<result>();
        }

        //Find posts on PF
        private async Task<List<result>> GetData()
        {
            var appSettings = "https://www.reddit.com/r/personalfinance.json";
            try
            {
                HttpClient client = new HttpClient();
                List<result> _Data = new List<result>();
                string response = await client.GetStringAsync(appSettings);

                //Serialize the json and loop through it
                dynamic jsonObj = JsonConvert.DeserializeObject(response);
                foreach (var obj in jsonObj.data.children)
                {
                    if (obj.data.author != "AutoModerator")
                    {
                        data _data = new data()
                        {
                            id = obj.data.id,
                            title = obj.data.title,
                            score = obj.data.score,
                            url = obj.data.url,
                            num_comments = obj.data.num_comments,
                            subreddit_id = obj.data.subreddit_id,
                            selftext = obj.data.selftext
                        };
                        result _child = new result()
                        {
                            id = obj.data.id,
                            data = _data
                        };
                        _Data.Add(_child);
                    }
                }
                return _Data;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task<List<result>> Find(string searchFor)
        {
            List<result> toReturn = new List<result>();
            this.Data = await this.GetData();
            if (this.Data.Count == 0) return toReturn;
            foreach (result r in this.Data)
            {
                //If the title contains what we are looking for
                //Instantly store it
                if (r.data.title.Contains(searchFor.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                    toReturn.Add(r);
                //Else if does not, check the text itself
                else if (r.data.selftext.Contains(searchFor.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                    toReturn.Add(r);
            }
            return toReturn;
        }

        //Override to string to get the data as a string
        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder();
            foreach (result r in this.Data)
                toReturn.Append(string.Format("found {0}", r.id)).Append("/r/n");

            return string.IsNullOrEmpty(toReturn.ToString()) ? toReturn.ToString() : "";
        }


        public class result
        {
            public string id { get; set; }
            public data data { get; set; }
        }
        public class data
        {
            public string id { get; set; }
            public string title { get; set; }
            public int score { get; set; }
            public string url { get; set; }
            public int num_comments { get; set; }
            public string subreddit_id { get; set; }

            private string _selfText;
            public string selftext
            {
                get { return _selfText; }
                set
                {
                    //Set only first 1000 characters
                    this._selfText = value.Length <= 1000 ? value : value.Substring(0, 1000) + "...";
                    this._selfText = this._selfText.Contains("\n\n") ? this._selfText.Replace("\n\n", " ") : this._selfText;
                }
            }
        }
    }
}
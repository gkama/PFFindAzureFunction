using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace pffind
{
    public class Four01k
    {
        public List<PFFind.data> Funds401k { get; set; }
        static readonly string four01k = "401k|401(k)|401|401{k}";
        public Four01k(PFFind.data data)
        {
            this.Funds401k = new List<PFFind.data>();
            this.Found401k(data);
        }

        //Is it a Fidelity Index Fund
        //They all start with capital F and have 5 characters
        private bool Found401k(PFFind.data data)
        {
            //First match, check title
            if (data.title.Contains(four01k))
               if (!Funds401k.Contains(data)) this.Funds401k.Add(data);
            
            //Second match, check text
            if (data.selftext.Contains(four01k))
                if (!Funds401k.Contains(data)) this.Funds401k.Add(data);

            return this.Funds401k.Count > 0 ? true : false;
        }

        //Override toString() to return all the funds
        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder();
            foreach (PFFind.data d in this.Funds401k) toReturn.Append(d.ToString()).Append('\n');
            string _toReturn = toReturn.ToString().TrimEnd('\n');

            return !string.IsNullOrEmpty(_toReturn) ? _toReturn : "";
        }
    }
}

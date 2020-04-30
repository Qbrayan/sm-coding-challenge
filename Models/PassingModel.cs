using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sm_coding_challenge.Models
{
    [DataContract]
    public class PassingModel
    {
        [DataMember(Name = "player_id")]
        public string Id { get; set; }

        [DataMember(Name = "entry_id")]
        public string EntryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "position")]
        public string Position { get; set; }

        [DataMember(Name = "yds")]
        public string Yds { get; set; }

        [DataMember(Name = "att")]
        public string Att { get; set; }

        [DataMember(Name = "tds")]
        public string Tds { get; set; }

        [DataMember(Name = "cmp")]
        public string Cmp { get; set; }

        [DataMember(Name = "int")]
        public string Int { get; set; }
    }
}

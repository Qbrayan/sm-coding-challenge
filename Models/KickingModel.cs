using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sm_coding_challenge.Models
{
    [DataContract]
    public class KickingModel
    {
        [DataMember(Name = "player_id")]
        public string Id { get; set; }

        [DataMember(Name = "entry_id")]
        public string EntryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "position")]
        public string Position { get; set; }


        [DataMember(Name = "fld_goals_made")]
        public string GoalsMade { get; set; }

        [DataMember(Name = "fld_goals_att")]
        public string GoalsAtt { get; set; }

        [DataMember(Name = "extra_pt_made")]
        public string ExtraMade { get; set; }

        [DataMember(Name = "extra_pt_att")]
        public string ExtraAtt { get; set; }


    }
}

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ITactDemo.Grid
{
    [DataContract]
    public class Filter
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public Rule[] rules { get; set; }
        public static Filter Create(string jsonData)
        {
            try
            {
                if (jsonData.Length <= 0)
                    return new Filter { groupOp = "", rules = new Rule[0] };
                else
                    return JsonConvert.DeserializeObject<Filter>(jsonData);
            }
            catch
            {
                return null;
            }
        }
    }
}

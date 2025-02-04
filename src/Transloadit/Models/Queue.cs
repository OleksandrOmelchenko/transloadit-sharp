using Newtonsoft.Json;

namespace Transloadit.Models
{
    public class _06f4a4b760d84e6191d5d1b25b3190e1
    {
        [JsonProperty("exported")]
        public Exported Exported { get; set; }
    }

    public class PriorityJobSlots
    {
        public int Count { get; set; }

        public Slots Slots { get; set; }
    }

    public class QueueResponse
    {
        public string Ok { get; set; }

        public string Message { get; set; }

        public PriorityJobSlots PriorityJobSlots { get; set; }
    }

    public class Slots
    {
        [JsonProperty("06f4a4b760d84e6191d5d1b25b3190e1")]
        public _06f4a4b760d84e6191d5d1b25b3190e1 _06f4a4b760d84e6191d5d1b25b3190e1 { get; set; }
    }
}

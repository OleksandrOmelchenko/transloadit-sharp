using System.Collections.Generic;

namespace Transloadit.Models
{
    public class PriorityJobSlots
    {
        public int Count { get; set; }

        public Dictionary<string, Dictionary<string, Dictionary<string, int>>> Slots { get; set; }
    }

    public class QueueResponse : ResponseBase
    {
        public PriorityJobSlots PriorityJobSlots { get; set; }
    }
}

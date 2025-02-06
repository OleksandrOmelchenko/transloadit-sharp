using System.Collections.Generic;

namespace Transloadit.Models.Queues
{
    public class QueueResponse : ResponseBase
    {
        public PriorityJobSlots PriorityJobSlots { get; set; }
    }

    public class PriorityJobSlots
    {
        public int Count { get; set; }

        public Dictionary<string, Dictionary<string, Dictionary<string, int>>> Slots { get; set; }
    }
}

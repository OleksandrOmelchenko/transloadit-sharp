using System.Collections.Generic;

namespace Transloadit.Models.Queues
{
    /// <summary>
    /// Represents queue response.
    /// </summary>
    public class QueueResponse : ResponseBase
    {
        /// <summary>
        /// Priority job slots.
        /// </summary>
        public PriorityJobSlots PriorityJobSlots { get; set; }
    }

    /// <summary>
    /// Represents priority job slots information.
    /// </summary>
    public class PriorityJobSlots
    {
        /// <summary>
        /// Priority job slots count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Slots information containing Step names, job ids and count.
        /// </summary>
        public Dictionary<string, Dictionary<string, Dictionary<string, int>>> Slots { get; set; }
    }
}

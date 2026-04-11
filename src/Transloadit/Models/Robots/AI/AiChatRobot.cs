using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/ai-chat/">/ai/chat</a> Robot.
    /// </summary>
    public class AiChatRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Optional expensive metadata extraction settings.
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// The model to use. Set to <c>auto</c> to let Transloadit choose.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Optional JSON Schema expected from the model output.
        /// </summary>
        [JsonProperty("schema")]
        public string Schema { get; set; }

        /// <summary>
        /// Prompt or message history to send.
        /// </summary>
        [JsonProperty("messages")]
        public AnyOf<string, List<AiChatMessage>> Messages { get; set; }

        /// <summary>
        /// Optional system prompt.
        /// </summary>
        [JsonProperty("system_message")]
        public string SystemMessage { get; set; }

        /// <summary>
        /// Reasoning effort level.
        /// </summary>
        [JsonProperty("reasoning_effort")]
        public string ReasoningEffort { get; set; }

        /// <summary>
        /// Template credential names used by the robot.
        /// </summary>
        [JsonProperty("credentials")]
        public AnyOf<string, List<string>> Credentials { get; set; }

        /// <summary>
        /// Uses Transloadit test credentials.
        /// </summary>
        [JsonProperty("test_credentials")]
        public bool? TestCredentials { get; set; }

        /// <summary>
        /// MCP servers available for tool calls.
        /// </summary>
        [JsonProperty("mcp_servers")]
        public List<AiChatMcpServer> McpServers { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/ai-chat/">/ai/chat</a> Robot.
        /// </summary>
        public AiChatRobot()
        {
            Robot = "/ai/chat";
        }
    }

    /// <summary>
    /// Represents a single chat message payload.
    /// </summary>
    public class AiChatMessage
    {
        /// <summary>
        /// Message role.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// Message content.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    /// <summary>
    /// Represents an MCP server configuration.
    /// </summary>
    public class AiChatMcpServer
    {
        /// <summary>
        /// Server URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Optional auth mode.
        /// </summary>
        [JsonProperty("auth")]
        public string Auth { get; set; }

        /// <summary>
        /// Optional request headers.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}

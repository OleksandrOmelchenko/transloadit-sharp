using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/ai-chat/">/ai/chat</a> Robot.
    /// </summary>
    public class AiChatRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The model to use. Set to <c>auto</c> to let Transloadit choose.
        /// </summary>
        [TransloaditJsonName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Optional JSON Schema expected from the model output.
        /// </summary>
        [TransloaditJsonName("schema")]
        public string Schema { get; set; }

        /// <summary>
        /// Prompt or message history to send.
        /// </summary>
        [TransloaditJsonName("messages")]
        public AnyOf<string, List<AiChatMessage>> Messages { get; set; }

        /// <summary>
        /// Optional system prompt.
        /// </summary>
        [TransloaditJsonName("system_message")]
        public string SystemMessage { get; set; }

        /// <summary>
        /// Reasoning effort level.
        /// </summary>
        [TransloaditJsonName("reasoning_effort")]
        public string ReasoningEffort { get; set; }

        /// <summary>
        /// Template credential names used by the robot.
        /// </summary>
        [TransloaditJsonName("credentials")]
        public AnyOf<string, List<string>> Credentials { get; set; }

        /// <summary>
        /// Uses Transloadit test credentials.
        /// </summary>
        [TransloaditJsonName("test_credentials")]
        public bool? TestCredentials { get; set; }

        /// <summary>
        /// MCP servers available for tool calls.
        /// </summary>
        [TransloaditJsonName("mcp_servers")]
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
        [TransloaditJsonName("role")]
        public string Role { get; set; }

        /// <summary>
        /// Message content.
        /// </summary>
        [TransloaditJsonName("content")]
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
        [TransloaditJsonName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Optional auth mode.
        /// </summary>
        [TransloaditJsonName("auth")]
        public string Auth { get; set; }

        /// <summary>
        /// Optional request headers.
        /// </summary>
        [TransloaditJsonName("headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}

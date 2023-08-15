using System;
using Newtonsoft.Json;

namespace testSignalRBackend.SignalR
{
	public class SocketWrapperError: SocketWrapper
	{
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("isSuccess")]
        public override bool IsSuccess { get => false; }

    }
}


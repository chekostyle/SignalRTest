using System;
using Newtonsoft.Json;

namespace testSignalRBackend.SignalR
{
	public class SocketWrapperSuccess<T> : SocketWrapper
	{
        [JsonProperty("data")]
        public T? Data { get; set; }
        [JsonProperty("isSuccess")]
        public override bool IsSuccess { get => true; }
    }
}


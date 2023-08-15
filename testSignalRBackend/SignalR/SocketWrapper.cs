using System;
using Newtonsoft.Json;

namespace testSignalRBackend.SignalR
{
	public class SocketWrapper
	{
		[JsonProperty("isSuccess")]
		public virtual bool IsSuccess { get; set; }
        [JsonProperty("actionCode")]
        public ActionCode ActionCode { get; set; }
	}
}


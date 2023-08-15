using System;
using Newtonsoft.Json;

namespace testSignalRBackend.SignalR
{
	public class RegisterCompanionDeviceResponse
	{
        [JsonProperty("token")]
        public string Token { get; set; }
	}
}


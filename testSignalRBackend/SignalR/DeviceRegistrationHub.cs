using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.SignalR;

namespace testSignalRBackend.SignalR
{
	public class DeviceRegistrationHub : Hub
	{

        public async Task RegisterCompanionDevice(string sessionID)
        {
            try
            {
                //Check if the session id is valid in the DB, otherwise send error
                if (true)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, sessionID);
                    await Clients.Caller.SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperSuccess<RegisterCompanionDeviceResponse>()
                    {
                        Data = null,
                        ActionCode = ActionCode.SOCKET_CREATED
                    });
                }
                else
                {
                    await Clients.Caller.SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperError()
                    {
                        ActionCode = ActionCode.DISCONNECT,
                        ErrorMessage = "Invalid Session ID"
                    }) ;
                }

              
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperError()
                {
                    ActionCode = ActionCode.DISCONNECT,
                    ErrorMessage = ex.Message
                });
            }
        }

        public async Task SendLoginData(string sessionID, RegisterCompanionDeviceResponse response)
        {
            try
            {
                //Manually check if the sessionID exists on the Db, otherwise, error
                if (true)
                {
                    await Clients.Group(sessionID).SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperSuccess<RegisterCompanionDeviceResponse>()
                    {
                        Data = response,
                        ActionCode = ActionCode.LOGGED_IN
                    });
                }
                else
                {
                    await Clients.Caller.SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperError()
                    {
                        ActionCode = ActionCode.DISCONNECT,
                        ErrorMessage = "Invalid Session ID"
                    });
                }
              
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync(Constants.SIGNALR_METHOD_LOGIN, new SocketWrapperError()
                {
                    ActionCode = ActionCode.DISCONNECT,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}


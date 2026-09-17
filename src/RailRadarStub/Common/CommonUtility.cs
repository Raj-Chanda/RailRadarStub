using System;
using System.Net;
using WireMock;
using WireMock.Types;
using WireMock.Util;

namespace RailRadarStub.Common;

public static class CommonUtility
{
    public static ResponseMessage GetDefaultResponseMessage()
    {
        return new ResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Headers = new Dictionary<string, WireMockList<string>>
            {
                { Constants.Header.ContentTypeName, new WireMockList<string> { Constants.Header.ContentTypeValue } }
            },
            BodyData = new BodyData
            {
                DetectedBodyType = BodyType.Json
            }
        };
    }
}